using AutoMapper;
using AutoMapperBugDemo.Data;

namespace AutoMapperBugDemo.Controllers;

public class TestModelProfile : Profile
{
    public TestModelProfile()
    {
        CreateMap<TestEntity, TestModel>();
    }
}
