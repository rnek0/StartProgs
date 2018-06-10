﻿using Microsoft.EntityFrameworkCore;
using System;
using StartProgs.Entities;

namespace SQLiteSerializer
{
    public class DossierDBContext : DbContext
    {
        private static bool _created = false;
        public DossierDBContext()
        {
            if (!_created)
            {
                _created = true;
                //Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var db = $@"{Environment.CurrentDirectory}\Sample.db";
            optionbuilder.UseSqlite($@"Data Source={db}");
        }

        public DbSet<Dossier> Dossiers { get; set; }
    }
}
