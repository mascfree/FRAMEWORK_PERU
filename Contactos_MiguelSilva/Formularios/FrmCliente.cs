using System;
using System.Windows.Forms;
using Entidades;
using BusinessRule;
using System.Collections.Generic;

namespace Formularios
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            ObtenerTipoDocumento();
            ObtenerClientes();
            
        }

        private void ObtenerTipoDocumento() {
                List<TipoDocumentos> tipoDoc = BRTipoDocumento.ObtenerTipoDocumentos();
                cmbTipoDocumento.DataSource = tipoDoc;
                cmbTipoDocumento.DisplayMember = "abreviatura";
                cmbTipoDocumento.ValueMember = "codigo";
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCliente()) {
                    if (opc == 0)
                    {
                        AgregarCliente();
                        MessageBox.Show("Agregado Correctamente!!");
                    }
                    if (opc == 1)
                    {
                        ActualizarCliente();
                        MessageBox.Show("Actualizado Correctamente!!");

                    }
                        limpiar();
                        ObtenerClientes();
                        
                    
                }   
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private Boolean ValidarCliente() {

            if (txtNroDocumento.TextLength == 0)
            {
                MessageBox.Show("Ingrese Nro. Documento");
                txtNroDocumento.Focus();
                return false;
            }

            if (cmbTipoDocumento.SelectedValue.ToString() == "01" && txtNroDocumento.TextLength!=8) { // DNI
                MessageBox.Show("Lontigud DNI Incorrecto");
                txtNroDocumento.Focus();
                return false;
            }else if((cmbTipoDocumento.SelectedValue.ToString() == "02" || cmbTipoDocumento.SelectedValue.ToString() == "04") && txtNroDocumento.TextLength != 11)// RUC
            {
                MessageBox.Show("Lontigud RUC Incorrecto");
                txtNroDocumento.Focus();
                return false;
            }


            return true;
        }

        private void AgregarCliente() {
            Clientes objCli = new Clientes();
            objCli.TipoDoc = cmbTipoDocumento.SelectedValue.ToString();
            objCli.NroDoc = txtNroDocumento.Text;
            objCli.Nombres = txtNombres.Text;
            objCli.Apellidos = txtApellidos.Text;

            BRCliente ClienteBR = new BRCliente();
            ClienteBR.GrabarCliente(objCli);
        }

        private void ObtenerClientes()
        {
            this.lvCliente.Items.Clear();

            List<Clientes> c = BRCliente.ObtenerClientes();
            foreach (var item in c)
            {
                ListViewItem ilist = lvCliente.Items.Add(item.NroDoc);
                ilist.SubItems.Add(item.TipoDoc);
                ilist.SubItems.Add(item.Nombres);
                ilist.SubItems.Add(item.Apellidos);
                ilist.SubItems.Add(item.Telefono);
            }
        }

        private void ActualizarCliente() {
            Clientes objCli = new Clientes();
            objCli.TipoDoc = lvCliente.Items[index].SubItems[1].Text;
            objCli.NroDoc = lvCliente.Items[index].SubItems[0].Text;
            objCli.Nombres = txtNombres.Text;
            objCli.Apellidos = txtApellidos.Text;
            BRCliente ClienteBR = new BRCliente();
            ClienteBR.ActualizarCliente(objCli);
        }

        private void EliminiarCliente()
        {
            Clientes objCli = new Clientes();
            objCli.TipoDoc = lvCliente.Items[index].SubItems[1].Text;
            objCli.NroDoc = lvCliente.Items[index].SubItems[0].Text;
            objCli.Nombres = txtNombres.Text;
            objCli.Apellidos = txtApellidos.Text;
            BRCliente ClienteBR = new BRCliente();
            ClienteBR.EliminarCliente(objCli);
        }


        private void cmdEliminar_Click(object sender, EventArgs e)
        {

            EliminiarCliente();
            MessageBox.Show("Eliminado Correctamente!!");
            limpiar();
            ObtenerClientes();

        }
        private void limpiar() {
            txtNroDocumento.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            ObtenerClientes();
            cmdAgregar.Text = "Agregar";
            opc = 0;
            txtNroDocumento.Enabled = true;
            cmbTipoDocumento.Enabled = true;
        }

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        int index = 0;
        int opc = 0;
        private void lvCliente_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            index = e.Item.Index;
        }

        private void lvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCliente.SelectedItems.Count == 0) 
                return;

            cmbTipoDocumento.SelectedValue = lvCliente.Items[index].SubItems[1].Text;
            txtNroDocumento.Text = lvCliente.Items[index].SubItems[0].Text;
            txtNombres.Text = lvCliente.Items[index].SubItems[2].Text;
            txtApellidos.Text = lvCliente.Items[index].SubItems[3].Text;
            txtNroDocumento.Enabled = false;
            cmbTipoDocumento.Enabled = false;

            cmdAgregar.Text = "Actualizar";
            opc = 1;
        }
        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}