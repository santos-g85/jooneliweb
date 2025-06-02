﻿using jooneliweb.Models;
using jooneliweb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace jooneliweb.Controllers
{
    public class NewsController : Controller
    {

        private readonly ILogger<NewsController> _logger;
        private readonly IMongoCollection<NewsModel> _newsCollection;
        //private readonly GridFSBucket _gridBucket;
       
        public NewsController(ILogger<NewsController> logger, MongoDbContext mongoDbContext)
        {
            _logger = logger;
            _newsCollection = mongoDbContext.NewsCollection;
           // _gridBucket = gridBucket;
        }

        // GET: NewsController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
