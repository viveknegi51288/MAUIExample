using System;
namespace Spherum.Models
{
	public class ItemService : IItemService
    {
        public async Task<List<Item>> GetItemsAsync(int page, int pageSize)
        {
            // Simulate network delay
            await Task.Delay(1000);

            // Generate dummy items
            var items = new List<Item>();
            for (int i = 0; i < pageSize; i++)
            {
                items.Add(new Item
                {
                    Id = (page - 1) * pageSize + i + 1,
                    Name = $"Item {(page - 1) * pageSize + i + 1}"
                });
            }

            return items;
        }
    }
}

