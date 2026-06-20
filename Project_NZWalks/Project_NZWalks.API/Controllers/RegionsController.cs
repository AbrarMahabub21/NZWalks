using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> getAll()
        {
            // getting data from DB - domain models
            var regionDB = await NZDb.Regions.ToListAsync();

            // DM to DTO mapping
            var regions = new List<RegionDto>();
            foreach (var region in regionDB)
            {
                regions.Add(new RegionDto()
                {
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageURL = region.RegionImageURL
                });
            }

            // return DTO
            return Ok(regions);
        }

        // GET BY a SPECIFIC ID
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getById([FromRoute] Guid id)
        {
            //var region = NZDb.Regions.Find(id);
            var regionDB = NZDb.Regions.FirstOrDefault(x => x.Id == id);
            var region = new RegionDto()
            {
                Code = regionDB.Code,
                Name = regionDB.Name,
                RegionImageURL = regionDB.RegionImageURL
            };

            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }


        // CREATE A NEW REGION
        [HttpPost]
        public IActionResult create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //DTO to DM
            var regionDM = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageURL = addRegionRequestDto.RegionImageURL
            };

            // DM saved to DB and saved the changes
            NZDb.Regions.Add(regionDM);
            NZDb.SaveChanges();

            // Revert to DTO
            var regionDTO = new RegionDto
            {
                Code = regionDM.Code,
                Name = regionDM.Name,
                RegionImageURL = regionDM.RegionImageURL
            };

            return CreatedAtAction(nameof(getById), new { id = regionDM.Id }, regionDTO);
        }

        //UPDATE A REGION
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDB = NZDb.Regions.FirstOrDefault(x => x.Id == id);
            if(regionDB == null)
            {
                return NotFound();
            }
            

            regionDB.Name = updateRegionRequestDto.Name;
            regionDB.Code = updateRegionRequestDto.Code;
            regionDB.RegionImageURL = updateRegionRequestDto.RegionImageURL;

            NZDb.SaveChanges();

            var regionDTO = new RegionDto
            {
                Code = regionDB.Code,
                Name = regionDB.Name,
                RegionImageURL = regionDB.RegionImageURL
            };

            return Ok(regionDTO);
        }

        //DELETE A REGION
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult delete([FromRoute] Guid id)
        {
            var region = NZDb.Regions.FirstOrDefault(x => x.Id == id);
            if(region == null)
            {
                return NotFound();
            }

            NZDb.Remove(region);
            NZDb.SaveChanges();

            return NoContent();
        }
    }
}
