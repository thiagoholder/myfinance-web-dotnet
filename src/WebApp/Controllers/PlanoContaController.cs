using Microsoft.AspNetCore.Mvc;
using MyFinance.Application.Dto;
using MyFinance.Application.Interfaces;
using MyFinance.WebApp.Models;

namespace MyFinance.WebApp.Controllers;

public class PlanoContaController : Controller
{
    private readonly IGetAllPlanoConta _getAllPlanoConta;
    private readonly IDeletePlanoConta _deletePlanoConta;
    private readonly IGetPlanoContaById _getPlanoContaById;
    private readonly IUpdatePlanoConta _updatePlanoConta;
    private readonly ICreatePlanoConta _createPlanoConta;

    public PlanoContaController(
        IGetAllPlanoConta getAllPlanoConta,
        IDeletePlanoConta deletePlanoConta,
        IGetPlanoContaById getPlanoContaById,
        IUpdatePlanoConta updatePlanoConta,
        ICreatePlanoConta createPlanoConta)
    {
        _getAllPlanoConta = getAllPlanoConta;
        _deletePlanoConta = deletePlanoConta;
        _getPlanoContaById = getPlanoContaById;
        _updatePlanoConta = updatePlanoConta;
        _createPlanoConta = createPlanoConta;
    }

    public async Task<IActionResult> Index()
    {
        var planoContas = await _getAllPlanoConta.ExecuteAsync();
        var viewModel = new PlanoContaListViewModel
        {
            PlanoContas = planoContas.Select(pc => new Application.Dto.PlanoConta
            {
                Id = pc.Id,
                Descricao = pc.Descricao,
                Tipo = pc.Tipo
            }).ToList()
        };
        return View(viewModel);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var planoConta = await _getPlanoContaById.ExecuteAsync(id);

        if (planoConta == null)
        {
            return NotFound();
        }

        var viewModel = new EditPlanoContaViewModel
        {
            Id = planoConta.Id,
            Descricao = planoConta.Descricao,
            Tipo = planoConta.Tipo
        };

        return View(viewModel);
    }

    // POST: PlanoConta/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, EditPlanoContaViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var planoConta = new PlanoConta
            {
                Id = viewModel.Id,
                Descricao = viewModel.Descricao,
                Tipo = viewModel.Tipo
            };

            await _updatePlanoConta.ExecuteAsync(planoConta);

            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreatePlanoContaViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var planoContaDto = new PlanoConta
        {
            Descricao = viewModel.Descricao,
            Tipo = viewModel.Tipo
        };

        await _createPlanoConta.ExecuteAsync(planoContaDto);

        return RedirectToAction(nameof(Index));
    }

    // POST: PlanoContaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deletePlanoConta.ExecuteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}