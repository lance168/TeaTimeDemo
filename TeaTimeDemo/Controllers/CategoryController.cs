﻿using Microsoft.AspNetCore.Mvc;
using TeaTimeDemo.DataAcess.Data;
using TeaTimeDemo.DataAcess.Repository.IRepository;
using TeaTimeDemo.Models;

namespace TeaTimeDemo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();

            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "類別名稱不能與顯示順序一樣!");
            }
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["Success"] = "類別新增成功!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categortFromDb = _categoryRepo.Get(u=>u.Id==id);

            if (categortFromDb == null)
            {
                return NotFound();
            }

            return View(categortFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
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
            Category? categortFromDb = _categoryRepo.Get(u=>u.Id==id);

            if (categortFromDb == null)
            {
                return NotFound();
            }

            return View(categortFromDb);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            //TODO: Confirm: 不知道為什麼物能直接傳物件進來，但是Edit就可以???
            //直接傳obj.Name、obj.DisplayOrder的資料會是空的
            Category? obj = _categoryRepo.Get(u=>u.Id==id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
