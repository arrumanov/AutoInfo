using Ext.Net.MVC;
using System.Collections.Generic;
namespace AutoInfo.Domain.Entities
{
    [Model(Name = "Person", ClientIdProperty = "PhantomId")]
    [JsonWriter(Encode = true, RootProperty = "data")]
    public class Car
    {
        [ModelField(IDProperty = true, UseNull = true)]
        [Field(Ignore = true)]
        public int CarId { get; set; }

        [ModelField(Ignore = true)]
        public string PhantomId
        {
            get;
            set;
        }

        [PresenceValidator]
        public string BrandOfCar { get; set; }

        [PresenceValidator]
        public string ModelOfCar { get; set; }

        [ModelField(Ignore = true)]
        public virtual ICollection<Country> Countries { get; set; }

        public IEnumerator<Country> GetEnumerator()
        {
            return Countries.GetEnumerator();
        }
    }
}
