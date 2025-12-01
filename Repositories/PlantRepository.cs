using Greenhouse.Data;
using Greenhouse.Models;
using Microsoft.EntityFrameworkCore;

namespace Greenhouse.Repositories
{
    public interface IPlantRepository
    {
        Task Create(Plant plant);
        Task Update(Plant plant);
        Task<Plant?> GetById(int id);
        Task<List<Plant>> GetAll();
        Task Delete(Plant plant);
    }

    public class PlantRepository(GreenhouseDbContext context) : IPlantRepository
    {
        public async Task Create(Plant plant)
        {
            await context.Plants.AddAsync(plant);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Plant plant)
        {
            context.Plants.Remove(plant);
            await context.SaveChangesAsync();
        }

        public async Task<List<Plant>> GetAll()
        {
            return await context.Plants.ToListAsync();
        }

        public async Task<Plant?> GetById(int id)
        {
            return await context.Plants.FindAsync(id);
        }

        public async Task Update(Plant plant)
        {
            context.Plants.Update(plant);
            await context.SaveChangesAsync();
        }
    }
}
