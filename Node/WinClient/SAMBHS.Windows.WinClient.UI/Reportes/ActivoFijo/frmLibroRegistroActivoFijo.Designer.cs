﻿namespace SAMBHS.Windows.WinClient.UI.Reportes.ActivoFijo
{
    partial class frmLibroRegistroActivoFijo
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("btnBuscarActivoFijoFin");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton("btnBuscarActivoFijoInicio");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.frmLibroRegistroActivoFijo_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.groupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.pBuscando = new System.Windows.Forms.Panel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.uckNroPagina = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.groupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtCodigoHasta = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label3 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCodigoDesde = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1 = new Infragistics.Win.Misc.UltraLabel();
            this.nupAnio = new System.Windows.Forms.NumericUpDown();
            this.label2 = new Infragistics.Win.Misc.UltraLabel();
            this.btnVisualizar = new Infragistics.Win.Misc.UltraButton();
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.frmLibroRegistroActivoFijo_Fill_Panel.ClientArea.SuspendLayout();
            this.frmLibroRegistroActivoFijo_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pBuscando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uckNroPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // frmLibroRegistroActivoFijo_Fill_Panel
            // 
            // 
            // frmLibroRegistroActivoFijo_Fill_Panel.ClientArea
            // 
            this.frmLibroRegistroActivoFijo_Fill_Panel.ClientArea.Controls.Add(this.groupBox2);
            this.frmLibroRegistroActivoFijo_Fill_Panel.ClientArea.Controls.Add(this.groupBox1);
            this.frmLibroRegistroActivoFijo_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmLibroRegistroActivoFijo_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmLibroRegistroActivoFijo_Fill_Panel.Location = new System.Drawing.Point(8, 31);
            this.frmLibroRegistroActivoFijo_Fill_Panel.Name = "frmLibroRegistroActivoFijo_Fill_Panel";
            this.frmLibroRegistroActivoFijo_Fill_Panel.Size = new System.Drawing.Size(1184, 521);
            this.frmLibroRegistroActivoFijo_Fill_Panel.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pBuscando);
            this.groupBox2.Controls.Add(this.crystalReportViewer1);
            this.groupBox2.Location = new System.Drawing.Point(6, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1169, 438);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.Text = "Reporte de Libro Registro de Activo Fijo";
            // 
            // pBuscando
            // 
            this.pBuscando.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pBuscando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBuscando.Controls.Add(this.ultraLabel2);
            this.pBuscando.Controls.Add(this.pictureBox1);
            this.pBuscando.Location = new System.Drawing.Point(492, 198);
            this.pBuscando.Name = "pBuscando";
            this.pBuscando.Size = new System.Drawing.Size(185, 42);
            this.pBuscando.TabIndex = 7;
            this.pBuscando.Visible = false;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ultraLabel2.Location = new System.Drawing.Point(53, 13);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(134, 17);
            this.ultraLabel2.TabIndex = 1;
            this.ultraLabel2.Text = "Generando Reporte...";
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
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 16);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1163, 419);
            this.crystalReportViewer1.TabIndex = 4;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.uckNroPagina);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.nupAnio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnVisualizar);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1172, 65);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.Text = "Filtro de Búsqueda";
            // 
            // uckNroPagina
            // 
            this.uckNroPagina.Location = new System.Drawing.Point(494, 28);
            this.uckNroPagina.Name = "uckNroPagina";
            this.uckNroPagina.Size = new System.Drawing.Size(101, 20);
            this.uckNroPagina.TabIndex = 265;
            this.uckNroPagina.Text = "Nro. de Página";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCodigoHasta);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtCodigoDesde);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(134, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(345, 45);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.Text = "Rango de Bienes";
            // 
            // txtCodigoHasta
            // 
            appearance2.Image = global::SAMBHS.Windows.WinClient.UI.Properties.Resources.find;
            editorButton1.Appearance = appearance2;
            editorButton1.Key = "btnBuscarActivoFijoFin";
            this.txtCodigoHasta.ButtonsLeft.Add(editorButton1);
            this.txtCodigoHasta.Location = new System.Drawing.Point(218, 18);
            this.txtCodigoHasta.Name = "txtCodigoHasta";
            this.txtCodigoHasta.NullText = "Código Activo Fijo";
            this.txtCodigoHasta.Size = new System.Drawing.Size(113, 21);
            this.txtCodigoHasta.TabIndex = 11;
            this.txtCodigoHasta.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.txtCodigoHasta_EditorButtonClick);
            this.txtCodigoHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoHasta_KeyPress);
            this.txtCodigoHasta.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoHasta_Validating);
            this.txtCodigoHasta.Validated += new System.EventHandler(this.txtCodigoHasta_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Hasta : ";
            // 
            // txtCodigoDesde
            // 
            appearance3.Image = global::SAMBHS.Windows.WinClient.UI.Properties.Resources.find;
            editorButton2.Appearance = appearance3;
            editorButton2.Key = "btnBuscarActivoFijoInicio";
            this.txtCodigoDesde.ButtonsLeft.Add(editorButton2);
            this.txtCodigoDesde.Location = new System.Drawing.Point(56, 18);
            this.txtCodigoDesde.Name = "txtCodigoDesde";
            this.txtCodigoDesde.NullText = "Código Activo Fijo";
            this.txtCodigoDesde.Size = new System.Drawing.Size(113, 21);
            this.txtCodigoDesde.TabIndex = 5;
            this.txtCodigoDesde.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.txtRangoBienes_EditorButtonClick);
            this.txtCodigoDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoDesde_KeyPress);
            this.txtCodigoDesde.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoDesde_Validating);
            this.txtCodigoDesde.Validated += new System.EventHandler(this.txtCodigoDesde_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Desde :";
            // 
            // nupAnio
            // 
            this.nupAnio.Location = new System.Drawing.Point(57, 28);
            this.nupAnio.Name = "nupAnio";
            this.nupAnio.Size = new System.Drawing.Size(52, 20);
            this.nupAnio.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Periodo :";
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = global::SAMBHS.Windows.WinClient.UI.Resource.eye;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.btnVisualizar.Appearance = appearance1;
            this.btnVisualizar.Location = new System.Drawing.Point(1038, 18);
            this.btnVisualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(129, 32);
            this.btnVisualizar.TabIndex = 9;
            this.btnVisualizar.Text = "Visualizar Reporte";
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // _frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left
            // 
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 31);
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left.Name = "_frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left";
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 521);
            // 
            // _frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right
            // 
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(1192, 31);
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right.Name = "_frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right";
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 521);
            // 
            // _frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top
            // 
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top.Name = "_frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top";
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(1200, 31);
            // 
            // _frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 552);
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom.Name = "_frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom";
            this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(1200, 8);
            // 
            // frmLibroRegistroActivoFijo
            // 
            this.AcceptButton = this.btnVisualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 560);
            this.Controls.Add(this.frmLibroRegistroActivoFijo_Fill_Panel);
            this.Controls.Add(this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom);
            this.Name = "frmLibroRegistroActivoFijo";
            this.ShowIcon = false;
            this.Text = "Reporte Libro Registro de Activo Fijo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLibroRegistroActivoFijo_FormClosing);
            this.Load += new System.EventHandler(this.frmLibroRegistroActivoFijo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.frmLibroRegistroActivoFijo_Fill_Panel.ClientArea.ResumeLayout(false);
            this.frmLibroRegistroActivoFijo_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.pBuscando.ResumeLayout(false);
            this.pBuscando.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uckNroPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.Misc.UltraPanel frmLibroRegistroActivoFijo_Fill_Panel;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmLibroRegistroActivoFijo_UltraFormManager_Dock_Area_Bottom;
        private Infragistics.Win.Misc.UltraButton btnVisualizar;
        private Infragistics.Win.Misc.UltraGroupBox groupBox1;
        private Infragistics.Win.Misc.UltraLabel label1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCodigoDesde;
        private Infragistics.Win.Misc.UltraGroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nupAnio;
        private Infragistics.Win.Misc.UltraLabel label2;
        private Infragistics.Win.Misc.UltraGroupBox groupBox3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCodigoHasta;
        private Infragistics.Win.Misc.UltraLabel label3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel pBuscando;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uckNroPagina;
    }
}