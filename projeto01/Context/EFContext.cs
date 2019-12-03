using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Projeto01.Models;

namespace Projeto01.Context
{
    public class EFContext : DbContext
    {
        public DbSet<Fabricante> fabricantes { get; set; }
        public DbSet<Categoria> categorias { get; set; }
    }
}