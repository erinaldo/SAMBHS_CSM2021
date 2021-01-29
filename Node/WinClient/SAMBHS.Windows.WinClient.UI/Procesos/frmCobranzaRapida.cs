﻿using Infragistics.Win.UltraWinGrid;
using SAMBHS.Cobranza.BL;
using SAMBHS.Common.BE;
using SAMBHS.Common.Resource;
using SAMBHS.CommonWIN.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAMBHS.Almacen.BL;
using SAMBHS.Common.BL;
using SAMBHS.Common.DataModel;
using SAMBHS.Requerimientos.NBS;
using SAMBHS.Windows.WinClient.UI.Requerimientos.NotariaBecerraSosaya;
using SAMBHS.Venta.BL;


namespace SAMBHS.Windows.WinClient.UI.Procesos
{
    public partial class frmCobranzaRapida : Form
    {
        CobranzaBL _objCobranzaBL = new CobranzaBL();
        FormaPagoDocumentoBL _objFormaPagoDocumentoBL = new FormaPagoDocumentoBL();
        DocumentoBL _objDocumentoBL = new DocumentoBL();
        DatahierarchyBL _objDatahierarchyBL = new DatahierarchyBL();
        cobranzaDto _cobranzaDto = new cobranzaDto();
        cobranzadetalleDto _cobranzadetalleDto = new cobranzadetalleDto();
        ventaDto _ventaDto = new ventaDto();
        UltraCombo ucTipoDocumento = new UltraCombo();
        List<KeyValueDTO> _ListadoCobranzas = new List<KeyValueDTO>();
        List<GridKeyValueDTO> _ListadoComboDocumentos = new List<GridKeyValueDTO>();
        string _Mode = "New", strModo = "Nuevo", strIdCobranza, _pstrIdMovimiento_Nuevo;
        int _MaxV, _ActV;
        int TipoDocumento;
        int _IdIdentificacion = 0;
        decimal MaxAdelanto, _tipoCambioVenta;
        private decimal _vuelto;
        string _IdVenta;
        readonly int _TipoDocumento;
        int _idMonedaCobranza;
        bool DocumentoImpreso = false;
        bool FormaPagoRequiereNroDocumento = false;
        #region Temporales Detalles de Cobranza
        List<cobranzadetalleDto> _TempDetalle_AgregarDto = new List<cobranzadetalleDto>();
        #endregion
        VentaBL _objVentasBL = new VentaBL();
        decimal montoPago = 0;
        ventadetalleDto _ventadetalleDto = new ventadetalleDto();
        List<ventadetalleDto> _TempDetalle_AgregarDtoVent = new List<ventadetalleDto>();
        List<ventadetalleDto> _TempDetalle_ModificarDto = new List<ventadetalleDto>();
        List<ventadetalleDto> _TempDetalle_EliminarDto = new List<ventadetalleDto>();
        List<KeyValueDTO> ListaVendedores = new List<KeyValueDTO>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdVenta">EL id de la Venta</param>
        /// <param name="Tipodocumento"></param>
        /// <param name="IdIdentificacion">Indica si es ticket boleta o factura en caso d la empresa hormiguita</param>
        public frmCobranzaRapida(string IdVenta, int Tipodocumento, int IdIdentificacion)
        {
            _IdVenta = IdVenta;
            _TipoDocumento = Tipodocumento;
            _IdIdentificacion = IdIdentificacion;
            InitializeComponent();
        }

