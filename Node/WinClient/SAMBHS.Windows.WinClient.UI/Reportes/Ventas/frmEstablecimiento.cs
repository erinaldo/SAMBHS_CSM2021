﻿#region Name Space
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAMBHS.Common.BE;
using SAMBHS.Common.BL;
using SAMBHS.CommonWIN.BL;
using SAMBHS.Common.Resource;
using SAMBHS.Venta.BL;
using Infragistics.Win.UltraWinGrid;
using SAMBHS.Almacen.BL;
using System.Text.RegularExpressions;
using Infragistics.Win.UltraWinMaskedEdit;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Sql;
using System.Linq.Dynamic;
using System.Data.SqlClient;
using System.Configuration;
using SAMBHS.Security.BL;
using CrystalDecisions.Shared;
using System.Reflection;
#endregion


namespace SAMBHS.Windows.WinClient.UI.Reportes.Ventas
{
    public partial class frmEstablecimiento : Form
    {
        #region Declaraciones / Referencias
        EstablecimientoBL _objEstablecimientoBL = new EstablecimientoBL();
        //string strOrderExpression;
        DatahierarchyBL _objDatahierarchyBL = new DatahierarchyBL();
        #endregion 
        #region Carga de inicializacion
        public frmEstablecimiento(string parametro)
        {
            InitializeComponent();
        }
        #endregion
        #region Cargar Reporte
        private void CargarReporte()
        {

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues;
            ParameterDiscreteValue crParameterDiscreteValue;

            var rp = new Reportes.Ventas.crEstablecimiento();


            var aptitudeCertificate = new EstablecimientoBL().ReporteEstablecimiento();
            var aptitudeCertificate2 = new NodeBL().ReporteEmpresa();

            DataSet ds1 = new DataSet();
            DataTable dt = SAMBHS.Common.Resource.Utils.ConvertToDatatable(aptitudeCertificate);
            DataTable dt2 = SAMBHS.Common.Resource.Utils.ConvertToDatatable(aptitudeCertificate2);


            ds1.Tables.Add(dt);
            ds1.Tables.Add(dt2);
            ds1.Tables[0].TableName = "dsEstablecimiento";
            ds1.Tables[1].TableName = "dsEmpresa";

            rp.SetDataSource(ds1);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = chkHoraimpresion.Checked == true ? "1" : "0";  // TextBox con el valor del Parametro
            crParameterFieldDefinitions = rp.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["FechaHoraImpresion"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Show();
            crystalReportViewer1.Zoom(110);
        }
        #endregion
        #region Controles Botones
        private void BtnVuisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
                    CargarReporte();
            }
            catch
            {
                UltraMessageBox.Show("Se produjo un error  al mostrar el reporte ", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        private void frmEstablecimiento_Load(object sender, EventArgs e)
        {
            this.BackColor = new GlobalFormColors().FormColor;
      
        }

    }
}
