using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data;

namespace BusinessRule
{
    public class BRTipoDocumento
    {
        public static List<TipoDocumentos> ObtenerTipoDocumentos()
        {
            DATipoDocumento daTipoDocumento = new DATipoDocumento();
            return daTipoDocumento.ObtenerTipoDocumentos();
        }
    }
}
