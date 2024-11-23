using GestionRecursosHumanos2.Data;
using GestionRecursosHumanos2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionRecursosHumanos2.Pages.Cargo
{
    public class IndexModel : PageModel
    {
        private readonly GestionRecursosContext _context;

        public IndexModel(GestionRecursosContext context)
        {
            _context = context;
        }

        public IList<Cargos> cargo { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Cargo != null)
            {
                cargo = await _context.Cargo.ToListAsync();
            }
        }
    }
}
