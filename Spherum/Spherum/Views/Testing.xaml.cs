using Spherum.ViewModels;

namespace Spherum.Views;

public partial class Testing : ContentPage
{
	public Testing(ItemsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
