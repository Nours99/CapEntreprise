using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interface
{
    public interface IDrawerRepository
    {
       
        Task<List<Drawer>> GetAllAsync();
        Task<Drawer> PostAsync(Drawer drawer);
        Task CreateDrawerAsync(Drawer drawer);
        Task UpdateUserAsync(Drawer drawer);
        Task DeleteUserAsync(int id);
    }
}
