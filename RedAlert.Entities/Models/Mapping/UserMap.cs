using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RedAlert.Entities.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.UserName)
                .HasMaxLength(510);

            this.Property(t => t.Password)
                .HasMaxLength(510);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.DepartmentId).HasColumnName("DepartmentId");
        }
    }
}
