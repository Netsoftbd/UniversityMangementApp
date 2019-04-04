using AutoMapper;

namespace Ums.Core.AutoMapperConfigFiles
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingsProfile>();
            });
        }
    }
}