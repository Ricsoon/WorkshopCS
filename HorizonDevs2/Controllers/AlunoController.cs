using HorizonDevs2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HorizonDevs2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno(){
                Id = 1,
                Nome = "Maria",
                Sobrenome = "Paula",
                Telefone = "123456789"
            },
            new Aluno(){
                Id = 2,
                Nome = "Pedro",
                Sobrenome = "Morais",
                Telefone = "987654321"
            },
            new Aluno(){
                Id = 3,
                Nome = "Bob",
                Sobrenome = "Andrade",
                Telefone = "4573645835"
            }
        };

        public AlunoController(){ }

        [HttpGet]
        public IActionResult Get() {
            return Ok(Alunos);
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado.");
            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("Aluno não encontrado.");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
