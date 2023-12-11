﻿using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository.Database;
using EQ66L2_HFT_2023241.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository
{
    public class ManufacturerRepository : Reposit<Manufacturer>
    {

        public ManufacturerRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public override Manufacturer Read(int id)
        {
           return ReadAll().FirstOrDefault(x => x.ManufacturerID == id);
        }

        public override void Update(Manufacturer value)
        {

            var OldData = Read(value.ManufacturerID);

            foreach (var item in OldData.GetType().GetProperties())
            {
                //  

                item.SetValue(OldData, item.GetValue(value));

            }
            dbContext.SaveChanges();

        }
    }
 }

