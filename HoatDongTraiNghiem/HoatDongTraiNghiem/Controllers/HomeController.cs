﻿using HoatDongTraiNghiem.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoatDongTraiNghiem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return RedirectToRoute("login");
        }

        
    }
}