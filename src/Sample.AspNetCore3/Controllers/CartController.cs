﻿namespace Sample.AspNetCore3.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Sample.AspNetCore3.Data;
    using Sample.AspNetCore3.Models;
    using SwedbankPay.Sdk;
    using SwedbankPay.Sdk.PaymentOrders;

    public class CartController : Controller
    {
        private readonly ILogger<CartController> logger;
        private StoreDbContext storesContext;
        private Cart cartService;

        public CartController(ILogger<CartController> logger, StoreDbContext storesContext, Cart cartService)
        {
            this.logger = logger;
            this.storesContext = storesContext;
            this.cartService = cartService;
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            
            var productList = await this.storesContext.Products.ToListAsync();
            var product = productList.FirstOrDefault(p => p.ProductId == id);
            this.cartService.AddItem(product, 1);

            return RedirectToAction("Index", controllerName:"Products");
        }

        public IActionResult RemoveFromCart(int id)
        {
            
            var line = this.cartService.CartLines.FirstOrDefault(i => i.Product.ProductId == id);
            if (line != null)
            {
                this.cartService.RemoveItem(line.Product, line.Quantity);
            }
           
            return RedirectToAction("Index", controllerName:"Products");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int id, int quantity)
        {

            var line = this.cartService.CartLines.FirstOrDefault(i => i.Product.ProductId == id);
            if (line != null)
            {
                line.Quantity = quantity;
                this.cartService.Update();
            }
            
            return RedirectToAction("Index", controllerName:"Products");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cart cart)
        {

            if (ModelState.IsValid)
            {
                //cart.Product = _context.Products.First();

                return RedirectToAction("Index", "Payment", cart);
            }

            return View(cart);
        }


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
