using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetailss.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeDataController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
        "Ruby", "Stacey", "Sasha", "Humaira", "Robin"
    };
        private static readonly string[] Locations = new[]
{
        "Pune", "Aurangabad", "Hyderabad", "Mumbai", "Nagpur"
    };
        private static readonly int[] EmpIds = { 20, 40, 50, 82, 38 };

        private readonly ILogger<EmployeeDataController> _logger;

        public EmployeeDataController(ILogger<EmployeeDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEmployeeData")]
        public IEnumerable<EmployeeData> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new EmployeeData
            {
                Name = Names[Random.Shared.Next(Names.Length)],
                Location = Locations[Random.Shared.Next(Locations.Length)],
                EmpId = EmpIds[Random.Shared.Next(EmpIds.Length)],
                Date = DateTime.Now.AddDays(index),
            })
            .ToArray();
        }
    }
}