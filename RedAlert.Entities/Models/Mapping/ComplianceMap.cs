using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RedAlert.Entities.Models.Mapping
{
    public class ComplianceMap : EntityTypeConfiguration<Compliance>
    {
        public ComplianceMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.IsDeviationAcceptable)
                .HasMaxLength(255);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Compliance");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ActivityInfoId).HasColumnName("ActivityInfoId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.DueDate).HasColumnName("DueDate");
            this.Property(t => t.CompletionDate).HasColumnName("CompletionDate");
            this.Property(t => t.IsDelayed).HasColumnName("IsDelayed");
            this.Property(t => t.ReasonForDelay).HasColumnName("ReasonForDelay");
            this.Property(t => t.IsDelayAcceptable).HasColumnName("IsDelayAcceptable");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
            this.Property(t => t.HasDeviation).HasColumnName("HasDeviation");
            this.Property(t => t.DeviationDesc).HasColumnName("DeviationDesc");
            this.Property(t => t.IsDeviationAcceptable).HasColumnName("IsDeviationAcceptable");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasOptional(t => t.ActivityInfo)
                .WithMany(t => t.Compliances)
                .HasForeignKey(d => d.ActivityInfoId);

        }
    }
}
