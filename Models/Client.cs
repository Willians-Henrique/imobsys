using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations; // Importe o namespace para usar as anotações de chave primária
using System.ComponentModel.DataAnnotations.Schema;

namespace ImobSystem.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;  
        public string Interesse { get; set; } = string.Empty; 
        public string DescricaoImovel { get; set; } = string.Empty; 
        public decimal ValorImovel { get; set; }
        public string Origin { get; set; } = string.Empty; 

        // Relacionamento com ClientService  1/n
        public ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();
         // Relacionamento com ClientFase
        public ICollection<ClientFase> ClientFases { get; set; } = new List<ClientFase>();
        // Relacionamento com VisitHouse
        public ICollection<VisitHouse> VisitHouses { get; set; } = new List<VisitHouse>();
        // Relacionamento com Proposal
        public ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
    }
}
