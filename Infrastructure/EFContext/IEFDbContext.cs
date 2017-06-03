using System;
using System.Collections.Generic;
using AutoInfo.Domain.Entities;
using System.Data.Entity;

namespace AutoInfo.Infrastructure.EFContext
{
    public interface IEFDbContext : IDisposable
    {
        IDbSet<Car> Cars { get; set; }
        IDbSet<Country> Countries { get; set; }

        int Save();

        void Update(Car car);
        void Update(Country country);
    }
}
