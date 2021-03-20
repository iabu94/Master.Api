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
    [Route("api/userchoices")]
    public class UserChoiceController : MasterControllerBase
    {
        private readonly IUserChoiceRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserChoiceController(IUnitOfWork unitOfWork, IUserChoiceRepository repository, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userChoices = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IList<UserChoiceDto>>(userChoices));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody, Required] UserChoiceDto dto)
        {
            var userChoice = _mapper.Map<UserChoice>(dto);
            await _repository.AddAsync(userChoice);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<UserChoiceDto>(userChoice));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserChoiceDto dto)
        {
            var userChoice = await _repository.GetAsync(id);
            if (userChoice == null) return NotFound();
            _mapper.Map(dto, userChoice);
            _repository.Update(userChoice);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<UserChoiceDto>(userChoice));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userChoice = await _repository.GetAsync(id);
            if (userChoice == null) return NotFound();
            _repository.Delete(userChoice);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
