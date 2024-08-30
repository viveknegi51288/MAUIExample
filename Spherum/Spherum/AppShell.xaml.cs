using Spherum.Views;

namespace Spherum;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(StudentsView), typeof(StudentsView));
        Routing.RegisterRoute(nameof(StudentDetailsView), typeof(StudentDetailsView));
        Routing.RegisterRoute(nameof(StudentFormView), typeof(StudentFormView));
    }
}
