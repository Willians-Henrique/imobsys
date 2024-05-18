using System;
using System.ComponentModel.DataAnnotations; // Importe o namespace para usar as anotações de chave primária
using Microsoft.EntityFrameworkCore;

namespace ImobSystem.Models
{
    public class Service
    {
        [Key] // Anote a propriedade que será a chave primária com [Key]
        public int Id { get; set; } // Adicione uma propriedade Id como chave primária

        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Interesse { get; set; }
        public string DescricaoImovel { get; set; }
        public decimal ValorImovel { get; set; }
    }
}
