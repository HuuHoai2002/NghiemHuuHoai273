using Microsoft.AspNetCore.Mvc;
using NghiemHuuHoai273.Models;
namespace NghiemHuuHoai273.Controllers;

public class CompanyNHH273Controller : Controller
{

  private readonly ApplicationDbContext _context;
  public CompanyNHH273Controller(ApplicationDbContext context)
  {
    _context = context;
  }
  public async Task<IActionResult> Index()
  {
    var model = await _context.Companys.ToListAsync();
    return View(model);
  }
  public IActionResult Create()
  {
    return View();
  }
  [HttpPost]
  public async Task<IActionResult> Create(CompanyNHH273 company)
  {
    if (ModelState.IsValid)
    {
      _context.Companys.Add(company);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
    return View(company);
  }


  [HttpGet]
  public async Task<IActionResult> Edit(string id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var company = await _context.Companys.FindAsync(id);
    if (company == null)
    {
      return NotFound();
    }
    return View(company);
  }
  [HttpPost]
  public async Task<IActionResult> Edit(int id, [Bind("CompanyId, CompanyName")] CompanyNHH273 company)
  {
    if (id != company.CompanyId)
    {
      return NotFound();
    }
    if (ModelState.IsValid)
    {
      try
      {
        _context.Companys.Update(company);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PersonExists(company.CompanyId.ToString()))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
    }
    return View(company);
  }
  public async Task<IActionResult> Delete(string id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var company = await _context.Companys.FirstOrDefaultAsync(p => p.CompanyId == id);
    if (company == null)
    {
      return NotFound();
    }

    return View(company);
  }
  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
    var company = await _context.Companys.FindAsync(id);
    if (company != null)
    {
      _context.Companys.Remove(company);
      await _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(Index));
  }

  private bool CompanyExists(int id) => _context.Companys.Any(e => e.CompanyID == id);
}