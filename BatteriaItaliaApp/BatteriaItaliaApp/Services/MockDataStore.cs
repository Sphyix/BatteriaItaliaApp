using BatteriaItaliaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BatteriaItaliaApp.Models.Enums;

namespace BatteriaItaliaApp.Services
{
    public class MockDataStore : IDataStore<WorkOrder>
    {
        readonly List<WorkOrder> items;

        public MockDataStore()
        {
            items = new List<WorkOrder>()
            {
                new WorkOrder { WorkId = Guid.NewGuid().ToString(), TipoOggetto = "Bicicletta", Stato=Stato.DaFare, Difficolta=Difficolta.Facile, Descrizione="Batteria da ricostruire", Nome="Mario", Cognome="Bianchi", Telefono="0987654321" },
                new WorkOrder { WorkId = Guid.NewGuid().ToString(), TipoOggetto = "Monopattino", Stato=Stato.DaFare, Difficolta=Difficolta.Facile, Descrizione="Batteria da ricostruire", Nome="Federico", Cognome="Bianchi", Telefono="1234567890" },
            };
        }

        public async Task<bool> AddItemAsync(WorkOrder item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(WorkOrder item)
        {
            var oldItem = items.Where((WorkOrder arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((WorkOrder arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<WorkOrder> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<WorkOrder>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}