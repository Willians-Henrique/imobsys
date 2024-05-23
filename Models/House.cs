using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations; // Importe o namespace para usar as anotações de chave primária
using System.ComponentModel.DataAnnotations.Schema;


namespace ImobSystem.Models
{
    public class House
    {
        [Key]
        public int Id { get; set; }
        public string cep { get; set; } = string.Empty;
        public string logradouro { get; set; } = string.Empty;
        public string numero { get; set; } = string.Empty;
        public string complemento { get; set; } = string.Empty;
        public string bairro { get; set; } = string.Empty;
        public string cidade { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public decimal ValorImovel { get; set; }
        
        [NotMapped]
        public string FullAddress 
            { 
                get 
                { 
                    return $"{logradouro}, {numero}, {bairro}, {cidade}, {estado}, {cep}"; 
                } 
            }


        // Chave estrangeira Owner
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }  
        
        // Relacionamento com VisitHouse
        public ICollection<VisitHouse> VisitHouses { get; set; } = new List<VisitHouse>();
        // Relacionamento com Proposals
        public ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
    }
}
