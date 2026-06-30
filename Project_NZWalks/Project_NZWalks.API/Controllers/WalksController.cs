using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_NZWalks.API.Mappings;
using Project_NZWalks.API.Models.Domain;
using Project_NZWalks.API.Models.DTO;
using Project_NZWalks.API.Repository;
using Project_NZWalks.API.ActionModelFilter;
namespace Project_NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IWalkRepository walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            this.walkRepository = walkRepository;
        }

        //Create Walks
        // A post method
        [HttpPost]
        [ValidateModelAttributes]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //WalkDTO to Walk
            var walkDM = _mapper.Map<Walk>(addWalkRequestDto);

            var walk = await walkRepository.CreateAsync(walkDM);

            //walk to walkDTO again
            var walkDTO = _mapper.Map<WalkDto>(walk);

            return Ok(walkDTO);

        }

        //Get All Walks
        // A Get Method
        //api/walks?filterOn=name&filterQuery=Track
        //api/walks?filterOn=name&filterQuery=Track&sortBy=name&isAscending=True
        [HttpGet]
        public async Task<IActionResult> GetWalks(
            [FromQuery] string?filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool isAscending
            )
        {
            //Get Values from DB through Repository
            var allWalks = await walkRepository.GetWalkAsync(filterOn,filterQuery,sortBy,isAscending);

            // Mapping to DTO
            var walksDTO = _mapper.Map<List<WalkDto>>(allWalks);

            return Ok(walksDTO);
        }

        //Get a specific walk by it's id
        //A GET Method
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalkByID([FromRoute] Guid id)
        {
            var walk = await walkRepository.WalkByIDAsync(id);

            var walkDTO = _mapper.Map<WalkDto>(walk);

            return Ok(walkDTO);
        }

        //It will update a specific walk
        //A put method
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModelAttributes]
        public async Task<IActionResult> UpdateWalk([FromRoute]Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDM = _mapper.Map<Walk>(updateWalkRequestDto);
            var walk = await walkRepository.UpdateWalkAsync(id, walkDM);

            var walkDTO = _mapper.Map<WalkDto>(walk);

            return Ok(walkDTO);
        }


        //It will delete a specific walk
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk(Guid id)
        {
            var walk = await walkRepository.DeleteWalkAsync(id);

            if(walk == null)
            {
                return NotFound();
            }
               
          return NoContent();
        } 
    }


}
