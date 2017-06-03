using AutoInfo.Conctete.EFContext;
using AutoInfo.Infrastructure.EFContext;
using AutoInfo.Infrastructure.Repository;
using AutoInfo.Infrastructure.UnitOfWorkEFDbContext;
using System;
using System.Collections.Generic;

namespace AutoInfo.Conctete.UnitOfWorkEFDbContext
{
    //Паттерн Unit of Work позволяет упростить работу с различными 
    //репозиториями и дает уверенность, что все репозитории будут 
    //использовать один и тот же контекст данных
    public class UnitOfWorkEFDbContext : IUnitOfWorkEFDbContext
    {
        private IEFDbContext db = new EFDbContext();
        private ICarRepository carRepository;
        private ICountryRepository countryRepository;

        public ICarRepository Cars
        {
            get
            {
                return carRepository;
            }
        }

        public ICountryRepository Countries
        {
            get
            {
                return countryRepository;
            }
        }

        private bool disposed = false;


        public UnitOfWorkEFDbContext(ICarRepository carRepository, ICountryRepository countryRepository)
        {
            this.carRepository = carRepository;
            this.countryRepository = countryRepository;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save()
        {
            return db.Save();
        }
    }
}
