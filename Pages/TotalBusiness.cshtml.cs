using System.Collections.Generic;
using System.Linq;
using ImobSystem.Data;
using ImobSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImobSystem.Pages
{
    public class TotalBusinessModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TotalBusinessModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Client> Clients { get; set; } // Lista de serviços de clientes
        public List<ClientFase> ClientFases { get; set; } // Lista de fases de atendimento
        public List<Proposal> Proposals { get; set; } 
        public List<House> Houses { get; set; } 
        public List<Formalization> Formalizations { get; set; } 
        public IActionResult OnGet()
        {
            // Atualiza a lista de serviços de clientes puxando do banco de dados
            Clients = _context.Clients.ToList();
            ClientFases = _context.ClientFases.ToList(); 
            Proposals = _context.Proposals.ToList();
            Houses = _context.Houses.ToList();
            Formalizations = _context.Formalizations.ToList();
            return Page();
        }
    }
}
