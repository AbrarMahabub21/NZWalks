using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_NZWalks.API.Data;
using Project_NZWalks.API.Models.Domain;
using Project_NZWalks.API.Models.DTO;
using Project_NZWalks.API.Repository;

namespace Project_NZWalks.API.Controllers
{
    // api/Regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext NZDb;
        private readonly IRegionRepository regionRepository;
        public RegionsController(NZWalksDbContext NZDb, IRegionRepository regionRepository)
        {
            this.NZDb = NZDb;
            this.regionRepository = regionRepository;
        }

        //get All regions
        // GET: http://localhost/portnumber/api/Regions
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            // Getting data from Repository
            var regionDB = await regionRepository.getAllAsync();

            // DM to DTO mapping
            var regions = new List<RegionDto>();
            foreach (var Region in regionDB)
            {
                regions.Add(new RegionDto()
                {
                    Code = Region.Code,
                    Name = Region.Name,
                    RegionImageURL = Region.RegionImageURL
                });
            }

            // return DTO
            return Ok(regions);
        }

        // GET BY a SPECIFIC ID
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id) 
        {
            //var region = NZDb.Regions.Find(id);
            var regionDB = await regionRepository.getByIdAsync(id);

            if (regionDB == null)
            {
                return NotFound();
            }
            var region = new RegionDto()
            {
                Code = regionDB.Code,
                Name = regionDB.Name,
                RegionImageURL = regionDB.RegionImageURL
            };


            return Ok(region);
        }


        // CREATE A NEW REGION
        [HttpPost]
        public async Task<IActionResult> create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {

            var regionDM = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageURL = addRegionRequestDto.RegionImageURL
            };
            regionDM = await regionRepository.CreateRegion(regionDM);
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
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            var regionDM = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageURL = updateRegionRequestDto.RegionImageURL
            };

            regionDM = await regionRepository.UpdateRegion(id, regionDM);

            if(regionDM == null)
            {
                return NotFound();
            }

            var regionDTO = new RegionDto
            {
                Code = regionDM.Code,
                Name = regionDM.Name,
                RegionImageURL = regionDM.RegionImageURL
            };

            return Ok(regionDTO);
        }

        //DELETE A REGION
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            var region = await regionRepository.DeleteRegion(id);


            if(region == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
