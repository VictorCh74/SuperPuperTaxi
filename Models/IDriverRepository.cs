using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPuperTaxi.Models
{
    public interface IDriverRepository
    {
        List<TaxiDriver> GetDriverList();
        TaxiDriver GetDriverItem(int id);

        bool Add(TaxiDriver item);

        void Update(Object item);

        bool Delete(int id);

        Task<int> Save();
    }
}
