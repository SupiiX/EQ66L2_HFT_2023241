using EQ66L2_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository
{
    public class ManufacturerRepository : Reposit<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public void Origin(int id, string County)
        {
            var Manufacturer = Read(id);

            if (Manufacturer != null)
            {
                Manufacturer.PlaceOf = County;

               dbContext.SaveChanges();

            }
            else
            {
                throw new Exception("Error ID not found");
            }


        }



        public override Manufacturer Read(int id)
        {

            // exeption?

            return ReadAll().FirstOrDefault(x =>x.ManufacturerID == id);
        }
    }
}
