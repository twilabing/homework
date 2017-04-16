﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace birthdaycard.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult CardForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CardForm(Models.cardInfo cardInfo)
        {

            if (ModelState.IsValid)
            {
                return View("Card", cardInfo);
            }
            else {
                return View();
            }
            
        }

    }
}