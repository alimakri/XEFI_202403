﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class PriveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
