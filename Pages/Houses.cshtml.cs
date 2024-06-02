using System.Collections.Generic;
using System.Linq; // Adicionado para usar o método ToList()
using ImobSystem.Data;
using ImobSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImobSystem.Pages
{
    public class HousesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public HousesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public House House { get; set; }
        [BindProperty]
        public Owner Owner { get; set; }
        public List<House> Houses { get; set; } // Lista de casas
        public List<Owner> Owners { get; set; } // Lista de Proprietários

        public IActionResult OnGet()
        {
            Houses = _context.Houses.ToList();
            Owners = _context.Owners.ToList();
            return Page();
        } 

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult OnPost()
        {
        if (!ModelState.IsValid)
            {
                Houses = _context.Houses.ToList();
                return Page();
            } 
            // Redireciona de volta para a página de adicionar casas
            return RedirectToPage("./Houses");
        }

        
        
    }
}
