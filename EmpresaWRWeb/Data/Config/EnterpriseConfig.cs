using EmpresaWRWeb.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EmpresaWRWeb.Data.Config
{
    public class EnterpriseConfig : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.StaffNumber).IsRequired();
            builder.Property(x => x.City).IsRequired();            
        }
    }
}
