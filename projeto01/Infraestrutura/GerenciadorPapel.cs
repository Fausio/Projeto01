using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using projeto01.Areas.Seguranca.Data;
using Projeto01.DAL;
using System;

namespace projeto01.Infraestrutura
{
    public class GerenciadorPapel : RoleManager<Papel>, IDisposable
    {

        public GerenciadorPapel(RoleStore<Papel> store) : base(store)
        {

        }

        public static GerenciadorPapel Create(IdentityFactoryOptions<GerenciadorPapel> options, IOwinContext context)
        {
            return new GerenciadorPapel(new RoleStore<Papel>(context.Get<IdentityDbContextAplicacao>()));
        }
    }
}