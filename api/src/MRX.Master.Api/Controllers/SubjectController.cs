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
    [Route("api/subjects")]
    public class SubjectController : MasterControllerBase
    {
        private readonly ISubjectRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SubjectController(IUnitOfWork unitOfWork, ISubjectRepository repository, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subjects = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IList<SubjectDto>>(subjects));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody, Required] SubjectDto dto)
        {
            var subject = _mapper.Map<Subject>(dto);
            await _repository.AddAsync(subject);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<SubjectDto>(subject));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SubjectDto dto)
        {
            var subject = await _repository.GetAsync(id);
            if (subject == null) return NotFound();
            _mapper.Map(dto, subject);
            _repository.Update(subject);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<SubjectDto>(subject));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subject = await _repository.GetAsync(id);
            if (subject == null) return NotFound();
            _repository.Delete(subject);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
