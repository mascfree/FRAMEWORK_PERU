using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data;

namespace BusinessRule
{
    public class BRCliente
    {
        public static List<Clientes> ObtenerClientes() {
            DACliente daCliente = new DACliente();
            return daCliente.ObtenerClientes();
        }

        public void GrabarCliente(Clientes c) {
            DACliente daCliente = new DACliente();
            daCliente.GrabarCliente(c);
        }

        public void ActualizarCliente(Clientes c) {
            DACliente daCliente = new DACliente();
            daCliente.ActualizarCliente(c);
        }

        public void EliminarCliente(Clientes c) {
            DACliente daCliente = new DACliente();
            daCliente.EliminarCliente(c);
        }

    }
}
