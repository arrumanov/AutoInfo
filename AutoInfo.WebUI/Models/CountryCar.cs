using Ext.Net.MVC;
using System.Collections.Generic;

namespace AutoInfo.WebUI.Models
{
    [Model(Name = "Person", ClientIdProperty = "PhantomId")]
    [JsonWriter(Encode = true, RootProperty = "data")]
    public class CountryCar
    {
        //для вывода номера строки
        [ModelField(IDProperty = true, UseNull = true)]
        [Field(Ignore = true)]
        public int Counter { get; set; }

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

        [Field(Ignore = true)]
        public int CarId { get; set; }

        [PresenceValidator]
        public string BrandOfCar { get; set; }

        [PresenceValidator]
        public string ModelOfCar { get; set; }
    }
}