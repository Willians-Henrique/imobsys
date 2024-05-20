using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImobSystem.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
            public string Telefone { get; set; } = string.Empty; 

        // Relacionamento com ClientService
        public ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();
    }
}
