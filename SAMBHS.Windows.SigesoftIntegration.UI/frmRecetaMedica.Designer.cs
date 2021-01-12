﻿namespace SAMBHS.Windows.SigesoftIntegration.UI
{
    partial class frmRecetaMedica
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_DiagnosticRepositoryId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_DiseasesId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_ComponentName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_DiseasesName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn69 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_UpdateUser");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_AutoManualName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_RestrictionsName", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_RecomendationsName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_PreQualificationName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_FinalQualificationName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_DiagnosticTypeName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_IsSentToAntecedentName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_ExpirationDateDiagnostic");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_GenerateMedicalBreak");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_RecordStatus");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_RecordType");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_ComponentId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RecipeDetail");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("_AddRecipe", 0);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecetaMedica));
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RecipeDetail", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMedicamento", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_Cantidad");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_Posologia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_Duracion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("t_FechaFin");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("_EditRecipe", 0);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("_DeleteRecipe", 1);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridGroup ultraGridGroup1 = new Infragistics.Win.UltraWinGrid.UltraGridGroup("NewGroup0", 686062766);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.frmRecetaMedica_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.grdTotalDiagnosticos = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.frmRecetaMedica_Fill_Panel.ClientArea.SuspendLayout();
            this.frmRecetaMedica_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalDiagnosticos)).BeginInit();
            this.SuspendLayout();
            // 
            // frmRecetaMedica_Fill_Panel
            // 
            // 
            // frmRecetaMedica_Fill_Panel.ClientArea
            // 
            this.frmRecetaMedica_Fill_Panel.ClientArea.Controls.Add(this.ultraButton2);
            this.frmRecetaMedica_Fill_Panel.ClientArea.Controls.Add(this.ultraButton1);
            this.frmRecetaMedica_Fill_Panel.ClientArea.Controls.Add(this.ultraGroupBox1);
            this.frmRecetaMedica_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmRecetaMedica_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmRecetaMedica_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.frmRecetaMedica_Fill_Panel.Name = "frmRecetaMedica_Fill_Panel";
            this.frmRecetaMedica_Fill_Panel.Size = new System.Drawing.Size(1140, 377);
            this.frmRecetaMedica_Fill_Panel.TabIndex = 1;
            // 
            // ultraButton2
            // 
            this.ultraButton2.Location = new System.Drawing.Point(17, 347);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(134, 26);
            this.ultraButton2.TabIndex = 54;
            this.ultraButton2.Text = "Confirmar Despacho";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(157, 347);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(134, 26);
            this.ultraButton1.TabIndex = 53;
            this.ultraButton1.Text = "Imprimir Receta";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGroupBox1.Controls.Add(this.grdTotalDiagnosticos);
            this.ultraGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1114, 322);
            this.ultraGroupBox1.TabIndex = 52;
            this.ultraGroupBox1.Text = "Receta por Diagnóstico";
            // 
            // grdTotalDiagnosticos
            // 
            this.grdTotalDiagnosticos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTotalDiagnosticos.CausesValidation = false;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.Silver;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdTotalDiagnosticos.DisplayLayout.Appearance = appearance1;
            ultraGridColumn24.Header.VisiblePosition = 1;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.Header.VisiblePosition = 2;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.Header.Caption = "Consultorio";
            ultraGridColumn26.Header.VisiblePosition = 3;
            ultraGridColumn26.Width = 95;
            ultraGridColumn27.Header.Caption = "Diagnóstico";
            ultraGridColumn27.Header.VisiblePosition = 4;
            ultraGridColumn27.Width = 189;
            ultraGridColumn69.Header.Caption = "Usuario Act.";
            ultraGridColumn69.Header.VisiblePosition = 5;
            ultraGridColumn69.Width = 95;
            ultraGridColumn28.Header.Caption = "Automatico?";
            ultraGridColumn28.Header.VisiblePosition = 6;
            ultraGridColumn28.Width = 95;
            ultraGridColumn29.Header.Caption = "Restricciones";
            ultraGridColumn29.Header.VisiblePosition = 7;
            ultraGridColumn29.Width = 146;
            ultraGridColumn30.Header.Caption = "Recomendaciones";
            ultraGridColumn30.Header.VisiblePosition = 8;
            ultraGridColumn30.Width = 143;
            ultraGridColumn31.Header.Caption = "Pre-Calificación";
            ultraGridColumn31.Header.VisiblePosition = 9;
            ultraGridColumn31.Width = 49;
            ultraGridColumn32.Header.Caption = "Calificación Final";
            ultraGridColumn32.Header.VisiblePosition = 10;
            ultraGridColumn32.Width = 52;
            ultraGridColumn33.Header.Caption = "Tipo DX";
            ultraGridColumn33.Header.VisiblePosition = 11;
            ultraGridColumn33.Width = 58;
            ultraGridColumn34.Header.Caption = "Enviar a Ant";
            ultraGridColumn34.Header.VisiblePosition = 12;
            ultraGridColumn34.Width = 38;
            ultraGridColumn35.Header.Caption = "Fec Vcto";
            ultraGridColumn35.Header.VisiblePosition = 13;
            ultraGridColumn35.Width = 45;
            ultraGridColumn36.Header.VisiblePosition = 14;
            ultraGridColumn36.Hidden = true;
            ultraGridColumn37.Header.VisiblePosition = 15;
            ultraGridColumn37.Hidden = true;
            ultraGridColumn38.Header.VisiblePosition = 16;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn39.Header.VisiblePosition = 17;
            ultraGridColumn39.Hidden = true;
            ultraGridColumn1.Header.VisiblePosition = 18;
            ultraGridColumn7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraGridColumn7.CellButtonAppearance = appearance2;
            ultraGridColumn7.Header.VisiblePosition = 0;
            ultraGridColumn7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn7.Width = 28;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn69,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn1,
            ultraGridColumn7});
            ultraGridColumn2.Header.Caption = "Medicamento";
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.ParentGroupIndex = 0;
            ultraGridColumn2.RowLayoutColumnInfo.ParentGroupKey = "NewGroup0";
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(234, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn2.Width = 106;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn3.CellAppearance = appearance3;
            ultraGridColumn3.Header.Caption = "Cantidad";
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.ParentGroupIndex = 0;
            ultraGridColumn3.RowLayoutColumnInfo.ParentGroupKey = "NewGroup0";
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Header.Caption = "Posología";
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.ParentGroupIndex = 0;
            ultraGridColumn4.RowLayoutColumnInfo.ParentGroupKey = "NewGroup0";
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Header.Caption = "Duración";
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.ParentGroupIndex = 0;
            ultraGridColumn5.RowLayoutColumnInfo.ParentGroupKey = "NewGroup0";
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.Header.Caption = "Fecha Fin.";
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.ParentGroupIndex = 0;
            ultraGridColumn6.RowLayoutColumnInfo.ParentGroupKey = "NewGroup0";
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraGridColumn8.CellButtonAppearance = appearance4;
            ultraGridColumn8.Header.Caption = "";
            ultraGridColumn8.Header.VisiblePosition = 0;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.ParentGroupIndex = 0;
            ultraGridColumn8.RowLayoutColumnInfo.ParentGroupKey = "NewGroup0";
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn8.Width = 29;
            ultraGridColumn9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraGridColumn9.CellButtonAppearance = appearance5;
            ultraGridColumn9.Header.Caption = "";
            ultraGridColumn9.Header.VisiblePosition = 1;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.ParentGroupIndex = 0;
            ultraGridColumn9.RowLayoutColumnInfo.ParentGroupKey = "NewGroup0";
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn9.Width = 27;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn8,
            ultraGridColumn9});
            ultraGridGroup1.Header.Caption = "Receta";
            ultraGridGroup1.Key = "NewGroup0";
            ultraGridGroup1.RowLayoutGroupInfo.LabelSpan = 1;
            ultraGridGroup1.RowLayoutGroupInfo.OriginX = 0;
            ultraGridGroup1.RowLayoutGroupInfo.OriginY = 0;
            ultraGridGroup1.RowLayoutGroupInfo.SpanX = 14;
            ultraGridGroup1.RowLayoutGroupInfo.SpanY = 4;
            ultraGridBand2.Groups.AddRange(new Infragistics.Win.UltraWinGrid.UltraGridGroup[] {
            ultraGridGroup1});
            ultraGridBand2.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.GroupLayout;
            this.grdTotalDiagnosticos.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdTotalDiagnosticos.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.grdTotalDiagnosticos.DisplayLayout.InterBandSpacing = 10;
            this.grdTotalDiagnosticos.DisplayLayout.MaxColScrollRegions = 1;
            this.grdTotalDiagnosticos.DisplayLayout.MaxRowScrollRegions = 1;
            this.grdTotalDiagnosticos.DisplayLayout.NewColumnLoadStyle = Infragistics.Win.UltraWinGrid.NewColumnLoadStyle.Hide;
            this.grdTotalDiagnosticos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdTotalDiagnosticos.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdTotalDiagnosticos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdTotalDiagnosticos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdTotalDiagnosticos.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.grdTotalDiagnosticos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdTotalDiagnosticos.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.grdTotalDiagnosticos.DisplayLayout.Override.CardAreaAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.BackColor2 = System.Drawing.Color.White;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.grdTotalDiagnosticos.DisplayLayout.Override.CellAppearance = appearance7;
            this.grdTotalDiagnosticos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdTotalDiagnosticos.DisplayLayout.Override.ColumnSizingArea = Infragistics.Win.UltraWinGrid.ColumnSizingArea.HeadersOnly;
            this.grdTotalDiagnosticos.DisplayLayout.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.CheckOnDisplay;
            appearance8.BackColor = System.Drawing.Color.White;
            appearance8.BackColor2 = System.Drawing.Color.LightGray;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.DarkGray;
            appearance8.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdTotalDiagnosticos.DisplayLayout.Override.HeaderAppearance = appearance8;
            this.grdTotalDiagnosticos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance9.AlphaLevel = ((short)(187));
            appearance9.BackColor = System.Drawing.Color.Gainsboro;
            appearance9.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForegroundAlpha = Infragistics.Win.Alpha.Opaque;
            this.grdTotalDiagnosticos.DisplayLayout.Override.RowAlternateAppearance = appearance9;
            appearance10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdTotalDiagnosticos.DisplayLayout.Override.RowSelectorAppearance = appearance10;
            this.grdTotalDiagnosticos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.grdTotalDiagnosticos.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            appearance11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance11.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance11.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            appearance11.BorderColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            appearance11.FontData.BoldAsString = "False";
            appearance11.ForeColor = System.Drawing.Color.Black;
            this.grdTotalDiagnosticos.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.grdTotalDiagnosticos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grdTotalDiagnosticos.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grdTotalDiagnosticos.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.grdTotalDiagnosticos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdTotalDiagnosticos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdTotalDiagnosticos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdTotalDiagnosticos.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.grdTotalDiagnosticos.Location = new System.Drawing.Point(10, 25);
            this.grdTotalDiagnosticos.Margin = new System.Windows.Forms.Padding(2);
            this.grdTotalDiagnosticos.Name = "grdTotalDiagnosticos";
            this.grdTotalDiagnosticos.Size = new System.Drawing.Size(1093, 289);
            this.grdTotalDiagnosticos.TabIndex = 52;
            this.grdTotalDiagnosticos.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdTotalDiagnosticos_ClickCellButton);
            // 
            // frmRecetaMedica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 377);
            this.Controls.Add(this.frmRecetaMedica_Fill_Panel);
            this.Name = "frmRecetaMedica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Receta Medica";
            this.Load += new System.EventHandler(this.frmRecetaMedica_Load);
            this.frmRecetaMedica_Fill_Panel.ClientArea.ResumeLayout(false);
            this.frmRecetaMedica_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalDiagnosticos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPanel frmRecetaMedica_Fill_Panel;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdTotalDiagnosticos;
    }
}