using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using adv_portal.Data;
using adv_portal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace adv_portal.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public SearchController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index(string keyword)
        {          
            if (String.IsNullOrEmpty(keyword)) {
                return View();
            }
            

            var applications = from m in _context.Application
                         select m;
            
            applications = applications.Where(s => s.Name.ToLower().Contains(keyword));


            var users = from u in _context.Users.Where(p => p.UserName.ToLower().Contains(keyword))
                        select u;


            //users = users.Where(n => n.Firstname.ToLower().Contains(keyword) || n.Lastname.Contains(keyword));


            var assets = from w in _context.Asset
                               select w;

            assets = assets.Where(n => n.Name.ToLower().Contains(keyword));

            var searchResult = new Search() {
                ApplicationSearch = await applications.ToListAsync(),
                UserSearch = await users.ToListAsync(),
                AssetSearch = await assets.ToListAsync(),
            };

            return View(searchResult);
        }
    }
}