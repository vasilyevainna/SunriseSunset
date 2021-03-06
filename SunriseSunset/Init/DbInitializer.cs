﻿using System.Data.Entity;
using SunriseSunset.Models;

namespace SunriseSunset.Init
{
    public class DbInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context db)
        {
            db.Cities.Add(new CityModel { Key = "Kiev", Name = "Киев", Latitude = 50.4546600, Longitude = 30.5238000 });
            db.Cities.Add(new CityModel { Key = "Zaporozhye", Name = "Запорожье", Latitude = 47.8228900, Longitude = 35.1903100 });
            db.Cities.Add(new CityModel { Key = "Odessa", Name = "Одесса", Latitude = 46.4774700, Longitude = 30.7326200 });
            db.Cities.Add(new CityModel { Key = "Lyvov", Name = "Львов", Latitude = 49.8383,  Longitude = 24.0232 });
            db.Cities.Add(new CityModel { Key = "Kharkov", Name = "Харьков", Latitude = 49.9808100, Longitude = 36.2527200 });

            base.Seed(db);
        }
    }
}