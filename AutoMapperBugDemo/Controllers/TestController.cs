using AutoMapper;
using AutoMapper.AspNet.OData;
using AutoMapperBugDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace AutoMapperBugDemo.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly TestDbContext _testDbContext;
    private readonly IMapper _mapper;
    private static int _id = 1;

    public TestController(TestDbContext testDbContext, IMapper mapper)
    {
        _testDbContext = testDbContext;
        _mapper = mapper;
        
        _testDbContext.Entities.Add(new TestEntity() { Id = _id++, UserId = 2 });
        _testDbContext.SaveChanges();
    }

    [HttpGet]
    public async Task<IActionResult> Get(ODataQueryOptions<TestModel> options)
    {
        return Ok(await _testDbContext.Entities.GetQueryAsync(_mapper, options));
    }
}
