using System;
using Acr.UserDialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Spherum.ViewModels.Base;

namespace Spherum.ViewModels
{
	public partial class StudentFormViewModel : BaseViewModel
	{
		[RelayCommand]
		private async Task SubmitData()
		{
			using(UserDialogs.Instance.Loading("Uploading data...."))
			{
				await Task.Delay(2000);
				await Shell.Current.Navigation.PopToRootAsync();
            }
		}

        [ObservableProperty]
		private string _id;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _age;

        [ObservableProperty]
        private string _phoneNumber;
    }
}

