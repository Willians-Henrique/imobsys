using System.Collections.Generic;
using System.Linq;
using ImobSystem.Data;
using ImobSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImobSystem.Pages
{
    public class NotBusinessModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public NotBusinessModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Client> Clients { get; set; } // Lista de serviços de clientes
        public List<ClientFase> ClientFases { get; set; } // Lista de fases de atendimento

        public IActionResult OnGet()
        {
            // Atualiza a lista de serviços de clientes puxando do banco de dados
            Clients = _context.Clients.ToList();
            ClientFases = _context.ClientFases.ToList(); // Atualiza a lista de fases de atendimento
            return Page();
        }
    }
}
