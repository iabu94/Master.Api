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
    [Route("api/sectiontypes")]
    public class SectionTypeController : MasterControllerBase
    {
        private readonly ISectionTypeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SectionTypeController(IUnitOfWork unitOfWork, ISectionTypeRepository repository, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sectionTypes = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IList<SectionTypeDto>>(sectionTypes));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody, Required] SectionTypeDto dto)
        {
            var sectionType = _mapper.Map<SectionType>(dto);
            await _repository.AddAsync(sectionType);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<SectionTypeDto>(sectionType));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SectionTypeDto dto)
        {
            var sectionType = await _repository.GetAsync(id);
            if (sectionType == null) return NotFound();
            _mapper.Map(dto, sectionType);
            _repository.Update(sectionType);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<SectionTypeDto>(sectionType));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sectionType = await _repository.GetAsync(id);
            if (sectionType == null) return NotFound();
            _repository.Delete(sectionType);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
