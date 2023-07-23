using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFinance.Application.Dto;
using MyFinance.Application.Interfaces;
using MyFinance.WebApp.Models;

namespace MyFinance.WebApp.Controllers;

public class TransacaoController : Controller
{
    private readonly IGetAllTransacoes _getAllTransacoes;
    private readonly IDeleteTransacao _deleteTransacao;
    private readonly IGetTransacaoById _getTransacaoById;
    private readonly IGetAllPlanoConta _getAllPlanoConta;
    private readonly IUpdateTransacao _updateTransacao;
    private readonly ICreateTransacao _createTransacao;

    public TransacaoController(
        IGetAllTransacoes getAllTransacoes,
        IDeleteTransacao deleteTransacao,
        IGetTransacaoById getTransacaoById,
        IGetAllPlanoConta getAllPlanoConta,
        IUpdateTransacao updateTransacao,
        ICreateTransacao createTransacao)
    {
        _getAllTransacoes = getAllTransacoes;
        _deleteTransacao = deleteTransacao;
        _getTransacaoById = getTransacaoById;
        _getAllPlanoConta = getAllPlanoConta;
        _updateTransacao = updateTransacao;
        _createTransacao = createTransacao;
    }

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

    public async Task<IActionResult> Create()
    {
        ViewBag.PlanosConta = await SetPlanoContas();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TransacaoCreateViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var transacaoDto = new Transacao
        {
            Historico = viewModel.Historico,
            Valor = viewModel.Valor,
            Data = viewModel.Data,
            PlanoContaId = viewModel.PlanoContaId,
        };

        await _createTransacao.ExecuteAsync(transacaoDto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var transacao = await _getTransacaoById.ExecuteAsync(id);
        ViewBag.PlanosConta = await SetPlanoContas(id);

        if (transacao == null)
        {
            return NotFound();
        }

        var viewModel = new TransacaoEditViewModel
        {
            Id = transacao.Id,
            Historico = transacao.Historico,
            Data = transacao.Data,
            Valor = transacao.Valor,
            PlanoContaId = transacao.PlanoContaId,
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, TransacaoEditViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var transacao = new Transacao
            {
                Id = viewModel.Id,
                Historico = viewModel.Historico,
                Data = viewModel.Data,
                Valor = viewModel.Valor,
                PlanoContaId = viewModel.PlanoContaId,
            };

            await _updateTransacao.ExecuteAsync(transacao);

            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteTransacao.ExecuteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task<IEnumerable<SelectListItem>> SetPlanoContas(Guid id = default)
    {
        var planosContas = await _getAllPlanoConta.ExecuteAsync();
        var planosContaSelectList = planosContas.Select(pc => new SelectListItem
        {
            Value = pc.Id.ToString(),
            Text = pc.Descricao,
            Selected = pc.Id == id
        }).ToList();
        return planosContaSelectList;
    }
}