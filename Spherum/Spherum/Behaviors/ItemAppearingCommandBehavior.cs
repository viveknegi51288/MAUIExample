using System;
using System.Collections;
using System.Windows.Input;

namespace Spherum.Behaviors
{
    public class ItemAppearingBehavior : Behavior<ListView>
    {

        public static readonly BindableProperty CommandProperty =
             BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ItemAppearingBehavior));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemAppearing += OnItemAppearing;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemAppearing -= OnItemAppearing;
        }

        private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var listView = sender as ListView;
            if (listView?.ItemsSource is not IList items || Command == null)
                return;

            if (e.Item == items[items.Count - 1])
            {
                if (Command.CanExecute(null))
                {
                    Command.Execute(null);
                }
            }
        }
    }
}

