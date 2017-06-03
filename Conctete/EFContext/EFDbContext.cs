using AutoInfo.Domain.Entities;
using AutoInfo.Infrastructure.EFContext;
using System.Collections.Generic;
using System.Data.Entity;

namespace AutoInfo.Conctete.EFContext
{
    public class EFDbContext : DbContext, IEFDbContext
    {
        // Имя будущей базы данных можно указать через
        // вызов конструктора базового класса
        public EFDbContext()
            : base("AutoInfoDb")
        { }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Country> Countries { get; set; }

        //пришлось вынести Update сюда, так как не было видно метода Entry
        public void Update(Car car)
        {
            this.Entry(car).State = EntityState.Modified;
        }

        public void Update(Country country)
        {
            this.Entry(country).State = EntityState.Modified;
        }

        public int Save()
        {
            return this.SaveChanges();
        }
    }
}
