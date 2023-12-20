﻿using GabriEShopAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GabriEShopAPI.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DataContext(DbContextOptions<DataContext>
        options) : base(options)
        {

        }
    }
}
