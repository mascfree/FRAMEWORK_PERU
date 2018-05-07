using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Data
{
    public class DATipoDocumento
    {
        public List<TipoDocumentos> ObtenerTipoDocumentos()
        {

            using (demoEntities db = new demoEntities())
            {
               
                return db.TipoDocumentos.ToList();
            }
        }

    }
}
