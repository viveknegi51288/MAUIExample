using Spherum.ViewModels;

namespace Spherum.Views;

public partial class StudentDetailsView : ContentPage
{
	public StudentDetailsView()
	{
		InitializeComponent();
		BindingContext = new StudentDetailsViewModel();
	}
}
