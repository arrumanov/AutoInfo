using AutoInfo.Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace AutoInfo.Infrastructure.UnitOfWorkEFDbContext
{
    public interface IUnitOfWorkEFDbContext : IDisposable
    {
        ICarRepository Cars { get; }
        ICountryRepository Countries { get; }

        int Save();
    }
}
