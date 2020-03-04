using CandyStore.Models;
using CandyStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Controllers
{
    public class CandyController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CandyController(ICandyRepository candyRepository, ICategoryRepository categoryRepository)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            ////ViewBag.CurrentCategory = "Bestsellers";
            ////return View(_candyRepository.GetAllCandy);

            //var candyListViewModel = new CandyListViewModel();
            //candyListViewModel.Candies = _candyRepository.GetAllCandy;
            //candyListViewModel.CurrentCategory = "BestSellers";

            //return View(candyListViewModel);

            IEnumerable<Candy> candies;
            string currentCategory;

            if(string.IsNullOrEmpty(category))
            {
                candies = _candyRepository.GetAllCandy
                    .OrderBy(c => c.CandyId);

                currentCategory = "All Candy";
            }
            else
            {
                candies = _candyRepository.GetAllCandy.Where(c =>
                    c.Category.CategoryName == category);

                currentCategory = _categoryRepository.GetAllCategories
                    .FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            var candyListViewModel = new CandyListViewModel
            {
                Candies = candies,
                CurrentCategory = currentCategory
            };

            return View(candyListViewModel);

        }

        public IActionResult Details(int id)
        {
            var candy = _candyRepository.GetCandyById(id);

            if (candy == null)
                return NotFound();

            return View(candy);
        }
    }
}
