using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipoDocumento___Ruiz_Miranda_Mirko
{
    public partial class FrmTipoDocumento : Form
    {
        public FrmTipoDocumento()
        {
            InitializeComponent();
        }

        private void btncargardatos_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
           
            var adaptador = new dsTipoDocumentoTableAdapters.TipoDocumentoTableAdapter();
           
            var tabla = adaptador.GetData();
           
            dgvdatos.DataSource = tabla;
        }
        private int getId()
        {
            try
            {
               
                DataGridViewRow filActual = dgvdatos.CurrentRow;
                if (filActual == null)
                {
                    return 0;
                }
                return int.Parse(dgvdatos.Rows[filActual.Index].Cells[0].Value.ToString());
            }
            catch (Exception)
            {
               
                return 0;
            }

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            var frm = new FrmTipoDocumentoEdit();
            frm.ShowDialog();
            cargarDatos();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                var frm = new FrmTipoDocumentoEdit(id);
                frm.ShowDialog();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un Id valido", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                var rpta = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistemas",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                  
                    var adaptador = new dsTipoDocumentoTableAdapters.TipoDocumentoTableAdapter();
                    adaptador.Eliminar(id);

                    MessageBox.Show("Registro eliminardo", "Sistemas",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Id valido", "Sistemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
