using EQ66L2_HFT_2023241.Logic.Interfaces;
using EQ66L2_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EQ66L2_HFT_2023241.Endpoint
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerLogic Logic;

        public CustomerController(ICustomerLogic logic)
        {
            Logic = logic;
        }

        [HttpGet]
        public IEnumerable<Customer> ReadAll()
        {
            return Logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Customer Read(int id)
        {
            return Logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Customer customer)
        {
            this.Logic.Create(customer);
        }

        
        [HttpPut("{id}")]
        public void Update([FromBody] Customer customer)
        {
            this.Logic.Update(customer);
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          this.Logic.Delete(id);
        }
    }
}
