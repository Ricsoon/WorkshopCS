using System.Collections.Generic;

namespace HorizonDevs2.Models
{
    public class Disciplina
    {
        public Disciplina() { }
        public Disciplina(int Id, string NomeDisciplina, int ProfessorId)
        {
            this.Id = Id;
            this.NomeDisciplina = NomeDisciplina;
            this.ProfessorId = ProfessorId;
        }
        public int Id { get; set; }
        public string NomeDisciplina { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }
    }
}
