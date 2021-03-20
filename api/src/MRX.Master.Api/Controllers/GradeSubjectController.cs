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
    [Route("api/gradesubjects")]
    public class GradeSubjectController : MasterControllerBase
    {
        private readonly IGradeSubjectRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GradeSubjectController(IUnitOfWork unitOfWork, IGradeSubjectRepository repository, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var gradeSubjects = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IList<GradeSubjectDto>>(gradeSubjects));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody, Required] GradeSubjectDto dto)
        {
            var gradeSubject = _mapper.Map<GradeSubject>(dto);
            await _repository.AddAsync(gradeSubject);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<GradeSubjectDto>(gradeSubject));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GradeSubjectDto dto)
        {
            var gradeSubject = await _repository.GetAsync(id);
            if (gradeSubject == null) return NotFound();
            _mapper.Map(dto, gradeSubject);
            _repository.Update(gradeSubject);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<GradeSubjectDto>(gradeSubject));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var gradeSubject = await _repository.GetAsync(id);
            if (gradeSubject == null) return NotFound();
            _repository.Delete(gradeSubject);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
