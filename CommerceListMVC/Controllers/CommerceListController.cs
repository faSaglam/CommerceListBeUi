using Business.Abstract;
using Business.Concreate;
using CommerceListMVC.Extentions;
using DataAccess.Concreate;
using Entities.Concreate.ViewModels;
using Entitites.Concrete;
using Entitites.Concrete.ViewModels;
using MessagePack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace CommerceListMVC.Controllers
{
    [Authorize(Roles = "User")]
    public class CommerceListController : BaseController
    {

        private readonly ICommerceListService _commerceListService;
        private readonly UserManager<User> _userManager;
        private readonly IProductService _productService;
        private readonly IProductCommerceListService _productCommerceListService;
        CommerceListDbContext _context;

        public CommerceListController(ICommerceListService commerceListService, UserManager<User> userManager,
            IProductService productService,CommerceListDbContext context,
            IProductCommerceListService productCommerceListService)
        {
            _commerceListService = commerceListService;
            _userManager = userManager;
            _productService = productService;
            _context = context;
            _productCommerceListService = productCommerceListService;
        }

        public IActionResult List(CommerceListViewModel viewModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var commerceList = _commerceListService.GetByUserId(userId).Select(
                c => new CommerceListViewModel
                {
                    CommerceListID = c.CommerceListID,
                    CommerceListName = c.CommerceListName,

                }).ToList();


            return View(commerceList);
        }
     
        public async Task<IActionResult> Create()
        {

            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> Create(CommerceListCreateViewModel viewModel)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {

                return View();

            }
            var commerceList = new CommerceList();
            commerceList.Id = userId;
            commerceList.CommerceListName = viewModel.CommerceListName;
            ViewBag.Message = "Liste oluşturuldu";
           
            _commerceListService.Add(commerceList);
            return RedirectToAction("List");
        }
        public IActionResult Delete(int CommerceListId)
        {
            var cl = _commerceListService.GetById(CommerceListId);
            if(cl.IsOnMarket == true)
            {
                ViewBag.Error = "Şuan bu liste alış-verişte olduğu için müdahale edemezsiniz.";
                return View("Error");
            }
            return View(cl);
        }
        [HttpPost]
        public IActionResult Delete(CommerceList commerceList)
        {
            var clId = commerceList.CommerceListID;
            var cl = _commerceListService.GetById(clId);
            _commerceListService.Delete(cl);
            
            return RedirectToAction("List");
        }
        
        public IActionResult CurrentList(int CommerceListId)
        {


            var currentList = _commerceListService.GetById(CommerceListId);
            SetValueToSession<CommerceList>("activeList", currentList);
            
            return View(currentList);
        }

      
        public IActionResult Detail(int CommerceListId)
        {
            
            if( _commerceListService.GetById(CommerceListId).IsOnMarket==true)
            {
                ViewBag.Error = "Şuan bu liste alış-verişte olduğu için müdahale edemezsiniz.";
                //ViewData["Controller"] = "CommerceList";
                //ViewData["Action"] = "List";
                return View("Error");
            }

            var product = _context.CommerceLists.Include(x => x.Products).Where(x => x.CommerceListID == CommerceListId)
                .SelectMany(x => x.Products, (x, y) => new CommerceListDetailViewModel
                {
                    CommerceListId = x.CommerceListID,
                    PhotoUrl = y.Product.PhotoUrl,
                    ProductName = y.Product.ProductName,
                    Description = y.Description,
                    ProductId = y.Product.ProductID

                }).ToList();
          

        
            return View(product);

        }
        
        public IActionResult DetailDelete(int CommerceListID , int ProductID)
        {
            var productInCl = _productCommerceListService.GetAll().Where(x=>x.CommerceListID ==CommerceListID).FirstOrDefault(x=>x.ProductID == ProductID);
            return View(productInCl);
        }
       
        [HttpPost]
        public IActionResult DetailDelete(ProductCommerceList productCommerceList)
        {
            var productId = productCommerceList.ProductID;
            var CommerceListId = productCommerceList.CommerceListID;
            var removeItem = _productCommerceListService.GetAll().Where(x=>x.CommerceListID == CommerceListId).FirstOrDefault(x=>x.ProductID ==productId);
            _productCommerceListService.Delete(removeItem);


            var list = _context.CommerceLists.Include(x => x.Products).Where(x => x.CommerceListID == CommerceListId)
            .SelectMany(x => x.Products, (x, y) => new CommerceListDetailViewModel
            {
                CommerceListId = x.CommerceListID,
                PhotoUrl = y.Product.PhotoUrl,
                ProductName = y.Product.ProductName,
                Description = y.Description,
                ProductId = y.Product.ProductID

            }).ToList();
            return View("Detail", list);
        }

        
        public IActionResult AddDescription(int CommerceListId, int ProductId)
        {

            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach(var item in _context.CommerceLists.Include(x=>x.Products).Where(x=>x.CommerceListID== CommerceListId).SelectMany(x=>x.Products,
                (x, y) => new CommerceListDetailViewModel
                {
                    CommerceListId= x.CommerceListID,
                    ProductName = y.Product.ProductName,
                    ProductId = y.Product.ProductID,
                }))
            {
                selectList.Add(new SelectListItem
                {
                    Text = item.ProductName,
                    Value = item.ProductId.ToString()
                }) ;
                ViewBag.Products = selectList;
            }
           
         
            return View();

        }
       
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddDescription(  ProductCommerceList model)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            ProductCommerceList data = new ProductCommerceList();
            
            data.CommerceListID = model.CommerceListID;
            data.ProductID = model.ProductID;
            data.Description = model.Description;
            if(_context.ProductCommerceList
                .Where(x=>x.CommerceListID == model.CommerceListID)
                .Where(x=>x.ProductID==model.ProductID)
                .Any(x=>x.Description == model.Description))
            {
                ViewBag.Error = "Aynı açıklama zaten var!";
                
            }
            _productCommerceListService.Update(data);
            //int CommerceListId = model.CommerceListID;

            return RedirectToAction("Detail", new { CommerceListId = model.CommerceListID} );
        }
       
        public IActionResult GoToMarket(int CommerceListId)
        {
       
            List<CommerceListDetailViewModel> model= _context.CommerceLists.Include(x=>x.Products)
                .Where(x=>x.CommerceListID== CommerceListId)
                .SelectMany(x=>x.Products , (x, y) =>new CommerceListDetailViewModel
                {
                    PhotoUrl = y.Product.PhotoUrl,
                    ProductName = y.Product.ProductName,
                    Description = y.Description,
                    CommerceListId= x.CommerceListID
                }).ToList();
            //ViewData["Id"] = CommerceListId;
            ViewBag.Products = model;
            
            var cl = _commerceListService.GetById(CommerceListId);
            if (model.Count == 0)
            {
                ViewBag.Error = "Listede herhangi bir ürün yok.";
                return View("Error");
            }

            return View(cl);
        }
       
        [HttpPost]
        public IActionResult GoToMarket(CommerceList model , int CommerceListId)
        {
            //if (!ModelState.IsValid) { return View(); }
            var data = _commerceListService.GetById(CommerceListId);
         
            data.IsOnMarket = true;
            _commerceListService.Update(data);
            ClearSession("activeList");
            return RedirectToAction("MarketList","CommerceList");

        }
        
        public IActionResult MarketList(CommerceListViewModel viewModeL)

        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
          List<CommerceListViewModel> MarketList = _commerceListService.GetAll().Where(x => x.Id == userId).Where(x => x.IsOnMarket == true)
                .Select(x => new CommerceListViewModel {
                 CommerceListID= x.CommerceListID,
                 CommerceListName= x.CommerceListName,
                
                }).ToList();

            List<SelectListItem> selecList = new List<SelectListItem>();
            foreach(var item in MarketList)
            {
                selecList.Add(new SelectListItem()
                {
                    Text = item.CommerceListName,
                    Value = item.CommerceListID.ToString()
                });
            }
            ViewBag.MarketList = selecList;
            

            return View(MarketList); 
        }
        
        public IActionResult MarketListDetail(int CommerceListId)
        {
            List<MarketListDetailViewModel> product = _context.CommerceLists.Include(x => x.Products).Where(x => x.CommerceListID == CommerceListId)
                 .SelectMany(x => x.Products, (x, y) => new MarketListDetailViewModel
                 {
                     CommerceListId = x.CommerceListID,
                     PhotoUrl = y.Product.PhotoUrl,
                     ProductName = y.Product.ProductName,
                     Description = y.Description,
                     ProductId = y.Product.ProductID,
                     IsBought = y.IsBought

                 }).ToList();
            return View(product);
         
        }
        
        [HttpPost]
        public IActionResult Bought(
            List<MarketListDetailViewModel> model)
        {
          
          
            ProductCommerceList product2 = new ProductCommerceList();
           
                  foreach (var item in model)
                 {
                  product2.CommerceListID = item.CommerceListId;
                   product2.ProductID = item.ProductId;
                  product2.IsBought = item.IsBought;
                    product2.Description = item.Description;
  
                  _productCommerceListService.Update(product2);
                   if(item.IsBought == true)
                    {
                    _productCommerceListService.Delete(product2);   
                    }
                    var cl = _commerceListService.GetById(item.CommerceListId);
                     cl.IsOnMarket = false;
                     _commerceListService.Update(cl);
                  }
           
            return RedirectToAction("MarketList", "CommerceList");  
        }
    }
}
