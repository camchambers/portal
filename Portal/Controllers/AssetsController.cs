using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using portal.Data;
using portal.Models;
using Microsoft.AspNetCore.Identity;

namespace portal.Controllers
{

    public class AssetsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public AssetsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Assets
        public async Task<IActionResult> Index()
        {
            ViewData["assetTypeList"] = await _context.AssetType.ToDictionaryAsync(t => t.Id.ToString(), t => t.Name);
            ViewData["userList"] =  await _userManager.Users.ToDictionaryAsync(t => t.Id, t => t.UserName);

            return View(await _context.Asset.ToListAsync());
        }

        // A convenience route for workstations 
        public async Task<IActionResult> Workstations()
        {
            ViewData["assetTypeList"] = await _context.AssetType.ToDictionaryAsync(t => t.Id.ToString(), t => t.Name);
            ViewData["userList"] = await _userManager.Users.ToDictionaryAsync(t => t.Id, t => t.UserName);
            return View("Index", await _context.Asset.Where(t => t.AssetType == "1").ToListAsync());
        }

        [Route("rdp")]
        public async Task<IActionResult> RDP()
        {
            return View("~/Views/Assets/Rdp.cshtml", await _context.Asset.Where(t => t.AssetType == "1").ToListAsync());
        }



        // GET: Assets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // GET: Assets/Create
        public async Task<IActionResult> CreateAsync()
        {
            var userSelectList = await _userManager.Users.ToDictionaryAsync(t => t.Id, t => t.UserName);
            ViewData["userList"] = new SelectList(userSelectList, "Key", "Value");

            var assetTypes = await _context.AssetType.ToDictionaryAsync(t => t.Id, t => t.Name);
            ViewData["assetTypes"] = new SelectList(assetTypes, "Key", "Value");

            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AssetType,Make,Model,Serial,Memory,Storage,Comment,UserID")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asset);
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSelectList = await _userManager.Users.ToDictionaryAsync(t => t.Id, t => t.UserName);
            ViewData["userList"] = new SelectList(userSelectList, "Key", "Value");

            var assetTypes = await _context.AssetType.ToDictionaryAsync(t => t.Id, t => t.Name);
            ViewData["assetTypes"] = new SelectList(assetTypes, "Key", "Value");

            var asset = await _context.Asset.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AssetType,Make,Model,Serial,Memory,Storage,Comment,UserID")] Asset asset)
        {
            if (id != asset.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetExists(asset.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(asset);
        }

        // GET: Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asset = await _context.Asset.FindAsync(id);
            _context.Asset.Remove(asset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetExists(int id)
        {
            return _context.Asset.Any(e => e.Id == id);
        }
    }
}
