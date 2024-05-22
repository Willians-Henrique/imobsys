using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations; // Importe o namespace para usar as anotações de chave primária
using System.ComponentModel.DataAnnotations.Schema;

namespace ImobSystem.Models
{
    public class Proposal
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorProposal { get; set; }
        public decimal ValorContraProposal { get; set; }

        // Chave estrangeira
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; } 
        // Chave estrangeira
        public int HouseId { get; set; }
        [ForeignKey("HouseId")]
        public House House { get; set; } 

        // Relacionamento com Formalization
        public ICollection<Formalization> Formalizations { get; set; } = new List<Formalization>();
    }
}
