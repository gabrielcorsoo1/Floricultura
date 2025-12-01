using Greenhouse.Models;
using Greenhouse.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.Controllers
{
    public class PlantController(IPlantRepository plantRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await plantRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,SensorValue,SensorEvent")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                await plantRepository.Create(plant);
                return RedirectToAction(nameof(Index));
            }
            return View(plant);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realty = await plantRepository.GetById(id.Value);

            if (realty == null)
            {
                return NotFound();
            }
            return View(realty);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SensorValue,SensorEvent")] Plant plant)
        {
            if (id != plant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await plantRepository.Update(plant);

                return RedirectToAction(nameof(Index));
            }
            return View(plant);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var plant = await plantRepository.GetById(id);
            if (plant == null)
                return NotFound();

            await plantRepository.Delete(plant);
            return RedirectToAction("Index");
        }
    }
}
