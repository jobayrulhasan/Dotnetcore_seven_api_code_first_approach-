namespace Dotnetcore_seven_api.Service.SuperHeroService
{
    public interface ISuperHeroService
    {
        //get all data
        Task<List<SuperHero>?> GetAllHeroes();
        //get single data by using id
        Task<SuperHero?> GetSingleHero(int id);
        //Add new data
        Task<List<SuperHero>?> AddHero(SuperHero hero);
        //update existing data by using id
        Task<List<SuperHero>?> UpdateHero(int id, SuperHero updateHero);
        //delete by id
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}