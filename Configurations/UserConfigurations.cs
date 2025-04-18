using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomBookingAPI.Models;

namespace RoomBookingAPI.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(50);
    }
}
