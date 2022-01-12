using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTest1.Models;
using BackendTest1.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest1.Controllers
{
    public class RobotController : Controller
    {
        private readonly IStorage storage;
        RobotController(IStorage _strorage)
        {
            storage = _strorage;
        }
        public IActionResult Index()
        {
            StorageViewModel model = new StorageViewModel();
            model.modifications = this.storage.startMods();
            return View(model);
        }

        
       
    }
}
