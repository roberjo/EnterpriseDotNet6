using AutoMapper;
using Azure;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnterpriseDotNet6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private readonly ILogger<OwnerController> _logger;

        public OwnerController(IRepositoryWrapper repository, IMapper mapper, ILogger<OwnerController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public IActionResult GetAllOwners()
        {
            _logger.LogDebug("Starting GetAllOwners endpoint");
            try
            {
                var owners = _repository.Owner.GetAllOwners();
                _logger.LogInformation($"Returned all owners from database.");

                var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
                _logger.LogDebug($"The response for the get all owners is {JsonSerializer.Serialize(ownersResult)}");
                return Ok(ownersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OwnerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
