using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDomo.DataAccess.Repository.IRepository;
using TeaTimeDomo.Models;
using TeaTimeDomo.Models.ViewModels;

namespace TeaTimeDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }

        }


            [HttpPost]

            public IActionResult Upsert(ProductVM productVM, IFormFile? file)
            {

                if (ModelState.IsValid)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                    _unitOfWork.Save();
                    TempData["success"] = "產品新增成功!";
                    return RedirectToAction("Index");
                }
                else
                {
                    productVM.CategoryList =
                        _unitOfWork.Category.GetAll().Select(u => new
                        SelectListItem
                        {
                            Text = u.Name,
                            Value = u.Id.ToString()
                        });
                    return View(productVM);
                }
            }
        




        /*public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }

            return View(ProductFromDb);
        }



        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "類別更新成功!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product ProductFromDb = _unitOfWork.Product.Get(u => u.Id ==id);
            if (ProductFromDb == null) 
            { 
                return NotFound();
            }

            return View(ProductFromDb);
        }
        */

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "類別刪除成功!";
            return RedirectToAction("Index");
        }
        private readonly ApplicationDbContext _db;




    }



}
       