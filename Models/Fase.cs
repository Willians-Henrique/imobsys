using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations; // Importe o namespace para usar as anotações de chave primária
using System.ComponentModel.DataAnnotations.Schema;

namespace ImobSystem.Models
{
    public class Fase
    {
        [Key]
        public int Id { get; set; }
        public string Fases { get; set; } = string.Empty;
        
        // Relacionamento com ClientFase
        public ICollection<ClientFase> ClientFases { get; set; } = new List<ClientFase>();
    }
}
