using System;
using System.Windows.Input;

namespace Spherum.Behaviors
{
	public class ListViewItemClickBehavior : Behavior<ListView>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ListViewItemClickBehavior), defaultBindingMode: BindingMode.TwoWay);

        public ListView associatedList { get; private set; } = new();

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(ListView listView)

        {
            base.OnAttachedTo(listView);
            var context = BindingContext;
            associatedList = listView;
            listView.BindingContextChanged += OnBindingContextChanged;
            listView.ItemSelected += OnItemSelected;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = associatedList.BindingContext;
        }

        void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnDetachingFrom(ListView listView)

        {
            base.OnDetachingFrom(listView);
            listView.ItemSelected -= OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            if (Command != null && Command.CanExecute(e.SelectedItem))
            {
                ((ListView)sender).SelectedItem = null;
                var selectedItem = e.SelectedItem;
                Command.Execute(e.SelectedItem);
            }
        }
    }
}


