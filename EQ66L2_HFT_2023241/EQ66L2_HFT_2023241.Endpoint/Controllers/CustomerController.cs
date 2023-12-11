using EQ66L2_HFT_2023241.Logic.Interfaces;
using EQ66L2_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EQ66L2_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        ICustomerLogic logic;

        public CustomerController(ICustomerLogic logic)
        {
            this.logic = logic;
        }





        [HttpGet]
        public IEnumerable<Customer> ReadAll()
        {
            return this.logic.ReadAll();
        }

      


        [HttpGet("{id}")]
        public Customer Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Customer value)
        {
            this.logic.Create(value);

        }

      
        [HttpPut]
        public void Update([FromBody] Customer value)
        {
            this.logic.Update(value);
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);

        }
    }
}
