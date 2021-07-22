using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


//MAPEAMENTO
namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntities>
    {
        //podemos criar os campos que acessarãoo banco para criar as tabelasno BD
        public void Configure(EntityTypeBuilder<UserEntities> builder)
        {
            builder.ToTable("User");
            //key
            builder.HasKey(user => user.id);

            //campo email
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(user => user.Name)
                   .IsRequired()
                   .HasMaxLength(60);
            //campo name
            builder.Property(user => user.Name)
                   .HasMaxLength(100);


        }
    }
}
