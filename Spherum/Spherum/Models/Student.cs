using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Spherum.Models
{
    public partial class Student : ObservableObject
	{
        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string details;

        [ObservableProperty]
        public int age;

        
        public string Address => Name + " Flat Number " + Id;

        [ObservableProperty]
        public string phoneNumber;

        [ObservableProperty]
        public bool isSelected;
    }
}

