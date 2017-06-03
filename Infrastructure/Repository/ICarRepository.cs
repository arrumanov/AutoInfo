using System.Collections.Generic;
using AutoInfo.Domain.Entities;

namespace AutoInfo.Infrastructure.Repository
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car Get(int id);
        void Create(Car item);
        void Update(Car item);
        void Delete(int id);
    }
}
