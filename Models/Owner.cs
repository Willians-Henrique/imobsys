using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations; // Importe o namespace para usar as anotações de chave primária
using System.ComponentModel.DataAnnotations.Schema;
namespace ImobSystem.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;  
        // Relacionamento com House
        public ICollection<House> Houses { get; set; } = new List<House>();

        // Propriedade para armazenar o total de casas
        [NotMapped]
        public int TotalHouses { get; set; }
    }
}
