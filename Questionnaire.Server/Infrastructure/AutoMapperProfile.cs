using AutoMapper;
using Questionnaire.BLL.Models;
using Questionnaire.Data.Entities;
using Questionnaire.Server.Models;

namespace Questionnaire.BLL.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<QuestionModel, Question>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<AnswerModel, Answer>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<AnswerDisplayModel, Answer>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
