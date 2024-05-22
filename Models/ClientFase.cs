using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations; // Importe o namespace para usar as anotações de chave primária
using System.ComponentModel.DataAnnotations.Schema;


namespace ImobSystem.Models
{
    public class ClientFase
    {
        [Key] // Anote a propriedade que será a chave primária com [Key]
        public int Id { get; set; } // Adicione uma propriedade Id como chave primária
       
        // Chave estrangeira Cliente
        public int ClientId { get; set; } 
        [ForeignKey("ClientId")]
        public Client Client { get; set; } 
        // Chave estrangeira Fase
        public int FaseId { get; set; }
        [ForeignKey("FaseId")]
        public Fase Fase { get; set; } 
        
    }
}
