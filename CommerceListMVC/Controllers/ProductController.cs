using Business.Abstract;
using DataAccess.Concreate;
using Entities.Concreate.ViewModels;
using Entitites.Concrete;
using Entitites.Concrete.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CommerceListMVC.Controllers
{
    [Authorize(Roles="Admin,User")]
    public class ProductController :BaseController
    {

      
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        
        private readonly IProductCommerceListService _productCommerceListService;
        CommerceListDbContext _context;
        public ProductController(IProductService productService,ICategoryService categoryService,
            IProductCommerceListService productCommerceListService,
            CommerceListDbContext context)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productCommerceListService = productCommerceListService;
            _context = context;
        }

      
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult List(string id)
        {
            List<ProductListViewModel> products = _productService.GetAll().Select(p=>new ProductListViewModel
            {
                ProductName = p.ProductName,
                PhotoUrl= p.PhotoUrl,
            }).ToList();
           if(!String.IsNullOrEmpty(id))
            {
                List<ProductListViewModel> searchedProduct  =
                    _productService.GetAll().Where(p=>p.ProductName.Contains(id))
                    .Select(p=>new ProductListViewModel
                    {
                        ProductName = p.ProductName,
                        PhotoUrl= p.PhotoUrl,
                    }).ToList() ;
                if (User.IsInRole("Admin"))
                {
                    return View("AdminList",searchedProduct);
                }
                return View(searchedProduct);
            }
            if (User.IsInRole("Admin"))
            {
                return View("AdminList", products);
            }
            return View(products);
           
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Add()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach(var item in _categoryService.GetAll())
            {
                selectList.Add(new SelectListItem()
                {
                    Text = item.CategoryName,
                    Value = item.CategoryID.ToString(),
                });
                ViewBag.Categories= selectList;
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(ProductCreateViewModel viewModel) {

            
            if(!ModelState.IsValid)
            {
                return View();

            }
          
            Product product = new Product();
            product.ProductName = viewModel.ProductName;
            product.PhotoUrl = viewModel.PhotoUrl;
            product.CategoryID = viewModel.Category;
            if (_productService.GetProduct(viewModel.ProductName) == null)
            {
                _productService.Add(product);
            }
            
            return View(viewModel);

        }
        [Authorize(Roles = "Admin")]
        public IActionResult ProductControl(string id)
        {
            List<ProductListDetailedViewModel> products = _productService.GetAll().Select(p => new ProductListDetailedViewModel
            {
                ProductName = p.ProductName,
                PhotoUrl= p.PhotoUrl,
                ProductId = p.ProductID
            }).ToList();
            if (!String.IsNullOrEmpty(id))
            {
                List<ProductListDetailedViewModel> searchedProduct =
                    _productService.GetAll().Where(p => p.ProductName.Contains(id))
                    .Select(p => new ProductListDetailedViewModel
                    {
                        ProductId = p.ProductID,
                        ProductName = p.ProductName,
                        PhotoUrl = p.PhotoUrl,
                    }).ToList();
                return View(searchedProduct);
            }
            return View(products);
           
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Update(int ProductID)

        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var item in _categoryService.GetAll())
            {
                selectList.Add(new SelectListItem()
                {
                    Text = item.CategoryName,
                    Value = item.CategoryID.ToString(),
                });
                ViewBag.Categories = selectList;
            }
            var data = _productService.GetAll().Where(x=>x.ProductID== ProductID).FirstOrDefault();
            return View(data);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
    
        public IActionResult Update(int ProductID, Product product)
        {
           
            var data2 = _productService.GetAll().Where(x=>x.ProductID == ProductID).FirstOrDefault();
            data2.PhotoUrl = product.PhotoUrl;
            data2.ProductName = product.ProductName;
            data2.CategoryID = product.CategoryID;
            data2.ProductID= product.ProductID;
            _productService.Update(data2);
            
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int ProductID)
        {
            var data = _productService.GetAll().Where(x => x.ProductID == ProductID).FirstOrDefault();
            return View(data);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            
            var productId = product.ProductID;
            var product2 = _productService.GetAll().Where(x=>x.ProductID==productId).FirstOrDefault();
            _productService.Delete(product2);
            return RedirectToAction("ProductControl", "Product");
        }
       
        public IActionResult AddToCommerceList(string ProductName)
            
        {
            if (IsExistInSession("activeList"))
            {
                var commerceListId = GetValueFromSession<CommerceList>("activeList").CommerceListID;
                var ProductId = _productService.GetProduct(ProductName).ProductID;



                var ProductCommerceList = new ProductCommerceList
                {
                    CommerceListID = commerceListId,
                    ProductID = ProductId,
                };

                if (_productCommerceListService.GetByCommerceListId(commerceListId).Where(x => x.ProductID == ProductId).Any())
                {
                    ViewBag.Message = "Ürün zaten var";
                    return View();
                }

                _productCommerceListService.Add(ProductCommerceList);



                ViewBag.Message = "Ürün başarıyla listeye eklendi";
                return View();
            }
            ViewBag.Error = "Aktif bir listeniz yok";
            return View("Error");
  

          
        }
    }
}
