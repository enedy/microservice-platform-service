using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/platforms")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            Console.WriteLine("--> Gettin Platforms...");

            var platformItem = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformItem));
        }

        [Route("{id}"), HttpGet]
        public ActionResult<PlatformReadDTO> GetPlatformById(int id)
        {
            Console.WriteLine("--> Gettin Platform...");

            var platformItem = _repository.GetPlatformById(id);
            if (platformItem is null)
                return NotFound();

            return Ok(_mapper.Map<PlatformReadDTO>(platformItem));
        }

        [HttpPost]
        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO platformCreateDTO)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDTO);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();

            var platformReadDTO = _mapper.Map<PlatformReadDTO>(platformModel);
            return CreatedAtAction(nameof(GetPlatformById), new { id = platformReadDTO.Id }, platformReadDTO);
        }
    }
}