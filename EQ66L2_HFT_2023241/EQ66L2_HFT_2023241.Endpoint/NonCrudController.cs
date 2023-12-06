using EQ66L2_HFT_2023241.Logic.Interfaces;
using EQ66L2_HFT_2023241.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EQ66L2_HFT_2023241.Endpoint
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        IOrderLogic logic;

        public ValuesController(IOrderLogic logic)
        {
            this.logic = logic;
        }

        /*
        public IEnumerable<PupularPrd> MostPopularPrd()

        public IEnumerable<MoneySpend> MostMoneySpend()

        public IEnumerable<CountryMostPopularPrd> PlaceOfPopularPrd()

        public IEnumerable<DateOrders> MonthOrders(int Month)
        */


        [HttpGet]
        public IEnumerable<PupularPrd> MostPopularPrd()
        {
            return this.logic.MostPopularPrd();
        }
        [HttpGet]
        public IEnumerable<MoneySpend> MostMoneySpend()
        {
            return this.logic.MostMoneySpend();
        }

        [HttpGet]
        public IEnumerable<CountryMostPopularPrd> PlaceOfPopularPrd()
        {
            return this.logic.PlaceOfPopularPrd();
        }
        [HttpGet("{Month}")]
        public IEnumerable<DateOrders> MonthOrders(int Month)
        {
            return this.logic.MonthOrders(Month);
        }




    }
}
