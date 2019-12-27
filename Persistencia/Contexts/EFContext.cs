﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Modelo.Cadastros;
using Modelo.Tabelas;
using System.Data.Entity.ModelConfiguration.Conventions;
using Modelo.Carrinho;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        public DbSet<Fabricante> fabricantes { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
                       public DbSet<ItemCarrinho> ItensCarrinhos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); /*nessa linha ilimuno a plurralizacao nos nomes das tabelas*/
        }
    }
}