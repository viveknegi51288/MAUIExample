using Spherum.Services;
using Spherum.ViewModels;

namespace Spherum.Views;

public partial class StudentsView : ContentPage
{
	public StudentsView()
	{
		InitializeComponent();

        var studentService = new StudentService();
		BindingContext = new StudentsViewModel(studentService);
	}
}
