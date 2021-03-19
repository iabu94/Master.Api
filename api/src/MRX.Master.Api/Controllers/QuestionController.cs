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
    [Route("api/questions")]
    public class QuestionController : MasterControllerBase
    {
        private readonly IQuestionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuestionController(IUnitOfWork unitOfWork, IQuestionRepository repository, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var questions = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IList<QuestionDto>>(questions));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody, Required] QuestionDto dto)
        {
            var question = _mapper.Map<QuestionInfo>(dto);
            await _repository.AddAsync(question);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<QuestionDto>(question));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] QuestionDto dto)
        {
            var question = await _repository.GetAsync(id);
            if (question == null) return NotFound();
            _mapper.Map(dto, question);
            _repository.Update(question);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<QuestionDto>(question));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var question = await _repository.GetAsync(id);
            if (question == null) return NotFound();
            _repository.Delete(question);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
