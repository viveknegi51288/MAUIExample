using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Spherum.Models;
using Spherum.ViewModels.Base;
using Spherum.Views;

namespace Spherum.ViewModels
{

    [QueryProperty(nameof(SelectedStudent), nameof(SelectedStudent))]
    public partial class StudentDetailsViewModel : BaseViewModel
	{
        [ObservableProperty]
        private Student? _selectedStudent;

        [RelayCommand]
        private async Task GoToFillFormView()
        {
            await Shell.Current.GoToAsync(nameof(StudentFormView));
        }
    }
}