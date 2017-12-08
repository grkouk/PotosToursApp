using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PotosToursApp.Services
{
    public interface IDataStore<T>
    {
        Task<IEnumerable<T>> GetItemsAsync();
        Task<bool> AddItemAsync(T item);
    }
}