        private void frmCobranzaRapida_Load(object sender, EventArgs e)
        {
            UltraStatusbarManager.Inicializar(ultraStatusBar1, 0);
            this.BackColor = new GlobalFormColors().FormColor;
            panel1.BackColor = new GlobalFormColors().BannerColor;
            OperationResult objOperationResult = new OperationResult();
            _ListadoComboDocumentos = _objDocumentoBL.ObtenDocumentosCobranzaParaComboGrid(ref objOperationResult, null);
            txtPeriodo.Text = Globals.ClientSession.i_Periodo.ToString();
            txtMes.Text = DateTime.Now.Month.ToString("00");
            var dsFormaPago = _objDatahierarchyBL.GetDataHierarchiesForCombo(ref objOperationResult, 46, null, UserConfig.Default.MostrarSoloFormasPagoAlmacenActual);
            if (dsFormaPago.Any()) dsFormaPago = dsFormaPago.Where(p => !p.Value1.Contains("MIXTO")).ToList();
            Utils.Windows.LoadUltraComboEditorList(cboFormaPago, "Value1", "Id", dsFormaPago, DropDownListAction.Select);
            Utils.Windows.LoadUltraComboList(cboTipoDocumento, "Value1", "Id", _ListadoComboDocumentos, DropDownListAction.Select);
            CargarCombosDetalle();
            CargarDetalle("");
            ObtenerCobranzaPendiente(_IdVenta);
            #region Inicia valor para la forma de pago
            try
            {
                var Doc = ((List<KeyValueDTO>)cboFormaPago.DataSource).FirstOrDefault(p => p.Value1.Contains("EFECTIVO"));

                if (Doc != null)
                {
                    var IdDocumento = Doc.Id;

                    if (IdDocumento != null)
                    {
                        if (_ventaDto.i_IdMoneda == 1)
                        {
                            var DocMoneda = ((List<KeyValueDTO>)cboFormaPago.DataSource).FirstOrDefault(p => p.Value1.Contains("EFECTIVO") && p.Value1.Contains("SOLES"));

                            if (DocMoneda != null)
                            {
                                var idDocumentoMoneda = DocMoneda.Id;
                                cboFormaPago.Value = idDocumentoMoneda ?? IdDocumento;
                            }
                            else
                                cboFormaPago.Value = "-1";
                        }
                        else if (_ventaDto.i_IdMoneda == 9)
                        {
                            var DocMoneda = ((List<KeyValueDTO>)cboFormaPago.DataSource).FirstOrDefault(p => p.Value1.Contains("DEPÓSITO"));

                            if (DocMoneda != null)
                            {
                                var idDocumentoMoneda = DocMoneda.Id;
                                cboFormaPago.Value = idDocumentoMoneda ?? IdDocumento;
                            }
                            else
                                cboFormaPago.Value = "-1";
                        }
                        else
                        {
                            var DocMoneda = ((List<KeyValueDTO>)cboFormaPago.DataSource).FirstOrDefault(p => p.Value1.Contains("EFECTIVO") && p.Value1.Contains("DOLARES"));

                            if (DocMoneda != null)
                            {
                                var idDocumentoMoneda = DocMoneda.Id;
                                cboFormaPago.Value = idDocumentoMoneda ?? IdDocumento;
                            }
                            else
                                cboFormaPago.Value = "-1";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                UltraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            txtMonedaSign.Text = _ventaDto.i_IdMoneda != null && _ventaDto.i_IdMoneda.Value.ToString() == "1" ? "S/." : "US$.";

            dtpFechaRegistro.Value = DateTime.Now;
            
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows(false);
            CalcularTotales();
        }

        public void ObtenerCobranzaPendiente(string IdVenta)
        {
            OperationResult objOperationResult = new OperationResult();
            _ventaDto = _objCobranzaBL.ObtenerCobranzaPendientePorVenta(ref objOperationResult, IdVenta);

            txtMonto.Text = _ventaDto.SaldoPendiente.ToString();
            txtSaldo.Text = _ventaDto.SaldoPendiente.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var objOperationResult = new OperationResult();

                if (uvDatos.Validate(true, false).IsValid)
                {
                    if (!grdData.Rows.Any())
                    {
                        UltraStatusbarManager.MarcarError(ultraStatusBar1, "Ingrese almenos una fila al detalle", timer1);
                        return;
                    }
                    if (_Mode == "New")
                    {
                        var listaDocumentos = grdData.Rows.Select(p => int.Parse(p.Cells["i_IdDocumento"].Value.ToString())).Distinct().ToList();

                        foreach (int documento in listaDocumentos)
                        {
                            _cobranzaDto.v_Correlativo = Utils.Windows.RetornaCorrelativoPorFecha(ref objOperationResult, ListaProcesos.Cobranza, _cobranzaDto.t_FechaRegistro, dtpFechaRegistro.Value, _cobranzaDto.v_Correlativo, documento);

                            var filas = grdData.Rows.Where(x => x.Cells["i_IdDocumento"].Value.ToString() == documento.ToString()).ToList();
                            var _fila = filas.FirstOrDefault();
                            if (_fila != null)
                            {
                                var idMoneda = int.Parse(_fila.Cells["i_IdMoneda"].Value.ToString());
                                while (_objCobranzaBL.ExisteNroRegistro(txtPeriodo.Text, txtMes.Text, _cobranzaDto.v_Correlativo, documento) == false)
                                {
                                    _cobranzaDto.v_Correlativo = (int.Parse(_cobranzaDto.v_Correlativo) + 1).ToString("00000000");
                                }

                                _cobranzaDto.i_IdTipoDocumento = documento;
                                
                                _cobranzaDto.t_FechaRegistro = dtpFechaRegistro.Value.Date;
                                _cobranzaDto.v_Nombre = null;
                                _cobranzaDto.v_Mes = txtMes.Text;
                                _cobranzaDto.v_Periodo = txtPeriodo.Text;
                                _cobranzaDto.d_TipoCambio = _tipoCambioVenta;
                                _cobranzaDto.v_Glosa = @"COBRANZA DEL DÍA " + dtpFechaRegistro.Value.Date.ToShortDateString();
                                _cobranzaDto.v_Mes = txtMes.Text.Trim();
                                _cobranzaDto.v_Periodo = txtPeriodo.Text.Trim();
                                _cobranzaDto.d_TotalSoles = filas.Sum(p => decimal.Parse(p.Cells["d_ImporteSoles"].Value.ToString()));
                                _cobranzaDto.i_IdEstado = 1;
                                _cobranzaDto.i_IdMoneda = idMoneda;
                            }
                            _cobranzaDto.i_IdMedioPago = _objCobranzaBL.DevuelveMedioPago(ref objOperationResult, filas[0].Cells["FormaPago"].Value.ToString());

                            foreach (UltraGridRow Fila in filas)
                            {
                                LlenarTemporalesCobranza(Fila.Cells["FormaPago"].Value.ToString());
                            }

                            _pstrIdMovimiento_Nuevo = _objCobranzaBL.InsertarCobranza(ref objOperationResult, _cobranzaDto, Globals.ClientSession.GetAsList(), _TempDetalle_AgregarDto);
                            _TempDetalle_AgregarDto = new List<cobranzadetalleDto>();
                            _cobranzaDto = new cobranzaDto();
                        }
                    }

                    if (objOperationResult.Success == 1)
                    {
                        strModo = "Guardado";
                        
                        strIdCobranza = _cobranzaDto.v_IdCobranza;
                        UltraStatusbarManager.Mensaje(ultraStatusBar1, "Cobranza Guardada Correctamente", timer1);
                        if (checkPagoCuota.Checked == true)
                        {
                            //string Correlativo = _objDocumentoBL.CorrelativoxSerie(int.Parse(cboDocumento.Value.ToString()), txtSerieDoc.Text);
                            string Correlativo = _objDocumentoBL.CorrelativoxSerie(503, "ICA");
                            var correlativoFinal = new VentaBL().getVentaFinal("");
                            //while (_objVentasBL.ExisteNroRegistro(txtPeriodo.Text, txtMes.Text, txtCorrelativo.Text) == false)
                            //{
                            //    txtCorrelativo.Text = (int.Parse(txtCorrelativo.Text) + 1).ToString("00000000");
                            //}

                            if (_objVentasBL.ExisteNroRegistro(txtPeriodo.Text, txtMes.Text, correlativoFinal.v_Correlativo) == false)
                            {
                                txtCorrelativo.Text = (int.Parse(correlativoFinal.v_Correlativo) + 1).ToString("00000000");

                            }
                            while (_objVentasBL.ExisteDocumento(503, "ICA", Correlativo) == false)
                            {
                                Correlativo = (int.Parse(Correlativo) + 1).ToString("00000000");
                            }
                            int i;
                            string comprobante = "";
                            var _getVentaDTo = new VentaBL().getVentaDTo(ref objOperationResult, _IdVenta); 
                            comprobante = _getVentaDTo.v_SerieDocumento + "-" + _getVentaDTo.v_CorrelativoDocumento;
                            #region Guarda Entidad Venta
                            _ventaDto.i_IdMoneda = 1;
                            _ventaDto.v_Mes = int.Parse(txtMes.Text.Trim()).ToString("00");
                            _ventaDto.v_Periodo = txtPeriodo.Text.Trim();
                            _ventaDto.v_Correlativo = txtCorrelativo.Text;
                            _ventaDto.d_Anticipio = 0;
                            _ventaDto.d_IGV = montoPago - (montoPago / (decimal)1.18);
                            _ventaDto.d_TipoCambio = _tipoCambioVenta;
                            _ventaDto.d_Total = montoPago;
                            _ventaDto.d_Valor = montoPago / (decimal)1.18;
                            _ventaDto.d_ValorVenta = montoPago / (decimal)1.18;
                            _ventaDto.i_DeduccionAnticipio = 0;
                            _ventaDto.i_EsAfectoIgv = 0;
                            _ventaDto.t_FechaRef = DateTime.Today;
                            _ventaDto.t_FechaVencimiento = dtpFechaRegistro.Value;
                            _ventaDto.t_FechaRegistro = dtpFechaRegistro.Value;
                            _ventaDto.i_IdCondicionPago = 1; //contado, credito, 
                            _ventaDto.i_IdEstablecimiento = 1;
                            _ventaDto.i_IdEstado = 1;
                            _ventaDto.i_IdIgv = 1; //evaluar
                            _ventaDto.i_IdMoneda = 1;          //
                            _ventaDto.i_IdTipoDocumento = 503;
                            _ventaDto.i_IdTipoDocumentoRef = -1;
                            _ventaDto.i_PreciosIncluyenIgv = 1;
                            _ventaDto.v_CorrelativoDocumentoRef = string.Empty;
                            _ventaDto.v_Mes = txtMes.Text;
                            _ventaDto.v_Periodo = txtPeriodo.Text;
                            _ventaDto.v_SerieDocumento = "ICA";
                            _ventaDto.v_CorrelativoDocumento = Correlativo;
                            _ventaDto.v_CorrelativoDocumentoFin = string.Empty;
                            _ventaDto.v_Concepto = "ABONO DE DEUDA SALDO PENDIENTE - COMPROBANTE: " + comprobante;
                            _ventaDto.v_SerieDocumentoRef = string.Empty;
                            _ventaDto.d_PorcDescuento = 0;
                            _ventaDto.d_PocComision = 0;
                            _ventaDto.d_Descuento = 0;
                            _ventaDto.v_BultoDimensiones = string.Empty;
                            _ventaDto.v_NroGuiaRemisionCorrelativo = string.Empty;
                            _ventaDto.v_NroGuiaRemisionSerie = string.Empty;
                            _ventaDto.d_IGV = montoPago - (montoPago / (decimal)1.18);
                            _ventaDto.v_Marca = string.Empty;
                            _ventaDto.v_NroBulto = string.Empty;
                            _ventaDto.i_NroDias = 0;
                            _ventaDto.v_NroPedido = string.Empty;
                            _ventaDto.v_OrdenCompra = string.Empty;
                            _ventaDto.d_PesoBrutoKG = 0;
                            _ventaDto.d_PesoNetoKG = 0;
                            _ventaDto.t_FechaOrdenCompra = DateTime.Today;
                            _ventaDto.i_IdMedioPagoVenta = -1;
                            _ventaDto.i_IdPuntoDestino = -1;
                            _ventaDto.i_IdPuntoEmbarque = -1;
                            _ventaDto.i_IdTipoEmbarque = -1;
                            _ventaDto.i_IdTipoDocumentoRef = -1;
                            _ventaDto.v_SerieDocumentoRef = _IdVenta.Split('-')[0];
                            _ventaDto.v_CorrelativoDocumentoRef = _IdVenta.Split('-')[1];
                            _ventaDto.i_IdTipoOperacion = 1;
                            _ventaDto.i_IdTipoNota = -1;
                            _ventaDto.i_IdTipoVenta = 3; //int.Parse(cboTipoVenta.Value.ToString());
                            _ventaDto.i_DrawBack = 0;
                            _ventaDto.v_IdVendedor = Globals.ClientSession.GetAsList()[2];
                            _ventaDto.v_IdVendedorRef = "-1";
                            _ventaDto.v_NombreClienteTemporal = _getVentaDTo.v_NombreClienteTemporal;
                            _ventaDto.v_IdCliente = _getVentaDTo.v_IdCliente;
                            //_ventaDto.v_DireccionClienteTemporal = _ventaDto.v_IdCliente == "N002-CL000000000" ? txtDireccion.Text : string.Empty;
                            _ventaDto.v_DireccionClienteTemporal = _getVentaDTo.v_DireccionClienteTemporal;
                            _ventaDto.NombreCliente = _getVentaDTo.v_NombreClienteTemporal;
                            _ventaDto.i_FacturacionCliente = 1;
                            _ventaDto.v_SigesoftServiceId = "";
                            _ventaDto.i_ClienteEsAgente = 2;
                            LlenarTemporalesVenta(comprobante);
                            string idVentaGuardada = "";
                            _ventaDto.v_IdVenta = idVentaGuardada = _objVentasBL.InsertarVenta(ref objOperationResult, _ventaDto, Globals.ClientSession.GetAsList(), _TempDetalle_AgregarDtoVent);

                            new CobranzaBL().RealizaCobranzaAlContado(ref objOperationResult,
                            1, 1, "ABONO DE DEUDA SALDO PENDIENTE", montoPago, idVentaGuardada,
                            DateTime.Now, _tipoCambioVenta);

                            UltraStatusbarManager.Mensaje(ultraStatusBar1, "Venta guardada correctamente!", timer1);
                            #endregion

                        }
                        btnGuardar.Enabled = false;
                        btnImprimir.Enabled = true;
                        panel1.Enabled = false;
                        string Impresion = Globals.ClientSession.v_ImpresionDirectoVentas;

                        #region Requerimientos para Notaria Becerra Sosaya
                        if (Globals.ClientSession.v_RucEmpresa.Equals(Constants.RucNotariaBecerrSosaya))
                        {
                            var ds = new CobranzaBL().ObtenerCobranzaDetalle(ref objOperationResult, _pstrIdMovimiento_Nuevo);
                            var objDbfSincro = new DbfSincronizador();
                            var objOperationResult2 = new OperationResult();
                            objDbfSincro.RutaDbfCabecera = NBS_DBF_PathSettings.Default.dbfSincro_Cabecera;
                            objDbfSincro.RutaDbfDetalle = NBS_DBF_PathSettings.Default.dbfSincro_Detalle;
                            foreach (var row in ds.Cast<cobranzadetalle>().ToList())
                            {
                                var idVenta = row.v_IdVenta;
                                var idformaPago = row.i_IdFormaPago??1;
                                var idCobranzaDetalle = row.v_IdCobranzaDetalle;
                                var importe = row.d_ImporteSoles??0;
                                objDbfSincro.ActualizarDatosVenta(ref objOperationResult2, idVenta, DbfSincronizador.TipoAccion.Cobranza, 
                                    new DbfSincronizador.DatosCobranza
                                    {
                                        FechaCobranza = dtpFechaRegistro.Value, 
                                        IdFormaPago = idformaPago, 
                                        MontoCobrado = importe, 
                                        IdCobranzaDetalle = idCobranzaDetalle
                                    });
                                if (objOperationResult2.Success == 0)
                                {
                                    MessageBox.Show(objOperationResult2.ErrorMessage,
                                                    @"Error al sincronizar DBF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        #endregion

                        if (Impresion != "1") return;
                        btnImprimir_Click(sender, e);



                        if (UltraMessageBox.Show("¿ Desea Realizar Una Nueva Venta Rapida ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            new LoadingClass.PleaseWait(this.Location, "Por favor espere...");
                            var list =new List<string>();
                            //BindingList<ventadetalleDto> a = new BindingList<ventadetalleDto>();
                            var frm = new frmRegistroVentaRapida("Nuevo", "", list);
                            frm.ShowDialog();

                            Close();
                        }
                        else
                            Close();
                    }
                    else
                    {
                        UltraMessageBox.Show(objOperationResult.ErrorMessage + "\n\n" + objOperationResult.ExceptionMessage + "\n\nTARGET: " + objOperationResult.AdditionalInformation, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    UltraMessageBox.Show("Por favor llene los campos requeridos antes de guardar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void LlenarTemporalesVenta(string comprobante)
        {
            if (grdData.Rows.Count() != 0)
            {
                var objOperationResult = new OperationResult();
                var centroCosto = _objVentasBL.CentroCostoDeEstablecimiento(ref objOperationResult);
                foreach (UltraGridRow Fila in grdData.Rows)
                {
                    switch (Fila.Cells["i_RegistroTipo"].Value.ToString())
                    {
                        case "Temporal":
                            if (Fila.Cells["i_RegistroEstado"].Value.ToString() == "Modificado")
                            {
                                _ventadetalleDto = new ventadetalleDto();
                                _ventadetalleDto.v_IdVenta = _ventaDto.v_IdVenta;
                                _ventadetalleDto.d_Descuento = 0;
                                _ventadetalleDto.i_InsertaIdUsuario = int.Parse(Globals.ClientSession.GetAsList()[2]);
                                _ventadetalleDto.i_IdTipoOperacion = 1;
                                _ventadetalleDto.i_NroUnidades =0;
                                _ventadetalleDto.d_PorcentajeComision = 0 ;
                                _ventadetalleDto.i_NroUnidades = 0;
                                _ventadetalleDto.v_Observaciones = "ABONO DE DEUDA SALDO PENDIENTE - COMPROBANTE: " + comprobante;
                                _ventadetalleDto.v_PedidoExportacion =  null ;
                                _ventadetalleDto.v_FacturaRef =  null ;
                                //_ventadetalleDto.EsServicio = Fila.Cells["i_EsServicio"].Value == null | Fila.Cells["i_EsServicio"].Value.ToString() == "0" ? 0 : 1;
                                _ventadetalleDto.d_Percepcion = 0;
                                _ventadetalleDto.d_PrecioContraparte = 0;
                                _ventadetalleDto.v_NroLote = null ;
                                _ventadetalleDto.t_FechaCaducidad =  null;
                                _ventadetalleDto.i_Anticipio = 0;
                                _ventadetalleDto.i_IdAlmacen = 1;
                                _ventadetalleDto.i_IdCentroCosto = "0";
                                _ventadetalleDto.i_IdUnidadMedida = 15;
                                _ventadetalleDto.ProductoNombre = "";
                                _ventadetalleDto.v_DescripcionProducto = "ABONO DE DEUDA SALDO PENDIENTE - COMPROBANTE: " + comprobante;
                                _ventadetalleDto.v_IdProductoDetalle = "N001-PE000015780";
                                _ventadetalleDto.v_NroCuenta = string.Empty;
                                _ventadetalleDto.d_PrecioVenta = montoPago;
                                _ventadetalleDto.d_Igv = montoPago - (montoPago / (decimal)1.18);
                                _ventadetalleDto.d_Cantidad = 1;
                                _ventadetalleDto.d_CantidadEmpaque = 1;
                                _ventadetalleDto.d_Precio = 0;
                                _ventadetalleDto.d_Valor = montoPago / (decimal)1.18;
                                _ventadetalleDto.d_ValorVenta = montoPago / (decimal)1.18;
                                _ventadetalleDto.d_PrecioImpresion = 0;
                                _ventadetalleDto.v_CodigoInterno = "ATMD01";
                                _ventadetalleDto.Empaque = 1;
                                _ventadetalleDto.UMEmpaque = "UND";
                                _ventadetalleDto.i_EsServicio = 1;
                                _ventadetalleDto.i_IdUnidadMedidaProducto = 15;
                                _ventadetalleDto.v_ServiceId = "";
                                _ventadetalleDto.EmpresaFacturacion = "";
                                _ventadetalleDto.RucEmpFacturacion = "";
                                _TempDetalle_AgregarDtoVent.Add(_ventadetalleDto);
                            }
                            break;

                        case "NoTemporal":
                            if (Fila.Cells["i_RegistroEstado"].Value != null && Fila.Cells["i_RegistroEstado"].Value.ToString() == "Modificado")
                            {
                                _ventadetalleDto = new ventadetalleDto();
                                _ventadetalleDto.v_IdVentaDetalle = Fila.Cells["v_IdVentaDetalle"].Value == null ? null : Fila.Cells["v_IdVentaDetalle"].Value.ToString();
                                _ventadetalleDto.v_IdMovimientoDetalle = Fila.Cells["v_IdMovimientoDetalle"].Value == null ? null : Fila.Cells["v_IdMovimientoDetalle"].Value.ToString();
                                _ventadetalleDto.v_IdVenta = Fila.Cells["v_IdVenta"].Value == null ? null : Fila.Cells["v_IdVenta"].Value.ToString();
                                _ventadetalleDto.v_IdProductoDetalle = Fila.Cells["v_IdProductoDetalle"].Value == null ? null : Fila.Cells["v_IdProductoDetalle"].Value.ToString();
                                _ventadetalleDto.i_IdUnidadMedida = Fila.Cells["i_IdUnidadMedida"].Value == null ? 0 : int.Parse(Fila.Cells["i_IdUnidadMedida"].Value.ToString());
                                _ventadetalleDto.i_IdAlmacen = Fila.Cells["i_IdAlmacen"].Value == null ? 0 : int.Parse(Fila.Cells["i_IdAlmacen"].Value.ToString());
                                _ventadetalleDto.d_Precio = Fila.Cells["d_Precio"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Precio"].Value.ToString());
                                _ventadetalleDto.d_ValorVenta = Fila.Cells["d_ValorVenta"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_ValorVenta"].Value.ToString());
                                _ventadetalleDto.d_Cantidad = Fila.Cells["d_Cantidad"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Cantidad"].Value.ToString());
                                _ventadetalleDto.d_Igv = Fila.Cells["d_Igv"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Igv"].Value.ToString());
                                _ventadetalleDto.d_Descuento = Fila.Cells["d_Descuento"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Descuento"].Value.ToString());
                                _ventadetalleDto.d_Valor = Fila.Cells["d_Valor"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Valor"].Value.ToString());
                                _ventadetalleDto.d_PrecioVenta = Fila.Cells["d_PrecioVenta"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_PrecioVenta"].Value.ToString());
                                _ventadetalleDto.i_Anticipio = Fila.Cells["i_Anticipio"].Value == null ? 0 : int.Parse(Fila.Cells["i_Anticipio"].Value.ToString());
                                _ventadetalleDto.i_InsertaIdUsuario = Fila.Cells["i_InsertaIdUsuario"].Value == null ? 0 : int.Parse(Fila.Cells["i_InsertaIdUsuario"].Value.ToString());
                                _ventadetalleDto.v_NroCuenta = Fila.Cells["v_NroCuenta"].Value == null ? null : Fila.Cells["v_NroCuenta"].Value.ToString().Trim();
                                _ventadetalleDto.i_IdCentroCosto = centroCosto ?? string.Empty;
                                _ventadetalleDto.i_IdTipoOperacion = Fila.Cells["i_IdTipoOperacion"].Value == null ? 0 : int.Parse(Fila.Cells["i_IdTipoOperacion"].Value.ToString());
                                _ventadetalleDto.i_NroUnidades = Fila.Cells["i_NroUnidades"].Value == null ? 0 : int.Parse(Fila.Cells["i_NroUnidades"].Value.ToString());
                                _ventadetalleDto.d_PorcentajeComision = Fila.Cells["d_PorcentajeComision"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_PorcentajeComision"].Value.ToString());
                                _ventadetalleDto.i_NroUnidades = Fila.Cells["i_NroUnidades"].Value == null ? 0 : int.Parse(Fila.Cells["i_NroUnidades"].Value.ToString());
                                _ventadetalleDto.v_Observaciones = Fila.Cells["v_Observaciones"].Value == null ? null : Fila.Cells["v_Observaciones"].Value.ToString();
                                _ventadetalleDto.v_PedidoExportacion = Fila.Cells["v_PedidoExportacion"].Value == null ? null : Fila.Cells["v_PedidoExportacion"].Value.ToString();
                                _ventadetalleDto.v_FacturaRef = Fila.Cells["v_FacturaRef"].Value == null ? null : Fila.Cells["v_FacturaRef"].Value.ToString();
                                _ventadetalleDto.v_DescripcionProducto = Fila.Cells["v_DescripcionProducto"].Value == null ? null : Fila.Cells["v_DescripcionProducto"].Value.ToString();
                                _ventadetalleDto.i_Eliminado = int.Parse(Fila.Cells["i_Eliminado"].Value.ToString());
                                _ventadetalleDto.i_InsertaIdUsuario = int.Parse(Fila.Cells["i_InsertaIdUsuario"].Value.ToString());
                                _ventadetalleDto.t_InsertaFecha = Convert.ToDateTime(Fila.Cells["t_InsertaFecha"].Value);
                                _ventadetalleDto.d_Percepcion = Fila.Cells["d_Percepcion"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_Percepcion"].Value.ToString());
                                _ventadetalleDto.d_CantidadEmpaque = Fila.Cells["d_CantidadEmpaque"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_CantidadEmpaque"].Value.ToString());
                                _ventadetalleDto.d_PrecioContraparte = Fila.Cells["d_PrecioContraparte"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_PrecioContraparte"].Value.ToString());
                                _ventadetalleDto.v_NroLote = Fila.Cells["v_NroLote"].Value == null ? null : Fila.Cells["v_NroLote"].Value.ToString();
                                _ventadetalleDto.t_FechaCaducidad = Fila.Cells["t_FechaCaducidad"].Value == null ? (DateTime?)null : (DateTime?)Fila.Cells["t_FechaCaducidad"].Value;
                                _TempDetalle_ModificarDto.Add(_ventadetalleDto);
                            }
                            break;
                    }
                }
            }

        }

        private void LlenarTemporalesCobranza(string FormaPago)
        {
            if (grdData.Rows.Count() != 0)
            {
                foreach (UltraGridRow Fila in grdData.Rows)
                {
                    if (Fila.Cells["FormaPago"].Text == FormaPago)
                    {
                        switch (Fila.Cells["i_RegistroTipo"].Value.ToString())
                        {
                            case "Temporal":
                                if (Fila.Cells["i_RegistroEstado"].Value.ToString() == "Modificado")
                                {
                                    _cobranzadetalleDto = new cobranzadetalleDto();
                                    _cobranzadetalleDto.d_NetoXCobrar = Fila.Cells["d_NetoXCobrar"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_NetoXCobrar"].Value.ToString());
                                    _cobranzadetalleDto.v_IdVenta = _ventaDto.v_IdVenta;
                                    _cobranzadetalleDto.i_IdTipoDocumentoRef = Fila.Cells["i_IdTipoDocumentoRef"].Value == null ? 0 : int.Parse(Fila.Cells["i_IdTipoDocumentoRef"].Value.ToString());
                                    _cobranzadetalleDto.d_ImporteDolares = Fila.Cells["d_ImporteDolares"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_ImporteDolares"].Value.ToString());
                                    _cobranzadetalleDto.d_ImporteSoles = Fila.Cells["d_ImporteSoles"].Value == null ? 0 : decimal.Parse(Fila.Cells["d_ImporteSoles"].Value.ToString());
                                    _cobranzadetalleDto.v_DocumentoRef = Fila.Cells["v_DocumentoRef"].Value == null ? null : Fila.Cells["v_DocumentoRef"].Value.ToString();
                                    _cobranzadetalleDto.i_IdFormaPago = Fila.Cells["i_IdFormaPago"].Value == null ? 0 : int.Parse(Fila.Cells["i_IdFormaPago"].Value.ToString());
                                    _cobranzadetalleDto.v_Observacion = Fila.Cells["v_Observacion"].Value == null ? null : Fila.Cells["v_Observacion"].Value.ToString();
                                    _cobranzadetalleDto.Moneda = txtMoneda.Text.Trim();
                                    _TempDetalle_AgregarDto.Add(_cobranzadetalleDto);
                                }
                                break;
                        }
                    }
                }
            }

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            //||  
            if (cboTipoDocumento.Value == null || cboTipoDocumento.Value.ToString() == "-1")
            {
                UltraMessageBox.Show("No se relacionó correctamente la forma de pago con un documento.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoDocumento.Focus();
                return;
            }

            if (_tipoCambioVenta <= 0)
            {
                UltraMessageBox.Show("Por favor ingrese un tipo de cambio para la fecha de cobranza", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoDocumento.Focus();
                return;
            }

            if (FormaPagoRequiereNroDocumento && string.IsNullOrEmpty(txtDocumento.Text.Trim()))
            {
                txtDocumento.Focus();
                return;
            }

            if (cboFormaPago.Text.Contains("ADELANTO") && MaxAdelanto == 0)
            {
                UltraMessageBox.Show("Por favor ingrese un documento de adelanto válido", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDocumento.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(txtMonto.Text.Trim()))
            {
                montoPago = decimal.Parse(txtMonto.Text.ToString());
                var montoEquivalente = DevuelveMontoPorCobrar(_idMonedaCobranza, _ventaDto.i_IdMoneda.Value, decimal.Parse(txtMonto.Text));
                if (montoEquivalente <= 0)
                {
                    UltraMessageBox.Show("Por favor ingrese un monto correcto", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMonto.Focus();
                    return;
                }
                if (montoEquivalente > decimal.Parse(txtSaldo.Text) && !cboFormaPago.Text.Contains("EFECTIVO"))
                {
                    UltraMessageBox.Show("Por favor ingrese un monto correcto", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMonto.Focus();
                    return;
                }

                if (grdData.Rows.Any(fila => fila.Cells["FormaPago"].Value.ToString() == cboFormaPago.Text))
                {

                    txtMonto.Clear();
                    CalcularTotales();
                    montoPago = decimal.Parse(txtMonto.Text.ToString());
                    if (txtSaldo.Text != _ventaDto.SaldoPendiente.ToString()) txtMonto.Focus();
                    btnCobrar.Enabled = false;
                    CalcularValoresDetalle();
                    return;
                }

                UltraGridRow row = grdData.DisplayLayout.Bands[0].AddNew();
                grdData.Rows.Move(row, grdData.Rows.Count() - 1);
                string IdTipoDocumento = "-1";
                this.grdData.ActiveRowScrollRegion.ScrollRowIntoView(row);
                row.Cells["i_RegistroEstado"].Value = "Modificado";
                row.Cells["i_RegistroTipo"].Value = "Temporal";
                row.Cells["v_IdVenta"].Value = _ventaDto.v_IdVenta;

                if (FormaPagoRequiereNroDocumento)
                {
                    string Valor = ((KeyValueDTO)cboFormaPago.SelectedItem.ListObject).Value3;
                    IdTipoDocumento = !string.IsNullOrEmpty(Valor) ? Valor : "-1";
                }

                row.Cells["i_IdTipoDocumentoRef"].Value = IdTipoDocumento;
                row.Cells["v_DocumentoRef"].Value = txtDocumento.Text.Trim();
                row.Cells["v_Observacion"].Value = txtObservacion.Text.Trim();
                row.Cells["i_IdMoneda"].Value = _ventaDto.i_IdMoneda.ToString();
                row.Cells["d_NetoXCobrar"].Value = DevuelveMontoPorCobrar(_ventaDto.i_IdMoneda.Value, _idMonedaCobranza ,
                    decimal.Parse(txtSaldo.Text.Trim()));
                row.Cells["d_ImporteSoles"].Value = _ventaDto.i_IdMoneda.Value == _idMonedaCobranza ? (decimal.Parse(txtMonto.Text.Trim()) - _vuelto) : decimal.Parse(txtMonto.Text.Trim());
                row.Cells["d_ImporteDolares"].Value = _idMonedaCobranza == 1
                    ? Utils.Windows.DevuelveValorRedondeado(decimal.Parse(row.Cells["d_ImporteSoles"].Value.ToString()) / _tipoCambioVenta, 2) : Utils.Windows.DevuelveValorRedondeado(decimal.Parse(row.Cells["d_ImporteSoles"].Value.ToString()) * _tipoCambioVenta, 2);
                row.Cells["FormaPago"].Value = cboFormaPago.Text;
                row.Cells["i_IdFormaPago"].Value = cboFormaPago.Value.ToString();
                row.Cells["i_IdDocumento"].Value = cboTipoDocumento.Value.ToString();
                row.Cells["i_IdMoneda"].Value = _idMonedaCobranza;
                txtMonto.Clear();
                CalcularTotales();
                if (txtSaldo.Text != _ventaDto.SaldoPendiente.ToString()) txtMonto.Focus();
                btnCobrar.Enabled = false;
                CalcularValoresDetalle();
                txtMonto.ReadOnly = false;
                txtDocumento.Clear();
                txtObservacion.Clear();
                _vuelto = 0;
                grdData.DisplayLayout.Bands[0].Columns["d_ImporteDolares"].Hidden = grdData.Rows.All(f => f.Cells["i_IdMoneda"].Value.ToString() == _ventaDto.i_IdMoneda.Value.ToString());
            }
            else
            {
                btnCobrar.Enabled = false;
            }
        }
        
        private void CargarDetalle(string pstringIdCobranza)
        {
            OperationResult objOperationResult = new OperationResult();
            try
            {
                grdData.DataSource = _objCobranzaBL.ObtenerCobranzaDetalle(ref objOperationResult, pstringIdCobranza);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            for (int i = 0; i < grdData.Rows.Count(); i++)
            {
                grdData.Rows[i].Cells["i_RegistroTipo"].Value = "NoTemporal";
            }
        }

        private void cboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void txtMonto_Validating(object sender, CancelEventArgs e)
        {
            if (cboFormaPago.Text == "ADELANTO" && MaxAdelanto > 0)
            {
                if (!string.IsNullOrEmpty(txtMonto.Text) && decimal.Parse(txtMonto.Text) > MaxAdelanto)
                {
                    UltraMessageBox.Show("El monto ingresado no puede sobrepasar el monto del Adelanto", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            if (cboFormaPago.Value != null && (!string.IsNullOrEmpty(txtMonto.Text.Trim()) && cboFormaPago.Value.ToString() != "-1" && decimal.Parse(txtSaldo.Text) > 0))
            {
                btnCobrar.Enabled = true;
            }
            else
            {
                btnCobrar.Enabled = false;
            }
        }

        private void CalcularTotales()
        {
            decimal sumNetoXCobrar = 0;
            if (grdData.Rows.Any())
            {
                foreach (var fila in grdData.Rows)
                {
                    if (fila.Cells["d_ImporteSoles"].Value == null) { fila.Cells["d_ImporteSoles"].Value = "0"; }
                    var importeDetalle = decimal.Parse(fila.Cells["d_ImporteSoles"].Value.ToString());
                    var monedaDetalle = int.Parse(fila.Cells["i_IdMoneda"].Value.ToString());
                    sumNetoXCobrar += DevuelveMontoPorCobrar(monedaDetalle,_ventaDto.i_IdMoneda.Value, importeDetalle);
                }
            }
            else
                sumNetoXCobrar = 0;

            var saldo = (_ventaDto.SaldoPendiente - sumNetoXCobrar);
            txtSaldo.Text = saldo.ToString("0.00");
            if (decimal.Parse(txtSaldo.Text) < -0.01M)
            {
                btnImprimir.Enabled = false;
                btnGuardar.Enabled = false;
                UltraStatusbarManager.MarcarError(ultraStatusBar1, "El saldo no puede ser negativo.!", timer1);
            }
            else
            {
                btnGuardar.Enabled = true;
                UltraStatusbarManager.Reestablecer(ultraStatusBar1, timer1);
            }
        }

        private void CalcularValoresDetalle()
        {
            if (!grdData.Rows.Any()) return;
            foreach (var fila in grdData.Rows)
            {
                CalcularValoresFila(fila);
            }
        }

        private void CalcularValoresFila(UltraGridRow Fila)
        {
            CalcularTotales();
        }

        private void grdData_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new System.Drawing.Point(e.X, e.Y);
            Infragistics.Win.UIElement uiElement = ((Infragistics.Win.UltraWinGrid.UltraGridBase)sender).DisplayLayout.UIElement.ElementFromPoint(point);

            if (uiElement == null || uiElement.Parent == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridRow row = (Infragistics.Win.UltraWinGrid.UltraGridRow)uiElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (row == null)
            {
                btnEliminarDetalle.Enabled = false;
            }
            else
            {
                btnEliminarDetalle.Enabled = true;
            }
        }

        private void frmCobranzaRapida_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (strModo == "Nuevo" || strModo == "Edicion")
            {
                e.Cancel = UltraMessageBox.Show("¿Seguro de Salir del Formulario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes;
            }
            else
            {
                if (!DocumentoImpreso)
                {
                    if (UltraMessageBox.Show("¿Seguro de Salir sin Imprimir el Voucher?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        btnImprimir.Focus();
                        e.Cancel = true;
                    }
                }
            }

            if (Application.OpenForms["frmBandejaPedidosFacturados"] == null) return;
            var bandejaPendidosFacturados = (frmBandejaPedidosFacturados)Application.OpenForms["frmBandejaPedidosFacturados"];
            bandejaPendidosFacturados.Close();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Windows.NumeroDecimalUltraTextBox(txtMonto, e);

        }

        private void CargarCombosDetalle()
        {
            OperationResult objOperationResult = new OperationResult();

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
            _ultraGridBanda.Columns.AddRange(new object[] { _ultraGridColumnaID, _ultraGridColumnaDescripcion, _ultraGridColumnaSiglas });
            ucTipoDocumento.DisplayLayout.BandsSerializer.Add(_ultraGridBanda);
            ucTipoDocumento.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            ucTipoDocumento.DropDownWidth = 330;
            #endregion

            Utils.Windows.LoadUltraComboList(ucTipoDocumento, "Value2", "Id", _objDocumentoBL.ObtenDocumentosParaComboGridTesoreria(ref objOperationResult, null), DropDownListAction.Select);
        }

        private void grdData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["i_IdTipoDocumentoRef"].EditorComponent = ucTipoDocumento;
            e.Layout.Bands[0].Columns["i_IdTipoDocumentoRef"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
        }

        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDocumento.Text) && cboFormaPago.Value.ToString() != "-1")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtDocumento.Text.Contains("-"))
                    {
                        string[] SerieCorrelativo = new string[2];
                        SerieCorrelativo = txtDocumento.Text.Split('-');
                        try
                        {
                            int serie, correlativo;
                            if (int.TryParse(SerieCorrelativo[0], out serie) && int.TryParse(SerieCorrelativo[1], out correlativo))
                            {
                                txtDocumento.Text = serie.ToString("0000") + "-" + correlativo.ToString("00000000");
                            }
                        }
                        catch (Exception ex)
                        {
                            UltraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MaxAdelanto = 0;
                        return;
                    }

                    var xx = (KeyValueDTO)cboFormaPago.SelectedItem.ListObject;
                    switch (xx.Value3)
                    {
                        case "7":
                            if (txtDocumento.Text.Contains("-"))
                            {
                                txtMonto.Text = _objCobranzaBL.DevuelveMontoNotaCredito(txtDocumento.Text.Trim()).ToString("0.00");
                                txtMonto.ReadOnly = true;
                            }
                            break;

                        case "433":
                            if (txtDocumento.Text.Contains("-"))
                            {
                                txtMonto.Text = _objCobranzaBL.DevuelveSaldoAdelanto(txtDocumento.Text.Trim()).ToString("0.00");
                                MaxAdelanto = decimal.Parse(txtMonto.Text);
                                txtMonto.ReadOnly = false;
                            }
                            else
                            {
                                MaxAdelanto = 0;
                            }
                            break;
                    }
                }
            }
            else
            {
                //txtMonto.Text = "0";
                MaxAdelanto = 0;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var Ruc = new NodeBL().ReporteEmpresa().FirstOrDefault().RucEmpresaPropietaria.Trim();
            string RUC = Ruc;
            switch (RUC)
            {
                case "20513176962":

                    if (_TipoDocumento == (int)DocumentType.TicketBoleta)
                    {
                        var idVentas = _IdVenta.Split(',');
                        //Reportes.Ventas.Ablimatex.frmDocumentoTicketSinRuc frm1 = new Reportes.Ventas.Ablimatex.frmDocumentoTicketSinRuc(__IdVentas, _IdIdentificacion, false);
                        //frm1.ShowDialog();
                        var t = new Reportes.Ventas.Ablimatex.Ticket(idVentas);
                        t.Print();
                        DocumentoImpreso = true;
                    }

                    break;
                default:
                    if (Globals.ClientSession.i_PrecioDecimales != null)
                    {
                        Reportes.Cobranza.frmDocumentoVoucher frm = new Reportes.Cobranza.frmDocumentoVoucher(_IdVenta, (int)Globals.ClientSession.i_PrecioDecimales, "COBRANZA RAPIDA");
                        frm.ShowDialog();
                    }
                    DocumentoImpreso = true;
                    break;
            }
        }

        private void txtDocumento_Validated(object sender, EventArgs e)
        {
            txtDocumento_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }

        private void cboTipoDocumento_AfterDropDown(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in cboTipoDocumento.Rows)
            {
                if (cboTipoDocumento.Value != null && cboTipoDocumento.Value.ToString() == "-1") cboTipoDocumento.Text = string.Empty;
                bool filterRow = true;
                foreach (UltraGridColumn column in cboTipoDocumento.DisplayLayout.Bands[0].Columns)
                {
                    if (column.IsVisibleInLayout)
                    {
                        if (row.Cells[column].Text.Contains(cboTipoDocumento.Text.ToUpper()))
                        {
                            filterRow = false;
                            break;
                        }
                    }
                }
                row.Hidden = filterRow;

            }
        }

        private void cboTipoDocumento_Leave(object sender, EventArgs e)
        {
            if (cboTipoDocumento.Text.Trim() == "")
            {
                cboTipoDocumento.Value = "-1";
            }
            else
            {
                var x = _ListadoComboDocumentos.Find(p => p.Id == cboTipoDocumento.Value.ToString() || p.Id == cboTipoDocumento.Text);
                if (x == null)
                {
                    cboTipoDocumento.Value = "-1";
                }
            }
        }

        private void cboTipoDocumento_ValueChanged(object sender, EventArgs e)
        {
            if (cboTipoDocumento.Value != null && cboTipoDocumento.Value.ToString() != "-1")
            {
                if (!_objDocumentoBL.TieneCuentaValida(int.Parse(cboTipoDocumento.Value.ToString())))
                {
                    UltraMessageBox.Show("El documento con el que intenta pagar no tiene una cuenta contable válida relacionada. \nModifique la información del documento e ingrésele una cuenta válida.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboTipoDocumento.Value = "-1";
                    return;
                }
                txtSiglas.Text = ((GridKeyValueDTO)cboTipoDocumento.ActiveRow.ListObject).Value2;
            }
            else
            {
                txtSiglas.Clear();
            }
        }

        private void cboTipoDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in cboTipoDocumento.Rows)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    return;
                }
                bool filterRow =
                    cboTipoDocumento.DisplayLayout.Bands[0].Columns.Cast<UltraGridColumn>()
                        .Where(column => column.IsVisibleInLayout)
                        .All(column => !row.Cells[column].Text.Contains(cboTipoDocumento.Text.ToUpper()));
                row.Hidden = filterRow;
            }
        }

        private void dtpFechaRegistro_ValueChanged(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            txtPeriodo.Text = dtpFechaRegistro.Value.Year.ToString();
            txtMes.Text = dtpFechaRegistro.Value.Month.ToString("00");
            txtCorrelativo.Text = Utils.Windows.RetornaCorrelativoPorFecha(ref objOperationResult, ListaProcesos.Cobranza, _cobranzaDto.t_FechaRegistro, dtpFechaRegistro.Value, _cobranzaDto.v_Correlativo, 0);
            _tipoCambioVenta = decimal.Parse(_objCobranzaBL.DevolverTipoCambioPorFecha(ref objOperationResult, dtpFechaRegistro.Value.Date));
            UltraStatusbarManager.Inicializar(ultraStatusBar1, _tipoCambioVenta);
        }

        private void cboFormaPago_TextChanged(object sender, EventArgs e)
        {
            cboTipoDocumento.Value = _objFormaPagoDocumentoBL.DevuelveComprobantePorFormaPago(int.Parse(cboFormaPago.Value.ToString()), out FormaPagoRequiereNroDocumento, out _idMonedaCobranza).ToString();

            if (cboFormaPago.Value.ToString() != "-1" && decimal.Parse(txtSaldo.Text) > 0)
            {
                btnCobrar.Enabled = true;
                txtMoneda.Text = _idMonedaCobranza.ToString() == "1" ? "S/." : "US$.";
                txtMonto.ReadOnly = cboTipoDocumento.Value.ToString() == "7" || cboTipoDocumento.Value.ToString() == "8";
                txtDocumento.Enabled = true;
                txtMonto.Text = DevuelveMontoPorCobrar(_ventaDto.i_IdMoneda.Value,_idMonedaCobranza, decimal.Parse(txtSaldo.Text.Trim())).ToString();
            }
            else
                btnCobrar.Enabled = false;

            if (cboTipoDocumento.Value.ToString() != "-1")
            {
                txtSiglas.Text = ((GridKeyValueDTO)cboTipoDocumento.ActiveRow.ListObject).Value2;
                cboTipoDocumento.Enabled = false;
            }
            else
            {
                txtSiglas.Clear();
                cboTipoDocumento.Enabled = true;
            }
        }

        private void txtMonto_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMonto.Text.Trim()) || decimal.Parse(txtSaldo.Text.Trim()) == 0) return;

            if ((decimal.Parse(txtMonto.Text.Trim()) > decimal.Parse(txtSaldo.Text)) && cboFormaPago.Text.Contains("EFECTIVO"))
            {
                var saldo = decimal.Parse(txtSaldo.Text.Trim());
                var monto = decimal.Parse(txtMonto.Text.Trim());
                _vuelto = monto - saldo;
                UltraStatusbarManager.Mensaje(ultraStatusBar1, string.Format("Vuelto: {0}", _vuelto), timer1);
            }
            else
            {
                _vuelto = 0;
                UltraStatusbarManager.Reestablecer(ultraStatusBar1, timer1);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private decimal DevuelveMontoPorCobrar(int idMonedaVenta, int idMonedaCobranza, decimal saldoVenta)
        {
            try
            {
                if (idMonedaVenta == idMonedaCobranza) return saldoVenta;
                switch (idMonedaCobranza)
                {
                    case 1: return Utils.Windows.DevuelveValorRedondeado(saldoVenta * _tipoCambioVenta, 2);
                    case 2: return Utils.Windows.DevuelveValorRedondeado(saldoVenta / _tipoCambioVenta, 2);
                }

                return saldoVenta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
