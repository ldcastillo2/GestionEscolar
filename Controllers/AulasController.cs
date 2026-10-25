
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEscolar.Models;

public class AulasController : Controller
{
    private readonly GestionEscolarContext _context;

    public AulasController(GestionEscolarContext context)
    {
        _context = context;
    }

    // GET: AULAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Aula.ToListAsync());
    }

    // GET: AULAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var aula = await _context.Aula
            .FirstOrDefaultAsync(m => m.Id == id);
        if (aula == null)
        {
            return NotFound();
        }

        return View(aula);
    }

    // GET: AULAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: AULAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Capacidad,Descripcion,Tipo")] Aula aula)
    {
        if (ModelState.IsValid)
        {
            _context.Add(aula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(aula);
    }

    // GET: AULAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var aula = await _context.Aula.FindAsync(id);
        if (aula == null)
        {
            return NotFound();
        }
        return View(aula);
    }

    // POST: AULAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Capacidad,Descripcion,Tipo")] Aula aula)
    {
        if (id != aula.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(aula);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AulaExists(aula.Id))
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
        return View(aula);
    }

    // GET: AULAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var aula = await _context.Aula
            .FirstOrDefaultAsync(m => m.Id == id);
        if (aula == null)
        {
            return NotFound();
        }

        return View(aula);
    }

    // POST: AULAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var aula = await _context.Aula.FindAsync(id);
        if (aula != null)
        {
            _context.Aula.Remove(aula);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AulaExists(int? id)
    {
        return _context.Aula.Any(e => e.Id == id);
    }
}
