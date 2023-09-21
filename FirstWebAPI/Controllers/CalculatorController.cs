using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //api/calculator/Add?x=2&y=4
        [HttpGet("Calculator/Add")]
        public int Add(int x,int y)
        {
            return x+y;
        }
        //api/calculator/Add?x=2&y=4
        [HttpGet("Calculator/Sum")]
        public int Sum(int x, int y)
        {
            return x + y + 1000;
        }
        //api/calculator/Subtract?x=8&y=4
        [HttpPost]

        public int Subtract(int x, int y)
        {
            return x - y;
        }
        //api/calculator/Multiply?x=2&y=4
        [HttpPut]

        public int Multiply(int x, int y)
        {
            return x * y;
        }
        //api/calculator/Divide?x=16&y=4
        [HttpDelete]

        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}
