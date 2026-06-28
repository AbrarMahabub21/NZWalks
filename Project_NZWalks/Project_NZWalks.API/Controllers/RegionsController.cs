using AutoMapper;
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
        
        private readonly IRegionRepository regionRepository;
        private readonly IMapper _mapper;
        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            _mapper = mapper;
        }

        //get All regions
        // GET: http://localhost/portnumber/api/Regions
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            // Getting data from Repository
            var regionDB = await regionRepository.getAllAsync();

            // DM to DTO mapping
            var regions = _mapper.Map<List<RegionDto>>(regionDB);

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

            // DM to DTO mapping
            var region = _mapper.Map<RegionDto>(regionDB);
            return Ok(region);
        }


        // CREATE A NEW REGION
        [HttpPost]
        public async Task<IActionResult> create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                // DTO to DM
                var regionDM = _mapper.Map<Region>(addRegionRequestDto);
                regionDM = await regionRepository.CreateRegion(regionDM);

                // Revert to DTO
                var regionDTO = _mapper.Map<RegionDto>(regionDM);

                return CreatedAtAction(nameof(getById), new { id = regionDM.Id }, regionDTO);
            }

            else
            {
                return BadRequest(ModelState);
            }
        }

        //UPDATE A REGION
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                var regionDM = _mapper.Map<Region>(updateRegionRequestDto);

                regionDM = await regionRepository.UpdateRegion(id, regionDM);

                if (regionDM == null)
                {
                    return NotFound();
                }

                var regionDTO = _mapper.Map<RegionDto>(regionDM);

                return Ok(regionDTO);
            }

            else
            {
                return BadRequest(ModelState);
            }
            
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
