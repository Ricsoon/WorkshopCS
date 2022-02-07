using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorizonDevs2.Models
{
    public class AlunoCurso
    {
        public AlunoCurso() { }
        public AlunoCurso(int AlunoId, int cursoId)
        {
            this.AlunoId = AlunoId;
            this.CursoId = cursoId;
        }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
