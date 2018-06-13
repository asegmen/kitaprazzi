﻿using Kitaprazzi.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Kitaprazzi.Data.DataContext
{
    public class KitaprazziContext: DbContext
    {
        public KitaprazziContext() : base("Kitaprazzi") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<Publisher> Publishers{ get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries{ get; set; }
    }
}
