using AutoInfo.Conctete.UnitOfWorkEFDbContext;
using AutoInfo.Domain.Entities;
using AutoInfo.Infrastructure.Repository;
using AutoInfo.Infrastructure.UnitOfWorkEFDbContext;
using Ext.Net;
using Ext.Net.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoInfo.WebUI.Controllers
{
    public class CarController : Controller
    {
        private IUnitOfWorkEFDbContext unitOfWork;

        //библиотека Ninject конструктор объявляет зависимость
        //от интерфейсов
        public CarController(IUnitOfWorkEFDbContext UOW)
        {
            unitOfWork = UOW;
        }

        public ActionResult Index()
        {
            return View(unitOfWork.Cars.GetAll().ToList());
        }

        public ActionResult HandleChanges(StoreDataHandler handler)
        {
            ChangeRecords<Car> persons = handler.BatchObjectData<Car>();
            var store = this.GetCmp<Store>("Store1");

            foreach (Car created in persons.Created)
            {
                unitOfWork.Cars.Create(created);

                var record = store.GetByInternalId(created.PhantomId);
                record.CreateVariable = true;
                record.SetId(created.CarId);
                record.Commit();
                created.PhantomId = null;
            }

            foreach (Car deleted in persons.Deleted)
            {
                unitOfWork.Cars.Delete(deleted.CarId);
                
                store.CommitRemoving(deleted.CarId);
            }

            foreach (Car updated in persons.Updated)
            {
                unitOfWork.Cars.Update(updated);

                var record = store.GetById(updated.CarId);
                record.Commit();
            }

            return this.Direct();
        }
    }
}