using System;
using DemoPrep.Domain.Entities;
using DemoPrep.Infrastructure.Dtos;
using DemoPrep.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoPrep.API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UnicornController : ControllerBase {
        //private static readonly string[] Summaries = new[] {
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<UnicornController> _logger;
        private readonly IRepository<int, Unicorn> _repository;
        private readonly IUoW _uow;

        public UnicornController(
            IRepository<int, Unicorn> repository,
            IUoW uow) {
            //_logger = logger;
            _repository = repository;
            _uow = uow;
        }

        [HttpPost("AddForecast")]
        public async Task AddForecast(UnicornInput dto) {
            //var entity = new Unicorn {
            //    Date = dto.Date,
            //    Summary = dto.Summary,
            //    TemperatureC = dto.TemperatureC
            //};
            //await _repository.InsertAsync(entity);
            //await _uow.CompleteAsync();
        }

        [HttpPost("UpdateForecast")]
        public async Task UpdateForecast() {
            //var entities = await _repository.GetAllAsync();
            //var entity = entities.First();

            //entity.Summary = "first forecast summary updated";
            //entity.TemperatureC = 5;

            //_repository.Update(entity);
            //await _uow.CompleteAsync();
        }

        [HttpGet("GetInfo")]
        public IEnumerable<Unicorn> Get() {
            throw new NotImplementedException();
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new Unicorn {
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
