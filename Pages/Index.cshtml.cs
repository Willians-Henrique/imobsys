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

        public void OnGet()
        {
            TotalClientServices = _context.ClientServices.Count();
        }
    }
}
