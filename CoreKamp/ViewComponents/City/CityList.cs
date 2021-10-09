using CoreKamp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.ViewComponents.City
{
    [AllowAnonymous]
    public class CityList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var city = new List<CityModel>
            {
                new CityModel{cityId=01 , cityName="Adana"},
                new CityModel{cityId=02 , cityName="Adıyaman"},
                new CityModel{cityId=03 , cityName="Afyonkarahisar"},
                new CityModel{cityId=04 , cityName="Ağrı"},
                new CityModel{cityId=05 , cityName="Amasya"},
                new CityModel{cityId=06 , cityName="Ankara"},
                new CityModel{cityId=07 , cityName="Antalya"},
                new CityModel{cityId=08 , cityName="Artvin"},
                new CityModel{cityId=09 , cityName="Aydın"},
                new CityModel{cityId=10 , cityName="Balıkesir"},
                new CityModel{cityId=11 , cityName="Bilecik"},
                new CityModel{cityId=12 , cityName="Bingöl"},
                new CityModel{cityId=13 , cityName="Bitlis"},
                new CityModel{cityId=14 , cityName="Bolu"},
                new CityModel{cityId=15 , cityName="Burdur"},
                new CityModel{cityId=16 , cityName="Bursa"},
                new CityModel{cityId=17 , cityName="Çanakkale"},
                new CityModel{cityId=18 , cityName="Çankırı"},
                new CityModel{cityId=19 , cityName="Çorum"},
                new CityModel{cityId=20 , cityName="Denizli"},
                new CityModel{cityId=21 , cityName="Diyarbakır"},
                new CityModel{cityId=22 , cityName="Edirne"},
                new CityModel{cityId=23 , cityName="Elazığ"},
                new CityModel{cityId=24 , cityName="Erzincan"},
                new CityModel{cityId=25 , cityName="Erzurum"},
                new CityModel{cityId=26 , cityName="Eskişehir"},
                new CityModel{cityId=27 , cityName="Gaziantep"},
                new CityModel{cityId=28 , cityName="Giresun"},
                new CityModel{cityId=29 , cityName="Gümüşhane"},
                new CityModel{cityId=30 , cityName="Hakkâri"},
                new CityModel{cityId=31 , cityName="Hatay"},
                new CityModel{cityId=32 , cityName="Isparta"},
                new CityModel{cityId=33 , cityName="Mersin"},
                new CityModel{cityId=34 , cityName="İstanbul"},
                new CityModel{cityId=35 , cityName="İzmir"},
                new CityModel{cityId=36 , cityName="Kars"},
                new CityModel{cityId=37 , cityName="Kastamonu"},
                new CityModel{cityId=38 , cityName="Kayseri"},
                new CityModel{cityId=39 , cityName="Kırklareli"},
                new CityModel{cityId=40 , cityName="Kırşehir"},
                new CityModel{cityId=41 , cityName="Kocaeli"},
                new CityModel{cityId=42 , cityName="Konya"},
                new CityModel{cityId=43 , cityName="Kütahya"},
                new CityModel{cityId=44 , cityName="Malatya"},
                new CityModel{cityId=45 , cityName="Manisa"},
                new CityModel{cityId=46 , cityName="Kahramanmaraş"},
                new CityModel{cityId=47 , cityName="Mardin"},
                new CityModel{cityId=48 , cityName="Muğla"},
                new CityModel{cityId=49 , cityName="Muş"},
                new CityModel{cityId=50 , cityName="Nevşehir"},
                new CityModel{cityId=51 , cityName="Niğde"},
                new CityModel{cityId=52 , cityName="Ordu"},
                new CityModel{cityId=53 , cityName="Rize"},
                new CityModel{cityId=54 , cityName="Sakarya"},
                new CityModel{cityId=55 , cityName="Samsun"},
                new CityModel{cityId=56 , cityName="Siirt"},
                new CityModel{cityId=57 , cityName="Sinop"},
                new CityModel{cityId=58 , cityName="Sivas"},
                new CityModel{cityId=59 , cityName="Tekirdağ"},
                new CityModel{cityId=60 , cityName="Tokat"},
                new CityModel{cityId=61 , cityName="Trabzon"},
                new CityModel{cityId=62 , cityName="Tunceli"},
                new CityModel{cityId=63 , cityName="Şanlıurfa"},
                new CityModel{cityId=64 , cityName="Uşak"},
                new CityModel{cityId=65 , cityName="Van"},
                new CityModel{cityId=66 , cityName="Yozgat"},
                new CityModel{cityId=67 , cityName="Zonguldak"},
                new CityModel{cityId=68 , cityName="Aksaray"},
                new CityModel{cityId=69 , cityName="Bayburt"},
                new CityModel{cityId=70 , cityName="Karaman"},
                new CityModel{cityId=71 , cityName="Kırıkkale"},
                new CityModel{cityId=72 , cityName="Batman"},
                new CityModel{cityId=73 , cityName="Şırnak"},
                new CityModel{cityId=74 , cityName="Bartın"},
                new CityModel{cityId=75 , cityName="Ardahan"},
                new CityModel{cityId=76 , cityName="Iğdır"},
                new CityModel{cityId=77 , cityName="Yalova"},
                new CityModel{cityId=78 , cityName="Karabük"},
                new CityModel{cityId=79 , cityName="Kilis"},
                new CityModel{cityId=80 , cityName="Osmaniye"},
                new CityModel{cityId=81 , cityName ="Düzce"}

            };
            ViewBag.City = city;
            return View();
        }
    }
}
