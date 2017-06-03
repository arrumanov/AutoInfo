using System.Collections.Generic;
using AutoInfo.Domain.Entities;
using System;

namespace AutoInfo.Domain.Abstract
{
    public interface IUnitOfWorkEFDbContext : IDisposable
    {
        ICarRepository Cars { get; }
        ICountryRepository Countries { get; }

        int Save();
    }
}
