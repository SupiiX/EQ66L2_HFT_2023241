﻿using EQ66L2_HFT_2023241.Logic;
using EQ66L2_HFT_2023241.Logic.Interfaces;
using EQ66L2_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EQ66L2_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderLogic logic;

        public OrderController(IOrderLogic logic)
        {
            this.logic = logic;
        }



        [HttpGet]
        public IEnumerable<Order> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Order Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Order value)
        {
            this.logic.Create(value);

        }


        [HttpPut]
        public void Update([FromBody] Order value)
        {
            this.logic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);

        }

        /////// non crud 

        [HttpGet("[action]")]
        public IEnumerable<PupularPrd> MostPopularPrd()
        {
            return this.logic.MostPopularPrd();

        }


        [HttpGet("[action]")]
        public IEnumerable<MoneySpend> MostMoneySpend()
        {
            return this.logic.MostMoneySpend();

        }

        //IEnumerable<CountryMostPopularPrd> PlaceOfPopularPrd();

        [HttpGet("[action]")]
        public IEnumerable<CountryMostPopularPrd> PlaceOfPopularPrd()
        {
            return this.logic.PlaceOfPopularPrd();

        }

        //IEnumerable<DateOrders> MonthOrders(int Month);

        [HttpGet("[action]/{Month}")]
        public IEnumerable<DateOrders> MonthOrders(int Month)
        {
            return this.logic.MonthOrders(Month);

        }



    }
}
