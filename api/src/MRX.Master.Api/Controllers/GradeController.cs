﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MRX.Master.Api.DTOs;
using MRX.Master.Domain.Contracts;
using MRX.Master.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MRX.Master.Api.Controllers
{
    [Route("api/grades")]
    public class GradeController : MasterControllerBase
    {
        private readonly IGradeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GradeController(IUnitOfWork unitOfWork, IGradeRepository repository, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grades = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IList<GradeDto>>(grades));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody, Required] GradeDto dto)
        {
            var grade = _mapper.Map<Grade>(dto);
            await _repository.AddAsync(grade);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<GradeDto>(grade));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GradeDto dto)
        {
            var grade = await _repository.GetAsync(id);
            if (grade == null) return NotFound();
            _mapper.Map(dto, grade);
            _repository.Update(grade);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<GradeDto>(grade));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var grade = await _repository.GetAsync(id);
            if (grade == null) return NotFound();
            _repository.Delete(grade);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
