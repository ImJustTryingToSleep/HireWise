using AutoMapper;
using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.GradeLevels.InputModels;
using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.QuestionModels.InputModels;
using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.Common.Entities.TechTransferModels.InputModels;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;
using System;

namespace HireWise.Api.Extensions
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<QuestionCreateInputModel, Question>();
        }
    }
}
