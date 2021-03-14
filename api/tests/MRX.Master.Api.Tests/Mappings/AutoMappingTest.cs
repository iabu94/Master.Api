using Xunit;
using AutoMapper;
using MRX.Master.Api.Mappings;

namespace MRX.Master.Api.Tests.Mappings
{
    public class AutoMappingTest
    {
        [Fact]
        public void Check_DefaultProfile_AutoMapperConfigurations()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new DefaultProfile()));

            configuration.AssertConfigurationIsValid();
        }
    }
}
