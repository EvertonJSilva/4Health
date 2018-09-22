using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FourHealth.AppServices.DTOs;
using FourHealth.Domain.Results;

namespace FourHealth.AppServices.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<GenericResult<BeneficiarioDTO>,GenericResult<Domain.Entities.Beneficiario>>().ReverseMap();

            CreateMap<BeneficiarioDTO,Domain.Entities.Beneficiario>().ReverseMap();
            CreateMap<BeneficiarioFilterDTO, Domain.Filters.BeneficiarioFilter>().ReverseMap();

            CreateMap<PerguntaDTO, Domain.Entities.Pergunta>().ReverseMap();
            CreateMap<PerguntaFilterDTO, Domain.Filters.PerguntaFilter>().ReverseMap();

            CreateMap<QuestionarioDTO, Domain.Entities.Questionario>().ReverseMap();
            CreateMap<QuestionarioFilterDTO, Domain.Filters.QuestionarioFilter>().ReverseMap();

            CreateMap<ProgramaDTO, Domain.Entities.Programa>().ReverseMap();
            CreateMap<ProgramaFilterDTO, Domain.Filters.ProgramaFilter>().ReverseMap();



        }
    }
}
