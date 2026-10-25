using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEscolar.Models;

public class MaestrosController : Controller
{
    private readonly GestionEscolarContext _context;

    public MaestrosController(GestionEscolarContext context)
    {
        _context = context;
    }

    // GET: MAESTROS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Maestro.ToListAsync());
    }

    // GET: MAESTROS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var maestro = await _context.Maestro
            .FirstOrDefaultAsync(m => m.Id == id);
        if (maestro == null)
        {
            return NotFound();
        }

        return View(maestro);
    }

    // GET: MAESTROS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MAESTROS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Especialidad,Email")] Maestro maestro)
    {
        if (ModelState.IsValid)
        {
            _context.Add(maestro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(maestro);
    }

    // GET: MAESTROS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var maestro = await _context.Maestro.FindAsync(id);
        if (maestro == null)
        {
            return NotFound();
        }
        return View(maestro);
    }

    // POST: MAESTROS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Apellido,Especialidad,Email")] Maestro maestro)
    {
        if (id != maestro.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(maestro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaestroExists(maestro.Id))
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
        return View(maestro);
    }

    // GET: MAESTROS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var maestro = await _context.Maestro
            .FirstOrDefaultAsync(m => m.Id == id);
        if (maestro == null)
        {
            return NotFound();
        }

        return View(maestro);
    }

    // POST: MAESTROS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var maestro = await _context.Maestro.FindAsync(id);
        if (maestro != null)
        {
            _context.Maestro.Remove(maestro);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MaestroExists(int? id)
    {
        return _context.Maestro.Any(e => e.Id == id);
    }
}
