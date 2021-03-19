using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MRX.Master.Api.DTOs;
using MRX.Master.Domain.Contracts;
using MRX.Master.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MRX.Master.Api.Controllers
{
    [Route("api/users")]
    public class UserController : MasterControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unitOfWork, IUserRepository repository, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IList<UserDto>>(users));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody, Required] UserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _repository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto dto)
        {
            var user = await _repository.GetAsync(id);
            if (user == null) return NotFound();
            _mapper.Map(dto, user);
            _repository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _repository.GetAsync(id);
            if (user == null) return NotFound();
            _repository.Delete(user);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
