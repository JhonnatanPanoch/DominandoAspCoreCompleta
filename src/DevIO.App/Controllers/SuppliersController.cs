using AutoMapper;
using DevIO.App.ViewModels;
using DevIO.Bussiness.Interfaces.Repository;
using DevIO.Bussiness.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.App.Controllers
{
    public class SuppliersController : BaseController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public SuppliersController(
            ISupplierRepository supplierRepository, 
            IMapper mapper,
            IAddressRepository addressRepository)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.List()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);
            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
                return View(supplierViewModel);

            Supplier supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.Insert(supplier);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var supplierViewModel = await GetSupplierProductsAdress(id);
            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(supplierViewModel);

            Supplier supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.Update(supplier);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);
            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);
            if (supplierViewModel == null)
                return NotFound();

            await _supplierRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAddress(Guid id)
        {
            SupplierViewModel supplier = await GetSupplierAddress(id);
            if (supplier == null)
                return NotFound();

            return PartialView("_UpdateAddress", supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAddress(SupplierViewModel supplierViewModel)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Document");

            if (!ModelState.IsValid)
                return PartialView("_UpdateAddress", supplierViewModel);

            Address model = _mapper.Map<Address>(supplierViewModel.Address);
            await _addressRepository.Update(model);

            string url = Url.Action("GetAddress", "Suppliers", new { id = supplierViewModel.Address.SupplierId });

            return Json(new { success = true, url });
        }

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
