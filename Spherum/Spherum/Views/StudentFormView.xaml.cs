using Spherum.ViewModels;

namespace Spherum.Views;

public partial class StudentFormView : ContentPage
{
	public StudentFormView()
	{
		InitializeComponent();
        BindingContext = new StudentFormViewModel();
    }
}
