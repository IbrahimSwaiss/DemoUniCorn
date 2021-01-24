using DemoPrep.Domain.Entities;
using DemoPrep.Infrastructure.Dtos;
using DemoPrep.Persistance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPrep.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase {
        private readonly IRepository<int, Unicorn> _repository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IUoW _uow;

        public AdminController(IRepository<int, Unicorn> repository, IOwnerRepository ownerRepository, IUoW uow) {
            _repository = repository;
            _ownerRepository = ownerRepository;
            _uow = uow;
        }

        // unicorn
        [HttpPost("AddUnicorn")]
        public async Task AddUnicorn(UnicornInput input) {
            var unicorn = new Unicorn {
                Color = input.Color,
                Name = input.Name,
                DateOfBirth = input.DateOfBirth
            };

            await _repository.InsertAsync(unicorn);
            await _uow.CompleteAsync();
        }

        [HttpPost("EditUnicorn")]
        public async Task DeleteUnicorn(UnicornInput input) {
            if (input.Id <= 0) throw new ArgumentOutOfRangeException("unicorn id must be greate than zero.");

            var unicorn = await _repository.GetByIdAsync(input.Id);
            if (unicorn == null) throw new NullReferenceException($"THere's no unicorn with this id {input.Id}");

            unicorn.Name = input.Name;
            unicorn.Color = input.Color;
            unicorn.DateOfBirth = input.DateOfBirth;

            _repository.Update(unicorn);

            await _uow.CompleteAsync();
        }

        [HttpPost("ManageUnicorns")]
        public async Task ManageUnicorn(ManageUnicornInput input) {
            var owner = await _ownerRepository.GetByIdAsync(input.OwnerId);
            var unicorns = (await _repository.GetAllAsync()).Where(u => input.UnicornIds.Contains(u.Id));

            owner.SetUnicorns(unicorns);
            _ownerRepository.Update(owner);
            await _uow.CompleteAsync();
        }

        [HttpGet("GetAllUnicorns")]
        public async Task<List<UnicornList>> GetAllUnicorns() {
            var unicorns = await _repository.GetAllAsync();

            return unicorns.Select(u => new UnicornList { Id = u.Id, Color = u.Color, Name = u.Name }).ToList();
        }

        [HttpPost("AddOwner")]
        public async Task AddOwner(OwnerInput input) {
            Owner owner = new Owner {
                Name = input.Name,
                DateOfBirth = input.DateOfBirth
            };
            await _ownerRepository.InsertAsync(owner);
            await _uow.CompleteAsync();
        }

        [HttpGet("GetOwners")]
        public async Task<List<OwnerOutput>> GetOwners() {
            var owners = await _ownerRepository.GetOwnersWithUnicornsAsync();
            return owners.Select(o => new OwnerOutput {
                Id = o.Id,
                Name = o.Name,
                Unicorns = o.Unicorns.Select(u => new UnicornList { Color = u.Color, Name = u.Name }).ToList()

            }).ToList();

        }

        [HttpGet("GetOwner")]
        public async Task<OwnerOutput> GetOwner(int id) {
            var owner = await _ownerRepository.GetOwnerWithUnicornsAsync(id);
            return new OwnerOutput {
                Name = owner.Name,
                Unicorns = owner.Unicorns.Select(u => new UnicornList { Color = u.Color, Name = u.Name }).ToList()
            };
        }
    }
}
