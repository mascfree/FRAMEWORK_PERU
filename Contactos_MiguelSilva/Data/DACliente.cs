using System.Collections.Generic;
using System.Linq;
using Entidades;

namespace Data
{
    public class DACliente
    {
        public List<Clientes> ObtenerClientes() {
            
            using (demoEntities db = new demoEntities()) {
                return db.Clientes.ToList();
            }
        }

        public void GrabarCliente(Clientes c) {

            using (demoEntities db = new demoEntities())
            {
                db.Clientes.Add(c);
                db.SaveChanges();
            }
        }

        public void ActualizarCliente(Clientes oCli) {
            using (demoEntities db = new demoEntities())
            {
                Clientes cli = (from c in db.Clientes
                                where c.TipoDoc == oCli.TipoDoc && c.NroDoc == oCli.NroDoc
                                select c).FirstOrDefault();

                cli.Nombres = oCli.Nombres.Trim();
                cli.Apellidos = oCli.Apellidos.Trim();
                db.SaveChanges();
            }
        }

        public void EliminarCliente(Clientes oCli) {
            using (demoEntities db = new demoEntities())
            {
                Clientes cli = (from c in db.Clientes
                                where c.TipoDoc == oCli.TipoDoc
                                && c.NroDoc == oCli.NroDoc
                                select c).FirstOrDefault();
                db.Clientes.Remove(cli);
                db.SaveChanges();
            }
        }

    }
}
