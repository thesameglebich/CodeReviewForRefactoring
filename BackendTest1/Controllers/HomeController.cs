using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackendTest1.Models;
using BackendTest1.Services;

namespace BackendTest1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStorage storage;
        public HomeController(IStorage _storage)
        {
            storage = _storage;
        }
        public IActionResult Index()
        {
            StorageViewModel model = new StorageViewModel();
            model.modifications = this.storage.startMods();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(StorageViewModel model)
        {
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.CurrMoney = storage.getmoney();
            RegisterModel1 model = new RegisterModel1();
            model.modifications = storage.getmods();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegisterModel1 model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.CurrMoney = storage.getmoney();
                model.modifications = storage.getmods();
                ViewBag.Minus = storage.getmoney() - model.modifications[model.bodycurind].cost;
                return View("Create2", new RegisterModel2
                {
                    robotname = model.robotname,
                    bodycurind = model.bodycurind,
                    modifications = storage.getmods()
                }) ;
            }
            return View(model);
        }

        public IActionResult Create2()
        {
            RegisterModel2 model = new RegisterModel2();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create2(RegisterModel2 model)
        {
            if (ModelState.IsValid)
            {
                model.modifications = storage.getmods();
                ViewBag.Minus = storage.getmoney() - model.modifications[model.bodycurind].cost - model.modifications[model.headind].cost;
                return View("Create3", new Register3
                {
                    robotname = model.robotname,
                    bodycurind = model.bodycurind,
                    modifications = storage.getmods(),
                    headind = model.headind
                });
            }
            return View(model);
        }
        public IActionResult Create3()
        {
            Register3 model = new Register3();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create3(Register3 model, string action)
        {
            if (ModelState.IsValid)
            {
                if (action == "back")
                {
                    ViewBag.Minus = storage.getmoney() - model.modifications[model.bodycurind].cost;
                    return this.View("Create2", new RegisterModel2
                    {
                        robotname = model.robotname,
                        bodycurind = model.bodycurind,

                    });
                }
                if (action == "submit")
                {
                    model.modifications = storage.getmods();
                    ViewBag.Minus = storage.getmoney() - model.modifications[model.bodycurind].cost - model.modifications[model.headind].cost - model.modifications[model.modbodyind1].cost - model.modifications[model.modbodyind2].cost;
                    return View("Create4", new Register4
                    {
                        robotname = model.robotname,
                        bodycurind = model.bodycurind,
                        modifications = storage.getmods(),
                        headind = model.headind,
                        modbodyind1 = model.modbodyind1,
                        modbodyind2 = model.modbodyind2
                    });
                }
            }
            return View(model);
        }
        public IActionResult Create4()
        {
            Register4 model = new Register4();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create4(Register4 model, string action)
        {
            if (ModelState.IsValid)
            {
                if (action == "back")
                {
                    ViewBag.Minus = storage.getmoney() - model.modifications[model.bodycurind].cost - model.modifications[model.headind].cost;
                    return this.View("Create3", new Register3
                    {
                        robotname = model.robotname,
                        bodycurind = model.bodycurind,
                        headind = model.headind

                    });
                }
                model.modifications = storage.getmods();
                int count0 = model.modifications[model.bodycurind].cost + model.modifications[model.headind].cost + model.modifications[model.modbodyind1].cost + model.modifications[model.modbodyind2].cost + model.modifications[model.armind].cost;
                int count = storage.getmoney() - model.modifications[model.bodycurind].cost - model.modifications[model.headind].cost - model.modifications[model.modbodyind1].cost - model.modifications[model.modbodyind2].cost - model.modifications[model.armind].cost;
                storage.changeMoney(count);
                ViewBag.All = storage.getmoney();
                ViewBag.Robots = storage.getRobots();
                storage.addRobot(new MyRobot
                {
                    body = model.bodycurind,
                    arm = model.armind,
                    head = model.headind,
                    bodymod1 = model.modbodyind1,
                    bodymod2 = model.modbodyind2,
                    name = model.robotname,
                    cost = count0
                }) ;
                return View("Index", new StorageViewModel
                {
                    modifications = storage.getmods(),
                    myRobots = storage.getRobots()
                }); ;
            }
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
