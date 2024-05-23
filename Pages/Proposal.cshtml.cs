using System.Collections.Generic;
using System.Linq; // Adicionado para usar o método ToList()
using ImobSystem.Data;
using ImobSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImobSystem.Pages
{
    public class ProposalModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ProposalModel (ApplicationDbContext context)
        {
            _context = context;
        }

        public List<House> Houses { get; set; } // Lista de serviços de clientes
        public List<Owner> Owner { get; set; } // Lista de Proprietários
        public List<Proposal> Proposals { get; set; } // Lista de Visitas
        public List<Client> Clients { get; set; } // Lista de clientes
        public List<ClientFase> ClientFases { get; set; } // Lista de fases de atendimento

        public IActionResult OnGet()
        {
            // Atualiza a lista de serviços de clientes puxando do banco de dados
            Houses = _context.Houses.ToList();
            Proposals = _context.Proposals.ToList();
            Clients = _context.Clients.ToList(); // Atualiza a lista de clientes puxando do banco de dados
            ClientFases = _context.ClientFases.ToList(); // Atualiza a lista de fases de atendimento puxando do banco de dados
            return Page();
        }

    }
}
