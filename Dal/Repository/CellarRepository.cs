using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface;
using Microsoft.EntityFrameworkCore;
using Models;


    namespace Dal.Repository
    {
        public class CellarRepository : ICellarRepository
        {
            private readonly CellarContext _context; //context BDD

            public CellarRepository(CellarContext context)
            {
                _context = context;
            }
        // Lister la cave
            public async Task<List<Cellar>> GetCellarsAsync()
            {
                return await _context.Cellars.ToListAsync();
            }

        public async Task<Cellar?> GetCellarByIDAsync(int id)
        {
            return await _context.Cellars.FindAsync(id);
        }
        // Créer la cave
        public async Task CreateCeallarAsync(Cellar cellar)
            {
                await _context.Cellars.AddAsync(cellar);
                await _context.SaveChangesAsync();
            }
        // Réactualiser la cave
            public async Task UpdateCellarAsync(Cellar cellar)
            {
                _context.Cellars.Update(cellar);
                await _context.SaveChangesAsync();
            }
        // Effacer la cave
            public async Task DeleteCellarAsync(int id)
            {
                var cellar = await _context.Cellars.FindAsync(id);
                if (cellar != null)
                {
                    _context.Cellars.Remove(cellar);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
