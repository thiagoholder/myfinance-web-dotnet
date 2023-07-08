using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class PlanoContaController : Controller
{
    protected IPlanoContaService _planoContaService;

    public PlanoContaController(IPlanoContaService planocontaService)
    {
        _planoContaService = planocontaService;
    }

    // GET: PlanoContaController
    public async Task<IActionResult> Index()
    {
        var planosConta = await _planoContaService.GetAllPlanosContasAsync();
        return View(planosConta);
    }

    // GET: PlanoContaController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: PlanoContaController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PlanoContaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Domain.Models.PlanoConta planoConta)
    {
        try
        {
            await _planoContaService.CreatePlanoContaAsync(planoConta);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View("Details");
        }
    }

    // GET: PlanoContaController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: PlanoContaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PlanoContaController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: PlanoContaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}