using CA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Persistence.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.HasKey(e => e.Id).HasName("PK__Clientes__3214EC075764C7A2");

            builder.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                builder.Property(e => e.Nombre)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            
        }
    }
}
