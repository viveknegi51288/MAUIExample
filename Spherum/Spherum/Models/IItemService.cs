using System;
namespace Spherum.Models
{
	public interface IItemService
	{
        Task<List<Item>> GetItemsAsync(int page, int pageSize);
    }
}

