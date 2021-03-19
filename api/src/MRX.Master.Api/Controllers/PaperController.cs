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
    [Route("api/papers")]
    public class PaperController : MasterControllerBase
    {
        private readonly IPaperRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaperController(IUnitOfWork unitOfWork, IPaperRepository repository, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var papers = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IList<PaperDto>>(papers));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody, Required] PaperDto dto)
        {
            var paper = _mapper.Map<Paper>(dto);
            await _repository.AddAsync(paper);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<PaperDto>(paper));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PaperDto dto)
        {
            var paper = await _repository.GetAsync(id);
            if (paper == null) return NotFound();
            _mapper.Map(dto, paper);
            _repository.Update(paper);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<PaperDto>(paper));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var paper = await _repository.GetAsync(id);
            if (paper == null) return NotFound();
            _repository.Delete(paper);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
