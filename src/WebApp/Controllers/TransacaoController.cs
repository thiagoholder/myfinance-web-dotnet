using Microsoft.AspNetCore.Mvc;
using MyFinance.Application.Dto;
using MyFinance.Application.Interfaces;
using MyFinance.WebApp.Models;

namespace MyFinance.WebApp.Controllers;

public class TransacaoController : Controller
{
    private readonly IGetAllTransacoes _getAllTransacoes;
    private readonly IDeleteTransacao _deleteTransacao;

    public TransacaoController(IGetAllTransacoes getAllTransacoes, IDeleteTransacao deleteTransacao)
    {
        _getAllTransacoes = getAllTransacoes;
        _deleteTransacao = deleteTransacao;
    }

    // GET: TransacaoController
    public async Task<IActionResult> Index()
    {
        var transacoes = await _getAllTransacoes.ExecuteAsync();
        var viewModel = new TransacaoListViewModel
        {
            Transacoes = transacoes.Select(x => new Transacao
            {
                Id = x.Id,
                Data = x.Data,
                Historico = x.Historico,
                PlanoConta = x.PlanoConta,
                PlanoContaId = x.PlanoContaId,
                Valor = x.Valor
            }).ToList(),
        };
        return View(viewModel);
    }

    // GET: TransacaoController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: TransacaoController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
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

    // GET: TransacaoController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: TransacaoController/Edit/5
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

    // POST: TransacaoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteTransacao.ExecuteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}