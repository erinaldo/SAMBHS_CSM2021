﻿using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
namespace SAMBHS.Windows.WinClient.UI.Procesos
{
    partial class frmBandejaRegistroVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (_tarea != null)
                {
                    _tarea.Dispose();
                    _tarea = null;
                }
                if (_cts != null)
                    _cts.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Misc.UltraLabel ultraLabel1;
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NroRegistro");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Documento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("t_FechaRegistro");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("t_FechaEmision");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_Total");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_IdEstado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("t_InsertaFecha", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("t_ActualizaFecha");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TieneGRM");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_UsuarioCreacion", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_UsuarioModificacion", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda", 2);
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("Total", Infragistics.Win.UltraWinGrid.SummaryType.Custom, null, "d_Total", 7, true, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, null, -1, false);
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("btnBuscarCliente");
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton("btnEliminar");
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Value1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Value2");
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            this.groupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnObsv = new System.Windows.Forms.Button();
            this.btnEazyPay = new System.Windows.Forms.Button();
            this.btnEgreso = new System.Windows.Forms.Button();
            this.btnProduccion = new System.Windows.Forms.Button();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.btnCuadreCaja = new System.Windows.Forms.Button();
            this.pbRecalculandoStock = new System.Windows.Forms.PictureBox();
            this.pBuscando = new System.Windows.Forms.Panel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHistorial = new Infragistics.Win.Misc.UltraButton();
            this.lblDocumentoExportado = new Infragistics.Win.Misc.UltraLabel();
            this.btnExportarBandeja = new Infragistics.Win.Misc.UltraButton();
            this.chkFiltroPersonalizado = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkBandejaAgrupable = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnEliminar = new Infragistics.Win.Misc.UltraButton();
            this.btnEditar = new Infragistics.Win.Misc.UltraButton();
            this.btnAgregar = new Infragistics.Win.Misc.UltraButton();
            this.btnVentaRapida = new Infragistics.Win.Misc.UltraButton();
            this.grdData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.lblContadorFilas = new Infragistics.Win.Misc.UltraLabel();
            this.groupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.chkAllSales = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtDNIPAc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblDniPac = new Infragistics.Win.Misc.UltraLabel();
            this.txtNombrePac = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblNombrePac = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.rbPaciente = new System.Windows.Forms.RadioButton();
            this.rbVenta = new System.Windows.Forms.RadioButton();
            this.cboTipoServicio = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.cboTipoOperacion = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label40 = new Infragistics.Win.Misc.UltraLabel();
            this.cboMoneda = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnBuscar = new Infragistics.Win.Misc.UltraButton();
            this.txtCliente = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label7 = new Infragistics.Win.Misc.UltraLabel();
            this.cboTipoDocumento = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.txtCorrelativoDoc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtSerieDoc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new Infragistics.Win.Misc.UltraLabel();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new Infragistics.Win.Misc.UltraLabel();
            this.uvDatos = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.frmBandejaRegistroVenta_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecalculandoStock)).BeginInit();
            this.pBuscando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFiltroPersonalizado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBandejaAgrupable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNIPAc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombrePac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoServicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoOperacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorrelativoDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerieDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.frmBandejaRegistroVenta_Fill_Panel.ClientArea.SuspendLayout();
            this.frmBandejaRegistroVenta_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            ultraLabel1.AutoSize = true;
            ultraLabel1.Location = new System.Drawing.Point(410, 88);
            ultraLabel1.Name = "ultraLabel1";
            ultraLabel1.Size = new System.Drawing.Size(48, 14);
            ultraLabel1.TabIndex = 103;
            ultraLabel1.Text = "Moneda:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnObsv);
            this.groupBox2.Controls.Add(this.btnEazyPay);
            this.groupBox2.Controls.Add(this.btnEgreso);
            this.groupBox2.Controls.Add(this.btnProduccion);
            this.groupBox2.Controls.Add(this.btnAgendar);
            this.groupBox2.Controls.Add(this.btnCuadreCaja);
            this.groupBox2.Controls.Add(this.pbRecalculandoStock);
            this.groupBox2.Controls.Add(this.pBuscando);
            this.groupBox2.Controls.Add(this.btnHistorial);
            this.groupBox2.Controls.Add(this.lblDocumentoExportado);
            this.groupBox2.Controls.Add(this.btnExportarBandeja);
            this.groupBox2.Controls.Add(this.chkFiltroPersonalizado);
            this.groupBox2.Controls.Add(this.chkBandejaAgrupable);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.btnVentaRapida);
            this.groupBox2.Controls.Add(this.grdData);
            this.groupBox2.Controls.Add(this.lblContadorFilas);
            this.groupBox2.Location = new System.Drawing.Point(12, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1109, 353);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.Text = "Resultado de Búsqueda";
            // 
            // btnObsv
            // 
            this.btnObsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObsv.Enabled = false;
            this.btnObsv.Location = new System.Drawing.Point(-33, 322);
            this.btnObsv.Name = "btnObsv";
            this.btnObsv.Size = new System.Drawing.Size(87, 23);
            this.btnObsv.TabIndex = 178;
            this.btnObsv.Text = "Observaciones";
            this.btnObsv.UseVisualStyleBackColor = true;
            this.btnObsv.Click += new System.EventHandler(this.btnObsv_Click);
            // 
            // btnEazyPay
            // 
            this.btnEazyPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEazyPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEazyPay.Location = new System.Drawing.Point(54, 322);
            this.btnEazyPay.Name = "btnEazyPay";
            this.btnEazyPay.Size = new System.Drawing.Size(66, 23);
            this.btnEazyPay.TabIndex = 177;
            this.btnEazyPay.Text = "EazyPay";
            this.btnEazyPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEazyPay.UseVisualStyleBackColor = true;
            this.btnEazyPay.Click += new System.EventHandler(this.btnEazyPay_Click);
            // 
            // btnEgreso
            // 
            this.btnEgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEgreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEgreso.Location = new System.Drawing.Point(120, 322);
            this.btnEgreso.Name = "btnEgreso";
            this.btnEgreso.Size = new System.Drawing.Size(85, 23);
            this.btnEgreso.TabIndex = 176;
            this.btnEgreso.Text = "Egreso Detalle";
            this.btnEgreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEgreso.UseVisualStyleBackColor = true;
            this.btnEgreso.Click += new System.EventHandler(this.btnEgreso_Click);
            // 
            // btnProduccion
            // 
            this.btnProduccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProduccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduccion.Location = new System.Drawing.Point(205, 322);
            this.btnProduccion.Name = "btnProduccion";
            this.btnProduccion.Size = new System.Drawing.Size(71, 23);
            this.btnProduccion.TabIndex = 175;
            this.btnProduccion.Text = "Producción";
            this.btnProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProduccion.UseVisualStyleBackColor = true;
            this.btnProduccion.Click += new System.EventHandler(this.btnProduccion_Click);
            // 
            // btnAgendar
            // 
            this.btnAgendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgendar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgendar.Location = new System.Drawing.Point(276, 322);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(64, 23);
            this.btnAgendar.TabIndex = 174;
            this.btnAgendar.Text = "Agendar";
            this.btnAgendar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgendar.UseVisualStyleBackColor = true;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            // 
            // btnCuadreCaja
            // 
            this.btnCuadreCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCuadreCaja.Enabled = false;
            this.btnCuadreCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCuadreCaja.Location = new System.Drawing.Point(340, 322);
            this.btnCuadreCaja.Name = "btnCuadreCaja";
            this.btnCuadreCaja.Size = new System.Drawing.Size(131, 23);
            this.btnCuadreCaja.TabIndex = 173;
            this.btnCuadreCaja.Text = "Cuadre de Caja";
            this.btnCuadreCaja.UseVisualStyleBackColor = true;
            this.btnCuadreCaja.Click += new System.EventHandler(this.btnCuadreCaja_Click);
            // 
            // pbRecalculandoStock
            // 
            this.pbRecalculandoStock.Image = global::SAMBHS.Windows.WinClient.UI.Resource.loadingfinal1;
            this.pbRecalculandoStock.Location = new System.Drawing.Point(7, 15);
            this.pbRecalculandoStock.Name = "pbRecalculandoStock";
            this.pbRecalculandoStock.Size = new System.Drawing.Size(22, 19);
            this.pbRecalculandoStock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRecalculandoStock.TabIndex = 172;
            this.pbRecalculandoStock.TabStop = false;
            this.pbRecalculandoStock.Visible = false;
            // 
            // pBuscando
            // 
            this.pBuscando.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pBuscando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBuscando.Controls.Add(this.ultraLabel2);
            this.pBuscando.Controls.Add(this.pictureBox1);
            this.pBuscando.Location = new System.Drawing.Point(478, 172);
            this.pBuscando.Name = "pBuscando";
            this.pBuscando.Size = new System.Drawing.Size(153, 42);
            this.pBuscando.TabIndex = 171;
            this.pBuscando.Visible = false;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ultraLabel2.Location = new System.Drawing.Point(53, 13);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(87, 17);
            this.ultraLabel2.TabIndex = 1;
            this.ultraLabel2.Text = "Procesando...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SAMBHS.Windows.WinClient.UI.Resource.loadingfinal1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnHistorial
            // 
            this.btnHistorial.AllowDrop = true;
            this.btnHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = global::SAMBHS.Windows.WinClient.UI.Resource.book_magnify;
            this.btnHistorial.Appearance = appearance1;
            this.btnHistorial.Location = new System.Drawing.Point(471, 322);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(170, 23);
            this.btnHistorial.TabIndex = 162;
            this.btnHistorial.Text = "Ver Historial de Cobranzas";
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // lblDocumentoExportado
            // 
            this.lblDocumentoExportado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.FontData.BoldAsString = "True";
            this.lblDocumentoExportado.Appearance = appearance2;
            this.lblDocumentoExportado.AutoSize = true;
            this.lblDocumentoExportado.Location = new System.Drawing.Point(318, 334);
            this.lblDocumentoExportado.Name = "lblDocumentoExportado";
            this.lblDocumentoExportado.Size = new System.Drawing.Size(0, 0);
            this.lblDocumentoExportado.TabIndex = 161;
            // 
            // btnExportarBandeja
            // 
            this.btnExportarBandeja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.Image = global::SAMBHS.Windows.WinClient.UI.Resource.page_excel1;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.btnExportarBandeja.Appearance = appearance3;
            this.btnExportarBandeja.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarBandeja.Location = new System.Drawing.Point(7, 317);
            this.btnExportarBandeja.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportarBandeja.Name = "btnExportarBandeja";
            this.btnExportarBandeja.Size = new System.Drawing.Size(22, 24);
            this.btnExportarBandeja.TabIndex = 160;
            this.btnExportarBandeja.Click += new System.EventHandler(this.btnExportarBandeja_Click);
            // 
            // chkFiltroPersonalizado
            // 
            this.chkFiltroPersonalizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFiltroPersonalizado.Location = new System.Drawing.Point(34, 314);
            this.chkFiltroPersonalizado.Name = "chkFiltroPersonalizado";
            this.chkFiltroPersonalizado.Size = new System.Drawing.Size(108, 20);
            this.chkFiltroPersonalizado.TabIndex = 157;
            this.chkFiltroPersonalizado.Text = "Filtro Avanzado";
            this.chkFiltroPersonalizado.CheckedChanged += new System.EventHandler(this.chkFiltroPersonalizado_CheckedChanged);
            // 
            // chkBandejaAgrupable
            // 
            this.chkBandejaAgrupable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBandejaAgrupable.Location = new System.Drawing.Point(34, 331);
            this.chkBandejaAgrupable.Name = "chkBandejaAgrupable";
            this.chkBandejaAgrupable.Size = new System.Drawing.Size(77, 20);
            this.chkBandejaAgrupable.TabIndex = 156;
            this.chkBandejaAgrupable.Text = "Agrupable";
            this.chkBandejaAgrupable.CheckedChanged += new System.EventHandler(this.chkBandejaAgrupable_CheckedChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.Image = global::SAMBHS.Windows.WinClient.UI.Resource.delete;
            this.btnEliminar.Appearance = appearance4;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(997, 322);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(106, 23);
            this.btnEliminar.TabIndex = 155;
            this.btnEliminar.Text = "E&liminar Venta";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.Image = global::SAMBHS.Windows.WinClient.UI.Resource.pencil1;
            this.btnEditar.Appearance = appearance5;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(891, 322);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(106, 23);
            this.btnEditar.TabIndex = 154;
            this.btnEditar.Text = "&Editar Venta";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.Image = global::SAMBHS.Windows.WinClient.UI.Resource.add;
            this.btnAgregar.Appearance = appearance6;
            this.btnAgregar.Location = new System.Drawing.Point(777, 322);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(114, 23);
            this.btnAgregar.TabIndex = 153;
            this.btnAgregar.Text = "&Nueva Venta";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnVentaRapida
            // 
            this.btnVentaRapida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.Image = global::SAMBHS.Windows.WinClient.UI.Resource.lightning_add;
            this.btnVentaRapida.Appearance = appearance7;
            this.btnVentaRapida.Location = new System.Drawing.Point(641, 322);
            this.btnVentaRapida.Name = "btnVentaRapida";
            this.btnVentaRapida.Size = new System.Drawing.Size(136, 23);
            this.btnVentaRapida.TabIndex = 152;
            this.btnVentaRapida.Text = "Nueva Venta &Rápida";
            this.btnVentaRapida.Click += new System.EventHandler(this.btnVentaRapida_Click);
            // 
            // grdData
            // 
            this.grdData.AccessibleName = " ";
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.CausesValidation = false;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Appearance = appearance8;
            ultraGridBand1.CardSettings.Width = 241;
            ultraGridColumn20.Header.Caption = "Nº Registro";
            ultraGridColumn20.Header.VisiblePosition = 0;
            ultraGridColumn21.Header.VisiblePosition = 2;
            ultraGridColumn21.Width = 159;
            ultraGridColumn12.Header.Caption = "Tipo Doc.";
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.Width = 70;
            ultraGridColumn22.Header.Caption = "Fecha Registro";
            ultraGridColumn22.Header.VisiblePosition = 3;
            ultraGridColumn23.Header.Caption = "Fecha Emisión";
            ultraGridColumn23.Header.VisiblePosition = 4;
            ultraGridColumn24.Header.VisiblePosition = 5;
            ultraGridColumn24.Width = 133;
            ultraGridColumn25.Header.VisiblePosition = 6;
            ultraGridColumn25.Width = 252;
            appearance9.TextHAlignAsString = "Right";
            ultraGridColumn16.CellAppearance = appearance9;
            ultraGridColumn16.Format = "0.00";
            ultraGridColumn16.Header.Caption = "Total";
            ultraGridColumn16.Header.VisiblePosition = 8;
            ultraGridColumn16.MaxWidth = 150;
            ultraGridColumn16.Width = 134;
            ultraGridColumn17.Header.Caption = "E";
            ultraGridColumn17.Header.VisiblePosition = 10;
            ultraGridColumn17.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridColumn17.Width = 30;
            appearance10.TextHAlignAsString = "Left";
            ultraGridColumn13.CellAppearance = appearance10;
            ultraGridColumn13.Format = "dd/MM/yyyy hh:mm tt";
            ultraGridColumn13.Header.Caption = "Fecha Crea.";
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Width = 128;
            appearance11.TextHAlignAsString = "Left";
            ultraGridColumn14.CellAppearance = appearance11;
            ultraGridColumn14.Format = "dd/MM/yyyy hh:mm tt";
            ultraGridColumn14.Header.Caption = "Fecha Act.";
            ultraGridColumn14.Header.VisiblePosition = 14;
            ultraGridColumn14.Width = 118;
            appearance12.TextHAlignAsString = "Right";
            ultraGridColumn15.CellAppearance = appearance12;
            ultraGridColumn15.Header.VisiblePosition = 9;
            ultraGridColumn1.Header.Caption = "Con Guía";
            ultraGridColumn1.Header.VisiblePosition = 11;
            ultraGridColumn26.Header.Caption = "Usuario Crea.";
            ultraGridColumn26.Header.VisiblePosition = 13;
            ultraGridColumn27.Header.Caption = "Usuario Act.";
            ultraGridColumn27.Header.VisiblePosition = 15;
            ultraGridColumn27.Width = 88;
            appearance13.TextHAlignAsString = "Center";
            ultraGridColumn28.CellAppearance = appearance13;
            ultraGridColumn28.Header.VisiblePosition = 7;
            ultraGridColumn28.Width = 50;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn12,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn1,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28});
            summarySettings1.DisplayFormat = "Total S/.: {0:###,###.00}";
            summarySettings1.GroupBySummaryValueAppearance = appearance14;
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1});
            ultraGridBand1.SummaryFooterCaption = "Total:";
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdData.DisplayLayout.GroupByBox.Hidden = true;
            this.grdData.DisplayLayout.InterBandSpacing = 10;
            this.grdData.DisplayLayout.MaxColScrollRegions = 1;
            this.grdData.DisplayLayout.MaxRowScrollRegions = 1;
            this.grdData.DisplayLayout.NewColumnLoadStyle = Infragistics.Win.UltraWinGrid.NewColumnLoadStyle.Hide;
            appearance15.BackColor = System.Drawing.SystemColors.Highlight;
            appearance15.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance15.FontData.BoldAsString = "True";
            appearance15.ForeColor = System.Drawing.Color.White;
            this.grdData.DisplayLayout.Override.ActiveRowAppearance = appearance15;
            this.grdData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdData.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance16.BackColor = System.Drawing.Color.Transparent;
            this.grdData.DisplayLayout.Override.CardAreaAppearance = appearance16;
            appearance17.BackColor = System.Drawing.SystemColors.Control;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.grdData.DisplayLayout.Override.CellAppearance = appearance17;
            this.grdData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdData.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells;
            appearance18.BackColor = System.Drawing.SystemColors.Control;
            appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance18.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdData.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.grdData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdData.DisplayLayout.Override.RowSelectorAppearance = appearance19;
            this.grdData.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.grdData.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdData.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            this.grdData.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance20.BackColor = System.Drawing.SystemColors.Window;
            appearance20.FontData.BoldAsString = "True";
            appearance20.ForeColor = System.Drawing.SystemColors.WindowText;
            appearance20.ImageHAlign = Infragistics.Win.HAlign.Left;
            this.grdData.DisplayLayout.Override.SummaryValueAppearance = appearance20;
            this.grdData.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grdData.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.grdData.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdData.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdData.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdData.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.grdData.Location = new System.Drawing.Point(5, 36);
            this.grdData.Margin = new System.Windows.Forms.Padding(2);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(1098, 277);
            this.grdData.TabIndex = 148;
            this.grdData.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.grdData_InitializeRow);
            this.grdData.AfterRowActivate += new System.EventHandler(this.grdData_AfterRowActivate);
            this.grdData.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(this.grdData_ClickCell);
            this.grdData.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdData_DoubleClickRow);
            this.grdData.DoubleClick += new System.EventHandler(this.grdData_DoubleClick);
            this.grdData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdData_KeyDown);
            this.grdData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdData_MouseDown);
            // 
            // lblContadorFilas
            // 
            this.lblContadorFilas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContadorFilas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContadorFilas.Location = new System.Drawing.Point(891, 16);
            this.lblContadorFilas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContadorFilas.Name = "lblContadorFilas";
            this.lblContadorFilas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblContadorFilas.Size = new System.Drawing.Size(213, 19);
            this.lblContadorFilas.TabIndex = 143;
            this.lblContadorFilas.Text = "No se ha realizado la búsqueda aún.";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance21.FontData.BoldAsString = "False";
            this.groupBox1.Appearance = appearance21;
            this.groupBox1.Controls.Add(this.chkAllSales);
            this.groupBox1.Controls.Add(this.txtDNIPAc);
            this.groupBox1.Controls.Add(this.lblDniPac);
            this.groupBox1.Controls.Add(this.txtNombrePac);
            this.groupBox1.Controls.Add(this.lblNombrePac);
            this.groupBox1.Controls.Add(this.ultraGroupBox1);
            this.groupBox1.Controls.Add(this.cboTipoServicio);
            this.groupBox1.Controls.Add(this.ultraLabel3);
            this.groupBox1.Controls.Add(this.cboTipoOperacion);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(ultraLabel1);
            this.groupBox1.Controls.Add(this.cboMoneda);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboTipoDocumento);
            this.groupBox1.Controls.Add(this.txtCorrelativoDoc);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSerieDoc);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1109, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "Filtro de Búsqueda:";
            // 
            // chkAllSales
            // 
            this.chkAllSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAllSales.Location = new System.Drawing.Point(1021, 24);
            this.chkAllSales.Name = "chkAllSales";
            this.chkAllSales.Size = new System.Drawing.Size(58, 20);
            this.chkAllSales.TabIndex = 175;
            this.chkAllSales.Text = "Todos";
            // 
            // txtDNIPAc
            // 
            this.txtDNIPAc.Enabled = false;
            this.txtDNIPAc.Location = new System.Drawing.Point(837, 22);
            this.txtDNIPAc.Margin = new System.Windows.Forms.Padding(2);
            this.txtDNIPAc.MaxLength = 8;
            this.txtDNIPAc.Name = "txtDNIPAc";
            this.txtDNIPAc.Size = new System.Drawing.Size(162, 21);
            this.txtDNIPAc.TabIndex = 174;
            // 
            // lblDniPac
            // 
            this.lblDniPac.AutoSize = true;
            this.lblDniPac.Enabled = false;
            this.lblDniPac.Location = new System.Drawing.Point(783, 26);
            this.lblDniPac.Name = "lblDniPac";
            this.lblDniPac.Size = new System.Drawing.Size(49, 14);
            this.lblDniPac.TabIndex = 173;
            this.lblDniPac.Text = "DNI Pac:";
            // 
            // txtNombrePac
            // 
            this.txtNombrePac.Enabled = false;
            this.txtNombrePac.Location = new System.Drawing.Point(337, 22);
            this.txtNombrePac.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombrePac.MaxLength = 999;
            this.txtNombrePac.Name = "txtNombrePac";
            this.txtNombrePac.Size = new System.Drawing.Size(431, 21);
            this.txtNombrePac.TabIndex = 172;
            // 
            // lblNombrePac
            // 
            this.lblNombrePac.AutoSize = true;
            this.lblNombrePac.Enabled = false;
            this.lblNombrePac.Location = new System.Drawing.Point(253, 26);
            this.lblNombrePac.Name = "lblNombrePac";
            this.lblNombrePac.Size = new System.Drawing.Size(70, 14);
            this.lblNombrePac.TabIndex = 171;
            this.lblNombrePac.Text = "Nombre Pac:";
            // 
            // ultraGroupBox1
            // 
            appearance22.FontData.BoldAsString = "False";
            this.ultraGroupBox1.Appearance = appearance22;
            this.ultraGroupBox1.Controls.Add(this.rbPaciente);
            this.ultraGroupBox1.Controls.Add(this.rbVenta);
            this.ultraGroupBox1.Location = new System.Drawing.Point(11, 17);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(227, 29);
            this.ultraGroupBox1.TabIndex = 170;
            // 
            // rbPaciente
            // 
            this.rbPaciente.AutoSize = true;
            this.rbPaciente.Location = new System.Drawing.Point(121, 6);
            this.rbPaciente.Name = "rbPaciente";
            this.rbPaciente.Size = new System.Drawing.Size(67, 17);
            this.rbPaciente.TabIndex = 253;
            this.rbPaciente.Text = "Paciente";
            this.rbPaciente.UseVisualStyleBackColor = true;
            // 
            // rbVenta
            // 
            this.rbVenta.AutoSize = true;
            this.rbVenta.Checked = true;
            this.rbVenta.Location = new System.Drawing.Point(23, 6);
            this.rbVenta.Name = "rbVenta";
            this.rbVenta.Size = new System.Drawing.Size(53, 17);
            this.rbVenta.TabIndex = 252;
            this.rbVenta.TabStop = true;
            this.rbVenta.Text = "Venta";
            this.rbVenta.UseVisualStyleBackColor = true;
            this.rbVenta.CheckedChanged += new System.EventHandler(this.rbVenta_CheckedChanged);
            // 
            // cboTipoServicio
            // 
            this.cboTipoServicio.DropDownListWidth = 250;
            this.cboTipoServicio.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem5.DataValue = -1;
            valueListItem5.DisplayText = "--Seleccionar--";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "Empresarial";
            valueListItem7.DataValue = 2;
            valueListItem7.DisplayText = "Particular";
            valueListItem8.DataValue = 3;
            valueListItem8.DisplayText = "Farmacia";
            this.cboTipoServicio.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6,
            valueListItem7,
            valueListItem8});
            this.cboTipoServicio.Location = new System.Drawing.Point(887, 84);
            this.cboTipoServicio.Name = "cboTipoServicio";
            this.cboTipoServicio.Size = new System.Drawing.Size(116, 21);
            this.cboTipoServicio.TabIndex = 168;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.ForeColor = System.Drawing.Color.Black;
            this.ultraLabel3.Location = new System.Drawing.Point(808, 88);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(73, 14);
            this.ultraLabel3.TabIndex = 169;
            this.ultraLabel3.Text = "Tipo Servicio:";
            // 
            // cboTipoOperacion
            // 
            this.cboTipoOperacion.DropDownListWidth = 250;
            this.cboTipoOperacion.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboTipoOperacion.Location = new System.Drawing.Point(671, 85);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Size = new System.Drawing.Size(130, 21);
            this.cboTipoOperacion.TabIndex = 166;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(580, 90);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(85, 14);
            this.label40.TabIndex = 167;
            this.label40.Text = "Tipo Operación:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboMoneda.Location = new System.Drawing.Point(464, 84);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(101, 21);
            this.cboMoneda.TabIndex = 10;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance23.Image = global::SAMBHS.Windows.WinClient.UI.Resource.system_search;
            appearance23.ImageHAlign = Infragistics.Win.HAlign.Left;
            this.btnBuscar.Appearance = appearance23;
            this.btnBuscar.Location = new System.Drawing.Point(1021, 50);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 55);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance24.ImageHAlign = Infragistics.Win.HAlign.Left;
            editorButton1.Appearance = appearance24;
            editorButton1.Key = "btnBuscarCliente";
            editorButton1.Text = "Buscar Cliente";
            this.txtCliente.ButtonsLeft.Add(editorButton1);
            appearance25.Image = global::SAMBHS.Windows.WinClient.UI.Resource.user_cross;
            appearance25.ImageHAlign = Infragistics.Win.HAlign.Center;
            editorButton2.Appearance = appearance25;
            editorButton2.Enabled = false;
            editorButton2.Key = "btnEliminar";
            this.txtCliente.ButtonsRight.Add(editorButton2);
            this.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliente.Location = new System.Drawing.Point(400, 52);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(599, 21);
            this.txtCliente.TabIndex = 6;
            this.txtCliente.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.txtRucProveedor_EditorButtonClick);
            this.txtCliente.Validated += new System.EventHandler(this.txtCliente_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 14);
            this.label7.TabIndex = 100;
            this.label7.Text = "Documento:";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance26.BackColor = System.Drawing.Color.White;
            this.cboTipoDocumento.DisplayLayout.Appearance = appearance26;
            ultraGridColumn2.Format = "000";
            ultraGridColumn2.Header.Caption = "Cod.";
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(50, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 1;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Header.Caption = "Nombre";
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 1;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(248, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Header.Caption = "Siglas";
            ultraGridColumn5.Header.VisiblePosition = 2;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(63, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn5});
            ultraGridBand2.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.GroupLayout;
            this.cboTipoDocumento.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cboTipoDocumento.DisplayLayout.NewColumnLoadStyle = Infragistics.Win.UltraWinGrid.NewColumnLoadStyle.Hide;
            this.cboTipoDocumento.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance27.BackColor = System.Drawing.Color.Transparent;
            this.cboTipoDocumento.DisplayLayout.Override.CardAreaAppearance = appearance27;
            this.cboTipoDocumento.DisplayLayout.Override.CellPadding = 3;
            appearance28.TextHAlignAsString = "Left";
            this.cboTipoDocumento.DisplayLayout.Override.HeaderAppearance = appearance28;
            appearance29.BorderColor = System.Drawing.Color.LightGray;
            appearance29.TextVAlignAsString = "Middle";
            this.cboTipoDocumento.DisplayLayout.Override.RowAppearance = appearance29;
            this.cboTipoDocumento.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance30.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance30.BorderColor = System.Drawing.Color.Black;
            appearance30.ForeColor = System.Drawing.Color.Black;
            this.cboTipoDocumento.DisplayLayout.Override.SelectedRowAppearance = appearance30;
            this.cboTipoDocumento.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.cboTipoDocumento.Location = new System.Drawing.Point(117, 83);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(119, 22);
            this.cboTipoDocumento.TabIndex = 3;
            this.cboTipoDocumento.ValueChanged += new System.EventHandler(this.cboTipoDocumento_ValueChanged);
            this.cboTipoDocumento.Leave += new System.EventHandler(this.cboTipoDocumento_Leave);
            // 
            // txtCorrelativoDoc
            // 
            this.txtCorrelativoDoc.Enabled = false;
            this.txtCorrelativoDoc.Location = new System.Drawing.Point(295, 84);
            this.txtCorrelativoDoc.Margin = new System.Windows.Forms.Padding(2);
            this.txtCorrelativoDoc.MaxLength = 8;
            this.txtCorrelativoDoc.Name = "txtCorrelativoDoc";
            this.txtCorrelativoDoc.Size = new System.Drawing.Size(91, 21);
            this.txtCorrelativoDoc.TabIndex = 5;
            this.txtCorrelativoDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorrelativoDoc_KeyPress);
            this.txtCorrelativoDoc.Validated += new System.EventHandler(this.txtCorrelativoDoc_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(282, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(8, 14);
            this.label6.TabIndex = 95;
            this.label6.Text = "-";
            // 
            // txtSerieDoc
            // 
            this.txtSerieDoc.Enabled = false;
            this.txtSerieDoc.Location = new System.Drawing.Point(243, 84);
            this.txtSerieDoc.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerieDoc.MaxLength = 4;
            this.txtSerieDoc.Name = "txtSerieDoc";
            this.txtSerieDoc.Size = new System.Drawing.Size(34, 21);
            this.txtSerieDoc.TabIndex = 4;
            this.txtSerieDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerieDoc_KeyPress);
            this.txtSerieDoc.Validated += new System.EventHandler(this.txtSerieDoc_Validated);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(245, 53);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(102, 20);
            this.dtpFechaFin.TabIndex = 9;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Al:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(119, 53);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaInicio.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Registro del: ";
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // frmBandejaRegistroVenta_Fill_Panel
            // 
            // 
            // frmBandejaRegistroVenta_Fill_Panel.ClientArea
            // 
            this.frmBandejaRegistroVenta_Fill_Panel.ClientArea.Controls.Add(this.groupBox2);
            this.frmBandejaRegistroVenta_Fill_Panel.ClientArea.Controls.Add(this.groupBox1);
            this.frmBandejaRegistroVenta_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmBandejaRegistroVenta_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmBandejaRegistroVenta_Fill_Panel.Location = new System.Drawing.Point(8, 32);
            this.frmBandejaRegistroVenta_Fill_Panel.Name = "frmBandejaRegistroVenta_Fill_Panel";
            this.frmBandejaRegistroVenta_Fill_Panel.Size = new System.Drawing.Size(1133, 471);
            this.frmBandejaRegistroVenta_Fill_Panel.TabIndex = 0;
            // 
            // _frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left
            // 
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 32);
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left.Name = "_frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left";
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 471);
            // 
            // _frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right
            // 
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(1141, 32);
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right.Name = "_frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right";
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 471);
            // 
            // _frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top
            // 
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top.Name = "_frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top";
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(1149, 32);
            // 
            // _frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 503);
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom.Name = "_frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom";
            this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(1149, 8);
            // 
            // frmBandejaRegistroVenta
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1149, 511);
            this.Controls.Add(this.frmBandejaRegistroVenta_Fill_Panel);
            this.Controls.Add(this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom);
            this.Name = "frmBandejaRegistroVenta";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bandeja Registro Venta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBandejaRegistroVenta_FormClosing);
            this.Load += new System.EventHandler(this.frmBandejaRegistroVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecalculandoStock)).EndInit();
            this.pBuscando.ResumeLayout(false);
            this.pBuscando.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFiltroPersonalizado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBandejaAgrupable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNIPAc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombrePac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoServicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoOperacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorrelativoDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerieDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.frmBandejaRegistroVenta_Fill_Panel.ClientArea.ResumeLayout(false);
            this.frmBandejaRegistroVenta_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UltraGroupBox groupBox2;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdData;
        private UltraLabel lblContadorFilas;
        private UltraGroupBox groupBox1;
        private UltraLabel label7;
        private Infragistics.Win.UltraWinGrid.UltraCombo cboTipoDocumento;
        private UltraTextEditor txtCorrelativoDoc;
        private UltraLabel label6;
        private UltraTextEditor txtSerieDoc;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private UltraLabel label4;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private UltraLabel label3;
        private Infragistics.Win.Misc.UltraValidator uvDatos;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.Misc.UltraPanel frmBandejaRegistroVenta_Fill_Panel;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmBandejaRegistroVenta_UltraFormManager_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCliente;
        private UltraButton btnBuscar;
        private UltraButton btnVentaRapida;
        private UltraButton btnEliminar;
        private UltraButton btnEditar;
        private UltraButton btnAgregar;
        private UltraCheckEditor chkFiltroPersonalizado;
        private UltraCheckEditor chkBandejaAgrupable;
        private UltraLabel lblDocumentoExportado;
        private UltraButton btnExportarBandeja;
        private UltraComboEditor cboMoneda;
        private UltraButton btnHistorial;
        private UltraComboEditor cboTipoOperacion;
        private UltraLabel label40;
        private System.Windows.Forms.Panel pBuscando;
        private UltraLabel ultraLabel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbRecalculandoStock;
        private UltraComboEditor cboTipoServicio;
        private UltraLabel ultraLabel3;
        private System.Windows.Forms.Button btnCuadreCaja;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.Button btnProduccion;
        private System.Windows.Forms.Button btnEgreso;
        private UltraGroupBox ultraGroupBox1;
        private UltraTextEditor txtDNIPAc;
        private UltraLabel lblDniPac;
        private UltraTextEditor txtNombrePac;
        private UltraLabel lblNombrePac;
        private System.Windows.Forms.RadioButton rbPaciente;
        private System.Windows.Forms.RadioButton rbVenta;
        private System.Windows.Forms.Button btnEazyPay;
        private System.Windows.Forms.Button btnObsv;
        private UltraCheckEditor chkAllSales;

    }
}