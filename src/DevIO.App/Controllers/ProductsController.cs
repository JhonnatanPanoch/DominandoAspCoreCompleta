using AutoMapper;
using DevIO.App.ViewModels;
using DevIO.Bussiness.Interfaces.Repository;
using DevIO.Bussiness.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DevIO.App.Controllers
{
    [Route("admin-produtos")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public ProductsController(
            IProductRepository productRepository,
            ISupplierRepository supplierRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        [Route("listar")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductViewModel> productsWithSuppliers = _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductsSupplier());
            return View(productsWithSuppliers);
        }

        [Route("detalhes/{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            ProductViewModel productViewModel = await GetProduct(id);
            if (productViewModel == null)
                return NotFound();

            return View(productViewModel);
        }

        [Route("novo")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ProductViewModel productViewModel = await PopulateSupplier(new ProductViewModel());
            return View(productViewModel);
        }

        [Route("novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            productViewModel = await PopulateSupplier(productViewModel);

            string prefix = Guid.NewGuid() + "_";
            if (!await UploadFile(productViewModel.ImageUpload, prefix))
            {
                return View(productViewModel);
            }

            productViewModel.Image = prefix + productViewModel.ImageUpload.FileName;
            productViewModel.CreateDate = DateTime.Now;

            if (!ModelState.IsValid)
                return View(productViewModel);

            await _productRepository.Insert(_mapper.Map<Product>(productViewModel));

            return RedirectToAction(nameof(Index));
        }

        [Route("alterar/{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ProductViewModel productViewModel = await GetProduct(id);
            if (productViewModel == null)
                return NotFound();

            return View(productViewModel);
        }

        [Route("alterar/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
                return NotFound();

            var dbProduct = await GetProduct(id);
            productViewModel.Supplier = dbProduct.Supplier;
            productViewModel.Image = dbProduct.Image;

            if (!ModelState.IsValid)
                return View(productViewModel);

            if (productViewModel.ImageUpload != null)
            {
                string prefix = Guid.NewGuid() + "_";
                if (!await UploadFile(productViewModel.ImageUpload, prefix))
                {
                    return View(productViewModel);
                }

                dbProduct.Image = prefix + productViewModel.ImageUpload.FileName;
            }

            dbProduct.Name = productViewModel.Name;
            dbProduct.Description = productViewModel.Description;
            dbProduct.Value = productViewModel.Value;
            dbProduct.Active = productViewModel.Active;

            await _productRepository.Update(_mapper.Map<Product>(dbProduct));

            return RedirectToAction(nameof(Index));
        }

        [Route("apagar/{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var productViewModel = await GetProduct(id);
            if (productViewModel == null)
                return NotFound();

            return View(productViewModel);
        }

        [Route("apagar/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productViewModel = await GetProduct(id);
            if (productViewModel == null)
                return NotFound();

            await _productRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProductViewModel> GetProduct(Guid id)
        {
            ProductViewModel product = _mapper.Map<ProductViewModel>(await _productRepository.GetProductSupplier(id));
            product.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.List());

            return product;
        }

        private async Task<ProductViewModel> PopulateSupplier(ProductViewModel productViewModel)
        {
            productViewModel.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.List());
            return productViewModel;
        }

        private async Task<bool> UploadFile(IFormFile file, string prefix)
        {
            if (file.Length <= 0)
                return false;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", prefix + file.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Imagem com o mesmo nome já cadastrada!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return true;
        }
    }
}
