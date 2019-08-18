using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.Areas.Admin.Data;
using Model;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CoffeeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InfoesController : Controller
    {
        private readonly CoffeeContext _context;
        private readonly IHostingEnvironment _environment;
        public InfoesController(CoffeeContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/Infoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Infos.ToListAsync());
        }

        // GET: Admin/Infoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Infos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        // GET: Admin/Infoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Infoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ImagePath")] Info info)
        //{
        //    if (ModelState.IsValid)
        //    {
              
        //        string rootPath = _environment.WebRootPath;
        //        string fileName = info.ImagePath;
        //        var file = System.IO.Path.Combine(rootPath, "wwwroot\\User\\images" + fileName);


        //        //using (var stream = new FileStream(filePath, FileMode.Create))
        //        //{
        //        //    await vm.Avatar.CopyToAsync(stream);
        //        //}

        //        Info user = new Info
        //        {                 
        //            ImagePath = vm.Avatar.FileName
        //        };
        //        _context.Add(info);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(info);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post([FromForm]UserVM vm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var filePath = Path.Combine(_environment.ContentRootPath, @"Uploads", vm.Avatar.FileName);

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await vm.Avatar.CopyToAsync(stream);
        //    }

        //    User user = new User
        //    {
        //        Name = vm.Name,
        //        Avatar = vm.Avatar.FileName
        //    };

        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.Id }, user);
        //}
        // GET: Admin/Infoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Infos.FindAsync(id);
            if (info == null)
            {
                return NotFound();
            }
            return View(info);
        }

        // POST: Admin/Infoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImagePath")] Info info)
        {
            if (id != info.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(info);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoExists(info.Id))
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
            return View(info);
        }

        // GET: Admin/Infoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Infos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        // POST: Admin/Infoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var info = await _context.Infos.FindAsync(id);
            _context.Infos.Remove(info);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoExists(int id)
        {
            return _context.Infos.Any(e => e.Id == id);
        }
    }
}
