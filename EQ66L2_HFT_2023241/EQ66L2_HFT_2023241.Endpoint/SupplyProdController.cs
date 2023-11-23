using EQ66L2_HFT_2023241.Logic.Interfaces;
using EQ66L2_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EQ66L2_HFT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class SupplyProdController : ControllerBase
    {

        ISupplyLogic Logic;

        public SupplyProdController(ISupplyLogic logic)
        {
            Logic = logic;
        }

        [HttpGet]
        public IEnumerable<Product> ReadAll()
        {
            return Logic.ReadAll_Product();
        }

        
        [HttpGet("{id}")]
        public Product Read(int id)
        {
            return Logic.Read_Product(id);
        }

        
        [HttpPost]
        public void Create([FromBody] Product item)
        {
            Logic.Create_Product(item);
        }


        [HttpPut("{id}")]
        public void Update([FromBody] Product product)
        {
            Logic.Update_Product(product);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Logic.Delete_Product(id);
        }
    }
}
