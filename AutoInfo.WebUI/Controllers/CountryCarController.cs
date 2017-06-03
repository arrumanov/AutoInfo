using AutoInfo.Domain.Abstract;
using AutoInfo.Domain.Concrete;
using AutoInfo.Domain.Entities;
using AutoInfo.WebUI.Models;
using Ext.Net;
using Ext.Net.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AutoInfo.WebUI.Controllers
{
    public class CountryCarController : Controller
    {
       private IUnitOfWorkEFDbContext unitOfWork;

       public CountryCarController(ICarRepository carRepository,
            ICountryRepository countryRepository)
        {
            unitOfWork = new UnitOfWorkEFDbContext(carRepository, countryRepository);
        }

        public ActionResult Index()
        {
            List<CountryCar> list = new List<CountryCar>();
            int counter = 1;
            foreach(var country in unitOfWork.Countries.GetAll().ToList())
            {
                
                foreach (var car in country.Cars)
                {
                    CountryCar cc = new CountryCar();
                    cc.Counter = counter++;
                    cc.CountryId = country.CountryId;
                    cc.Continent = country.Continent;
                    cc.NameOfCountry = country.NameOfCountry;

                    cc.CarId = car.CarId;
                    cc.BrandOfCar = car.BrandOfCar;
                    cc.ModelOfCar = car.ModelOfCar;
                    list.Add(cc);
                }
            }

            return View(list);
        }

        public ActionResult HandleChanges(StoreDataHandler handler)
        {
            ChangeRecords<CountryCar> persons = handler.BatchObjectData<CountryCar>();
            ChangeRecords<Country> persons2 = handler.BatchObjectData<Country>();
            var store = this.GetCmp<Store>("Store1");

            foreach (CountryCar created in persons.Created)
            {
                Car car = new Car
                {
                    CarId = created.CarId,
                    BrandOfCar = created.BrandOfCar,
                    ModelOfCar = created.ModelOfCar
                };

                Country country = new Country
                {
                    CountryId = created.CountryId,
                    Continent = created.Continent,
                    NameOfCountry = created.NameOfCountry,
                    Cars = new List<Car> { { car } }
                };

                unitOfWork.Countries.Create(country);
                //unitOfWork.Cars.Create(car);

                var record = store.GetByInternalId(created.PhantomId);
                record.CreateVariable = true;
                record.SetId(created.Counter);
                record.Commit();
                created.PhantomId = null;
            }

            foreach (Country deleted in persons2.Deleted)
            {
                unitOfWork.Countries.Delete(deleted.CountryId);
                
                store.CommitRemoving(deleted.CountryId);
            }

            foreach (CountryCar updated in persons.Updated)
            {
                Car car = new Car
                {
                    CarId = updated.CarId,
                    BrandOfCar = updated.BrandOfCar,
                    ModelOfCar = updated.ModelOfCar
                };

                Country country = new Country
                {
                    CountryId = updated.CountryId,
                    Continent = updated.Continent,
                    NameOfCountry = updated.NameOfCountry,
                    Cars = new List<Car> { { car } }
                };

                unitOfWork.Countries.Update(country);
                unitOfWork.Cars.Update(car);

                var record = store.GetById(updated.CountryId);
                record.Commit();
            }

            //return this.Direct();
            return RedirectToAction("Index");
        }
    }
}