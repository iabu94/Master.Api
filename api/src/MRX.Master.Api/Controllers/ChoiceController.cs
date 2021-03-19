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
    [Route("api/choices")]
    public class ChoiceController : MasterControllerBase
    {
        private readonly IChoiceRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ChoiceController(IUnitOfWork unitOfWork, IChoiceRepository repository, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var choices = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IList<ChoiceDto>>(choices));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody, Required] ChoiceDto dto)
        {
            var choice = _mapper.Map<ChoiceInfo>(dto);
            await _repository.AddAsync(choice);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<ChoiceDto>(choice));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ChoiceDto dto)
        {
            var choice = await _repository.GetAsync(id);
            if (choice == null) return NotFound();
            _mapper.Map(dto, choice);
            _repository.Update(choice);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<ChoiceDto>(choice));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var choice = await _repository.GetAsync(id);
            if (choice == null) return NotFound();
            _repository.Delete(choice);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
