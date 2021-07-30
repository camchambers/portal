using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using adv_portal.Data;
using adv_portal.Models;
using Microsoft.AspNetCore.Authorization;

namespace adv_portal.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Applications
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
