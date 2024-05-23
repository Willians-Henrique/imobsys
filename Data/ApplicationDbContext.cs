using Microsoft.EntityFrameworkCore;
using ImobSystem.Models;

namespace ImobSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientFase> ClientFases { get; set; }
        public DbSet<ClientService> ClientServices { get; set; }
        public DbSet<Fase> Fases { get; set; }
        public DbSet<Formalization> Formalizations { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<VisitHouse> VisitHouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuração de chaves compostas e relacionamentos
            modelBuilder.Entity<ClientFase>()
                .HasKey(cf => cf.Id);
            modelBuilder.Entity<ClientFase>()
                .HasOne(cf => cf.Client)
                .WithMany(c => c.ClientFases)
                .HasForeignKey(cf => cf.ClientId);
            modelBuilder.Entity<ClientFase>()
                .HasOne(cf => cf.Fase)
                .WithMany(f => f.ClientFases)
                .HasForeignKey(cf => cf.FaseId);

            modelBuilder.Entity<ClientService>()
                .HasOne(cs => cs.Client)
                .WithMany(c => c.ClientServices)
                .HasForeignKey(cs => cs.ClientId);

            modelBuilder.Entity<VisitHouse>()
                .HasOne(vh => vh.Client)
                .WithMany(c => c.VisitHouses)
                .HasForeignKey(vh => vh.ClientId);
            modelBuilder.Entity<VisitHouse>()
                .HasOne(vh => vh.House)
                .WithMany(h => h.VisitHouses)
                .HasForeignKey(vh => vh.HouseId);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Proposals)
                .HasForeignKey(p => p.ClientId);
            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.House)
                .WithMany(h => h.Proposals)
                .HasForeignKey(p => p.HouseId);

            modelBuilder.Entity<Formalization>()
                .HasOne(f => f.Proposal)
                .WithMany(p => p.Formalizations)
                .HasForeignKey(f => f.ProposalId);

            modelBuilder.Entity<House>()
                .HasOne(h => h.Owner)
                .WithMany(o => o.Houses)
                .HasForeignKey(h => h.OwnerId);

             // Seed data for Fase
            modelBuilder.Entity<Fase>().HasData(
                new Fase { Id = 1, Fases = "Atendimento" },
                new Fase { Id = 2, Fases = "Visita" },
                new Fase { Id = 3, Fases = "Proposta" },
                new Fase { Id = 4, Fases = "Formalizacao" },
                new Fase { Id = 5, Fases = "Concluido" },
                new Fase { Id = 6, Fases = "Infrutifero" }
                );
        }
    }
}

