using GestionRecursosHumanos2.Data;
using GestionRecursosHumanos2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionRecursosHumanos2.Pages.Departamento
{
    public class EditModel : PageModel
    {
        private readonly GestionRecursosContext _context;

        public EditModel(GestionRecursosContext context)
        {
            this._context = context;
        }
        [BindProperty]
        public Departamentos Departamento { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento.FirstOrDefaultAsync(m =>
                m.IdDepartamento == id);
            if (departamento == null)
            {
                return NotFound();
            }
            Departamento = departamento;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Departamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(Departamento.IdDepartamento))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        public bool DepartamentoExists(int id)
        {
            return (_context.Departamento?.Any(e => e.IdDepartamento == id)).GetValueOrDefault();
        }

    }
}
