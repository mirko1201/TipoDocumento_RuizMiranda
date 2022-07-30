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
    public partial class FrmTipoDocumentoEdit : Form
    {
        private int? Id;
        public FrmTipoDocumentoEdit(int? id = null)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int estado = chkEstado.Checked ? 1 : 0;
            string nombre = txtNombre.Text;
            var adaptador = new dsTipoDocumentoTableAdapters.TipoDocumentoTableAdapter();
            if (this.Id == null)
            {
                adaptador.Agregar(nombre, (byte)estado);
            }
            else
            {
                adaptador.Editar(nombre, (byte)estado, (int)this.Id);
            }

            this.Close();
        }

        private void FrmTipoDocumentoEdit_Load(object sender, EventArgs e)
        {
            if (this.Id != null)
            {
                this.Text = "Editar";
                var adaptador = new dsTipoDocumentoTableAdapters.TipoDocumentoTableAdapter();
                var tabla = adaptador.GetDataByid((int)this.Id);
                var fila = (dsTipoDocumento.TipoDocumentoRow)tabla.Rows[0];
                txtNombre.Text = fila.Nombre;
                chkEstado.Checked = fila.Estado == 1 ? true : false;
            }
            else
            {
                this.Text = "Nuevo";
            }
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
