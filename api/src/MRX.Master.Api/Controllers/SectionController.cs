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
    [Route("api/sections")]
    public class SectionController : MasterControllerBase
    {
        private readonly ISectionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SectionController(IUnitOfWork unitOfWork, ISectionRepository repository, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sections = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IList<SectionDto>>(sections));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody, Required] SectionDto dto)
        {
            var section = _mapper.Map<Section>(dto);
            await _repository.AddAsync(section);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<SectionDto>(section));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SectionDto dto)
        {
            var section = await _repository.GetAsync(id);
            if (section == null) return NotFound();
            _mapper.Map(dto, section);
            _repository.Update(section);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<SectionDto>(section));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var section = await _repository.GetAsync(id);
            if (section == null) return NotFound();
            _repository.Delete(section);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
