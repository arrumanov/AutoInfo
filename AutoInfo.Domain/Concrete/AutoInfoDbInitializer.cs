using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using AutoInfo.Domain.Entities;
using AutoInfo.Domain.Abstract;

namespace AutoInfo.Domain.Concrete
{
    public class AutoInfoDbInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            Car car1 = new Car() { BrandOfCar = "A", ModelOfCar = "1" };
            Car car2 = new Car() { BrandOfCar = "B", ModelOfCar = "2" };
            Car car3 = new Car() { BrandOfCar = "C", ModelOfCar = "3" };
            Car car4 = new Car() { BrandOfCar = "D", ModelOfCar = "4" };
            Car car5 = new Car() { BrandOfCar = "E", ModelOfCar = "5" };
            Car car6 = new Car() { BrandOfCar = "F", ModelOfCar = "6" };
            List<Car> lCar1 = new List<Car>();
            List<Car> lCar2 = new List<Car>();
            List<Car> lCar3 = new List<Car>();
            List<Car> lCar4 = new List<Car>();
            List<Car> lCar5 = new List<Car>();
            lCar1.Add(car1); lCar1.Add(car3); lCar1.Add(car5);
            lCar2.Add(car2); lCar2.Add(car4); lCar2.Add(car5);
            lCar3.Add(car1); lCar3.Add(car4);
            lCar4.Add(car6);
            lCar5.Add(car1); lCar5.Add(car6);

            Country country1 = new Country() { Continent = "I", NameOfCountry = "CA", Cars = lCar1 };
            Country country2 = new Country() { Continent = "II", NameOfCountry = "CB", Cars = lCar2 };
            Country country3 = new Country() { Continent = "III", NameOfCountry = "CC", Cars = lCar3 };
            Country country4 = new Country() { Continent = "IV", NameOfCountry = "CD", Cars = lCar4 };
            Country country5 = new Country() { Continent = "V", NameOfCountry = "CE", Cars = lCar5 };


            context.Cars.Add(car1);
            context.Cars.Add(car2);
            context.Cars.Add(car3);
            context.Cars.Add(car4);
            context.Cars.Add(car5);
            context.Cars.Add(car6);
            context.Countries.Add(country1);
            context.Countries.Add(country2);
            context.Countries.Add(country3);
            context.Countries.Add(country4);
            context.Countries.Add(country5);

            base.Seed(context);
        }
    }
}
