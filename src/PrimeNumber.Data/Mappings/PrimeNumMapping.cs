using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeNumber.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumber.Data.Mappings
{
    public class PrimeNumMapping : IEntityTypeConfiguration<PrimeNum>
    {
        public void Configure(EntityTypeBuilder<PrimeNum> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasIndex(p => p.Index)
                .IsUnique();
        }
    }
}
