using EQ66L2_HFT_2023241.Logic.Interfaces;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EQ66L2_HFT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class SupplyManufController : ControllerBase
    {
        ISupplyLogic logic;

        public SupplyManufController(ISupplyLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Manufacturer> ReadAll()
        {
            return logic.ReadAll_Manufacturer();
        }
        
        
        [HttpGet("{id}")]
        public Manufacturer Read(int id)
        {
            return logic.Read_Manufacturer(id);
        }

    
        [HttpPost]
        public void Create([FromBody] Manufacturer item)
        {
            logic.Create_Manufacturer(item);
        }

       
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Manufacturer item)
        {
            logic.Update_Manufacturer(item);
        }

     
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete_Manufacturer(id);
        }

    }
}
