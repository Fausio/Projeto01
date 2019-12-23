using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projeto01.Areas.Seguranca.Data
{
    public class PapelEditModel
    {
        public Papel Papel { get; set; }
        public IEnumerable<Usuario> Membros { get; set; }
        public IEnumerable<Usuario> NaoMembros { get; set; }
    }


}