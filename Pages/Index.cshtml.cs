using Microsoft.AspNetCore.Mvc.RazorPages;
using ImobSystem.Data;

namespace ImobSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int TotalClientServices { get; set; }
        public int ClientInServices { get; set; }

        public void OnGet()
        {
            TotalClientServices = _context.ClientServices.Count();
            ClientInServices = _context.ClientFases.Count(cf => cf.FaseId == 1); // soma o total de cliente em atendimento
        }
    }
}
