using DoAnThucTap.Areas.Admin.Models;
using DoAnThucTap.Constants;
using DoAnThucTap.Models;
using DoAnThucTap.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace DoAnThucTap.Areas.Admin.Controllers
{
    public class BannersController : Controller
    {
        private readonly ADbContext _context;
        private readonly IStorageService _storageService;

        public BannersController(ADbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        // GET: Banners
        public async Task<IActionResult> Index()
        {
            return _context.banners != null ?
                        View(await _context.banners.ToListAsync()) :
                        Problem("Entity set 'ADbContext.banners'  is null.");
        }

        // GET: Banners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.banners == null)
            {
                return NotFound();
            }

            var banner = await _context.banners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // GET: Banners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Url,active")] Banner banner, IFormFile file)
        {
            if (file != null)
            {
                var filePath = UploadPathConstant.BannerPath;
                var savedFileName = await _storageService.SaveFileAsync(file, filePath);
                banner.Url = savedFileName;
            }
            if (ModelState.IsValid)
            {
                _context.Add(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(banner);
            }
        }


        // GET: Banners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.banners == null)
            {
                return NotFound();
            }

            var banner = await _context.banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        // POST: Banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url,active")] Banner banner)
        {
            if (id != banner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BannerExists(banner.Id))
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
            return View(banner);
        }

        // GET: Banners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.banners == null)
            {
                return NotFound();
            }

            var banner = await _context.banners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // POST: Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.banners == null)
            {
                return Problem("Entity set 'ADbContext.banners'  is null.");
            }
            var banner = await _context.banners.FindAsync(id);
            if (banner != null)
            {
                _context.banners.Remove(banner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerExists(int id)
        {
            return (_context.banners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
