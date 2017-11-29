using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RedAlert.Entities.Models.Mapping
{
    public class ActivityInfoMap : EntityTypeConfiguration<ActivityInfo>
    {
        public ActivityInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Type)
                .HasMaxLength(255);

            this.Property(t => t.PeriodicityType)
                .HasMaxLength(255);

            this.Property(t => t.AdvnaceAlertType)
                .HasMaxLength(255);

            this.Property(t => t.PreRespPerson)
                .HasMaxLength(510);

            this.Property(t => t.SecRespPerson)
                .HasMaxLength(510);

            this.Property(t => t.Status)
                .HasMaxLength(255);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("ActivityInfo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AreaId).HasColumnName("AreaId");
            this.Property(t => t.ActivityId).HasColumnName("ActivityId");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Periodicity).HasColumnName("Periodicity");
            this.Property(t => t.PeriodicityType).HasColumnName("PeriodicityType");
            this.Property(t => t.AdvnaceAlert).HasColumnName("AdvnaceAlert");
            this.Property(t => t.AdvnaceAlertType).HasColumnName("AdvnaceAlertType");
            this.Property(t => t.PreviousDate).HasColumnName("PreviousDate");
            this.Property(t => t.NextDueDate).HasColumnName("NextDueDate");
            this.Property(t => t.StartJobDate).HasColumnName("StartJobDate");
            this.Property(t => t.PreRespPerson).HasColumnName("PreRespPerson");
            this.Property(t => t.SecRespPerson).HasColumnName("SecRespPerson");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasOptional(t => t.Activity)
                .WithMany(t => t.ActivityInfoes)
                .HasForeignKey(d => d.ActivityId);
            this.HasOptional(t => t.Area)
                .WithMany(t => t.ActivityInfoes)
                .HasForeignKey(d => d.AreaId);

        }
    }
}
