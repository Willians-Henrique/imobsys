using Microsoft.AspNetCore.Mvc;
using ImobSystem.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImobSystem.Pages
{

public class ClientModel : PageModel 
{
    
        private readonly ApplicationDbContext _context;

        public ClientModel(ApplicationDbContext context)
        {
            _context = context; 
        }

        public int TotalClientServices { get; set; }
        public int ClientInServices { get; set; }
        public int ClientInVisits { get; set; }
        public int ClientInProposals { get; set; }
        public int ClientInFormalizations { get; set; }
        public int ClientInBusiness { get; set; }
        public int ClientNotBusiness { get; set; }
        public int TotalHouses { get; set; }
        public int TotalOwners { get; set; }



        public void OnGet()
        {
            TotalClientServices = _context.ClientServices.Count();
            TotalHouses = _context.Houses.Count();
            TotalOwners = _context.Owners.Count();
            ClientInServices = _context.ClientFases.Count(cf => cf.FaseId == 1); // soma o total de cliente em atendimento
            ClientInVisits = _context.ClientFases.Count(cf => cf.FaseId == 2); // soma o total de cliente em visita
            ClientInProposals = _context.ClientFases.Count(cf => cf.FaseId == 3); // soma o total de cliente em proposta
            ClientInFormalizations = _context.ClientFases.Count(cf => cf.FaseId == 4); // soma o total de cliente em formalização
            ClientInBusiness = _context.ClientFases.Count(cf => cf.FaseId == 5); // soma o total de cliente em concluído
            ClientNotBusiness = _context.ClientFases.Count(cf => cf.FaseId == 6); // soma o total de cliente em não concluído
        }
    }
}

