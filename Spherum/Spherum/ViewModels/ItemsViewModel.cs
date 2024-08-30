using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Spherum.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Spherum.ViewModels
{
	public partial class ItemsViewModel : ObservableObject
    {
        private const int BatchSize = 60;
        private bool _isBusy;
        private int _loadedItemCount;

        public ObservableCollection<Item> Items { get; private set; }
        public ICommand LoadMoreItemsCommand { get; private set; }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ItemsViewModel()
        {
            Items = new ObservableCollection<Item>();
            LoadMoreItemsCommand = new Command(async () => await LoadMoreItems());

            LoadInitialItems();
        }

        private void LoadInitialItems()
        {
            _loadedItemCount = 0;
            LoadMoreItemsCommand.Execute(null);
        }

        private async Task LoadMoreItems()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            await Task.Delay(2000); // Simulate network delay

            var newItems = new List<Item>();



            for (int i = _loadedItemCount + 1; i <= _loadedItemCount + BatchSize; i++)
            {
                newItems.Add(new Item
                {
                    Id = i,
                    Name = $"Item {i}",
                });
            }

            foreach (var item in newItems)
            {
                Items.Add(item);
            }

            _loadedItemCount += BatchSize;
            IsBusy = false;
        }
    }
}

