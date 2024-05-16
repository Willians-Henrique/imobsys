using System;

namespace ImobSystem.Models
{
    public class Atendimento
    {
        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Interesse { get; set; }
        public string DescricaoImovel { get; set; }
        public decimal ValorImovel { get; set; }
    }
}
