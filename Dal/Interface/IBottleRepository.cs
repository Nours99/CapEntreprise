using Models;

namespace Dal.Interface;
public interface IBottleRepository
{
    Task<IEnumerable<Bottle>> GetAll();
    Task<Bottle> GetById(int id);
    Task Add(Bottle entity);
    Task Update(Bottle entity);
    Task Delete(int id);
}

