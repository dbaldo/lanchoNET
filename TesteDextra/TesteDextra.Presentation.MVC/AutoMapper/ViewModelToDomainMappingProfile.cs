using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteDextra.Domain.Entities;
using TesteDextra.VMMV;

namespace TesteDextra.Presentation.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<Ingrediente, IngredienteListViewModel>();
            CreateMap<IngredienteLanche, IngredienteLancheListViewModel>();
            CreateMap<Lanche, LancheListViewModel>();
        }
    }
}