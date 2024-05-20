using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; // Importe o namespace para usar as anotações de chave primária


namespace ImobSystem.Models
{
    public class ClientService
    {
        [Key] // Anote a propriedade que será a chave primária com [Key]
        public int Id { get; set; } // Adicione uma propriedade Id como chave primária
        public DateTime Data { get; set; }
        public string Nome { get; set; } = string.Empty; 
        public string Telefone { get; set; } = string.Empty; 
        public string Interesse { get; set; } = string.Empty; 
        public string DescricaoImovel { get; set; } = string.Empty; 
        public decimal ValorImovel { get; set; }

        // Chave estrangeira
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; } = new Client(); 
    }
}
