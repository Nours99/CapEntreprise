using Dal.Interface;
using Models;
using Microsoft.EntityFrameworkCore;



namespace Dal.Repository;

//L'interface DrawerRepository implémente l'interface IDrawerRepository
public class DrawerRepository : IDrawerRepository
{
    //CellarContext classe qui représente le contexte de la Bdd
    private readonly CellarContext context;
    public DrawerRepository(CellarContext Context) 
    { 
        this.context = Context;
    }

    public Task CreateDrawerAsync(Drawer drawer)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }


    //méthode asynchrone qui doit renvoyer une tâche contenant une liste d'objets Drawer
    public Task<List<Drawer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Drawer> PostAsync(Drawer drawer)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserAsync(Drawer drawer)
    {
        throw new NotImplementedException();
    }
}