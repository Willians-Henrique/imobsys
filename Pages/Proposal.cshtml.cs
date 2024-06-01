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
        public List<Owner> Owners { get; set; } // Lista de Proprietários
        public List<Proposal> Proposals { get; set; } // Lista de Visitas
        public List<Client> Clients { get; set; } // Lista de clientes
        public List<ClientFase> ClientFases { get; set; } // Lista de fases de atendimento

        public IActionResult OnGet()
        {
            // Atualiza a lista de serviços de clientes puxando do banco de dados
            Houses = _context.Houses.ToList();
            Proposals = _context.Proposals.ToList();
            Owners = _context.Owners.ToList();
            Clients = _context.Clients.ToList(); // Atualiza a lista de clientes puxando do banco de dados
            ClientFases = _context.ClientFases.ToList(); // Atualiza a lista de fases de atendimento puxando do banco de dados
            return Page();
        }

        public async Task<IActionResult> OnPostAdicionarFormalizacaoAsync(int clientId, int proposalId, DateTime dataDocumentacao, string Modalidade, DateTime dataVistoria, DateTime dataContrato, DateTime dataEscritura, DateTime dataPagamento)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Crie uma nova instância de Proposal
            var newFormalization = new Formalization
            {
                ProposalId = proposalId,
                DataDoc = dataDocumentacao,
                Modalidade = Modalidade,
                DataVistoria = dataVistoria,
                DataContrato = dataContrato,
                DataEscritura= dataEscritura,
                DataPagamento = dataPagamento
            };

            // Adicione a nova formalizacao ao contexto do banco de dados
            _context.Formalizations.Add(newFormalization);

            var clientFase = _context.ClientFases.FirstOrDefault(cf => cf.ClientId == clientId);
            if (clientFase != null)
            {
                clientFase.FaseId = 4;
            }

            // Salve as mudanças no banco de dados
            await _context.SaveChangesAsync();

            // Redirecione de volta à página de Visitas
            return RedirectToPage("./Proposal");
        }


        public IActionResult OnPostDeleteProposal(int Id)
        {
            // Busca o serviço do cliente pelo Id
            var clientFase = _context.ClientFases.FirstOrDefault(cf => cf.ClientId == Id && cf.FaseId == 3);
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
