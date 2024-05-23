using System.Collections.Generic;
using System.Linq; // Adicionado para usar o método ToList()
using ImobSystem.Data;
using ImobSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImobSystem.Pages
{
    public class FormalizationModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public FormalizationModel (ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Proposal> Proposals { get; set; } // Lista de propostas
        public List<Formalization> Formalizations { get; set; } // Lista de propostas
        public List<Client> Clients { get; set; } // Lista de clientes

        public IActionResult OnGet()
        {
            // Atualiza a lista de serviços de clientes puxando do banco de dados
            Formalizations = _context.Formalizations.ToList();
            Proposals = _context.Proposals.ToList();
            Clients = _context.Clients.ToList(); // Atualiza a lista de clientes puxando do banco de dados
            return Page();
        }

    }
}
