﻿using Ninject.Extensions.Logging;
using SunriseSunset.HandleError;
using SunriseSunset.Models;
using SunriseSunset.Repositories;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SunriseSunset.Controllers
{
    [CustomHandleError]
    public class CitiesController : Controller
    {
        private readonly ICityRepository _cityRepository;
        private readonly ILogger _logger;

        public CitiesController(ICityRepository cityRepository, ILogger logger)
        {
            _cityRepository = cityRepository;
            _logger = logger;
        }

        // GET: Cities
        public async Task<ActionResult> Index() => View(await _cityRepository.ListAsync());
        
        // GET: Cities/Create
        public ActionResult Create() => View();
        

        // POST: Cities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Key,Name,Latitude,Longitude")] CityModel city)
        {
            if (!ModelState.IsValid) return View(city);
            await _cityRepository.CreateAsync(city);
            return RedirectToAction("Index");
        }

        // GET: Cities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                _logger.Debug("Id is not specified for the edit city method.");
                return RedirectToAction("Index");
            }
            var city = await _cityRepository.GetAsync(id.Value);
            if (city == null)
            {
                _logger.Debug($"City with the specified id - {id} wasn't found.");
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Key,Name,Latitude,Longitude")] CityModel city)
        {
            if (!ModelState.IsValid) return View(city);
            await _cityRepository.EditAsync(city);
            return RedirectToAction("Index");
        }

        // GET: Cities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                _logger.Debug("Id is not specified for the delete city method.");
                return RedirectToAction("Index");
            }
            var city = await _cityRepository.GetAsync(id.Value);
            if (city == null)
            {
                _logger.Debug($"City with the specified id - {id} wasn't found.");
                return RedirectToAction("Index");
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var city = await _cityRepository.GetAsync(id);
            if (city == null)
            {
                _logger.Debug($"City with the specified id - {id} wasn't found.");
                return RedirectToAction("Index");
            }

            await _cityRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
