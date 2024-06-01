using System.Collections.Generic;
using System.Linq; // Adicionado para usar o método ToList()
using ImobSystem.Data;
using ImobSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImobSystem.Pages
{
    public class VisitModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public VisitModel (ApplicationDbContext context)
        {
            _context = context;
        }

        public List<House> Houses { get; set; } // Lista de serviços de clientes
        public List<Owner> Owner { get; set; } // Lista de Proprietários
        public List<VisitHouse> VisitHouses { get; set; } // Lista de Visitas
        public List<Client> Clients { get; set; } // Lista de clientes
        public List<ClientFase> ClientFases { get; set; } // Lista de fases de atendimento

        public IActionResult OnGet()
        {
            // Atualiza a lista de serviços de clientes puxando do banco de dados
            Houses = _context.Houses.ToList();
            VisitHouses = _context.VisitHouses.ToList();
            Clients = _context.Clients.ToList(); // Atualiza a lista de clientes puxando do banco de dados
            ClientFases = _context.ClientFases.ToList(); // Atualiza a lista de fases de atendimento puxando do banco de dados
            return Page();
        }


        public async Task<IActionResult> OnPostAdicionarPropostaAsync(int clientId, int houseId, DateTime dataProposta, decimal valorProposta, decimal valorContraProposta)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Crie uma nova instância de Proposal
            var newProposal = new Proposal
            {
                ClientId = clientId,
                HouseId = houseId,
                Data = dataProposta,
                ValorProposal = valorProposta,
                ValorContraProposal = valorContraProposta
            };

            // Adicione a nova proposta ao contexto do banco de dados
            _context.Proposals.Add(newProposal);

            var clientFase = _context.ClientFases.FirstOrDefault(cf => cf.ClientId == clientId);
            if (clientFase != null)
            {
                clientFase.FaseId = 3;
            }

            // Salve as mudanças no banco de dados
            await _context.SaveChangesAsync();

            // Redirecione de volta à página de Visitas
            return RedirectToPage("./Visits");
        }

        public IActionResult OnPostDeleteVisit(int Id)
        {
            // Busca o serviço do cliente pelo Id
            var clientFase = _context.ClientFases.FirstOrDefault(cf => cf.ClientId == Id && cf.FaseId == 2);
            if (clientFase != null)
            {
                clientFase.FaseId = 6; // Define o Id da fase de at
                _context.SaveChanges(); // Salva as alterações
                return RedirectToPage("./Visits");
            }
            else{
                return new NotFoundResult();
            }
        }
        
    }
}
