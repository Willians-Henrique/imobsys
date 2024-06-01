using System.Collections.Generic;
using System.Linq; // Adicionado para usar o método ToList()
using ImobSystem.Data;
using ImobSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImobSystem.Pages
{
    public class ClientServicesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ClientServicesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] 
        public ClientService ClientService { get; set; }
        
        public List<ClientService> ClientServices { get; set; } // Lista de serviços de clientes
        public List<Client> Clients { get; set; } // Lista de clientes
        public List<ClientFase> ClientFases { get; set; } // Lista de fases de atendimento 
        public List<House> Houses { get; set; }

        public IActionResult OnGet()
        {
            // Atualiza a lista de serviços de clientes puxando do banco de dados
            ClientServices = _context.ClientServices.ToList();
            Houses = _context.Houses.ToList();
            Clients = _context.Clients.ToList(); // Atualiza a lista de clientes puxando do banco de dados
            ClientFases = _context.ClientFases.ToList(); // Atualiza a lista de fases de atendimento puxando do banco de dados
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Adiciona o serviço do cliente ao contexto do banco de dados
            _context.ClientServices.Add(ClientService);
            _context.SaveChanges();
        
            // Cria um novo registro em ClientFase para o cliente e a fase de atendimento
            var clientFase = new ClientFase
            {
                ClientId = ClientService.ClientId, // Define o Id do cliente
                FaseId = 1 // Define o Id da fase de atendimento (assumindo que 1 é o Id da fase de atendimento)
            };

            _context.ClientFases.Add(clientFase); // Adiciona o novo registro ao contexto
            _context.SaveChanges(); // Salva as alterações

            // Redireciona para a página de ClientServices
            return RedirectToPage("./ClientServices");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult OnPostDelete(int id)
        {
            // Busca o serviço do cliente pelo Id
            var clientFase = _context.ClientFases.FirstOrDefault(cf => cf.ClientId == id && cf.FaseId == 1);
            if (clientFase != null)
            {
                clientFase.FaseId = 6; // Define o Id da fase de at
                _context.SaveChanges(); // Salva as alterações
                return RedirectToPage("./ClientServices");
            }
            else{
                return new NotFoundResult();
            }
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult OnPostNovaVisita(int clientId, List<VisitHouse> visitHouses)
        {
            foreach (var visitHouse in visitHouses)
            {
                visitHouse.ClientId = clientId;
                _context.VisitHouses.Add(visitHouse);
            }

            var clientFase = _context.ClientFases.FirstOrDefault(cf => cf.ClientId == clientId);
            if (clientFase != null)
            {
                clientFase.FaseId = 2;
            }

            _context.SaveChanges();
            return RedirectToPage("./ClientServices");
        }
    }
}
