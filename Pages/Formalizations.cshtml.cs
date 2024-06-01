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
        public List<ClientFase> ClientFases { get; set; }

        public IActionResult OnGet()
        {
            // Atualiza a lista de serviços de clientes puxando do banco de dados
            Formalizations = _context.Formalizations.ToList();
            Proposals = _context.Proposals.ToList();
            ClientFases = _context.ClientFases.ToList();
            Clients = _context.Clients.ToList(); // Atualiza a lista de clientes puxando do banco de dados
            return Page();
        }

        public IActionResult OnPostDeleteFormalization(int Id)
        {
            // Busca o serviço do cliente pelo Id
            var clientFase = _context.ClientFases.FirstOrDefault(cf => cf.ClientId == Id && cf.FaseId == 4);
            if (clientFase != null)
            {
                clientFase.FaseId = 6; // Define o Id da fase de at
                _context.SaveChanges(); // Salva as alterações
                return RedirectToPage("./Formalizations");
            }
            else{
                return new NotFoundResult();
            }
        }
        public IActionResult OnPostAceitarFormalization(int Id)
        {
            // Busca o serviço do cliente pelo Id
            var clientFase = _context.ClientFases.FirstOrDefault(cf => cf.ClientId == Id && cf.FaseId == 4);
            if (clientFase != null)
            {
                clientFase.FaseId = 5; // Define o Id da fase de at
                _context.SaveChanges(); // Salva as alterações
                return RedirectToPage("./Formalizations");
            }
            else{
                return new NotFoundResult();
            }
        }

    }
}
