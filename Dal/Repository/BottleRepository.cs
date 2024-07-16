using Microsoft.EntityFrameworkCore;
using Models;
using Dal.Interface;


namespace Dal.Repository
{

    public class BottleRepository : IBottleRepository
    {
        private readonly CellarContext _context;

        public BottleRepository(CellarContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bottle>> GetAll()
        {
            return await _context.Bottles.ToListAsync();
        }

        public async Task<Bottle> GetById(int id) => await _context.Bottles.FindAsync(id);

        public async Task Add(Bottle bottle)
        {
            await _context.Bottles.AddAsync(bottle);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Bottle bottle)
        {
            _context.Bottles.Update(bottle);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var bottle = await _context.Bottles.FindAsync(id);
            if (bottle != null)
            {
                _context.Bottles.Remove(bottle);
                await _context.SaveChangesAsync();
            }
        }
    }

}
