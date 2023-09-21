using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAPI.Models;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=defaultString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
