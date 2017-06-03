﻿using System.Collections.Generic;
using AutoInfo.Domain.Entities;

namespace AutoInfo.Domain.Abstract
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll();
        Country Get(int id);
        void Create(Country item);
        void Update(Country item);
        void Delete(int id);
    }
}

