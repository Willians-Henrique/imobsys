using System.Collections.Generic;
using System.Linq; // Adicionado para usar o método ToList()
using ImobSystem.Data;
using ImobSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImobSystem.Pages
{
    public class OwnersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public OwnersModel (ApplicationDbContext context)
        {
            _context = context;
        }
   
        public List<Owner> Owners { get; set; } // Lista de Proprietários
        public List<House> Houses { get; set; } // Lista de Casas

        public IActionResult OnGet()
        {
            // Atualiza a lista de serviços de clientes puxando do banco de dados
            Owners = _context.Owners.ToList();
            Houses = _context.Houses.ToList();
;
            // Calcula o total de casas para cada proprietário
            foreach (var owner in Owners)
            {
                owner.TotalHouses = _context.Houses.Count(h => h.OwnerId == owner.Id);
            }
            
            return Page();
        }


        public async Task<IActionResult> OnPostAdicionarCasaAsync(int ownerId, string cep, string logradouro, string numero, string complemento, string bairro, string cidade, string estado, decimal valorImovel)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Crie uma nova instância de House
            var newHouse = new House
            {
                cep = cep,
                logradouro = logradouro,
                numero = numero,
                complemento = complemento,
                bairro = bairro,
                cidade = cidade,
                estado = estado,
                ValorImovel = valorImovel,
                OwnerId = ownerId
            };

            // Adicione a nova proposta ao contexto do banco de dados
            _context.Houses.Add(newHouse);

            // Salve as mudanças no banco de dados
            await _context.SaveChangesAsync();

            // Redirecione de volta à página de Visitas
            return RedirectToPage("./Owners");
        }

        public async Task<IActionResult> OnPostDeleteOwnerAsync(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            // Remova as casas associadas ao proprietário
            var houses = _context.Houses.Where(h => h.OwnerId == id).ToList();
            _context.Houses.RemoveRange(houses);

            // Remova o proprietário
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

        return RedirectToPage("./Owners");
        }
        public class OwnerViewModel
        {
            public Owner Owner { get; set; }
            public int TotalHouses { get; set; }
        }
        public async Task<IActionResult> OnPostNovoProprietario(string nomeProprietario, string telefoneProprietario)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Crie uma nova instância de Proposal
            var newOwner = new Owner
            {
                Nome = nomeProprietario,
                Telefone = telefoneProprietario,
    
            };

            _context.Owners.Add(newOwner);
            await _context.SaveChangesAsync();
            // Redireciona de volta para a página de adicionar casas
            return RedirectToPage("./Owners");
        }
    }
}
