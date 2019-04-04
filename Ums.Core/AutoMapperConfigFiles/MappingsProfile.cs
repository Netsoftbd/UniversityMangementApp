using AutoMapper;
using Ums.Core.Dto;
using Ums.Core.Models;
using Ums.Core.ViewModel;

namespace Ums.Core.AutoMapperConfigFiles
{
    public class MappingsProfile : Profile
    {
        public override string ProfileName => "MappingsProfile";

        public MappingsProfile()
        {
            // model to dto
            CreateMap<Student, StudentDto>();

            // dto to model
            CreateMap<StudentDto, Student>();


            // model to vm
            CreateMap<Student, StudentViewModel>();

            // vm to model
            CreateMap<StudentViewModel, Student>();
        }
    }
}