﻿using MeetingApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MeetingApp.BusinessObject.Entity;

namespace MeetingApp.Data;

public class MeetingAppContext : IdentityDbContext<ApplicationUser>
{
    public MeetingAppContext(DbContextOptions<MeetingAppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<MeetingApp.BusinessObject.Entity.Meetings> Meetings { get; set; } = default!;
}
