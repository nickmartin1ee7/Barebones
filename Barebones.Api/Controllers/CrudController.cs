using System;
using Barebones.Api.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Barebones.Api.DomainModels.Repositories;
using Barebones.Api.Extensions;

namespace Barebones.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class CrudController : ControllerBase
    {
        private readonly ILogger<CrudController> _logger;
        private readonly IRepository<DataModel<Guid, byte[]>> _repository;

        public CrudController(ILogger<CrudController> logger,
            IRepository<DataModel<Guid, byte[]>> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("get/all")]
        public IActionResult GetAll() => 
            Ok(_repository.GetAll());
        
        [HttpGet("get/{id:guid}")]
        public IActionResult Get(Guid id) => 
            Ok(_repository.Get(id));

        [HttpPost("create")]
        public IActionResult Post(object input) => 
            Ok(_repository.Create(new DataModel<Guid, byte[]>
            {
                Key = Guid.NewGuid(),
                Value = input.ToJson().ToBytes()
            }));

        [HttpDelete("delete/{id:guid}")]
        public IActionResult Delete(Guid id) =>
            Ok(_repository.Delete(
                    _repository.Get(id)));

        [HttpPatch("update/{id:guid}")]
        public IActionResult Update(Guid id, object input) =>
            Ok(_repository.Update(new DataModel<Guid, byte[]>
            {
                Key = Guid.NewGuid(),
                Value = input.ToJson().ToBytes()
            }));
    }
}