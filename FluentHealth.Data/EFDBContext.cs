using FluentHealth.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentHealth.Data
{
    public class EFDBContext: DbContext
    {
        public EFDBContext(DbContextOptions options) :base(options) { }

        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<DoctorVisit> Visits { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiseaseSymptom>()
                .HasKey(x => new { x.DiseaseId, x.SymptomId });
            modelBuilder.Entity<DiseaseSymptom>()
                .HasOne(x => x.Disease)
                .WithMany(x => x.Symptoms)
                .HasForeignKey(x => x.DiseaseId);
            modelBuilder.Entity<DiseaseSymptom>()
                .HasOne(x => x.Symptom)
                .WithMany(x => x.Diseases)
                .HasForeignKey(x => x.SymptomId);

            modelBuilder.Entity<DiseaseDiagnosis>()
                .HasKey(x => new { x.DiseaseId, x.DiagnosisId });
            modelBuilder.Entity<DiseaseDiagnosis>()
                .HasOne(x => x.Disease)
                .WithMany(x => x.Diagnoses)
                .HasForeignKey(x => x.DiseaseId);
            modelBuilder.Entity<DiseaseDiagnosis>()
                .HasOne(x => x.Diagnosis)
                .WithMany(x => x.Diseases)
                .HasForeignKey(x => x.DiagnosisId);
        }
    }
}
