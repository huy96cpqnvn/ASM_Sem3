﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeShop.Models;
using CoffeeShop.Models.ViewModels;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;

        public int PageSize = 4;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(string category, int productPage = 1)
            => View(new ProductListViewModel
                    {
                        Products = repository.Products
                        .Where(p => category == null || p.Category == category)
                        .OrderBy(p => p.ProductId)
                        .Skip((productPage - 1) * PageSize)
                        .Take(PageSize),
                        PageInfo = new PageInfo
                        {
                            CurrentPage = productPage,
                            ItemsPerPage = PageSize,
                            TotalItems = category == null ? 
                            repository.Products.Count() : 
                            repository.Products.Where(e => e.Category == category).Count()
                        },
                        CurrentCategory = category
                    }
                );
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
