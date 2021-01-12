﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SAMBHS.Common.BE;
using SAMBHS.CommonWIN.BL;
using SAMBHS.Common.Resource;
using SAMBHS.Venta.BL;
using SAMBHS.Almacen.BL;
using Infragistics.Win.UltraWinGrid;
using System.Globalization;
using SAMBHS.Security.BL;
using Infragistics.Win.UltraWinMaskedEdit;
using SAMBHS.Contabilidad.BL;
using LoadingClass;
using SAMBHS.Windows.WinClient.UI.Mantenimientos;
using SAMBHS.Common.DataModel;
using SAMBHS.Windows.SigesoftIntegration.UI;

namespace SAMBHS.Windows.WinClient.UI.Procesos
{
    public partial class frmNotaSalida : Form
    {
        DatahierarchyBL _objDatahierarchyBL = new DatahierarchyBL();
        NodeWarehouseBL _objNodeWarehouseBL = new NodeWarehouseBL();
        MovimientoBL _objMovimientoBL = new MovimientoBL();
        movimientodetalleDto _movimientodetalleDto = new movimientodetalleDto();
        DocumentoBL _objDocumentoBL = new DocumentoBL();
        UltraCombo ucUnidadMedida = new UltraCombo();
        UltraCombo ucTipoDocumento = new UltraCombo();
        SecurityBL _obSecurityBL = new SecurityBL();
        List<KeyValueDTO> _ListadoMovimientos = new List<KeyValueDTO>();
        List<KeyValueDTO> _ListadoMovimientosCambioFecha = new List<KeyValueDTO>();
        CierreMensualBL _objCierreMensualBL = new CierreMensualBL();
        EstablecimientoBL _objEstablecimientoBL = new EstablecimientoBL();
        AlmacenBL _objAlmacenBL = new AlmacenBL();
        string _IdMovimientoss;
        string _Mode;
        int _MaxV, _ActV;
        public string _pstrIdMovimiento_Nuevo;
        movimientoDto _movimientoDto = new movimientoDto();
        string strModo, strIdmovimiento, Mensaje, MENSAJE = "La lista de Producto(s) tienen la cantidad ingresada superior al stock de almacen: \n";
        string Agregado;
        decimal stockActual;
        bool _btnGuardar, _btnImprimir;
        PedidoBL _objPedidoBL = new PedidoBL();
        public string Utilizado = "";
        private List<string> _ListaDetalleId;
        public frmNotaSalida(string Modo, string IdMovimiento, string UtilizadoEn = null)
        {

            strModo = Modo;
            strIdmovimiento = IdMovimiento;
            Utilizado = UtilizadoEn;
            InitializeComponent();



        }
        private void frmNotaSalida_Load(object sender, EventArgs e)
        {
            BackColor = new GlobalFormColors().FormColor;
            panel1.BackColor = new GlobalFormColors().BannerColor;
            OperationResult objOperationResult = new OperationResult();
            #region ControlAcciones
            if (_objCierreMensualBL.VerificarMesCerrado(Globals.ClientSession.i_Periodo.ToString(), DateTime.Now.Month.ToString("00"), (int)ModulosSistema.Almacen) || Utilizado == "KARDEX")
            {
                btnGuardar.Visible = false;
                this.Text = Utilizado == "KARDEX" ? "Nota de Salida" : "Nota de Salida [MES CERRADO]";
                if (Utilizado == "KARDEX")
                {
                    BtnImprimir.Visible = false;
                    btnSalir.Visible = false;
                    btnAgregar.Visible = false;
                    btnEliminar.Visible = false;

                }
            }
            else
            {
                btnGuardar.Visible = true;
                this.Text = @"Nota de Salida";
            }
            var _formActions = _obSecurityBL.GetFormAction(ref objOperationResult, Globals.ClientSession.i_CurrentExecutionNodeId, Globals.ClientSession.i_SystemUserId, "frmNotaSalida", Globals.ClientSession.i_RoleId);
            _btnGuardar = Utils.Windows.IsActionEnabled("frmNotaSalida_Save", _formActions);
            _btnImprimir = Utils.Windows.IsActionEnabled("frmNotaSalida_Print", _formActions);
            btnGuardar.Enabled = _btnGuardar;
            btnEliminar.Enabled = false;
            BtnImprimir.Enabled = false;
            #endregion
            #region Cargar Combos
            Utils.Windows.LoadUltraComboEditorList(cboMotivo, "Value1", "Id", _objDatahierarchyBL.GetDataHierarchiesForCombo(ref objOperationResult, 20, null), DropDownListAction.Select);//20 numero del id Del motivo
            Utils.Windows.LoadUltraComboEditorList(cboMoneda, "Value1", "Id", _objDatahierarchyBL.GetDataHierarchiesForCombo(ref objOperationResult, 18, null), DropDownListAction.Select);
            Utils.Windows.LoadUltraComboEditorList(cboAlmacen, "Value1", "Id", _objNodeWarehouseBL.ObtenerAlmacenesParaCombo(ref objOperationResult, null, Globals.ClientSession.i_IdEstablecimiento.Value), DropDownListAction.Select);
            Utils.Windows.LoadUltraComboEditorList(cboEstablecimiento, "Value1", "Id", _objEstablecimientoBL.ObtenerEstablecimientosValueDto(ref objOperationResult, null), DropDownListAction.Select);
            Utils.Windows.LoadUltraComboEditorList(ddlZonaDireccion, "Value1", "Id", _objDatahierarchyBL.GetDataHierarchiesForCombo(ref objOperationResult, 161, null), DropDownListAction.Select);
            ddlZonaDireccion.Value = -1;
            cboEstablecimiento.Enabled = false;
            CargarCombosDetalle();
            #endregion
            txtPeriodo.Text = Globals.ClientSession.i_Periodo.ToString();
            txtMes.Text = DateTime.Now.Month.ToString();
            Utils.Windows.FijarFormatoUltraTextBox(txtMes, "{0:00}");
            ObtenerListadoMovimientos(txtPeriodo.Text, txtMes.Text);
            if (_movimientoDto.v_OrigenTipo != null)
            {
                btnAgregar.Enabled = false;
                dtpFecha.Enabled = false;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = false;
                btnBuscarCliente.Enabled = false;
                cboAlmacen.Enabled = false;
                cboMoneda.Enabled = false;
                cboMotivo.Enabled = false;
                txtTipoCambio.Enabled = false;
                txtCliente.Enabled = false;
                txtGlosa.Enabled = false;
                chkDevolucion.Enabled = false;
                //txtCliente.Text = "CLINICA SAN LORENZO S.R.L.";
                RestringirEdicionGrilla();
            }

            ValidarFechas();
            ConfigurarGrilla();

            if (Globals.ClientSession.v_RucEmpresa == Constants.RucCMR)
            {
                ddlZonaDireccion.Visible = strModo == "Nuevo" ? false : true;
                lblZona.Visible = strModo == "Nuevo" ? false : true;

            }
            else
            {
                ddlZonaDireccion.Visible = false;
                lblZona.Visible = false;

            }


            if (Application.OpenForms["LoadingForm"] != null) ((LoadingForm)Application.OpenForms["LoadingForm"]).CloseWindow();
            if (Application.OpenForms["frmMaster"] != null) ((frmMaster)Application.OpenForms["frmMaster"]).Activate();
            lblProductoIngresar.Visible = Globals.ClientSession.v_RucEmpresa == Constants.RucHormiguita;
            txtProductoIngresar.Visible = Globals.ClientSession.v_RucEmpresa == Constants.RucHormiguita;

        }
        private void ConfigurarGrilla()
        {
            if (Globals.ClientSession.i_IncluirNingunoCompraVenta == 1 && Globals.ClientSession.v_RucEmpresa == Constants.RucAgrofergic)
            {
                grdData.DisplayLayout.Bands[0].Columns["v_NroPedido"].Hidden = false;
                grdData.DisplayLayout.Bands[0].Columns["v_NroPedido"].CellActivation = Activation.AllowEdit;
                grdData.DisplayLayout.Bands[0].Columns["v_NroPedido"].CellClickAction = CellClickAction.Edit;
            }
            else
            {
                grdData.DisplayLayout.Bands[0].Columns["v_NroPedido"].Hidden = Globals.ClientSession.i_IncluirPedidoExportacionCompraVenta != 1;

            }

            FormatoDecimalesGrilla((int)Globals.ClientSession.i_CantidadDecimales, (int)Globals.ClientSession.i_PrecioDecimales);
            FormatoDecimalesTotales((int)Globals.ClientSession.i_CantidadDecimales, (int)Globals.ClientSession.i_PrecioDecimales);



        }

        #region Temporales DetalleVenta
        List<movimientodetalleDto> _TempDetalle_AgregarDto = new List<movimientodetalleDto>();
        List<movimientodetalleDto> _TempDetalle_ModificarDto = new List<movimientodetalleDto>();
        List<movimientodetalleDto> _TempDetalle_EliminarDto = new List<movimientodetalleDto>();
        #endregion
        #region Barra de Navegación


        private void HabilitarLotesSerie(bool Habilitar)
        {
            grdData.DisplayLayout.Bands[0].Columns["v_NroSerie"].CellActivation = !Habilitar ? Activation.NoEdit : Activation.AllowEdit;
            grdData.DisplayLayout.Bands[0].Columns["v_NroSerie"].CellClickAction = !Habilitar ? CellClickAction.CellSelect : CellClickAction.EditAndSelectText;
            grdData.DisplayLayout.Bands[0].Columns["v_NroLote"].CellActivation = !Habilitar ? Activation.NoEdit : Activation.AllowEdit;
            grdData.DisplayLayout.Bands[0].Columns["v_NroLote"].CellClickAction = !Habilitar ? CellClickAction.CellSelect : CellClickAction.EditAndSelectText;
            grdData.DisplayLayout.Bands[0].Columns["t_FechaCaducidad"].CellActivation = !Habilitar ? Activation.NoEdit : Activation.AllowEdit;
            grdData.DisplayLayout.Bands[0].Columns["t_FechaCaducidad"].CellClickAction = !Habilitar ? CellClickAction.CellSelect : CellClickAction.EditAndSelectText;



        }


