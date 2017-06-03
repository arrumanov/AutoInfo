using AutoInfo.Domain.Entities;
using AutoInfo.Domain.Abstract;
using System.Collections.Generic;

namespace AutoInfo.Domain.Concrete
{
    public class CountryRepository : ICountryRepository
    {
        private IEFDbContext db;

        public CountryRepository(IEFDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Country> GetAll()
        {
            return db.Countries;
        }

        public Country Get(int id)
        {
            return db.Countries.Find(id);
        }

        //с методом Save запутался, поэтому указал его и здесь
        public void Create(Country country)
        {
            db.Countries.Add(country);
            db.Save();
        }

        public void Update(Country country)
        {
            db.Update(country);
            db.Save();

        }

        public void Delete(int id)
        {
            Country country = db.Countries.Find(id);
            if (country != null)
            {
                db.Countries.Remove(country);
                db.Save();
            }
        }
    }
}