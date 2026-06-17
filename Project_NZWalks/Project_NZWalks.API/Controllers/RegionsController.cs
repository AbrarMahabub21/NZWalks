using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_NZWalks.API.Data;
using Project_NZWalks.API.Models.Domain;
using Project_NZWalks.API.Models.DTO;

namespace Project_NZWalks.API.Controllers
{
       // api/Regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext NZDb;
        public RegionsController(NZWalksDbContext NZDb)
        {
            this.NZDb = NZDb;
        }

        //get All regions
        // GET: http://localhost/portnumber/api/Regions
        [HttpGet]
        public IActionResult getAll()
        {
            // getting data from DB - domain models
            var regionDB = NZDb.Regions.ToList();

            // DM to DTO mapping
            var regions = new List<RegionDto>();
            foreach(var region in regionDB)
            {
                regions.Add(new RegionDto()
                {
                    Code = region.Code,
                    Name = region.Name
                });
            }

            // return DTO
            return Ok(regions);
        }

        
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult getById([FromRoute] Guid id)
        {
            //var region = NZDb.Regions.Find(id);
            var regionDB = NZDb.Regions.FirstOrDefault(x => x.Id == id);
            var region = new RegionDto()
            {
                Code = regionDB.Code,
                Name = regionDB.Name
            };
            
            if(region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }
    }
}
