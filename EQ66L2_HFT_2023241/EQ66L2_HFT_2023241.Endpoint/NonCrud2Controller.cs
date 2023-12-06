using EQ66L2_HFT_2023241.Logic.Interfaces;
using EQ66L2_HFT_2023241.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EQ66L2_HFT_2023241.Endpoint
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ValuesController2 : ControllerBase
    {
        ISupplyLogic Logic;

        public ValuesController2(ISupplyLogic logic)
        {
            Logic = logic;
        }

        [HttpGet("{Country}")]
        public IEnumerable<ManufactureByCountry> ManufactureByCountries(string Country)
        {
            return Logic.ManufactureByCountries(Country);
        }


    }
}
