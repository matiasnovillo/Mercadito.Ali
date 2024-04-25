using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * 
 * Coded by fiyistack.com
 * Copyright © 2024
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

namespace MercaditoAli.Areas.MercaditoAli.Entities.EntitiesConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entity)
        {
            try
            {
                //ClientId
                entity.HasKey(e => e.ClientId);
                entity.Property(e => e.ClientId)
                    .ValueGeneratedOnAdd();

                //Active
                entity.Property(e => e.Active)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                //DateTimeCreation
                entity.Property(e => e.DateTimeCreation)
                    .HasColumnType("datetime")
                    .IsRequired(true);

                //DateTimeLastModification
                entity.Property(e => e.DateTimeLastModification)
                    .HasColumnType("datetime")
                    .IsRequired(true);

                //UserCreationId
                entity.Property(e => e.UserCreationId)
                    .HasColumnType("int")
                    .IsRequired(true);

                //UserLastModificationId
                entity.Property(e => e.UserLastModificationId)
                    .HasColumnType("int")
                    .IsRequired(true);

                //FullName
                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(true);

                //CommercialName
                entity.Property(e => e.CommercialName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                //Address
                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .IsRequired(false);

                //Phone
                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);

                
            }
            catch (Exception) { throw; }
        }
    }
}
