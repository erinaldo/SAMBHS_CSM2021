﻿namespace SAMBHS.Windows.WinClient.UI.Reportes.Compras
{
    partial class frmCondicionPago
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.chkHoraimpresion = new System.Windows.Forms.CheckBox();
            this.BtnVuisualizar = new Infragistics.Win.Misc.UltraButton();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.frmCondicionPago_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this._frmCondicionPago_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmCondicionPago_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmCondicionPago_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmCondicionPago_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.frmCondicionPago_Fill_Panel.ClientArea.SuspendLayout();
            this.frmCondicionPago_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 16);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1011, 492);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColorInternal = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.crystalReportViewer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1017, 511);
            this.groupBox1.TabIndex = 212;
            this.groupBox1.Text = "Reporte Condicion de Pago";
            // 
            // chkHoraimpresion
            // 
            this.chkHoraimpresion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHoraimpresion.AutoSize = true;
            this.chkHoraimpresion.BackColor = System.Drawing.Color.Transparent;
            this.chkHoraimpresion.Checked = true;
            this.chkHoraimpresion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHoraimpresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHoraimpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHoraimpresion.Location = new System.Drawing.Point(747, 13);
            this.chkHoraimpresion.Name = "chkHoraimpresion";
            this.chkHoraimpresion.Size = new System.Drawing.Size(153, 17);
            this.chkHoraimpresion.TabIndex = 211;
            this.chkHoraimpresion.Text = "Fecha y Hora de Impresión ";
            this.chkHoraimpresion.UseVisualStyleBackColor = false;
            // 
            // BtnVuisualizar
            // 
            this.BtnVuisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = global::SAMBHS.Windows.WinClient.UI.Resource.eye;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.BtnVuisualizar.Appearance = appearance1;
            this.BtnVuisualizar.Location = new System.Drawing.Point(905, 6);
            this.BtnVuisualizar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnVuisualizar.Name = "BtnVuisualizar";
            this.BtnVuisualizar.Size = new System.Drawing.Size(124, 30);
            this.BtnVuisualizar.TabIndex = 213;
            this.BtnVuisualizar.Text = "Visualizar Reporte";
            this.BtnVuisualizar.Click += new System.EventHandler(this.BtnVuisualizar_Click);
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // frmCondicionPago_Fill_Panel
            // 
            // 
            // frmCondicionPago_Fill_Panel.ClientArea
            // 
            this.frmCondicionPago_Fill_Panel.ClientArea.Controls.Add(this.BtnVuisualizar);
            this.frmCondicionPago_Fill_Panel.ClientArea.Controls.Add(this.groupBox1);
            this.frmCondicionPago_Fill_Panel.ClientArea.Controls.Add(this.chkHoraimpresion);
            this.frmCondicionPago_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmCondicionPago_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmCondicionPago_Fill_Panel.Location = new System.Drawing.Point(8, 31);
            this.frmCondicionPago_Fill_Panel.Name = "frmCondicionPago_Fill_Panel";
            this.frmCondicionPago_Fill_Panel.Size = new System.Drawing.Size(1041, 547);
            this.frmCondicionPago_Fill_Panel.TabIndex = 0;
            // 
            // _frmCondicionPago_UltraFormManager_Dock_Area_Left
            // 
            this._frmCondicionPago_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmCondicionPago_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 31);
            this._frmCondicionPago_UltraFormManager_Dock_Area_Left.Name = "_frmCondicionPago_UltraFormManager_Dock_Area_Left";
            this._frmCondicionPago_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 547);
            // 
            // _frmCondicionPago_UltraFormManager_Dock_Area_Right
            // 
            this._frmCondicionPago_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmCondicionPago_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(1049, 31);
            this._frmCondicionPago_UltraFormManager_Dock_Area_Right.Name = "_frmCondicionPago_UltraFormManager_Dock_Area_Right";
            this._frmCondicionPago_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 547);
            // 
            // _frmCondicionPago_UltraFormManager_Dock_Area_Top
            // 
            this._frmCondicionPago_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmCondicionPago_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmCondicionPago_UltraFormManager_Dock_Area_Top.Name = "_frmCondicionPago_UltraFormManager_Dock_Area_Top";
            this._frmCondicionPago_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(1057, 31);
            // 
            // _frmCondicionPago_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmCondicionPago_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmCondicionPago_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmCondicionPago_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 578);
            this._frmCondicionPago_UltraFormManager_Dock_Area_Bottom.Name = "_frmCondicionPago_UltraFormManager_Dock_Area_Bottom";
            this._frmCondicionPago_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(1057, 8);
            // 
            // frmCondicionPago
            // 
            this.AcceptButton = this.BtnVuisualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1057, 586);
            this.Controls.Add(this.frmCondicionPago_Fill_Panel);
            this.Controls.Add(this._frmCondicionPago_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmCondicionPago_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmCondicionPago_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmCondicionPago_UltraFormManager_Dock_Area_Bottom);
            this.Name = "frmCondicionPago";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Condicion de Pago";
            this.Load += new System.EventHandler(this.frmCondicionPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.frmCondicionPago_Fill_Panel.ClientArea.ResumeLayout(false);
            this.frmCondicionPago_Fill_Panel.ClientArea.PerformLayout();
            this.frmCondicionPago_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Infragistics.Win.Misc.UltraButton BtnVuisualizar;
        private Infragistics.Win.Misc.UltraGroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkHoraimpresion;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.Misc.UltraPanel frmCondicionPago_Fill_Panel;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmCondicionPago_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmCondicionPago_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmCondicionPago_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmCondicionPago_UltraFormManager_Dock_Area_Bottom;
    }
}