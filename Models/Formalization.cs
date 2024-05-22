using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations; // Importe o namespace para usar as anotações de chave primária
using System.ComponentModel.DataAnnotations.Schema;

namespace ImobSystem.Models
{
    public class Formalization
    {
        [Key] // Anote a propriedade que será a chave primária com [Key]
        public int Id { get; set; } // Adicione uma propriedade Id como chave primária
        public DateTime DataDoc { get; set; }
        public string Modalidade { get; set; } = string.Empty;
        public DateTime DataVistoria { get; set; }
        public DateTime DataContrato { get; set; }
        public DateTime DataEscritura { get; set; }
        public DateTime DataPagamento { get; set; }
        // Chave estrangeira
        public int ProposalId { get; set; }
        [ForeignKey("ProposalId")]
        public Proposal Proposal { get; set; } 
    }
}
