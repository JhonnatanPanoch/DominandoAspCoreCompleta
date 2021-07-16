using AutoMapper;
using DevIO.App.Extensions;
using DevIO.App.ViewModels;
using DevIO.Bussiness.Interfaces;
using DevIO.Bussiness.Interfaces.Repository;
using DevIO.Bussiness.Interfaces.Service;
using DevIO.Bussiness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.App.Controllers
{
    [Authorize]
    [Route("admin-fornecedores")]
    public class SuppliersController : BaseController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(
            ISupplierRepository supplierRepository, 
            ISupplierService supplierService,
            IMapper mapper,
            INotificator notificator) : base(notificator)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _supplierService = supplierService;
        }

        [AllowAnonymous]
        [Route("lista")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.List()));
        }

        [AllowAnonymous]
        [Route("detalhes/{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);
            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        [ClaimsAuthorize("Fornecedor", "Adicionar")]
        [Route("novo")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Fornecedor", "Adicionar")]
        [Route("novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
                return View(supplierViewModel);

            Supplier supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierService.Insert(supplier);

            if (!IsValid())
                return View(supplierViewModel);

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Fornecedor", "Editar")]
        [Route("alterar/{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var supplierViewModel = await GetSupplierProductsAdress(id);
            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        [ClaimsAuthorize("Fornecedor", "Editar")]
        [Route("alterar/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id)
                return NotFound();

            var dbSupplier = await GetSupplierProductsAdress(id);
            supplierViewModel.Products = dbSupplier.Products;
            supplierViewModel.Address = dbSupplier.Address;

            if (!ModelState.IsValid)
                return View(supplierViewModel);

            Supplier supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierService.Update(supplier);

            if (!IsValid())
                return View(supplierViewModel);

            TempData["Sucesso"] = "Fornecedor alterado com sucesso.";

            return RedirectToAction(nameof(Index));

        }

        [ClaimsAuthorize("Fornecedor", "Excluir")]
        [Route("apagar/{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);
            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        [ClaimsAuthorize("Fornecedor", "Excluir")]
        [Route("apagar/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);
            if (supplierViewModel == null)
                return NotFound();

            await _supplierService.Delete(id);

            if (!IsValid())
                return View(supplierViewModel);

            TempData["Sucesso"] = "Fornecedor excluído com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Fornecedor", "Editar")]
        [Route("alterar-endereco/{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAddress(Guid id)
        {
            SupplierViewModel supplier = await GetSupplierAddress(id);
            if (supplier == null)
                return NotFound();


            return PartialView("_UpdateAddress", supplier);
        }

        [ClaimsAuthorize("Fornecedor", "Editar")]
        [Route("alterar-endereco/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAddress(SupplierViewModel supplierViewModel)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Document");

            if (!ModelState.IsValid)
                return PartialView("_UpdateAddress", supplierViewModel);

            Address model = _mapper.Map<Address>(supplierViewModel.Address);
            await _supplierService.UpdateAddress(model);

            string url = Url.Action("GetAddress", "Suppliers", new { id = supplierViewModel.Address.SupplierId });
           
            TempData["Sucesso"] = "Endereço alterado com sucesso.";
            ViewBag.Sucesso = "Endereço alterado com sucesso.";

            return Json(new { success = true, url });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAddress(Guid id)
        {
            SupplierViewModel supplier = await GetSupplierAddress(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return PartialView("_DetailsAdress", supplier);
        }

        private async Task<SupplierViewModel> GetSupplierProductsAdress(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierProductsAdress(id));
        }

        private async Task<SupplierViewModel> GetSupplierAddress(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierAdress(id));
        }
    }
}
