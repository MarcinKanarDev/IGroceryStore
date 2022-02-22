﻿using IGroceryStore.Baskets.Core.Entities;
using IGroceryStore.Baskets.Core.ValueObjects;
using IGroceryStore.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IGroceryStore.Baskets.Core.Persistence.Configurations;

internal class BasketsConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasConversion(x => x.Value, x => new BasketName(x));

        builder.Property(x => x.OwnerId)
            .IsRequired()
            .HasConversion(x => x.Value, x => new UserId(x));
    }
}