        private void ObtenerListadoMovimientos(string pstrPeriodo, string pstrMes)
        {

            OperationResult objOperationResult = new OperationResult();
            _ListadoMovimientos = _objMovimientoBL.ObtenerListadoMovimientos(ref objOperationResult, pstrPeriodo, pstrMes, (int)Common.Resource.TipoDeMovimiento.NotadeSalida);
            switch (strModo)
            {
                case "Edicion":
                    EdicionBarraNavegacion(false);
                    CargarCabecera(strIdmovimiento);
                    cboAlmacen.Enabled = false;
                    BtnImprimir.Enabled = _btnImprimir;
                    HabilitarLotesSerie(false);
                    break;

                case "Nuevo":

                    if (_ListadoMovimientos.Count != 0)
                    {
                        _MaxV = _ListadoMovimientos.Count() - 1;
                        _ActV = _MaxV;
                        LimpiarCabecera();
                        CargarDetalle("");
                        txtCorrelativo.Text = (int.Parse(_ListadoMovimientos[_MaxV].Value1) + 1).ToString("00000000");
                        _Mode = "New";
                        _movimientoDto = new movimientoDto();
                        cboAlmacen.Enabled = true;
                    }
                    else
                    {
                        txtCorrelativo.Text = Globals.ClientSession.i_IdAlmacenPredeterminado.Value.ToString("00") + "000001";
                        _Mode = "New";
                        LimpiarCabecera();
                        CargarDetalle("");
                        _MaxV = 1;
                        _ActV = 1;
                        _movimientoDto = new movimientoDto();
                        btnNuevoMovimiento.Enabled = false;
                        EdicionBarraNavegacion(false);
                    }

                    txtTipoCambio.Text = _objMovimientoBL.DevolverTipoCambioPorFecha(ref objOperationResult, dtpFecha.Value.Date);
                    txtMes.Enabled = false;
                    EdicionBarraNavegacion(false);
                    GenerarNumeroRegistro();

                    break;

                case "Guardado":
                    _MaxV = _ListadoMovimientos.Count() - 1;
                    _ActV = _MaxV;


                    if (strIdmovimiento == "" | strIdmovimiento == null)
                    {
                        CargarCabecera(_ListadoMovimientos[_MaxV].Value2);
                    }
                    else
                    {
                        CargarCabecera(strIdmovimiento);
                    }
                    btnNuevoMovimiento.Enabled = true;
                    cboAlmacen.Enabled = false;
                    EdicionBarraNavegacion(false);
                    BtnImprimir.Enabled = _btnImprimir;
                    HabilitarLotesSerie(false);
                    break;

                case "Consulta":
                    if (_ListadoMovimientos.Count != 0)
                    {
                        _MaxV = _ListadoMovimientos.Count() - 1;
                        _ActV = _MaxV;
                        txtCorrelativo.Text = (int.Parse(_ListadoMovimientos[_MaxV].Value1)).ToString("00000000");
                        CargarCabecera(_ListadoMovimientos[_MaxV].Value2);
                        _Mode = "Edit";
                    }
                    else
                    {
                        txtCorrelativo.Text = "00000001";
                        _Mode = "New";
                        LimpiarCabecera();
                        CargarDetalle("");
                        _MaxV = 1;
                        _ActV = 1;
                        _movimientoDto = new movimientoDto();
                        btnNuevoMovimiento.Enabled = false;
                        txtTipoCambio.Text = _objMovimientoBL.DevolverTipoCambioPorFecha(ref objOperationResult, dtpFecha.Value.Date);
                        //EdicionBarraNavegacion(false);
                        txtMes.Enabled = true;
                    }
                    EdicionBarraNavegacion(false);
                    BtnImprimir.Enabled = _btnImprimir;
                    HabilitarLotesSerie(false);
                    break;
            }

        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (_ListadoMovimientos.Count() > 0)
            {
                if (_MaxV == 0) CargarCabecera(_ListadoMovimientos[0].Value2);

                if (_ActV > 0 && _ActV <= _MaxV)
                {
                    _ActV = _ActV - 1;
                    txtCorrelativo.Text = _ListadoMovimientos[_ActV].Value1;
                    CargarCabecera(_ListadoMovimientos[_ActV].Value2);
                }
            }
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            if (_ActV >= 0 && _ActV < _MaxV)
            {
                _ActV = _ActV + 1;
                txtCorrelativo.Text = _ListadoMovimientos[_ActV].Value1;
                CargarCabecera(_ListadoMovimientos[_ActV].Value2);
            }
        }
        private void btnNuevoMovimiento_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            LimpiarCabecera();
            CargarDetalle("");
            txtCorrelativo.Text = (int.Parse(_ListadoMovimientos[_MaxV].Value1) + 1).ToString("00000000");
            _Mode = "New";
            _movimientoDto = new movimientoDto();
            EdicionBarraNavegacion(false);
            txtTipoCambio.Text = _objMovimientoBL.DevolverTipoCambioPorFecha(ref objOperationResult, dtpFecha.Value.Date);
            HabilitarLotesSerie(true);
        }
        private void txtCorrelativo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCorrelativo.Text = txtCorrelativo.Text == "" ? "" : int.Parse(txtCorrelativo.Text).ToString("00000000");
                if (txtCorrelativo.Text != "")
                {
                    var x = _ListadoMovimientos.Find(p => p.Value1 == txtCorrelativo.Text);


                    if (x != null)
                    {
                        CargarCabecera(x.Value2);
                    }
                    else
                    {
                        UltraMessageBox.Show("No se encontró el movimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ObtenerListadoMovimientos(txtPeriodo.Text, txtMes.Text);
                    }
                }
            }
        }
        private void txtMes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Utils.Windows.FijarFormato(txtMes, "{0:00}");
                if (txtMes.Text != "")
                {
                    int Mes;
                    Mes = int.Parse(txtMes.Text);
                    if (Mes >= 1 && Mes <= 12)
                    {
                        if (strModo == "Nuevo")
                        {
                            ObtenerListadoMovimientos(txtPeriodo.Text, txtMes.Text);
                        }
                        else if (strModo == "Guardado")
                        {
                            strModo = "Consulta";
                            ObtenerListadoMovimientos(txtPeriodo.Text, txtMes.Text);
                        }
                        else
                        {
                            ObtenerListadoMovimientos(txtPeriodo.Text, txtMes.Text);
                        }
                    }
                    else
                    {
                        UltraMessageBox.Show("Mes inválido", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }
        #endregion
        #region Clases/Validaciones
        private void ValidarFechas()
        {

            if (DateTime.Now.Year.ToString().Trim() == txtPeriodo.Text.Trim())
            {
                if (strModo == "Nuevo")
                {
                    dtpFecha.Value = DateTime.Parse((txtPeriodo.Text + "/" + txtMes.Text.Trim() + "/" + DateTime.Now.Date.Day.ToString()).ToString());
                    dtpFecha.MinDate = DateTime.Parse((txtPeriodo.Text + "/" + "01" + "/" + "01").ToString());
                    dtpFecha.MaxDate = DateTime.Parse((txtPeriodo.Text + "/" + DateTime.Now.Month.ToString() + "/" + (DateTime.DaysInMonth(int.Parse(txtPeriodo.Text), int.Parse(DateTime.Now.Month.ToString()))).ToString()).ToString());

                }
                else
                {
                    if (int.Parse(_movimientoDto.v_Mes.Trim()) <= int.Parse(DateTime.Now.Month.ToString()))
                    {
                        dtpFecha.MaxDate = DateTime.Parse((txtPeriodo.Text + "/" + DateTime.Now.Month.ToString() + "/" + (DateTime.DaysInMonth(int.Parse(txtPeriodo.Text), int.Parse(DateTime.Now.Month.ToString()))).ToString()).ToString());

                    }
                    dtpFecha.MinDate = DateTime.Parse((txtPeriodo.Text + "/" + "01" + "/" + "01").ToString());
                }


            }
            else
            {
                if (strModo == "Nuevo")
                {
                    dtpFecha.Value = DateTime.Parse((txtPeriodo.Text + "/" + txtMes.Text.Trim() + "/" + DateTime.Now.Date.Day.ToString()).ToString());
                    dtpFecha.MinDate = DateTime.Parse((txtPeriodo.Text + "/" + "01" + "/" + "01").ToString());
                    dtpFecha.MaxDate = DateTime.Parse((txtPeriodo.Text + "/" + " 12 " + "/" + (DateTime.DaysInMonth(int.Parse(txtPeriodo.Text), 12)).ToString()).ToString());

                }
                else
                {

                    dtpFecha.MinDate = DateTime.Parse((txtPeriodo.Text + "/" + "01" + "/01").ToString());
                    dtpFecha.MaxDate = DateTime.Parse((txtPeriodo.Text + "/" + " 12 " + "/" + (DateTime.DaysInMonth(int.Parse(txtPeriodo.Text), 12)).ToString()).ToString());

                }

            }
        }

        private void FormatoDecimalesTotales(int DecimalesCantidad, int DecimalesPrecio)
        {


            string FormatoCantidad;

            if (DecimalesCantidad > 0)
            {
                string sharp = "0";
                FormatoCantidad = "0.";
                for (int i = 0; i < DecimalesCantidad; i++)
                {
                    FormatoCantidad = FormatoCantidad + sharp;
                }
            }
            else
            {
                FormatoCantidad = "0";
            }
            if (txtCantidad.Text != "")
            {
                txtCantidad.Text = decimal.Parse(txtCantidad.Text).ToString(FormatoCantidad);
            }

        }
        private void EdicionCabecera(bool ON_OFF)
        {
            txtCorrelativo.Enabled = ON_OFF;
            btnNuevoMovimiento.Enabled = ON_OFF;
            btnAnterior.Enabled = ON_OFF;
            btnSiguiente.Enabled = ON_OFF;
            txtMes.Enabled = ON_OFF;
        }

        private void EdicionBarraNavegacion(bool ON_OFF)
        {
            txtCorrelativo.Enabled = ON_OFF;
            btnNuevoMovimiento.Enabled = ON_OFF;
            btnAnterior.Enabled = ON_OFF;
            btnSiguiente.Enabled = ON_OFF;
            txtMes.Enabled = ON_OFF;
            txtPeriodo.Enabled = ON_OFF;
        }
        private void LimpiarCabecera()
        {
            cboMotivo.Value = "-1";
            dtpFecha.Value = DateTime.Parse((txtPeriodo.Text + "/" + txtMes.Text.Trim() + "/" + DateTime.Now.Date.Day.ToString()).ToString());
            txtTipoCambio.Text = string.Empty;
            txtGlosa.Clear();
            txtCliente.Text = string.Empty;
            txtCliente.Text = "CLINICA SAN LORENZO S.R.L.";
            txtGlosa.Text = string.Empty;
            txtGlosa.Text = "SALIDA PARA: ";
            cboMoneda.Value = Globals.ClientSession.i_IdMoneda.ToString();
            cboAlmacen.Value = Globals.ClientSession.i_IdAlmacenPredeterminado.ToString();
            btnEliminar.Enabled = false;
            cboAlmacen.Enabled = true;
            cboMotivo.Value = "4";
            cboEstablecimiento.Value = Globals.ClientSession.i_IdEstablecimiento.Value.ToString();
            txtSerieDoc.Text = "";
            txtNroDoc.Text = "";

        }
        private void CargarCabecera(string idMovimiento)
        {
            OperationResult objOperationResult = new OperationResult();
            _movimientoDto = new movimientoDto();

            _movimientoDto = _objMovimientoBL.ObtenerMovimientoCabecera(ref objOperationResult, idMovimiento);
            _pstrIdMovimiento_Nuevo = idMovimiento;

            if (_movimientoDto != null)
            {
                _Mode = "Edit";
                cboAlmacen.Value = _movimientoDto.i_IdAlmacenOrigen.ToString();
                cboMoneda.Value = _movimientoDto.i_IdMoneda.ToString();
                cboMotivo.Value = _movimientoDto.i_IdTipoMotivo.ToString();
                dtpFecha.Value = _movimientoDto.t_Fecha.Value;
                txtTipoCambio.Text = _movimientoDto.d_TipoCambio.ToString();
                txtGlosa.Text = _movimientoDto.v_Glosa;
                txtCliente.Text = _movimientoDto.v_NombreCliente;
                txtCorrelativo.Text = _movimientoDto.v_Correlativo;
                txtTotal.Text = decimal.Parse(_movimientoDto.d_TotalPrecio.ToString()).ToString("0.00");
                txtCantidad.Text = decimal.Parse(_movimientoDto.d_TotalCantidad.ToString()).ToString();
                chkDevolucion.Checked = _movimientoDto.i_EsDevolucion == 1 ? true : false;
                cboEstablecimiento.Value = _movimientoDto.i_IdEstablecimiento.ToString();
                cboTipoDocumento.Value = (_movimientoDto.i_IdTipoDocumento ?? -1).ToString();
                txtSerieDoc.Text = _movimientoDto.v_SerieDocumento;
                txtNroDoc.Text = _movimientoDto.v_CorrelativoDocumento;
                ddlZonaDireccion.Value = int.Parse(_movimientoDto.i_IdZona.ToString());
                CargarDetalle(_movimientoDto.v_IdMovimiento);
            }
            else
            {
                UltraMessageBox.Show("Hubo un error al cargar el movimiento", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }
        private void CargarDetalle(string pstringIdMovimiento)
        {
            OperationResult objOperationResult = new OperationResult();
            grdData.DataSource = _objMovimientoBL.ObtenerMovimientoDetalles(ref objOperationResult, pstringIdMovimiento);
            for (int i = 0; i < grdData.Rows.Count(); i++)
            {
                grdData.Rows[i].Cells["i_RegistroTipo"].Value = "NoTemporal";
            }
        }

        private void CargarCombosDetalle()
        {
            OperationResult objOperationResult = new OperationResult();

            #region Configura Combo Unidad Medida
            UltraGridBand ultraGridBanda = new UltraGridBand("Band 0", -1);
            UltraGridColumn ultraGridColumnaID = new UltraGridColumn("Id");
            UltraGridColumn ultraGridColumnaDescripcion = new UltraGridColumn("Value1");
            ultraGridColumnaDescripcion.Header.Caption = "Descripción";
            ultraGridColumnaDescripcion.Header.VisiblePosition = 0;
            ultraGridColumnaDescripcion.Width = 267;
            ultraGridColumnaID.Hidden = true;
            ultraGridBanda.Columns.AddRange(new object[] { ultraGridColumnaDescripcion, ultraGridColumnaID });
            ucUnidadMedida.DisplayLayout.BandsSerializer.Add(ultraGridBanda);
            ucUnidadMedida.DropDownWidth = 270;
            #endregion

            #region Configura Combo Tipo Documento
            UltraGridBand _ultraGridBanda = new UltraGridBand("Band 0", -1);
            UltraGridColumn _ultraGridColumnaID = new UltraGridColumn("Id");
            UltraGridColumn _ultraGridColumnaDescripcion = new UltraGridColumn("Value1");
            UltraGridColumn _ultraGridColumnaSiglas = new UltraGridColumn("Value2");
            _ultraGridColumnaID.Header.Caption = "Cod.";
            _ultraGridColumnaDescripcion.Header.Caption = "Descripción";
            _ultraGridColumnaSiglas.Header.Caption = "Siglas";
            _ultraGridColumnaID.Width = 30;
            _ultraGridColumnaDescripcion.Width = 200;
            _ultraGridColumnaSiglas.Width = 80;
            //_ultraGridColumnaID.Hidden = true;
            _ultraGridBanda.Columns.AddRange(new object[] { _ultraGridColumnaID, _ultraGridColumnaDescripcion, _ultraGridColumnaSiglas });
            ucTipoDocumento.DisplayLayout.BandsSerializer.Add(_ultraGridBanda);
            ucTipoDocumento.DropDownStyle = UltraComboStyle.DropDownList;

            ucTipoDocumento.DropDownWidth = 330;
            #endregion

            var docs = _objDocumentoBL.ObtenDocumentosParaComboGridAll(ref objOperationResult);


            //Utils.Windows.LoadUltraComboList(ucTipoDocumento, "Value2", "Id", _objDocumentoBL.ObtenDocumentosParaComboGridAll(ref objOperationResult), DropDownListAction.Select);


            Utils.Windows.LoadUltraComboList(ucTipoDocumento, "Value2", "Id", docs, DropDownListAction.Select); //Envio como parametros 1 - porque se utiliza para las ventas
            Utils.Windows.LoadUltraComboList(cboTipoDocumento, "Value2", "Id", docs, DropDownListAction.Select);
            Utils.Windows.LoadUltraComboList(ucUnidadMedida, "Value1", "Id", _objDatahierarchyBL.GetDataHierarchiesForComboGrid(ref objOperationResult, 17, null), DropDownListAction.Select);
        }

        private void LlenarTemporales()
        {
            if (grdData.Rows.Count() != 0)
            {
                foreach (UltraGridRow Fila in grdData.Rows)
                {
                    switch (Fila.Cells["i_RegistroTipo"].Value.ToString())
                    {
                        case "Temporal":
                            if (Fila.Cells["i_RegistroEstado"].Value.ToString() == "Modificado")
                            {
                                _movimientodetalleDto = new movimientodetalleDto();
                                _movimientodetalleDto.v_IdMovimiento = _movimientoDto.v_IdMovimiento;
                                _movimientodetalleDto.v_IdProductoDetalle = Fila.Cells["v_IdProductoDetalle"].Value == null ? null : Fila.Cells["v_IdProductoDetalle"].Value.ToString();
                                _movimientodetalleDto.v_NroGuiaRemision = Fila.Cells["v_NroGuiaRemision"].Value == null ? null : Fila.Cells["v_NroGuiaRemision"].Value.ToString();
                                _movimientodetalleDto.i_IdTipoDocumento = Fila.Cells["i_IdTipoDocumento"].Value == null ? 0 : int.Parse(Fila.Cells["i_IdTipoDocumento"].Value.ToString());
                                _movimientodetalleDto.v_NumeroDocumento = Fila.Cells["v_NumeroDocumento"].Value == null ? null : Fila.Cells["v_NumeroDocumento"].Value.ToString();
                                _movimientodetalleDto.d_Cantidad = Fila.Cells["d_Cantidad"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Cantidad"].Value.ToString());
                                _movimientodetalleDto.d_CantidadEmpaque = Fila.Cells["d_CantidadEmpaque"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_CantidadEmpaque"].Value.ToString());
                                
                                _movimientodetalleDto.i_IdUnidad = Fila.Cells["i_IdUnidad"].Value == null ? 0 : int.Parse(Fila.Cells["i_IdUnidad"].Value.ToString());
                                if (_movimientodetalleDto.i_IdUnidad == 0)
                                {
                                    MessageBox.Show(
                                        "Existen productos sin unidad de medidad, por favor elija una y vuelva a grabar.",
                                        "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                _movimientodetalleDto.d_Precio = Fila.Cells["d_Precio"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Precio"].Value.ToString());
                                _movimientodetalleDto.d_Total = Fila.Cells["d_Total"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Total"].Value.ToString());
                                _movimientodetalleDto.v_NroPedido = Fila.Cells["v_NroPedido"].Value == null ? null : Fila.Cells["v_NroPedido"].Value.ToString().Trim();
                                _movimientodetalleDto.v_NroSerie = Fila.Cells["v_NroSerie"].Value == null || Fila.Cells["v_NroSerie"].Value == "" ? null : Fila.Cells["v_NroSerie"].Value.ToString().Trim();
                                _movimientodetalleDto.v_NroLote = Fila.Cells["v_NroLote"].Value == null || Fila.Cells["v_NroLote"].Value == "" ? null : Fila.Cells["v_NroLote"].Value.ToString().Trim();
                                _movimientodetalleDto.t_FechaCaducidad = Fila.Cells["t_FechaCaducidad"].Value == null ? (DateTime?)null : DateTime.Parse(Fila.Cells["t_FechaCaducidad"].Value.ToString());
                                _movimientodetalleDto.v_NroOrdenProduccion = Fila.Cells["v_NroOrdenProduccion"].Value == null || Fila.Cells["v_NroOrdenProduccion"].Value == "" ? null : Fila.Cells["v_NroOrdenProduccion"].Value.ToString();
                                _movimientodetalleDto.CodigoProducto = Fila.Cells["v_CodigoInterno"].Value as string;

                                _TempDetalle_AgregarDto.Add(_movimientodetalleDto);
                            }
                            break;

                        case "NoTemporal":
                            if (Fila.Cells["i_RegistroEstado"].Value != null && Fila.Cells["i_RegistroEstado"].Value.ToString() == "Modificado")
                            {
                                _movimientodetalleDto = new movimientodetalleDto();
                                _movimientodetalleDto.v_IdMovimientoDetalle = Fila.Cells["v_IdMovimientoDetalle"].Value == null ? null : Fila.Cells["v_IdMovimientoDetalle"].Value.ToString();
                                _movimientodetalleDto.v_IdMovimiento = Fila.Cells["v_IdMovimiento"].Value == null ? null : Fila.Cells["v_IdMovimiento"].Value.ToString();
                                _movimientodetalleDto.v_IdProductoDetalle = Fila.Cells["v_IdProductoDetalle"].Value == null ? null : Fila.Cells["v_IdProductoDetalle"].Value.ToString();
                                _movimientodetalleDto.v_NroGuiaRemision = Fila.Cells["v_NroGuiaRemision"].Value == null ? null : Fila.Cells["v_NroGuiaRemision"].Value.ToString();
                                _movimientodetalleDto.i_IdTipoDocumento = Fila.Cells["i_IdTipoDocumento"].Value == null ? 0 : int.Parse(Fila.Cells["i_IdTipoDocumento"].Value.ToString());
                                _movimientodetalleDto.v_NumeroDocumento = Fila.Cells["v_NumeroDocumento"].Value == null ? null : Fila.Cells["v_NumeroDocumento"].Value.ToString();
                                _movimientodetalleDto.d_Cantidad = Fila.Cells["d_Cantidad"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Cantidad"].Value.ToString());
                                _movimientodetalleDto.d_CantidadEmpaque = Fila.Cells["d_CantidadEmpaque"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_CantidadEmpaque"].Value.ToString());
                               
                                _movimientodetalleDto.i_IdUnidad = Fila.Cells["i_IdUnidad"].Value == null ? 0 : int.Parse(Fila.Cells["i_IdUnidad"].Value.ToString());
                                if (_movimientodetalleDto.i_IdUnidad == 0)
                                {
                                    MessageBox.Show(
                                        "Existen productos sin unidad de medidad, por favor elija una y vuelva a grabar.",
                                        "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                
                                _movimientodetalleDto.d_Precio = Fila.Cells["d_Precio"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Precio"].Value.ToString());
                                _movimientodetalleDto.d_Total = Fila.Cells["d_Total"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Total"].Value.ToString());
                                _movimientodetalleDto.v_NroPedido = Fila.Cells["v_NroPedido"].Value == null ? null : Fila.Cells["v_NroPedido"].Value.ToString().Trim();
                                _movimientodetalleDto.v_NroSerie = Fila.Cells["v_NroSerie"].Value == null || Fila.Cells["v_NroSerie"].Value == "" ? null : Fila.Cells["v_NroSerie"].Value.ToString().Trim();
                                _movimientodetalleDto.v_NroLote = Fila.Cells["v_NroLote"].Value == null || Fila.Cells["v_NroLote"].Value == "" ? null : Fila.Cells["v_NroLote"].Value.ToString().Trim();
                                _movimientodetalleDto.t_FechaCaducidad = Fila.Cells["t_FechaCaducidad"].Value == null ? (DateTime?)null : DateTime.Parse(Fila.Cells["t_FechaCaducidad"].Value.ToString());
                                _movimientodetalleDto.i_Eliminado = int.Parse(Fila.Cells["i_Eliminado"].Value.ToString());
                                _movimientodetalleDto.CodigoProducto = Fila.Cells["v_CodigoInterno"].Value as string;
                                _movimientodetalleDto.i_InsertaIdUsuario = int.Parse(Fila.Cells["i_InsertaIdUsuario"].Value.ToString());
                                _movimientodetalleDto.t_InsertaFecha = Convert.ToDateTime(Fila.Cells["t_InsertaFecha"].Value);
                                _movimientodetalleDto.v_NroOrdenProduccion = Fila.Cells["v_NroOrdenProduccion"].Value == null || Fila.Cells["v_NroOrdenProduccion"].Value == "" ? null : Fila.Cells["v_NroOrdenProduccion"].Value.ToString();
                                _TempDetalle_ModificarDto.Add(_movimientodetalleDto);
                            }
                            break;
                    }
                }
            }

        }


        private string VerificarStockProductoAlmacen()
        {

            string mensaje = "";

            OperationResult objOperation = new OperationResult();
            OperationResult objOperationResultValidarStock = new OperationResult();
            int ValidarStockAlmacen = _objAlmacenBL.ObtenerAlmacen(ref objOperationResultValidarStock, int.Parse(cboAlmacen.Value.ToString())).i_ValidarStockAlmacen ?? 0;
            List<productoalmacen> ListaProductoAlmacen = _objMovimientoBL.ListaProductoAlmacen(Globals.ClientSession.i_Periodo.ToString());
            List<producto> ListaProducto = _objMovimientoBL.ListaProductos();
            List<productodetalle> ListaProductoDetalle = _objMovimientoBL.ListaProductosDetalles();
            foreach (UltraGridRow Fila in grdData.Rows)
            {
                decimal cantidad = decimal.Parse(Fila.Cells["d_Cantidad"].Value.ToString());
                decimal stockActual = 0;
                var sa = _objMovimientoBL.ObtenerStockProductoAlmacen(ref objOperation, Fila.Cells["v_IdProductoDetalle"].Value.ToString(), int.Parse(cboAlmacen.Value.ToString()), Fila.Cells["v_NroPedido"].Value == null ? null : Fila.Cells["v_NroPedido"].Value.ToString().Trim(), ListaProductoAlmacen, Fila.Cells["v_NroSerie"].Value == null || Fila.Cells["v_NroSerie"].Value == "" ? null : Fila.Cells["v_NroSerie"].Value.ToString().Trim(), Fila.Cells["v_NroLote"].Value == null || Fila.Cells["v_NroLote"].Value == "" ? null : Fila.Cells["v_NroLote"].Value.ToString().Trim());
                stockActual = sa != null ? sa.d_StockActual ?? 0 : 0;
                int ValidarStock = _objMovimientoBL.ValidarStock(ref objOperationResultValidarStock, Fila.Cells["v_IdProductoDetalle"].Value.ToString(), ListaProducto, ListaProductoDetalle);
                if (objOperationResultValidarStock.Success == 0)
                {
                    mensaje = mensaje + "Error Validar Stock" + Fila.Cells["v_CodigoInterno"].Value.ToString().Trim() + "-" + Fila.Cells["v_NombreProducto"].Value.ToString() + "\n";
                }

                if (ValidarStockAlmacen == 1 && ValidarStock == 1)
                {
                    if (cantidad > stockActual)
                    {
                        mensaje = mensaje + "Item: " + Fila.Cells["Index"].Value.ToString().Trim() + " " + Fila.Cells["v_CodigoInterno"].Value.ToString().Trim() + "-" + Fila.Cells["v_NombreProducto"].Value.ToString() + "\n";

                        UltraGridRow Row = grdData.Rows.Where(x => x.Cells["Index"].Value == Fila.Cells["Index"].Value.ToString().Trim()).FirstOrDefault();
                        grdData.Selected.Cells.Add(Row.Cells["Index"]);
                        grdData.Focus();
                        Row.Activate();
                        grdData.ActiveColScrollRegion.Scroll(ColScrollAction.Left);
                        UltraGridCell aCell = this.grdData.ActiveRow.Cells["Index"];
                        this.grdData.ActiveCell = aCell;

                    }
                }
            }
            return mensaje;

        }

        private string VerificarStockProductoAlmacenEditado()
        {
            OperationResult objOperation = new OperationResult();
            OperationResult objOperationResultValidarStock = new OperationResult();
            int ValidarStockAlmacen = _objAlmacenBL.ObtenerAlmacen(ref objOperationResultValidarStock, int.Parse(cboAlmacen.Value.ToString())).i_ValidarStockAlmacen ?? 0;
            string mensaje = "";
            List<productoalmacen> ListaProductoAlmacen = _objMovimientoBL.ListaProductoAlmacen(Globals.ClientSession.i_Periodo.ToString());
            List<producto> ListaProducto = _objMovimientoBL.ListaProductos();
            List<productodetalle> ListaProductoDetalle = _objMovimientoBL.ListaProductosDetalles();


            foreach (UltraGridRow Fila in grdData.Rows)
            {
                decimal cantidad = decimal.Parse(Fila.Cells["d_Cantidad"].Value.ToString());
                var sa = _objMovimientoBL.ObtenerStockProductoAlmacen(ref objOperation, Fila.Cells["v_IdProductoDetalle"].Value.ToString(), int.Parse(cboAlmacen.Value.ToString()), Fila.Cells["v_NroPedido"].Value == null ? null : Fila.Cells["v_NroPedido"].Value.ToString().Trim(), ListaProductoAlmacen, Fila.Cells["v_NroSerie"].Value == null || Fila.Cells["v_NroSerie"].Value == "" ? null : Fila.Cells["v_NroSerie"].Value.ToString().Trim(), Fila.Cells["v_NroLote"].Value == null || Fila.Cells["v_NroLote"].Value == "" ? null : Fila.Cells["v_NroLote"].Value.ToString().Trim());
                decimal stockActual = sa != null ? sa.d_StockActual ?? 0 : 0;
                int ValidarStock = _objMovimientoBL.ValidarStock(ref objOperationResultValidarStock, Fila.Cells["v_IdProductoDetalle"].Value.ToString(), ListaProducto, ListaProductoDetalle);
                if (objOperationResultValidarStock.Success == 0)
                {
                    mensaje = mensaje + "Error Validar Stock" + Fila.Cells["v_CodigoInterno"].Value.ToString().Trim() + "-" + Fila.Cells["v_NombreProducto"].Value.ToString() + "\n";
                }
                if (Fila.Cells["v_IdMovimientoDetalle"].Value != null && Fila.Cells["i_RegistroEstado"].Value != null && Fila.Cells["i_RegistroEstado"].Value.ToString() == "Modificado")
                {
                    decimal stockAnterior = _objMovimientoBL.ObtenerCantidadMovimientoDetalle(ref objOperation, Fila.Cells["v_IdMovimientoDetalle"].Value.ToString());
                    if (ValidarStock == 1 && ValidarStockAlmacen == 1)
                    {

                        if (cantidad > stockActual + stockAnterior)
                        {
                            mensaje = mensaje + " " + " Item: " + Fila.Cells["Index"].Value.ToString().Trim() + " " + Fila.Cells["v_CodigoInterno"].Value.ToString().Trim() + "-" + Fila.Cells["v_NombreProducto"].Value.ToString() + "\n";
                            UltraGridRow Row = grdData.Rows.Where(x => x.Cells["Index"].Value == Fila.Cells["Index"].Value.ToString().Trim()).FirstOrDefault();
                            grdData.Selected.Cells.Add(Row.Cells["Index"]);
                            grdData.Focus();
                            Row.Activate();
                            grdData.ActiveColScrollRegion.Scroll(ColScrollAction.Left);
                            UltraGridCell aCell = this.grdData.ActiveRow.Cells["Index"];
                            this.grdData.ActiveCell = aCell;


                        }
                    }
                }
                else if (Fila.Cells["i_RegistroEstado"].Value != null && Fila.Cells["i_RegistroEstado"].Value.ToString() == "Modificado")
                {
                    if (ValidarStock == 1 && ValidarStockAlmacen == 1)
                    {
                        if (cantidad > stockActual)
                        {
                            mensaje = mensaje + " " + " Item: " + Fila.Cells["Index"].Value.ToString().Trim() + " " + Fila.Cells["v_CodigoInterno"].Value.ToString().Trim() + "-" + Fila.Cells["v_NombreProducto"].Value.ToString() + "\n";

                            UltraGridRow Row = grdData.Rows.Where(x => x.Cells["Index"].Value == Fila.Cells["Index"].Value.ToString().Trim()).FirstOrDefault();
                            grdData.Selected.Cells.Add(Row.Cells["Index"]);
                            grdData.Focus();
                            Row.Activate();
                            grdData.ActiveColScrollRegion.Scroll(ColScrollAction.Left);
                            UltraGridCell aCell = this.grdData.ActiveRow.Cells["Index"];
                            this.grdData.ActiveCell = aCell;

                        }
                    }


                }


            }
            return mensaje;

        }
        private bool ValidaCamposNulosVacios()
        {
            if (grdData.Rows.Where(p => p.Cells["v_IdProductoDetalle"].Value == null || p.Cells["v_IdProductoDetalle"].Value.ToString().Trim() == string.Empty).Count() != 0)
            {
                UltraMessageBox.Show("Por favor ingrese correctamente los productos", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UltraGridRow Row = grdData.Rows.Where(x => x.Cells["v_IdProductoDetalle"].Value == null || x.Cells["v_IdProductoDetalle"].Value.ToString().Trim() == string.Empty).FirstOrDefault();
                grdData.Selected.Cells.Add(Row.Cells["v_CodigoInterno"]);
                grdData.Focus();
                Row.Activate();
                grdData.ActiveColScrollRegion.Scroll(ColScrollAction.Left);
                UltraGridCell aCell = this.grdData.ActiveRow.Cells["v_CodigoInterno"];
                this.grdData.ActiveCell = aCell;
                return false;
            }

            if (grdData.Rows.Where(p => p.Cells["d_Cantidad"].Value == null || p.Cells["d_Cantidad"].Value.ToString().Trim() == string.Empty || decimal.Parse(p.Cells["d_Cantidad"].Value.ToString()) <= 0).Count() != 0)
            {
                UltraMessageBox.Show("Por favor ingrese correctamente la Cantidad", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UltraGridRow Row = grdData.Rows.Where(x => x.Cells["d_Cantidad"].Value == null || x.Cells["d_Cantidad"].Value.ToString().Trim() == string.Empty || decimal.Parse(x.Cells["d_Cantidad"].Value.ToString()) <= 0).FirstOrDefault();
                grdData.Selected.Cells.Add(Row.Cells["d_Cantidad"]);
                grdData.Focus();
                Row.Activate();
                grdData.ActiveColScrollRegion.Scroll(ColScrollAction.Left);
                UltraGridCell aCell = this.grdData.ActiveRow.Cells["d_Cantidad"];
                this.grdData.ActiveCell = aCell;
                return false;
            }


            var FilasSinLote = grdData.Rows.Where(p => p.Cells["i_SolicitarNroLoteSalida"].Value != null && p.Cells["i_SolicitarNroLoteSalida"].Value.ToString() == "1" && (p.Cells["v_NroLote"].Value == null || p.Cells["v_NroLote"].Value.ToString() == "")).ToList();

            if (FilasSinLote.Any())
            {
                UltraMessageBox.Show("Por favor registre el Nro. de Lote para el producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UltraGridRow Fila = FilasSinLote.FirstOrDefault();
                grdData.Focus();
                Fila.Activate();
                Fila.Cells["v_NroLote"].Activate();
                grdData.PerformAction(UltraGridAction.EnterEditModeAndDropdown, true, false);
                return false;
            }


            var FilasConLoteSinSerRequeridas = grdData.Rows.Where(p => p.Cells["i_SolicitarNroLoteSalida"].Value != null && p.Cells["i_SolicitarNroLoteSalida"].Value.ToString() == "0" && (p.Cells["v_NroLote"].Value != null && p.Cells["v_NroLote"].Value != "")).ToList();

            if (FilasConLoteSinSerRequeridas.Any())
            {
                UltraMessageBox.Show("No es necesario registrar el Numero de Lote para este producto", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UltraGridRow Fila = FilasConLoteSinSerRequeridas.FirstOrDefault();
                grdData.Focus();
                Fila.Activate();
                Fila.Cells["v_NroLote"].Activate();
                grdData.PerformAction(UltraGridAction.EnterEditModeAndDropdown, true, false);
                return false;
            }
            var FilasConSerieSinSerRequeridas = grdData.Rows.Where(p => p.Cells["i_SolicitarNroSerieSalida"].Value != null && p.Cells["i_SolicitarNroSerieSalida"].Value.ToString() == "0" && (p.Cells["v_NroSerie"].Value != null && p.Cells["v_NroSerie"].Value != "")).ToList();

            if (FilasConSerieSinSerRequeridas.Any())
            {
                UltraMessageBox.Show("No es necesario registrar el Numero de Serie para este producto", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UltraGridRow Fila = FilasConSerieSinSerRequeridas.FirstOrDefault();
                grdData.Focus();
                Fila.Activate();
                Fila.Cells["v_NroSerie"].Activate();
                grdData.PerformAction(UltraGridAction.EnterEditModeAndDropdown, true, false);
                return false;
            }

            var FilasSinFechaVencimientoLote = grdData.Rows.Where(p => p.Cells["i_SolicitarNroLoteSalida"].Value != null && p.Cells["i_SolicitarNroLoteSalida"].Value.ToString() == "1" && (DateTime.Parse(p.Cells["t_FechaCaducidad"].Value.ToString()) == DateTime.MinValue)).ToList();

            if (FilasSinFechaVencimientoLote.Any())
            {
                UltraMessageBox.Show("Por favor registre la fecha de vencimiento para producto", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UltraGridRow Fila = FilasSinFechaVencimientoLote.FirstOrDefault();
                grdData.Focus();
                Fila.Activate();
                Fila.Cells["t_FechaCaducidad"].Activate();
                grdData.PerformAction(UltraGridAction.EnterEditModeAndDropdown, true, false);
                return false;
            }

            var FilaDebenTenerOrdenProduccion = grdData.Rows.Where(p => p.Cells["i_SolicitaOrdenProduccionSalida"].Value != null && p.Cells["i_SolicitaOrdenProduccionSalida"].Value.ToString() == "1" && (p.Cells["v_NroOrdenProduccion"].Value == null || p.Cells["v_NroOrdenProduccion"].Value.ToString().Trim() == "")).ToList();

            if (FilaDebenTenerOrdenProduccion.Any())
            {
                UltraMessageBox.Show("Por favor registre el Nro. de Orden de Producción para el producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UltraGridRow Fila = FilaDebenTenerOrdenProduccion.FirstOrDefault();
                grdData.Focus();
                Fila.Activate();
                Fila.Cells["v_NroOrdenProduccion"].Activate();
                grdData.PerformAction(UltraGridAction.EnterEditModeAndDropdown, true, false);
                return false;
            }


            var FilasConOrdenProduccionSinSerRequeridas = grdData.Rows.Where(p => p.Cells["i_SolicitaOrdenProduccionSalida"].Value != null && p.Cells["i_SolicitaOrdenProduccionSalida"].Value.ToString() == "0" && (p.Cells["v_NroOrdenProduccion"].Value != null && p.Cells["v_NroOrdenProduccion"].Value != "")).ToList();

            if (FilasConOrdenProduccionSinSerRequeridas.Any())
            {
                UltraMessageBox.Show("No es necesario registrar el Nro. de Orden de Producción para el producto", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UltraGridRow Fila = FilasConOrdenProduccionSinSerRequeridas.FirstOrDefault();
                grdData.Focus();
                Fila.Activate();
                Fila.Cells["v_NroOrdenProduccion"].Activate();
                grdData.PerformAction(UltraGridAction.EnterEditModeAndDropdown, true, false);
                return false;
            }









            return true;
        }

        private void GenerarNumeroRegistro()
        {
            OperationResult objOperationResult = new OperationResult();
            string Mes;
            Mes = int.Parse(dtpFecha.Value.Month.ToString()) <= 9 ? ("0" + dtpFecha.Value.Month.ToString()).Trim() : dtpFecha.Value.Month.ToString();
            _ListadoMovimientosCambioFecha = _objMovimientoBL.ObtenerListadoMovimientos(ref objOperationResult, txtPeriodo.Text.Trim(), Mes, (int)Common.Resource.TipoDeMovimiento.NotadeSalida);
            if (_ListadoMovimientosCambioFecha.Count != 0)
            {
                int MaxMovimiento;
                MaxMovimiento = _ListadoMovimientosCambioFecha.Count() > 0 ? int.Parse(_ListadoMovimientosCambioFecha[_ListadoMovimientosCambioFecha.Count() - 1].Value1.ToString()) : 0;
                MaxMovimiento++;
                txtCorrelativo.Text = MaxMovimiento.ToString("00000000");
                txtMes.Text = int.Parse(dtpFecha.Value.Month.ToString()) <= 9 ? 0 + dtpFecha.Value.Month.ToString() : dtpFecha.Value.Month.ToString();
                txtPeriodo.Text = dtpFecha.Value.Year.ToString();

            }
            else
            {
                txtCorrelativo.Text = Globals.ClientSession.i_IdAlmacenPredeterminado.Value.ToString("00") + "000001";
                txtMes.Text = int.Parse(dtpFecha.Value.Month.ToString()) <= 9 ? 0 + dtpFecha.Value.Month.ToString() : dtpFecha.Value.Month.ToString();
                txtPeriodo.Text = dtpFecha.Value.Year.ToString();
            }

        }
        #endregion

        #region  Grilla
        private void RestringirEdicionGrilla()
        {
            UltraGridColumn c;
            c = grdData.DisplayLayout.Bands[0].Columns["v_NroGuiaRemision"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;

            c = grdData.DisplayLayout.Bands[0].Columns["i_IdTipoDocumento"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;

            c = grdData.DisplayLayout.Bands[0].Columns["v_NumeroDocumento"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;

            c = grdData.DisplayLayout.Bands[0].Columns["d_Cantidad"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;

            c = grdData.DisplayLayout.Bands[0].Columns["i_IdUnidad"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;

            c = grdData.DisplayLayout.Bands[0].Columns["d_Precio"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;

            c = grdData.DisplayLayout.Bands[0].Columns["d_Total"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;


            c = grdData.DisplayLayout.Bands[0].Columns["v_NroPedido"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;

            c = grdData.DisplayLayout.Bands[0].Columns["v_NroPedido"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;

            c = grdData.DisplayLayout.Bands[0].Columns["v_NombreProducto"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;

            c = grdData.DisplayLayout.Bands[0].Columns["StockActual"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;

            c = grdData.DisplayLayout.Bands[0].Columns["UMEmpaque"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;
            c = grdData.DisplayLayout.Bands[0].Columns["Empaque"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;

            c = grdData.DisplayLayout.Bands[0].Columns["v_CodigoInterno"];
            c.CellActivation = Activation.NoEdit;
            c.CellClickAction = CellClickAction.RowSelect;

        }
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdData.ActiveCell == null) return;

            if (this.grdData.ActiveCell.Column.Key != "i_IdTipoDocumento" && grdData.ActiveCell.Column.Key != "i_IdUnidad")
            {

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        grdData.PerformAction(UltraGridAction.ExitEditMode, false, false);
                        grdData.PerformAction(UltraGridAction.AboveCell, false, false);
                        e.Handled = true;
                        grdData.PerformAction(UltraGridAction.EnterEditMode, false, false);
                        break;
                    case Keys.Down:
                        grdData.PerformAction(UltraGridAction.ExitEditMode, false, false);
                        grdData.PerformAction(UltraGridAction.BelowCell, false, false);
                        e.Handled = true;
                        grdData.PerformAction(UltraGridAction.EnterEditMode, false, false);
                        break;
                    case Keys.Right:
                        grdData.PerformAction(UltraGridAction.ExitEditMode, false, false);
                        grdData.PerformAction(UltraGridAction.NextCellByTab, false, false);
                        e.Handled = true;
                        grdData.PerformAction(UltraGridAction.EnterEditMode, false, false);
                        break;
                    case Keys.Left:
                        grdData.PerformAction(UltraGridAction.ExitEditMode, false, false);
                        grdData.PerformAction(UltraGridAction.PrevCellByTab, false, false);
                        e.Handled = true;
                        grdData.PerformAction(UltraGridAction.EnterEditMode, false, false);
                        break;
                    case Keys.Enter:
                        DoubleClickCellEventArgs eventos = new DoubleClickCellEventArgs(grdData.ActiveCell);
                        grdData_DoubleClickCell(sender, eventos);
                        e.Handled = true;
                        break;
                }

            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Right:
                        grdData.PerformAction(UltraGridAction.ExitEditMode, false, false);
                        grdData.PerformAction(UltraGridAction.NextCellByTab, false, false);
                        e.Handled = true;
                        grdData.PerformAction(UltraGridAction.EnterEditMode, false, false);
                        break;
                    case Keys.Left:
                        grdData.PerformAction(UltraGridAction.ExitEditMode, false, false);
                        grdData.PerformAction(UltraGridAction.PrevCellByTab, false, false);
                        e.Handled = true;
                        grdData.PerformAction(UltraGridAction.EnterEditMode, false, false);
                        break;
                }

            }
            if (grdData.ActiveCell != null && grdData.ActiveCell.Column.Key == "v_NroLote")
            {
                if (grdData.ActiveRow.Cells["i_SolicitarNroLoteSalida"].Value != null && grdData.ActiveRow.Cells["i_SolicitarNroLoteSalida"].Value.ToString() == "1")
                    e.SuppressKeyPress = true;
            }
            if (grdData.ActiveCell != null && grdData.ActiveCell.Column.Key == "v_NroSerie")
            {
                if (grdData.ActiveRow.Cells["i_SolicitarNroSerieSalida"].Value != null && grdData.ActiveRow.Cells["i_SolicitarNroSerieSalida"].Value.ToString() == "1")
                    e.SuppressKeyPress = true;
            }

        }
        private void grdData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["i_IdUnidad"].EditorComponent = ucUnidadMedida;
            e.Layout.Bands[0].Columns["i_IdUnidad"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            e.Layout.Bands[0].Columns["i_IdTipoDocumento"].EditorComponent = ucTipoDocumento;
            e.Layout.Bands[0].Columns["i_IdTipoDocumento"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
        }
        private void grdData_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {

            OperationResult objOperationResultValidarStock = new OperationResult();
            int ValidarStockAlmacen = _objAlmacenBL.ObtenerAlmacen(ref objOperationResultValidarStock, int.Parse(cboAlmacen.Value.ToString())).i_ValidarStockAlmacen ?? 0;
            if (int.Parse(cboAlmacen.Value.ToString()) == -1)
            {
                UltraMessageBox.Show("Porfavor seleccione un almacén antes de buscar un producto", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (e.Cell.Column.Key == "v_CodigoInterno")
            {

                if (grdData.Rows[grdData.ActiveRow.Index].Cells["i_RegistroTipo"].Value.ToString() == "Temporal")
                {


                    if (_objPedidoBL.EsValidoCodProducto(e.Cell.Text))
                    {
                        productoshortDto prod = new productoshortDto();
                        var row = grdData.ActiveRow;
                        OperationResult objOperationResult = new OperationResult();
                        prod = _objPedidoBL.DevolverArticuloPorCodInternoNuevo(ref objOperationResult, int.Parse(cboAlmacen.Value.ToString()), e.Cell.Text.Trim().ToUpper()).FirstOrDefault();
                        if (prod != null)
                        {
                            row.Cells["v_NombreProducto"].Value = prod.v_Descripcion;
                            row.Cells["v_IdProductoDetalle"].Value = prod.v_IdProductoDetalle;
                            row.Cells["v_CodigoInterno"].Value = prod.v_CodInterno;
                            row.Cells["i_IdUnidad"].Value = prod.i_IdUnidadMedida;  //Por defecto ,pero si desea el usuario lo puede cambiar
                            row.Cells["i_IdUnidadMedidaProducto"].Value = prod.i_IdUnidadMedida;
                            row.Cells["Empaque"].Value = prod.d_Empaque;
                            row.Cells["UMEmpaque"].Value = prod.EmpaqueUnidadMedida;
                            row.Cells["StockActual"].Value = prod.stockActual;
                            row.Cells["i_RegistroEstado"].Value = "Modificado";
                            row.Cells["v_NroPedido"].Value = prod.v_NroPedidoExportacion;  // Filas[i].Cells["v_NroPedidoExportacion"].Value == null ? Filas[i].Cells["v_NroPedidoExportacion"].Value.ToString() : null;
                            row.Cells["d_Precio"].Value = prod.d_Precio;  //frm._PrecioUnitario.ToString(CultureInfo.CurrentCulture);
                            row.Cells["i_ValidarStock"].Value = prod.i_ValidarStock;
                            row.Cells["i_SolicitarNroSerieSalida"].Value = prod.i_SolicitarNroSerieSalida;
                            row.Cells["i_SolicitarNroLoteSalida"].Value = prod.i_SolicitarNroLoteSalida;
                            row.Cells["i_SolicitaOrdenProduccionSalida"].Value = prod.i_SolicitaOrdenProduccionSalida;
                        }
                        else
                        {
                            UltraMessageBox.Show("El Artículo existe Pero no tuvo ingresos a este almacén", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        }
                    }
                    else
                    {

                        Mantenimientos.frmBuscarProducto frm = new Mantenimientos.frmBuscarProducto(int.Parse(cboAlmacen.Value.ToString()), "Salida", null, grdData.Rows[grdData.ActiveRow.Index].Cells["v_CodigoInterno"].Text == null ? string.Empty : grdData.Rows[grdData.ActiveRow.Index].Cells["v_CodigoInterno"].Text.ToString());
                        frm.ShowDialog();
                        if (frm._NombreProducto != null)
                        {
                            if ((frm._stockActual - frm._SeparaccionTotal <= 0) && frm._ValidarStock == 1 && ValidarStockAlmacen == 1)
                            {

                                UltraMessageBox.Show("El producto tiene Stock 0", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_NombreProducto"].Value = frm._NombreProducto;
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_IdProductoDetalle"].Value = frm._IdProducto;
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_CodigoInterno"].Value = frm._CodigoInternoProducto;
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_IdUnidad"].Value = frm._UnidadMedidaEmpaque ?? string.Empty;  //Por defecto ,pero si desea el usuario lo puede cambiar
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_IdUnidadMedidaProducto"].Value = frm._UnidadMedidaEmpaque != null ? frm._UnidadMedidaEmpaque.ToString() : null;
                                grdData.Rows[grdData.ActiveRow.Index].Cells["Empaque"].Value = frm._Empaque.ToString(CultureInfo.CurrentCulture);
                                grdData.Rows[grdData.ActiveRow.Index].Cells["UMEmpaque"].Value = frm._UnidadMedida ?? string.Empty;
                                grdData.Rows[grdData.ActiveRow.Index].Cells["StockActual"].Value = frm._stockActual.ToString(CultureInfo.CurrentCulture);
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_RegistroEstado"].Value = "Modificado";
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroPedido"].Value = frm._NroPedidoExportacion;  // Filas[i].Cells["v_NroPedidoExportacion"].Value == null ? Filas[i].Cells["v_NroPedidoExportacion"].Value.ToString() : null;
                                grdData.Rows[grdData.ActiveRow.Index].Cells["d_Precio"].Value = frm._PrecioUnitario.ToString(CultureInfo.CurrentCulture);
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_ValidarStock"].Value = frm._ValidarStock.ToString();
                            }
                        }
                    }
                    UltraGridCell aCell = grdData.Rows[e.Cell.Row.Index].Cells["d_Cantidad"];
                    grdData.Rows[e.Cell.Row.Index].Activate();
                    grdData.ActiveCell = aCell;
                    grdData.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    grdData.Focus();
                }
            }

        }
        private void grdData_CellChange(object sender, CellEventArgs e) // cambio en el valor de la celda
        {
            grdData.Rows[e.Cell.Row.Index].Cells["i_RegistroEstado"].Value = "Modificado";
        }
        private void grdData_AfterCellActivate(object sender, EventArgs e) // para obtener el valor de la célula activada por el usuario final
        {
            CalcularValores();
        }
        private void grdData_AfterExitEditMode(object sender, EventArgs e)
        {
            OperationResult objOperation = new OperationResult();
            decimal cantidad, cantidadAnterior;

            int ValidarStockAlmacen = _objAlmacenBL.ObtenerAlmacen(ref objOperation, int.Parse(cboAlmacen.Value.ToString())).i_ValidarStockAlmacen ?? 0;
            //decimal precio, total;
            if (grdData.Rows[grdData.ActiveRow.Index].Cells["v_CodigoInterno"].Value != null)
            {
                if (this.grdData.ActiveCell.Column.Key == "d_Cantidad" | this.grdData.ActiveCell.Column.Key == "d_Precio")
                {
                    if (grdData.Rows[grdData.ActiveRow.Index].Cells["d_Cantidad"].Value == null) return;

                    string stockIngresado = grdData.Rows[grdData.ActiveRow.Index].Cells["d_Cantidad"].Value.ToString();

                    if (strModo == "Edicion" || strModo == "Guardado")
                    {

                        if (Agregado != "Agregado")
                        {
                            stockActual = grdData.Rows[grdData.ActiveRow.Index].Cells["StockActual"].Value == null ? 0 : decimal.Parse(grdData.Rows[grdData.ActiveRow.Index].Cells["StockActual"].Value.ToString());
                            cantidad = decimal.Parse(grdData.Rows[grdData.ActiveRow.Index].Cells["d_Cantidad"].Value.ToString());
                            cantidadAnterior = _objMovimientoBL.ObtenerCantidadMovimientoDetalle(ref objOperation, grdData.Rows[grdData.ActiveRow.Index].Cells["v_IdMovimientoDetalle"].Value.ToString());
                            if (ValidarStockAlmacen == 1 && grdData.Rows[grdData.ActiveRow.Index].Cells["i_ValidarStock"].Value.ToString() == "1")
                            {
                                if (cantidad > cantidadAnterior + stockActual)
                                {
                                    //UltraMessageBox.Show("La Cantidad Ingresada a sobrepasado el stock existente", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                        }
                        else
                        {
                            stockActual = grdData.Rows[grdData.ActiveRow.Index].Cells["StockActual"].Value == null ? 0 : decimal.Parse(grdData.Rows[grdData.ActiveRow.Index].Cells["StockActual"].Value.ToString());
                            cantidad = decimal.Parse(grdData.Rows[grdData.ActiveRow.Index].Cells["d_Cantidad"].Value.ToString());
                            if (ValidarStockAlmacen == 1 && grdData.Rows[grdData.ActiveRow.Index].Cells["i_ValidarStock"].Value.ToString() == "1")
                            {
                                if (decimal.Parse(stockIngresado) > stockActual)
                                {
                                    //UltraMessageBox.Show("La Cantidad Ingresada a sobrepasado el stock existente", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        stockActual = grdData.Rows[grdData.ActiveRow.Index].Cells["StockActual"].Value == null ? 0 : decimal.Parse(grdData.Rows[grdData.ActiveRow.Index].Cells["StockActual"].Value.ToString());
                        if (ValidarStockAlmacen == 1 && grdData.Rows[grdData.ActiveRow.Index].Cells["i_ValidarStock"].Value.ToString() == "1")
                        {
                            if (decimal.Parse(stockIngresado) > stockActual)
                            {
                                //  UltraMessageBox.Show("La Cantidad Ingresada a sobrepasado el stock existente", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);


                            }
                        }
                    }
                    if (grdData.Rows[grdData.ActiveRow.Index].Cells["d_Precio"].Value == null) return;

                }
            }

            if (grdData.ActiveCell.Column.Key == "v_NroGuiaRemision")
            {
                if (grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroGuiaRemision"].Value != null)
                {
                    string NroGuia;
                    NroGuia = grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroGuiaRemision"].Value.ToString();
                    if (NroGuia.Contains("-"))
                    {
                        string[] SerieCorrelativo = new string[2];
                        SerieCorrelativo = NroGuia.Split(new Char[] { '-' });
                        grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroGuiaRemision"].Value = int.Parse(SerieCorrelativo[0]).ToString("0000") + "-" + int.Parse(SerieCorrelativo[1]).ToString("00000000");
                    }
                }
            }

            if (grdData.ActiveCell.Column.Key == "v_NumeroDocumento")
            {
                if (grdData.ActiveRow.Cells["v_NumeroDocumento"].Value != null)
                {
                    var nroGuia = grdData.ActiveRow.Cells["v_NumeroDocumento"].Value.ToString();
                    if (nroGuia.Contains("-"))
                    {
                        var serieCorrelativo = nroGuia.Split('-');
                        int i;
                        var serie = int.TryParse(serieCorrelativo[0], out i) ? i.ToString("0000") : serieCorrelativo[0];
                        grdData.ActiveRow.Cells["v_NumeroDocumento"].Value = serie + "-" + int.Parse(serieCorrelativo[1]).ToString("00000000");
                    }
                }

            }
            if (grdData.ActiveCell.Column.Key.Equals("d_Cantidad") || grdData.ActiveCell.Column.Key.Equals("d_Precio") || grdData.ActiveCell.Column.Key.Equals("i_IdUnidad"))
            {
                CalcularValoresFila(grdData.Rows[grdData.ActiveRow.Index]);
            }
        }
        private void CalcularValoresFila(UltraGridRow Fila)
        {
            decimal precio, total, cantidad;
            cantidad = decimal.Parse(Fila.Cells["d_Cantidad"].Value.ToString());
            precio = Fila.Cells["d_Precio"].Value == null ? (decimal)0 : decimal.Parse(Fila.Cells["d_Precio"].Value.ToString());
            total = Utils.Windows.DevuelveValorRedondeado(cantidad * precio, 2);
            Fila.Cells["d_Total"].Value = total;

            CalcularValores();


        }
        private void CalcularValores()
        {
            decimal Total = 0, TotalCantidad = 0;

            if (_Mode == "Nuevo")
            {
                txtTotal.Text = Total.ToString("0.00");
                txtCantidad.Text = TotalCantidad.ToString();
            }
            else
            {
                foreach (UltraGridRow Fila in grdData.Rows)
                {
                    if (Fila.Cells["d_Total"].Value != null)
                        Total = Total + decimal.Parse(Fila.Cells["d_Total"].Value.ToString());

                    if (Fila.Cells["d_Cantidad"].Value != null)
                        TotalCantidad = TotalCantidad + decimal.Parse(Fila.Cells["d_Cantidad"].Value.ToString());


                    if (Fila.Cells["i_IdUnidad"].Value != null)
                    {
                        decimal CantidadGrilla = Fila.Cells["d_Cantidad"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Cantidad"].Value.ToString());
                        if (Fila.Cells["v_IdProductoDetalle"].Value != null && Fila.Cells["v_IdProductoDetalle"].Value.ToString() != "N002-PE000000000" && Fila.Cells["i_IdUnidad"].Value.ToString() != "-1" && CantidadGrilla != 0)
                        {
                            decimal TotalEmpaque = 0;
                            decimal Empaque = decimal.Parse(Fila.Cells["Empaque"].Value.ToString());
                            string Producto = Fila.Cells["v_IdProductoDetalle"].Value.ToString();
                            decimal Cantidad = decimal.Parse(Fila.Cells["d_Cantidad"].Value.ToString());
                            int UM = int.Parse(Fila.Cells["i_IdUnidad"].Value.ToString());
                            int UMProducto = int.Parse(Fila.Cells["i_IdUnidadMedidaProducto"].Value.ToString());

                            GridKeyValueDTO _UMProducto = ((List<GridKeyValueDTO>)ucUnidadMedida.DataSource).Where(p => p.Id == UMProducto.ToString()).FirstOrDefault();
                            GridKeyValueDTO _UM = ((List<GridKeyValueDTO>)ucUnidadMedida.DataSource).Where(p => p.Id == UM.ToString()).FirstOrDefault();

                            if (_UM != null)
                            {
                                switch (_UM.Value1)
                                {
                                    case "CAJA":
                                        decimal Caja = Empaque * (!string.IsNullOrEmpty(_UMProducto.Value2) ? decimal.Parse(_UMProducto.Value2) : 0);
                                        TotalEmpaque = Cantidad * Caja;
                                        break;

                                    default:
                                        TotalEmpaque = Cantidad * (!string.IsNullOrEmpty(_UM.Value2) ? decimal.Parse(_UM.Value2) : 0);
                                        break;
                                }
                            }
                            Fila.Cells["d_CantidadEmpaque"].Value = TotalEmpaque.ToString();
                        }
                        else
                        {
                            Fila.Cells["d_CantidadEmpaque"].Value = "0";

                        }
                    }

                }
                txtTotal.Text = Total.ToString("0.00");
                txtCantidad.Text = TotalCantidad.ToString();
                FormatoDecimalesTotales((int)Globals.ClientSession.i_CantidadDecimales, (int)Globals.ClientSession.i_PrecioDecimales);
            }

        }
        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            UltraGridCell Celda;
            if (grdData.ActiveCell != null)
            {

                switch (this.grdData.ActiveCell.Column.Key)
                {
                    case "d_Cantidad":

                        Celda = grdData.ActiveCell;
                        Utils.Windows.NumeroDecimalCelda(Celda, e);
                        break;

                    case "d_Precio":

                        Celda = grdData.ActiveCell;
                        Utils.Windows.NumeroDecimalCelda(Celda, e);
                        break;

                    case "d_Total":

                        Celda = grdData.ActiveCell;
                        Utils.Windows.NumeroDecimalCelda(Celda, e);
                        break;

                    case "v_NumeroDocumento":

                    //Celda = grdData.ActiveCell;
                    //Utils.Windows.NumeroDocumentoCelda(Celda, e);
                    //break;

                    case "v_NroGuiaRemision":

                        //Celda = grdData.ActiveCell;
                        //Utils.Windows.NumeroDocumentoCelda(Celda, e);
                        // Utils.Windows.NumeroSerieDocumento(Celda, e);
                        break;

                }
            }
        }
        private void grdData_MouseDown(object sender, MouseEventArgs e)
        {
            if (_movimientoDto.v_OrigenTipo == null)
            {
                var point = new Point(e.X, e.Y);
                var uiElement = ((UltraGridBase)sender).DisplayLayout.UIElement.ElementFromPoint(point);

                if (uiElement == null || uiElement.Parent == null) return;

                var row = (UltraGridRow)uiElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

                btnEliminar.Enabled = row != null;
            }
        }
        private void grdData_InitializeRow(object sender, InitializeRowEventArgs e)
        {

            e.Row.Cells["Index"].Value = (e.Row.Index + 1).ToString("00");
            if (e.Row.Band.Index == 0 && e.Row.Cells["t_FechaCaducidad"].Value != null && DateTime.Parse(e.Row.Cells["t_FechaCaducidad"].Value.ToString()).Date.ToShortDateString() == Constants.FechaNula)
            {
                e.Row.Cells["t_FechaCaducidad"].Appearance.BackColor = Color.White;
                e.Row.Cells["t_FechaCaducidad"].Appearance.ForeColor = Color.White;
            }
        }
        public void RecibirItems(List<UltraGridRow> Filas)
        {
            OperationResult objOperationResultValidarStock = new OperationResult();
            bool ExistenciaGrilla = false, anteriorRegistro = false;
            int ValidarStockAlmacen = _objAlmacenBL.ObtenerAlmacen(ref objOperationResultValidarStock, int.Parse(cboAlmacen.Value.ToString())).i_ValidarStockAlmacen ?? 0;
            bool Saldo0 = false;
            int mensajeEg = 0, cantMensajes = 0;

            for (int i = 0; i < Filas.Count; i++)
            {
                ExistenciaGrilla = false;
                Saldo0 = false;
                //int IdAlmacen = int.Parse(grdData.Rows[grdData.ActiveRow.Index].Cells["i_IdAlmacen"].Value.ToString());
                if (Filas[i].Cells["v_CodInterno"].Value != null)
                {

                    decimal SaldoGrilla = Filas[i].Cells["Saldo"].Value == null ? 0 : decimal.Parse(Filas[i].Cells["Saldo"].Value.ToString());
                    if (SaldoGrilla <= 0 && ValidarStockAlmacen == 1 && int.Parse(Filas[i].Cells["i_ValidarStock"].Value.ToString()) == 1)
                    {
                        if (cantMensajes == 0)
                        {
                            UltraMessageBox.Show("Uno de los productos seleccionados tiene stock  0", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Saldo0 = true;
                            cantMensajes = cantMensajes + 1;
                        }
                        else
                        {
                            Saldo0 = true;
                            cantMensajes = cantMensajes + 1;
                        }

                    }
                }


                foreach (UltraGridRow Fila in grdData.Rows)
                {
                    if (Fila.Cells["v_IdProductoDetalle"].Value != null)
                    {
                        if (Filas[i].Cells["v_IdProductoDetalle"].Value.ToString() == Fila.Cells["v_IdProductoDetalle"].Value.ToString())
                        {
                            if (mensajeEg == 0)
                            {
                                //UltraMessageBox.Show("Uno de los productos seleccionados ya existe en el detalle", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //ExistenciaGrilla = true;
                                //mensajeEg = mensajeEg + 1;
                            }
                            else
                            {
                                // ExistenciaGrilla = true;
                                // mensajeEg = mensajeEg + 1;
                            }

                        }

                    }
                }
                if (i == 0)
                {
                    if (!Saldo0)
                    {
                        if (!ExistenciaGrilla)
                        {
                            grdData.Rows[grdData.ActiveRow.Index].Cells["v_NombreProducto"].Value = Filas[i].Cells["v_Descripcion"].Value.ToString();
                            grdData.Rows[grdData.ActiveRow.Index].Cells["v_IdProductoDetalle"].Value = Filas[i].Cells["v_IdProductoDetalle"].Value.ToString();
                            grdData.Rows[grdData.ActiveRow.Index].Cells["v_CodigoInterno"].Value = Filas[i].Cells["v_CodInterno"].Value.ToString();
                            grdData.Rows[grdData.ActiveRow.Index].Cells["i_IdUnidad"].Value = Filas[i].Cells["i_IdUnidadMedida"].Value == null ? null : Filas[i].Cells["i_IdUnidadMedida"].Value.ToString();  //Por defecto ,pero si desea el usuario lo puede cambiar
                            grdData.Rows[grdData.ActiveRow.Index].Cells["i_IdUnidadMedidaProducto"].Value = Filas[i].Cells["i_IdUnidadMedida"].Value == null ? null : Filas[i].Cells["i_IdUnidadMedida"].Value.ToString();
                            grdData.Rows[grdData.ActiveRow.Index].Cells["d_Cantidad"].Value = Filas[i].Cells["_Cantidad"].Value == null ? 1 : decimal.Parse(Filas[i].Cells["_Cantidad"].Value.ToString());
                            grdData.Rows[grdData.ActiveRow.Index].Cells["d_Precio"].Value = "0";
                            grdData.Rows[grdData.ActiveRow.Index].Cells["i_RegistroEstado"].Value = "Modificado";
                            grdData.Rows[grdData.ActiveRow.Index].Cells["Empaque"].Value = Filas[i].Cells["d_Empaque"].Value == null ? null : Filas[i].Cells["d_Empaque"].Value.ToString();
                            grdData.Rows[grdData.ActiveRow.Index].Cells["UMEmpaque"].Value = Filas[i].Cells["EmpaqueUnidadMedida"].Value == null ? null : Filas[i].Cells["EmpaqueUnidadMedida"].Value.ToString();
                            grdData.Rows[grdData.ActiveRow.Index].Cells["StockActual"].Value = Filas[i].Cells["stockActual"].Value == null ? 0 : decimal.Parse(Filas[i].Cells["stockActual"].Value.ToString());
                            grdData.Rows[grdData.ActiveRow.Index].Cells["i_RegistroTipo"].Value = "Temporal";
                            grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroPedido"].Value = Filas[i].Cells["v_NroPedidoExportacion"].Value == null ? null : Filas[i].Cells["v_NroPedidoExportacion"].Value.ToString();
                            grdData.Rows[grdData.ActiveRow.Index].Cells["d_Precio"].Value = Filas[i].Cells["d_Precio"] == null ? "0" : decimal.Parse(Filas[i].Cells["d_Precio"].Value.ToString()).ToString();
                            grdData.Rows[grdData.ActiveRow.Index].Cells["i_ValidarStock"].Value = Filas[i].Cells["i_ValidarStock"] == null ? 0 : int.Parse(Filas[i].Cells["i_ValidarStock"].Value.ToString());
                            grdData.Rows[grdData.ActiveRow.Index].Cells["i_SolicitarNroSerieSalida"].Value = int.Parse(Filas[i].Cells["i_SolicitarNroSerieSalida"].Value.ToString());
                            grdData.Rows[grdData.ActiveRow.Index].Cells["i_SolicitarNroLoteSalida"].Value = int.Parse(Filas[i].Cells["i_SolicitarNroLoteSalida"].Value.ToString());
                            grdData.Rows[grdData.ActiveRow.Index].Cells["i_SolicitaOrdenProduccionSalida"].Value = int.Parse(Filas[i].Cells["i_SolicitaOrdenProduccionSalida"].Value.ToString());
                            grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroSerie"].Value = Filas[i].Cells["v_NroSerie"].Value == null || Filas[i].Cells["v_NroSerie"].Value == "" ? null : Filas[i].Cells["v_NroSerie"].Value.ToString();
                            grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroLote"].Value = Filas[i].Cells["v_NroLote"].Value == null || Filas[i].Cells["v_NroLote"].Value == "" ? null : Filas[i].Cells["v_NroLote"].Value.ToString();
                            grdData.Rows[grdData.ActiveRow.Index].Cells["t_FechaCaducidad"].Value = Filas[i].Cells["t_FechaCaducidad"].Value == null ? null : Filas[i].Cells["t_FechaCaducidad"].Value.ToString();

                        }
                        else
                        {
                            anteriorRegistro = true;
                        }
                    }
                    else
                    {
                        anteriorRegistro = true;
                    }

                }
                else
                {
                    if (!Saldo0)
                    {
                        if (!ExistenciaGrilla)
                        {

                            if (anteriorRegistro)
                            {
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_NombreProducto"].Value = Filas[i].Cells["v_Descripcion"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_IdProductoDetalle"].Value = Filas[i].Cells["v_IdProductoDetalle"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_CodigoInterno"].Value = Filas[i].Cells["v_CodInterno"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["Empaque"].Value = Filas[i].Cells["d_Empaque"].Value == null ? null : Filas[i].Cells["d_Empaque"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["UMEmpaque"].Value = Filas[i].Cells["EmpaqueUnidadMedida"].Value == null ? null : Filas[i].Cells["EmpaqueUnidadMedida"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["d_Cantidad"].Value = Filas[i].Cells["_Cantidad"].Value == null ? 1 : decimal.Parse(Filas[i].Cells["_Cantidad"].Value.ToString());
                                grdData.Rows[grdData.ActiveRow.Index].Cells["d_Precio"].Value = "0";
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_RegistroEstado"].Value = "Modificado";
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_RegistroTipo"].Value = "Temporal";
                                grdData.Rows[grdData.ActiveRow.Index].Cells["StockActual"].Value = Filas[i].Cells["stockActual"].Value == null ? 0 : decimal.Parse(Filas[i].Cells["stockActual"].Value.ToString());
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_IdUnidad"].Value = Filas[i].Cells["i_IdUnidadMedida"].Value == null ? null : Filas[i].Cells["i_IdUnidadMedida"].Value.ToString();  //Por defecto ,pero si desea el usuario lo puede cambiar
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_IdUnidadMedidaProducto"].Value = Filas[i].Cells["i_IdUnidadMedida"].Value == null ? null : Filas[i].Cells["i_IdUnidadMedida"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroPedido"].Value = Filas[i].Cells["v_NroPedidoExportacion"].Value == null ? null : Filas[i].Cells["v_NroPedidoExportacion"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["d_Precio"].Value = Filas[i].Cells["d_Precio"] == null ? "0" : decimal.Parse(Filas[i].Cells["d_Precio"].Value.ToString()).ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_ValidarStock"].Value = Filas[i].Cells["i_ValidarStock"] == null ? 0 : int.Parse(Filas[i].Cells["i_ValidarStock"].Value.ToString());
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_SolicitarNroSerieSalida"].Value = int.Parse(Filas[i].Cells["i_SolicitarNroSerieSalida"].Value.ToString());
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_SolicitarNroLoteSalida"].Value = int.Parse(Filas[i].Cells["i_SolicitarNroLoteSalida"].Value.ToString());
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_SolicitaOrdenProduccionSalida"].Value = int.Parse(Filas[i].Cells["i_SolicitaOrdenProduccionSalida"].Value.ToString());
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroSerie"].Value = Filas[i].Cells["v_NroSerie"].Value == null || Filas[i].Cells["v_NroSerie"].Value == "" ? null : Filas[i].Cells["v_NroSerie"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroLote"].Value = Filas[i].Cells["v_NroLote"].Value == null || Filas[i].Cells["v_NroLote"].Value == "" ? null : Filas[i].Cells["v_NroLote"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["t_FechaCaducidad"].Value = Filas[i].Cells["t_FechaCaducidad"].Value == null ? null : Filas[i].Cells["t_FechaCaducidad"].Value.ToString();

                                anteriorRegistro = false;

                            }
                            else
                            {
                                UltraGridRow row = grdData.DisplayLayout.Bands[0].AddNew();
                                grdData.Rows.Move(row, grdData.Rows.Count() - 1);
                                this.grdData.ActiveRowScrollRegion.ScrollRowIntoView(row);
                                row.Cells["i_RegistroEstado"].Value = "Agregado";
                                row.Cells["i_RegistroTipo"].Value = "Temporal";
                                row.Cells["i_IdUnidad"].Value = "-1";
                                row.Cells["d_Cantidad"].Value = "1";
                                row.Cells["d_Precio"].Value = "0";
                                row.Cells["i_IdTipoDocumento"].Value = "-1";
                                row.Activate();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_NombreProducto"].Value = Filas[i].Cells["v_Descripcion"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_IdProductoDetalle"].Value = Filas[i].Cells["v_IdProductoDetalle"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_CodigoInterno"].Value = Filas[i].Cells["v_CodInterno"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["Empaque"].Value = Filas[i].Cells["d_Empaque"].Value == null ? null : Filas[i].Cells["d_Empaque"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["UMEmpaque"].Value = Filas[i].Cells["EmpaqueUnidadMedida"].Value == null ? null : Filas[i].Cells["EmpaqueUnidadMedida"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["d_Cantidad"].Value = Filas[i].Cells["_Cantidad"].Value == null ? 1 : decimal.Parse(Filas[i].Cells["_Cantidad"].Value.ToString());
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_IdUnidad"].Value = Filas[i].Cells["i_IdUnidadMedida"].Value == null ? null : Filas[i].Cells["i_IdUnidadMedida"].Value.ToString();  //Por defecto ,pero si desea el usuario lo puede cambiar
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_IdUnidadMedidaProducto"].Value = Filas[i].Cells["i_IdUnidadMedida"].Value == null ? null : Filas[i].Cells["i_IdUnidadMedida"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["d_Precio"].Value = "0";
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_RegistroEstado"].Value = "Modificado";
                                grdData.Rows[grdData.ActiveRow.Index].Cells["StockActual"].Value = Filas[i].Cells["stockActual"].Value == null ? 0 : decimal.Parse(Filas[i].Cells["stockActual"].Value.ToString());
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroPedido"].Value = Filas[i].Cells["v_NroPedidoExportacion"].Value == null ? null : Filas[i].Cells["v_NroPedidoExportacion"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["d_Precio"].Value = Filas[i].Cells["d_Precio"] == null ? "0" : decimal.Parse(Filas[i].Cells["d_Precio"].Value.ToString()).ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_ValidarStock"].Value = Filas[i].Cells["i_ValidarStock"] == null ? 0 : int.Parse(Filas[i].Cells["i_ValidarStock"].Value.ToString());
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_SolicitarNroSerieSalida"].Value = int.Parse(Filas[i].Cells["i_SolicitarNroSerieSalida"].Value.ToString());
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_SolicitarNroLoteSalida"].Value = int.Parse(Filas[i].Cells["i_SolicitarNroLoteSalida"].Value.ToString());
                                grdData.Rows[grdData.ActiveRow.Index].Cells["i_SolicitaOrdenProduccionSalida"].Value = int.Parse(Filas[i].Cells["i_SolicitaOrdenProduccionSalida"].Value.ToString());
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroSerie"].Value = Filas[i].Cells["v_NroSerie"].Value == null || Filas[i].Cells["v_NroSerie"].Value == "" ? null : Filas[i].Cells["v_NroSerie"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroLote"].Value = Filas[i].Cells["v_NroLote"].Value == null || Filas[i].Cells["v_NroLote"].Value == "" ? null : Filas[i].Cells["v_NroLote"].Value.ToString();
                                grdData.Rows[grdData.ActiveRow.Index].Cells["t_FechaCaducidad"].Value = Filas[i].Cells["t_FechaCaducidad"].Value == null ? null : Filas[i].Cells["t_FechaCaducidad"].Value.ToString();
                            }
                        }
                    }
                }
            }
            CalcularValoresDetalle();
        }
        private void CalcularValoresDetalle()
        {
            if (grdData.Rows.Count() == 0) return;
            foreach (UltraGridRow Fila in grdData.Rows)
            {
                CalcularValoresFila(Fila);

            }
        }


        private void FormatoDecimalesGrilla(int DecimalesCantidad, int DecimalesPrecio)
        {
            string FormatoCantidad, FormatoPrecio;
            UltraGridColumn _Cantidad = this.grdData.DisplayLayout.Bands[0].Columns["d_Cantidad"];
            _Cantidad.MaskDataMode = MaskMode.IncludeLiterals;
            _Cantidad.MaskDisplayMode = MaskMode.IncludeLiterals;

            UltraGridColumn _Precio = this.grdData.DisplayLayout.Bands[0].Columns["d_Precio"];
            _Precio.MaskDataMode = MaskMode.IncludeLiterals;
            _Precio.MaskDisplayMode = MaskMode.IncludeLiterals;

            if (DecimalesCantidad > 0)
            {
                string sharp = "n";
                FormatoCantidad = "nnnnnnnnnn.";
                for (int i = 0; i < DecimalesCantidad; i++)
                {
                    FormatoCantidad = FormatoCantidad + sharp;
                }
            }
            else
            {
                FormatoCantidad = "nnnnnnnnnn";
            }

            if (DecimalesPrecio > 0)
            {
                string sharp = "n";
                FormatoPrecio = "nnnnnnnnnn.";
                for (int i = 0; i < DecimalesPrecio; i++)
                {
                    FormatoPrecio = FormatoPrecio + sharp;
                }
            }
            else
            {
                FormatoPrecio = "nnnnnnnnnn";
            }

            _Cantidad.MaskInput = FormatoCantidad;
            _Precio.MaskInput = FormatoPrecio;
        }

        #endregion

        #region CRUD
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarAlmacen.Validate(true, false).IsValid)
            {
                var ultimaFila = grdData.Rows.LastOrDefault();
                if (ultimaFila == null || ultimaFila.Cells["v_IdProductoDetalle"].Value != null)
                {
                    UltraGridRow row = grdData.DisplayLayout.Bands[0].AddNew();
                    grdData.Rows.Move(row, grdData.Rows.Count() - 1);
                    this.grdData.ActiveRowScrollRegion.ScrollRowIntoView(row);
                    row.Cells["i_RegistroEstado"].Value = "Agregado";
                    row.Cells["i_RegistroTipo"].Value = "Temporal";
                    row.Cells["i_IdUnidad"].Value = "-1";
                    row.Cells["i_IdTipoDocumento"].Value = "-1";
                    row.Cells["d_Cantidad"].Value = "1";
                    row.Cells["d_Precio"].Value = "0";
                }

                var aCell = grdData.ActiveRow.Cells["v_CodigoInterno"];
                grdData.Focus();
                grdData.ActiveColScrollRegion.Scroll(ColScrollAction.Left);
                grdData.ActiveCell = aCell;
                grdData.PerformAction(UltraGridAction.EnterEditMode, false, false);
                Agregado = "Agregado";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var objOperationResult = new OperationResult();

            if (uvNotaSalida.Validate(true, false).IsValid)
            {
                if (_movimientoDto.v_IdCliente == null)
                {
                    UltraMessageBox.Show("Por Favor ingrese un Cliente que exista en el Sistema.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCliente.Focus();
                    return;

                }

                if (txtTipoCambio.Text == "")
                {
                    UltraMessageBox.Show("Por Favor ingrese un Tipo de cambio válido ", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTipoCambio.Focus();
                    return;

                }
                else if (decimal.Parse(txtTipoCambio.Text) <= 0)
                {
                    UltraMessageBox.Show("Por Favor ingrese un Tipo de cambio válido ", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTipoCambio.Focus();
                    return;

                }
                if (grdData.Rows.Count == 0)
                {
                    UltraMessageBox.Show("No se permite guardar mientras el detalle está vacío", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ValidaCamposNulosVacios() == true)
                {
                    CalcularValores();
                    if (_Mode == "New")
                    {
                        while (_objMovimientoBL.ExisteNroRegistro(txtPeriodo.Text, txtMes.Text, txtCorrelativo.Text, (int)TipoDeMovimiento.NotadeSalida) == false)
                        {
                            txtCorrelativo.Text = (int.Parse(txtCorrelativo.Text) + 1).ToString("00000000");
                        }
                        _movimientoDto.d_TipoCambio = txtTipoCambio.Text == string.Empty ? 0 : decimal.Parse(txtTipoCambio.Text);
                        _movimientoDto.i_IdAlmacenOrigen = int.Parse(cboAlmacen.Value.ToString());
                        _movimientoDto.i_IdMoneda = int.Parse(cboMoneda.Value.ToString());
                        _movimientoDto.i_IdTipoMotivo = int.Parse(cboMotivo.Value.ToString());
                        _movimientoDto.t_Fecha = dtpFecha.Value;
                        _movimientoDto.v_Glosa = txtGlosa.Text.Trim();
                        _movimientoDto.v_Mes = txtMes.Text.Trim();
                        _movimientoDto.v_Periodo = txtPeriodo.Text.Trim();
                        _movimientoDto.i_IdTipoMovimiento = (int)Common.Resource.TipoDeMovimiento.NotadeSalida;
                        _movimientoDto.v_Correlativo = txtCorrelativo.Text;
                        _movimientoDto.i_EsDevolucion = chkDevolucion.Checked == true ? 1 : 0;
                        _movimientoDto.d_TotalCantidad = txtCantidad.Text == string.Empty ? 0 : decimal.Parse(txtCantidad.Text);
                        _movimientoDto.d_TotalPrecio = txtTotal.Text == string.Empty ? 0 : decimal.Parse(txtTotal.Text);
                        _movimientoDto.i_IdEstablecimiento = int.Parse(cboEstablecimiento.Value.ToString());

                        _movimientoDto.i_IdTipoDocumento = cboTipoDocumento.Value != null ? int.Parse(cboTipoDocumento.Value.ToString()) : -1;
                        _movimientoDto.v_SerieDocumento = txtSerieDoc.Text.Trim();
                        _movimientoDto.v_CorrelativoDocumento = txtNroDoc.Text.Trim();
                        int ValidarStockAlmacen = _objAlmacenBL.ObtenerAlmacen(ref objOperationResult, int.Parse(cboAlmacen.Value.ToString())).i_ValidarStockAlmacen ?? 0;
                        if (ValidarStockAlmacen == 1)
                        {
                            Mensaje = VerificarStockProductoAlmacen();
                            if (Mensaje != "")
                            {
                                UltraMessageBox.Show(MENSAJE + Mensaje, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        // Save the data
                        LlenarTemporales();
                        _objMovimientoBL.InsertarMovimiento(ref objOperationResult, _movimientoDto, Globals.ClientSession.GetAsList(), _TempDetalle_AgregarDto.OrderBy(r => r.CodigoProducto).ToList());
                        if (_ListaDetalleId != null)
                        {
                            FarmaciaBl.Despachar(_ListaDetalleId);
                        }
                        
                    }
                    else if (_Mode == "Edit")
                    {
                        _movimientoDto.d_TipoCambio = txtTipoCambio.Text == string.Empty ? 0 : decimal.Parse(txtTipoCambio.Text);
                        _movimientoDto.i_IdAlmacenOrigen = int.Parse(cboAlmacen.Value.ToString());
                        _movimientoDto.i_IdMoneda = int.Parse(cboMoneda.Value.ToString());
                        _movimientoDto.i_IdTipoMotivo = int.Parse(cboMotivo.Value.ToString());
                        _movimientoDto.t_Fecha = dtpFecha.Value;
                        _movimientoDto.v_Glosa = txtGlosa.Text.Trim();
                        _movimientoDto.v_Mes = txtMes.Text.Trim();
                        _movimientoDto.v_Periodo = txtPeriodo.Text.Trim();
                        _movimientoDto.i_IdTipoMovimiento = (int)Common.Resource.TipoDeMovimiento.NotadeSalida;
                        _movimientoDto.v_Correlativo = txtCorrelativo.Text;
                        _movimientoDto.i_EsDevolucion = chkDevolucion.Checked == true ? 1 : 0;
                        _movimientoDto.d_TotalCantidad = txtCantidad.Text == string.Empty ? 0 : decimal.Parse(txtCantidad.Text);
                        _movimientoDto.d_TotalPrecio = txtTotal.Text == string.Empty ? 0 : decimal.Parse(txtTotal.Text);
                        _movimientoDto.i_IdEstablecimiento = int.Parse(cboEstablecimiento.Value.ToString());
                        _movimientoDto.i_IdTipoDocumento = cboTipoDocumento.Value != null ? int.Parse(cboTipoDocumento.Value.ToString()) : -1;
                        _movimientoDto.v_SerieDocumento = txtSerieDoc.Text.Trim();
                        _movimientoDto.v_CorrelativoDocumento = txtNroDoc.Text.Trim();


                        int ValidarStockAlmacen = _objAlmacenBL.ObtenerAlmacen(ref objOperationResult, int.Parse(cboAlmacen.Value.ToString())).i_ValidarStockAlmacen ?? 0;
                        if (ValidarStockAlmacen == 1)
                        {
                            Mensaje = VerificarStockProductoAlmacenEditado();
                            if (Mensaje != "")
                            {
                                UltraMessageBox.Show(MENSAJE + Mensaje, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                            }
                        }

                        LlenarTemporales();
                        _objMovimientoBL.ActualizarMovimiento(ref objOperationResult, _movimientoDto, Globals.ClientSession.GetAsList(), _TempDetalle_AgregarDto.OrderBy(r => r.CodigoProducto).ToList(), _TempDetalle_ModificarDto.OrderBy(r => r.CodigoProducto).ToList(), _TempDetalle_EliminarDto);

                    }
                    if (objOperationResult.Success == 1)
                    {

                        strModo = "Guardado";
                        EdicionCabecera(true);
                        _pstrIdMovimiento_Nuevo = _movimientoDto.v_IdMovimiento;
                        strIdmovimiento = _pstrIdMovimiento_Nuevo;
                        ObtenerListadoMovimientos(txtPeriodo.Text, txtMes.Text);
                        Agregado = " ";
                        BtnImprimir.Enabled = _btnImprimir;
                        if (UltraMessageBox.Show("N/S se ha guardado correctamente ,¿Desea Generar  Nueva Nota Salida?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                        {
                            strModo = "Nuevo";
                            btnNuevoMovimiento_Click(sender, e);
                        }
                    }
                    else
                    {
                        UltraMessageBox.Show(Constants.GenericErrorMessage, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    _TempDetalle_AgregarDto = new List<movimientodetalleDto>();
                    _TempDetalle_ModificarDto = new List<movimientodetalleDto>();
                    _TempDetalle_EliminarDto = new List<movimientodetalleDto>();

                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow == null) return;

            if (grdData.Rows[grdData.ActiveRow.Index].Cells["i_RegistroTipo"].Value.ToString() == "NoTemporal")
            {
                if (UltraMessageBox.Show("¿Seguro de Eliminar este Registro?", "Sistemas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _movimientodetalleDto = new movimientodetalleDto();
                    _movimientodetalleDto.v_IdMovimientoDetalle = grdData.Rows[grdData.ActiveRow.Index].Cells["v_IdMovimientoDetalle"].Value.ToString();
                    _movimientodetalleDto.i_IdAlmacen = cboAlmacen.Value.ToString();
                    _TempDetalle_EliminarDto.Add(_movimientodetalleDto);
                    grdData.Rows[grdData.ActiveRow.Index].Delete(false);
                    CalcularValores();
                }
            }
            else
            {
                grdData.Rows[grdData.ActiveRow.Index].Delete(false);
                CalcularValores();
            }
            btnCopiarFila.Enabled = false;
        }
        #endregion

        #region ComportamientoControles

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {

            Mantenimientos.frmBuscarCliente frm = new Mantenimientos.frmBuscarCliente("VV", "");
            frm.ShowDialog();

            if (frm._RazonSocial != null)
            {
                txtCliente.Text = frm._RazonSocial.ToString();
                _movimientoDto.v_IdCliente = frm._IdCliente;

            }

        }

        private void txtCorrelativo_TextChanged(object sender, EventArgs e)
        {
            txtCorrelativo.Text = string.Format("{0:00000000}", int.Parse(txtCorrelativo.Text));
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCliente.Text.Trim().Length < 3)
                {

                    UltraMessageBox.Show("Por favor ingrese 3 caracteres para iniciar una búsqueda.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Mantenimientos.frmBuscarCliente frm = new Mantenimientos.frmBuscarCliente("V", txtCliente.Text);
                frm.ShowDialog();
                if (frm._IdCliente != null)
                {
                    txtCliente.Text = frm._RazonSocial;
                    _movimientoDto.v_IdCliente = frm._IdCliente;
                }
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            string TipoCambio = _objMovimientoBL.DevolverTipoCambioPorFecha(ref objOperationResult, dtpFecha.Value.Date);

            if (TipoCambio == "0.0000")
            {
                txtTipoCambio.Text = string.Empty;
            }
            txtTipoCambio.Text = TipoCambio;


            if (strModo == "Nuevo")
            {
                GenerarNumeroRegistro();
            }

            else
            {
                string MesCambiado = int.Parse(dtpFecha.Value.Month.ToString()) <= 9 ? ("0" + dtpFecha.Value.Month.ToString()).Trim() : dtpFecha.Value.Month.ToString();
                string AnioCambiado = dtpFecha.Value.Year.ToString().Trim();
                if (MesCambiado.Trim() != _movimientoDto.v_Mes.Trim() || AnioCambiado != _movimientoDto.v_Periodo.Trim())
                {
                    GenerarNumeroRegistro();

                }
                else
                {
                    txtPeriodo.Text = _movimientoDto.v_Periodo.Trim();
                    txtMes.Text = _movimientoDto.v_Mes.Trim();
                    txtCorrelativo.Text = _movimientoDto.v_Correlativo.Trim();
                }
            }
            if (_objCierreMensualBL.VerificarMesCerrado(txtPeriodo.Text.Trim(), txtMes.Text.Trim(), (int)ModulosSistema.Almacen) || Utilizado == "KARDEX")
            {
                btnGuardar.Visible = false;
                // this.Text = "Nota de Salida [MES CERRADO]";
                this.Text = Utilizado == "KARDEX" ? "Nota de Salida" : "Nota de Salida [MES CERRADO]";
                if (Utilizado == "KARDEX")
                {
                    BtnImprimir.Visible = false;
                    btnSalir.Visible = false;
                    btnAgregar.Visible = false;
                    btnEliminar.Visible = false;


                }
            }
            else
            {
                btnGuardar.Visible = true;
                Text = @"Nota de Salida";
            }

        }

        private void txtMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Windows.NumeroEnteroUltraTextBox(txtMes, e);
        }

        private void txtMes_Leave(object sender, EventArgs e)
        {
            if (txtMes.Text != "")
            {
                var mes = int.Parse(txtMes.Text);
                if (mes >= 1 && mes <= 12)
                {
                    if (strModo == "Nuevo")
                    {
                        ObtenerListadoMovimientos(txtPeriodo.Text, txtMes.Text);
                    }
                    else if (strModo == "Guardado")
                    {
                        strModo = "Consulta";
                        ObtenerListadoMovimientos(txtPeriodo.Text, txtMes.Text);
                    }
                    else
                    {
                        ObtenerListadoMovimientos(txtPeriodo.Text, txtMes.Text);
                    }
                }
                else
                {
                    UltraMessageBox.Show("Mes inválido", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            _IdMovimientoss = _pstrIdMovimiento_Nuevo;
            var frm = new Reportes.Almacen.frmDocumentoNotaSalidaAlmacen(_IdMovimientoss);
            frm.Show();
        }
        #endregion

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            frmMovimientosImportacionExcel frm = new frmMovimientosImportacionExcel();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {

                if (!frm.ListaRetorno.Any()) return;

                grdData.DataSource = frm.ListaRetorno;
                grdData.Rows.ToList().ForEach(row =>
                {
                    row.Cells["i_RegistroTipo"].Value = "Temporal";
                    row.Cells["i_RegistroEstado"].Value = "Modificado";
                    row.Cells["t_FechaCaducidad"].Value = DateTime.Parse(Constants.FechaNula);
                });
                CalcularValoresDetalle();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtProductoIngresar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (txtProductoIngresar.Text.Trim() == "") return;

            var codProd = txtProductoIngresar.Text.Trim();
            var row = grdData.Rows.FirstOrDefault(r => (string)r.GetCellValue("v_CodigoInterno") == codProd);
            if (row != null)
            {
                row.Cells["d_Cantidad"].Value = decimal.Parse(row.GetCellValue("d_Cantidad").ToString()) + 1;
                row.Cells["i_RegistroEstado"].Value = "Modificado";
            }
            else
            {
                var prod = _objMovimientoBL.DevolverArticuloPorCodInterno(codProd, int.Parse(cboAlmacen.Value.ToString()));
                if (prod == null)
                {
                    if (UltraMessageBox.Show(" ¡Producto No encontrado!,Error en Búsqueda¿Desea Continuar?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }
                InvokeOnClick(btnAgregar, e);
                row = grdData.ActiveRow;
                //grdData.Rows.Move(row, 0);
                if (row == null) return;
                if (prod != null)
                {
                    row.Cells["v_NombreProducto"].Value = prod.v_Descripcion.Trim();
                    row.Cells["v_IdProductoDetalle"].Value = prod.v_IdProductoDetalle.Trim();
                    row.Cells["v_CodigoInterno"].Value = prod.v_CodInterno.Trim();
                    row.Cells["Empaque"].Value = prod.d_Empaque.HasValue
                        ? prod.d_Empaque.Value.ToString(CultureInfo.CurrentCulture)
                        : null;
                    row.Cells["UMEmpaque"].Value = prod.EmpaqueUnidadMedida;
                    row.Cells["d_Cantidad"].Value = 1M;
                    row.Cells["d_CantidadEmpaque"].Value = 1M;
                    row.Cells["d_Precio"].Value = 0M;
                    row.Cells["i_RegistroEstado"].Value = "Modificado";
                    row.Cells["i_RegistroTipo"].Value = "Temporal";
                    row.Cells["StockActual"].Value = prod.stockActual ?? 0M;
                    row.Cells["i_IdUnidad"].Value = prod.i_IdUnidadMedida;
                    row.Cells["i_IdUnidadMedidaProducto"].Value = prod.i_IdUnidadMedida;
                    row.Cells["t_FechaCaducidad"].Value = DateTime.Parse(Constants.FechaNula);
                    txtProductoIngresar.Focus();


                }
            }
            grdData.Rows.Move(row, 0);
            if (row != grdData.ActiveRowScrollRegion.FirstRow) grdData.ActiveRowScrollRegion.ScrollRowIntoView(row);
            CalcularValoresFila(row);
            txtProductoIngresar.Clear();
        }



        private void cboMotivo_ValueChanged(object sender, EventArgs e)
        {
            chkDevolucion.Checked = cboMotivo.Value != null && cboMotivo.Value.ToString() == "3";
            chkDevolucion.Enabled = false;
        }

        private void btnCopiarFila_Click(object sender, EventArgs e)
        {
            try
            {
                var fila = grdData.ActiveRow;
                if (fila == null || fila.IsFilterRow || fila.IsGroupByRow) return;
                var elementoFila = (GridmovimientodetalleDto)fila.ListObject;
                var row = grdData.DisplayLayout.Bands[0].AddNew();
                grdData.Rows.Move(row, grdData.Rows.Count() - 1);
                grdData.ActiveRowScrollRegion.ScrollRowIntoView(row);
                row.Cells["i_RegistroEstado"].Value = "Modificado";
                row.Cells["i_RegistroTipo"].Value = "Temporal";
                row.Cells["v_NombreProducto"].Value = elementoFila.v_NombreProducto.Trim();
                row.Cells["v_IdProductoDetalle"].Value = elementoFila.v_IdProductoDetalle;
                row.Cells["v_CodigoInterno"].Value = elementoFila.v_CodigoInterno;
                row.Cells["i_IdUnidad"].Value = elementoFila.i_IdUnidad;
                row.Cells["i_IdUnidadMedidaProducto"].Value = elementoFila.i_IdUnidad;
                row.Cells["Empaque"].Value = elementoFila.Empaque ?? 0;
                row.Cells["UMEmpaque"].Value = elementoFila.UMEmpaque;
                row.Cells["d_Precio"].Value = elementoFila.d_Precio ?? 0;
                row.Cells["i_EsProductoFinal"].Value = elementoFila.i_EsProductoFinal;
                row.Cells["d_Cantidad"].Value = elementoFila.d_Cantidad ?? 0M;
                row.Cells["d_CantidadEmpaque"].Value = elementoFila.d_CantidadEmpaque ?? 0M;
                row.Cells["StockActual"].Value = elementoFila.StockActual ?? 0;
                row.Cells["i_ValidarStock"].Value = elementoFila.i_ValidarStock;
                row.Cells["i_IdTipoDocumento"].Value = elementoFila.i_IdTipoDocumento ?? -1;
                row.Cells["v_NumeroDocumento"].Value = elementoFila.v_NumeroDocumento;
                row.Cells["v_NroGuiaRemision"].Value = elementoFila.v_NroGuiaRemision;
                row.Cells["v_NroPedido"].Value = elementoFila.v_NroPedido;
                row.Cells["EsServicio"].Value = elementoFila.EsServicio ?? 0;
                row.Cells["d_Total"].Value = elementoFila.d_Total ?? 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdData_AfterRowActivate(object sender, EventArgs e)
        {
            var fila = grdData.ActiveRow;
            if (fila == null || fila.IsFilterRow || fila.IsGroupByRow) return;
            btnCopiarFila.Enabled = true;
        }

        private void grdData_ClickCellButton(object sender, CellEventArgs e)
        {
            switch (e.Cell.Column.Key)
            {


            }
        }

        private void btnBuscarTicket_Click(object sender, EventArgs e)
        {
            frmBuscarTicket frm = new frmBuscarTicket();
            frm.ShowDialog();
            var lista = frm.ticketDetalle;
            if (lista == null)
            {
                return;
            }
            _ListaDetalleId = new List<string>();
            foreach (var item in lista)
            {
                _ListaDetalleId.Add(item.v_TicketDetalleId);
            }
            grdData.DataSource = lista;
            grdData.Rows.ToList().ForEach(r =>
            {
                r.Cells["i_RegistroEstado"].Value = "Modificado";
                r.Cells["i_RegistroTipo"].Value = "Temporal";
            });
        }
    }
}
