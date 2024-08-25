using AutoMapper;
using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.GradeLevels.InputModels;
using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.QuestionModels.InputModels;
using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.Common.Entities.TechTransferModels.InputModels;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;

namespace HireWise.Api.Extensions
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<QuestionInputModel, Question>()
                .ForMember(q => q.Id, opt => opt.Ignore());
            CreateMap<UserInputModel, User>();
            CreateMap<GradeLevelInputModel, GradeLevel>();
            CreateMap<TechTransferInputModel, TechTransfer>();
            CreateMap<UserGroupInputModel, UserGroup>();
        }
    }
}
