using Ext.Net.MVC;
using System.Collections.Generic;
namespace AutoInfo.Domain.Entities
{
    [Model(Name = "Person", ClientIdProperty = "PhantomId")]
    [JsonWriter(Encode = true, RootProperty = "data")]
    public class Country
    {

        [ModelField(IDProperty = true, UseNull = true)]
        [Field(Ignore = true)]
        public int CountryId { get; set; }

        [ModelField(Ignore = true)]
        public string PhantomId
        {
            get;
            set;
        }

        [PresenceValidator]
        public string Continent { get; set; }

        [PresenceValidator]
        public string NameOfCountry { get; set; }

        //[Column(Hidden = true)]
        [ModelField(Ignore = true)]
        public virtual ICollection<Car> Cars { get; set; }

        public IEnumerator<Car> GetEnumerator()
        {
            return Cars.GetEnumerator();
        }
    }
}
