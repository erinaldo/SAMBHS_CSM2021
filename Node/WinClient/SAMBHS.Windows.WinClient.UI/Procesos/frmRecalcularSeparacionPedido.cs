﻿using SAMBHS.Almacen.BL;
using SAMBHS.Common.Resource;
using SAMBHS.Venta.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAMBHS.Windows.WinClient.UI.Procesos
{
    public partial class frmRecalcularSeparacionPedido : Form
    {
        int IDAlmacen;
        public frmRecalcularSeparacionPedido(string p)
        {
            InitializeComponent();
        }

        private void frmRecalcularSeparacionPedido_Load(object sender, EventArgs e)
        {
            this.BackColor = new GlobalFormColors().FormColor;
            panel1.BackColor = new GlobalFormColors().BannerColor;
            OperationResult objOperationResult = new OperationResult();
            Utils.Windows.LoadUltraComboEditorList(cboAlmacen, "Value1", "Id", new NodeWarehouseBL().ObtenerAlmacenesParaComboAll(ref objOperationResult, null), DropDownListAction.All);
            cboAlmacen.Value = "-1";
            IDAlmacen = cboAlmacen.Value==null ? -1 : int.Parse(cboAlmacen.Value.ToString());
        }

        private void btnRecalcularSeparacion_Click(object sender, EventArgs e)
        {
           
            if (!(System.Windows.Forms.Application.OpenForms["frmMaster"] as frmMaster).IsBussy())
            {
                if (UltraMessageBox.Show("¿Seguro de recalcular los separación stock?", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    Globals.ProgressbarStatus.i_Progress = 1;
                    Globals.ProgressbarStatus.i_TotalProgress = 1;
                    Globals.ProgressbarStatus.b_Cancelado = false;
                    bwkProcesoBL.RunWorkerAsync();
                    (System.Windows.Forms.Application.OpenForms["frmMaster"] as frmMaster).ComenzarBackGroundProcess();
                }
            }
           
        }

        private void bwkProcesoBL_DoWork(object sender, DoWorkEventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            MovimientoBL _objMovimientoBL = new MovimientoBL();
            PedidoBL _objPedidoLBL = new PedidoBL();
            _objPedidoLBL.RecalcularSeparacionProductoAlmacen(ref objOperationResult, IDAlmacen, Globals.ClientSession.GetAsList() ,Globals.ClientSession.i_Periodo.ToString ());

            if (objOperationResult.Success == 1)
            {
                UltraMessageBox.Show("Proceso terminado correctamente!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Globals.ProgressbarStatus.b_Cancelado = true;
                UltraMessageBox.Show("Ocurrió un Error al realizar recálculo", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDAlmacen = int.Parse(cboAlmacen.Value.ToString());
        }
    }
}
