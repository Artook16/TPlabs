using Microsoft.AspNetCore.Mvc;
using Лабораторная_работа__2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Лабораторная_работа__2.Controllers
{
    public class HomeController : Controller
    {
        private static List<ClientModel> clients = new List<ClientModel>();
        private static int nextId = 1;

        public IActionResult Index()
        {
            TempData["UseExternalHelper"] = true;
            return View(clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = nextId++;
                clients.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var client = clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                return NotFound();
            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(ClientModel model)
        {
            if (ModelState.IsValid)
            {
                int index = clients.FindIndex(c => c.Id == model.Id);
                if (index != -1)
                    clients[index] = model;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var client = clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                return NotFound();
            return View(client);
        }
    }
}