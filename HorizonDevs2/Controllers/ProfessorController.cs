using HorizonDevs2.Data;
using HorizonDevs2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorizonDevs2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext context;

        public ProfessorController(SmartContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(context.Professores);
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = context.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado.");
            return Ok(professor);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var aluno = context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
            if (aluno == null) return BadRequest("Professor não encontrado.");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            context.Add(professor);
            context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado.");
            context.Update(professor);
            context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado.");
            context.Update(professor);
            context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = context.Alunos.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado.");
            context.Remove(professor);
            context.SaveChanges();
            return Ok();
        }

    }
}
