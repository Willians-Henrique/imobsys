using System.Collections.Generic;
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
            ClientServices = new List<ClientService>();
            Clients = new List<Client>();
            ClientService = new ClientService(); // Inicializando ClientService com um novo objeto
        }

        [BindProperty]
        public ClientService ClientService { get; set; }

        public List<ClientService> ClientServices { get; set; } // Alterando para List<ClientService>
        public List<Client> Clients { get; set; } // Alterando para List<Client>

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ClientServices.Add(ClientService);
            _context.SaveChanges();

            return RedirectToPage("./ClientServices");
        }
    }
}
