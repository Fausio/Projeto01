﻿using Modelo.Cadastros;
using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System.Linq; 

namespace Servicos.Tabelas
{
    public class CategoriaServico
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();
        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
        {
            return categoriaDAL.ObterCategoriasClassificadasPorNome();
        }
    }
}