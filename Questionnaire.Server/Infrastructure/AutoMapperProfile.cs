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
            CreateMap<Question, QuestionDisplayModel>();

            CreateMap<Answer, AnswerDisplayModel>();

            CreateMap<QuestionCreateModel, Question>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<AnswerCreateModel, Answer>()
                .ForMember(x => x.Id, opt => opt.Ignore());        
        }
    }
}
