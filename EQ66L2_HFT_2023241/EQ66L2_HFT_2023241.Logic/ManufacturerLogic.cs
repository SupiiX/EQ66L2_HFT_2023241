using EQ66L2_HFT_2023241.Logic.Interfaces;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Logic
{
    public class ManufacturerLogic : IManufacturerLogic
    {
        IReposit<Manufacturer> reposit;

        public ManufacturerLogic(IReposit<Manufacturer> reposit)
        {
            this.reposit = reposit;
        }

        public void Create(Manufacturer item)
        {
            if (item.ManufacturerName.Length < 2)
            {
                throw new Exception("Manufacturer name is too short ");

            }

            this.reposit.Create(item);
        }



        public void Delete(int id)
        {
            this.reposit.Delete(id);
        }

        public Manufacturer Read(int id)
        {
            return this.reposit.Read(id);
        }

        public IEnumerable<Manufacturer> ReadAll()
        {
            return this.reposit.ReadAll();
        }

        public void Update(Manufacturer value)
        {
            this.reposit.Update(value);
        }

        /// non crud
        /// 

        public IEnumerable<ManufactureByCountry> ManufactureByCountries(string Country)
        {

            /// ki gyart ott és mit 


            return ProductLogic.ReadAll().Include(x => x.Manufacturer)
                .Select(x => new ManufactureByCountry
                {
                    ManufaturerName = x.Manufacturer.ManufacturerName,

                    ProductName = x.ProductName,

                    MadeIn = x.Manufacturer.PlaceOf


                }).Where(x => x.MadeIn == Country);

        }



    }


    public class ManufactureByCountry
    {
        public string ManufaturerName;
        public string MadeIn;
        public string ProductName;

    }
}
