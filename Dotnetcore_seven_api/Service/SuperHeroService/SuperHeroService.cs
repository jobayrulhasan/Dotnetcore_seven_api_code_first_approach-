using Dotnetcore_seven_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Dotnetcore_seven_api.Service.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext.DataContext _context;
        public SuperHeroService(DataContext.DataContext context)
        {
                _context = context;
        }
        public async Task<List<SuperHero>?> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            _context.Remove(hero);
            await _context.SaveChangesAsync();  
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heres = await _context.SuperHeroes.ToListAsync();
            return heres;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null) 
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero updateHero)
        {
            var heroUpdate = await _context.SuperHeroes.FindAsync(id);
            if (heroUpdate == null)
            {
                return null;
            }
            heroUpdate.Name = updateHero.Name;
            heroUpdate.FistName = updateHero.FistName;
            heroUpdate.LastName = updateHero.LastName;
            heroUpdate.Place = updateHero.Place;
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
