using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace UI.Models
{
    public class CityList
    {
        private readonly ICityService _cityService;
        public CityList(ICityService cityService)
        {
            _cityService = cityService;
        }

        public SelectList GetCities()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var cities = _cityService.GetAllCities().Data;
            foreach (var city in cities)
            {
                items.Add(new SelectListItem { Value = city.CityId.ToString(), Text = city.CityName });
            }
            return new SelectList(items, "Value", "Text");
        }
    }
}
