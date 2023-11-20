using EQ66L2_HFT_2023241.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EQ66L2_HFT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class SupplyController : ControllerBase
    {
        IManufacturerRepository logic;

        public SupplyController(IManufacturerRepository logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<string> ReadAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SupplyController>/5
        [HttpGet("{id}")]
        public string Read(int id)
        {
            return "value";
        }

        // POST api/<SupplyController>
        [HttpPost]
        public void Create([FromBody] string value)
        {
        }

        // PUT api/<SupplyController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
