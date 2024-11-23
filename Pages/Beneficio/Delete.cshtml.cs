using GestionRecursosHumanos2.Data;
using GestionRecursosHumanos2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionRecursosHumanos2.Pages.Beneficio
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly GestionRecursosContext _context;

        public DeleteModel(GestionRecursosContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public Beneficios Beneficio { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Beneficio == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficio.FirstOrDefaultAsync(m => m.IdBeneficio == id);

            if (beneficio == null)
            {
                return NotFound();
            }
            else
            {
                Beneficio = beneficio;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Beneficio == null)
            {
                return NotFound();
            }
            var beneficio = await _context.Beneficio.FindAsync(id);

            if (beneficio != null)
            {
                Beneficio = beneficio;
                _context.Beneficio.Remove(Beneficio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        ///
    }
}
