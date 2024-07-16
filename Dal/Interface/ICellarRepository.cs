using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Dal.Interface
{
    public interface ICellarRepository
    {

        Task<List<Cellar>> GetCellarsAsync();
        Task<Cellar?> GetCellarByIDAsync(int id);
        Task CreateCeallarAsync(Cellar cellar);
        Task UpdateCellarAsync(Cellar cellar);
        Task DeleteCellarAsync(int id);
    }
}
