using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteDextra.Domain.Entities;
using TesteDextra.VMMV;

namespace TesteDextra.Apresentation.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<IngredienteListViewModel, Ingrediente>();
            CreateMap<IngredienteLancheListViewModel, IngredienteLanche>();
            CreateMap<LancheListViewModel, Lanche>();
        }
    }
}