using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Spherum.Services;

namespace Spherum.ViewModels.Base
{
	public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;
        public BaseViewModel()
        {
            
        }

    }
}

