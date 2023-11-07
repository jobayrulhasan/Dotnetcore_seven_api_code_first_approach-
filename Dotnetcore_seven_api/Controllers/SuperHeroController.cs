using Dotnetcore_seven_api.Models;
using Dotnetcore_seven_api.Service.SuperHeroService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnetcore_seven_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly SuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = (SuperHeroService?)superHeroService;
        }

        //get all data by calling method
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>>GetAllHeroes()
        {
            return await _superHeroService.GetAllHeroes();
        }

        //get single data by using id
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>>GetSingleHero(int id)
        {
           var result = await _superHeroService.GetSingleHero(id);
            if (result == null)
            {
                return NotFound("No data found!");
            }
            return Ok(result);
        }

        //Add new data
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>>AddHero(SuperHero hero)
        {
            var result = await _superHeroService.AddHero(hero);
            return Ok(result);
        }

        //update existing data by using id
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>>UpdateHero(int id, SuperHero updateHero)
        {
           var result = await _superHeroService.UpdateHero(id, updateHero);
            if (result == null)
            {
                return NotFound("No data updated!");
            }
            return Ok(result);
        }
        
        //delete by id
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>>DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);
            if (result == null)
            {
                return NotFound("No data found to delete!");
            }
            return Ok(result);
        }
    }
}