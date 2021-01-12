﻿using SAMBHS.Windows.SigesoftIntegration.UI.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAMBHS.Common.Resource;
using SAMBHS.Windows.SigesoftIntegration.UI;

namespace SAMBHS.Windows.WinClient.UI.Procesos
{
    public partial class frmBuscarServicios : Form
    {
        public frmBuscarServicios(string value)
        {
            InitializeComponent();
        }

        private void frmBuscarServicios_Load(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void BindingGrid()
        {
            var DataSource = new ServiceBL().GetServicesByDataPerson(txtValue.Text, dtInicio.Value.Date, dtFin.Value);

            grdServices.DataSource = DataSource;
            grdServices.DataBind();

        }

        private void grdServices_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            var serviceId = grdServices.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
            var protocolId = grdServices.Selected.Rows[0].Cells["v_ProtocolId"].Value.ToString();
            var ListDiseases = new ServiceBL().GetServiceComponentDisgnosticsByServiceId(ref objOperationResult, serviceId);
            if (ListDiseases == null)
            {
                MessageBox.Show("Sucedió un error, por favor vuelva a intentarlo.", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (ListDiseases.Count == 0)
            {
                var DialogResult =  MessageBox.Show("El paciente no cuenta con diagnosticos, se procederá a agregar un diagnostico genérico.", "AVISO", MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Information);
                if (DialogResult == DialogResult.OK)
                {
                    new ServiceBL().AddGenericDiseasesByServiceId(serviceId, Globals.ClientSession.GetAsList());
                    ListDiseases = new ServiceBL().GetServiceComponentDisgnosticsByServiceId(ref objOperationResult, serviceId);
                }
                else
                {
                    return;
                }
                
            }
            var frm = new frmRecetaMedica(ListDiseases, serviceId, protocolId);
            frm.ShowDialog();

        }

        

    }
}
