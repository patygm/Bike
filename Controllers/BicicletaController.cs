using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web;
using Bike.Models;
using System.Data;

namespace Bike.Controllers
{
    public class BicicletaController : Controller
    {
        private readonly IBicicletaRepository _bicicletaRepositorio;

        public BicicletaController()
        {
            this._bicicletaRepositorio = new BicicletaRepository(new BicicletaDbContext());
        }

        // GET: /Bike/
        public ActionResult Index()
        {
            var bikes = from bike in _bicicletaRepositorio.GetBike()
                        select bike;
            return View(bikes);
        }

        // GET: /Bike/Details/5
        public ActionResult Details(int id)
        {
            Bicicleta bike = _bicicletaRepositorio.GetBikePorID(id);
            return View(bike);
        }

        // GET: /Bike/Create
        public ActionResult Create()
        {
            return View(new Bicicleta());
        }

        // POST: /Bike/Create
        [HttpPost]
        public ActionResult Create(Bicicleta bike)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bicicletaRepositorio.InserirBike(bike);
                    _bicicletaRepositorio.Salvar();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente novamente....");
            }
            return View(bike);
        }

        // GET: /Bike/Edit/5
        public ActionResult Edit(int id)
        {
            Bicicleta bike = _bicicletaRepositorio.GetBikePorID(id);
            return View(bike);
        }

        //
        // POST: /Bike/Edit/5
        [HttpPost]
        public ActionResult Edit(Bicicleta bike)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bicicletaRepositorio.AtualizaBike(bike);
                    _bicicletaRepositorio.Salvar();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente novamente.....");
            }
            return View(bike);
        }

        // GET: /Bike/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Não foi possível salvar as mudanças. Tente novamente......";
            }
            Bicicleta bike = _bicicletaRepositorio.GetBikePorID(id);
            return View(bike);
        }

        // POST: /Bike/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                Bicicleta bike = _bicicletaRepositorio.GetBikePorID(id);
                _bicicletaRepositorio.DeletarBike(id);
                _bicicletaRepositorio.Salvar();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                  new Routing.RouteValueDictionary {
               { "id", id },
               { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }

    }
}
