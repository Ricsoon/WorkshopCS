
using HorizonDevs2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HorizonDevs2.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;

        public Repository(SmartContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor) 
            {
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(p => p.Professor)
                    .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Professor[] GetAllProfessores()
        {
            throw new System.NotImplementedException();
        }

        public Professor[] GetAllProfessoresByDisciplinaId()
        {
            throw new System.NotImplementedException();
        }

        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(p => p.Professor)
                    .Where(aluno => aluno.Id == alunoId);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.FirstOrDefault();
        }

        public Professor GetProfessorById()
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
