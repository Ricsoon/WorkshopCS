using AutoMapper;
using HorizonDevs2.Dtos;
using HorizonDevs2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorizonDevs2.Helpers
{
    public class HorizonDevsProfile : Profile
    {
        public HorizonDevsProfile()
        {
            CreateMap<Aluno, AlunoDto>().ForMember(dest => dest.Nome, opt => opt.MapFrom(scr => $"{scr.Nome} {scr.Sobrenome}"));
        }
    }
}
