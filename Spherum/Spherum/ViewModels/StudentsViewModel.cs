using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Acr.UserDialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Spherum.Models;
using Spherum.Services;
using Spherum.ViewModels.Base;
using Spherum.Views;

namespace Spherum.ViewModels
{
	public partial class StudentsViewModel : BaseViewModel
	{

        public ObservableCollection<Student> Students { get; } = new();
        protected readonly StudentService _studentService;
        public ICommand ItemClickedCommand { get; set; }

        [ObservableProperty]
        public Student _selectedItem;

        private bool _isLoadingMore;
        private bool _isBusy;
        private int _pageSize = 10;
        private int _currentPage = 1;
        private List<Student> StudentList = new();

        public StudentsViewModel(StudentService studentService): base()
        {
            ItemClickedCommand = new Command<Student>(OnItemClicked);
            _studentService = studentService;
            LoadInitialStudents();

        }

        

        private async void LoadInitialStudents()
        {
            using (UserDialogs.Instance.Loading("Loading..."))
            {
                StudentList = await _studentService.GetStudentsAsync();
                foreach (var student in StudentList.Take(_pageSize))
                {
                    Students.Add(student);
                }
            }
        }

        [RelayCommand]
        public async Task LoadMoreStudents()
        {
            if (Students.Count > 0 && Students.Count < StudentList.Count)
            {
                using (UserDialogs.Instance.Loading("Loading..."))
            {
                await Task.Delay(2000);
               
                    foreach (var student in StudentList.Skip(Students.Count).Take(_pageSize))
                    {
                        Students.Add(student);
                    }
            }
            }
        }

       

        [ObservableProperty]
        private Student _selectedStudent = new();


        private async void OnItemClicked(Student selectedStudent)
        {
            if (selectedStudent == null)
                return;
            Students.ToList().ForEach(x => x.IsSelected = false);
            selectedStudent.IsSelected = true;
            var parameter = new Dictionary<string, object>
            {
                { "SelectedStudent", selectedStudent }
            };
            await Shell.Current.GoToAsync(nameof(StudentDetailsView), parameter);
        }

        [RelayCommand]
        private void ItemSelected(object selectedStudent)
        {

        }
    }
}

