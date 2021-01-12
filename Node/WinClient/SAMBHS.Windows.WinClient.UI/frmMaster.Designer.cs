﻿namespace SAMBHS.Windows.WinClient.UI
{
    partial class frmMaster
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
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedBottom, new System.Guid("dc82f5d2-1506-4133-9d88-cf69c9e0f71e"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("f8cf2aa8-4447-4650-bdd6-6e26d98b354d"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("dc82f5d2-1506-4133-9d88-cf69c9e0f71e"), -1);
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("search");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.Default, "Info", Infragistics.Win.DefaultableBoolean.True);
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("lblPeriodo");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("ListForm");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("lblPeriodo");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("ListForm");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAbout");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaster));
            this.txtOutputMessages = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraRibbonCustomizationProvider1 = new Infragistics.Win.SupportDialogs.RibbonCustomizationProvider.UltraRibbonCustomizationProvider(this.components);
            this.ultraTabbedMdiManager1 = new Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager(this.components);
            this.statusStrip1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.bwkMasterProgressbar = new System.ComponentModel.BackgroundWorker();
            this.bwkBuscaActualizaciones = new System.ComponentModel.BackgroundWorker();
            this.t_RevisaConexion = new System.Windows.Forms.Timer(this.components);
            this.bwkRevisaConexion = new System.ComponentModel.BackgroundWorker();
            this.ultraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._frmMasterUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmMasterUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmMasterUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmMasterUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmMasterAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.bwkLlenaCacheCombos = new System.ComponentModel.BackgroundWorker();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.cbTextSearch = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.pNotificationBar = new System.Windows.Forms.Panel();
            this.linkCerrarBar = new System.Windows.Forms.LinkLabel();
            this.linkReiniciar = new System.Windows.Forms.LinkLabel();
            this.pbActualizacionImg = new System.Windows.Forms.PictureBox();
            this.lblDownloadNotification = new System.Windows.Forms.Label();
            this.t_BuscaActualizaciones = new System.Windows.Forms.Timer(this.components);
            this.appStylistRuntime1 = new Infragistics.Win.AppStyling.Runtime.AppStylistRuntime(this.components);
            this._frmMaster_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._frmMaster_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmMaster_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmMaster_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutputMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).BeginInit();
            this.windowDockingArea1.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTextSearch)).BeginInit();
            this.pNotificationBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbActualizacionImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutputMessages
            // 
            this.txtOutputMessages.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputMessages.Location = new System.Drawing.Point(0, 18);
            this.txtOutputMessages.Multiline = true;
            this.txtOutputMessages.Name = "txtOutputMessages";
            this.txtOutputMessages.ReadOnly = true;
            this.txtOutputMessages.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutputMessages.Size = new System.Drawing.Size(1092, 77);
            this.txtOutputMessages.TabIndex = 17;
            // 
            // ultraTabbedMdiManager1
            // 
            this.ultraTabbedMdiManager1.AllowMaximize = true;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.White;
            this.ultraTabbedMdiManager1.Appearance = appearance1;
            this.ultraTabbedMdiManager1.MdiParent = this;
            this.ultraTabbedMdiManager1.SettingsKey = "frmMaster.ultraTabbedMdiManager1";
            this.ultraTabbedMdiManager1.TabGroupSettings.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Borderless;
            appearance11.BorderColor = System.Drawing.Color.Transparent;
            appearance11.BorderColor2 = System.Drawing.Color.Transparent;
            this.ultraTabbedMdiManager1.TabGroupSettings.CloseButtonAppearance = appearance11;
            this.ultraTabbedMdiManager1.TabGroupSettings.CloseButtonLocation = Infragistics.Win.UltraWinTabs.TabCloseButtonLocation.Tab;
            this.ultraTabbedMdiManager1.TabGroupSettings.TabButtonStyle = Infragistics.Win.UIElementButtonStyle.Borderless;
            this.ultraTabbedMdiManager1.TabGroupSettings.TabStyle = Infragistics.Win.UltraWinTabs.TabStyle.Office2010Ribbon;
            this.ultraTabbedMdiManager1.TabSettings.DisplayFormIcon = Infragistics.Win.DefaultableBoolean.True;
            this.ultraTabbedMdiManager1.TabSettings.TabWidth = 190;
            // 
            // statusStrip1
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            appearance5.BackColorAlpha = Infragistics.Win.Alpha.Opaque;
            appearance5.ForeColor = System.Drawing.Color.White;
            this.statusStrip1.Appearance = appearance5;
            this.statusStrip1.Location = new System.Drawing.Point(0, 423);
            this.statusStrip1.Name = "statusStrip1";
            appearance6.Image = global::SAMBHS.Windows.WinClient.UI.Properties.Resources.script_gear;
            appearance6.TextHAlignAsString = "Left";
            ultraStatusPanel1.Appearance = appearance6;
            ultraStatusPanel1.Width = 140;
            appearance7.Image = global::SAMBHS.Windows.WinClient.UI.Properties.Resources.database_yellow_start;
            appearance7.TextHAlignAsString = "Left";
            ultraStatusPanel2.Appearance = appearance7;
            ultraStatusPanel2.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Adjustable;
            ultraStatusPanel2.Width = 210;
            appearance8.Image = global::SAMBHS.Windows.WinClient.UI.Properties.Resources.user_suit_black;
            appearance8.TextHAlignAsString = "Left";
            ultraStatusPanel3.Appearance = appearance8;
            ultraStatusPanel3.Width = 280;
            appearance9.Image = global::SAMBHS.Windows.WinClient.UI.Properties.Resources.folder_key;
            appearance9.TextHAlignAsString = "Left";
            ultraStatusPanel4.Appearance = appearance9;
            ultraStatusPanel4.Width = 320;
            appearance10.TextHAlignAsString = "Center";
            ultraStatusPanel5.Appearance = appearance10;
            ultraStatusPanel5.Key = "pbrMaster";
            ultraStatusPanel5.ProgressBarInfo.Style = Infragistics.Win.UltraWinProgressBar.ProgressBarStyle.Continuous;
            ultraStatusPanel5.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel5.Visible = false;
            this.statusStrip1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5});
            this.statusStrip1.Size = new System.Drawing.Size(1094, 27);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "ultraStatusBar1";
            // 
            // bwkMasterProgressbar
            // 
            this.bwkMasterProgressbar.WorkerReportsProgress = true;
            this.bwkMasterProgressbar.WorkerSupportsCancellation = true;
            this.bwkMasterProgressbar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwkMasterProgressbar_DoWork);
            this.bwkMasterProgressbar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwkMasterProgressbar_RunWorkerCompleted);
            // 
            // bwkBuscaActualizaciones
            // 
            this.bwkBuscaActualizaciones.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwkBuscaActualizaciones_DoWork);
            // 
            // t_RevisaConexion
            // 
            this.t_RevisaConexion.Interval = 350;
            this.t_RevisaConexion.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bwkRevisaConexion
            // 
            this.bwkRevisaConexion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwkRevisaConexion_DoWork);
            this.bwkRevisaConexion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwkRevisaConexion_RunWorkerCompleted);
            // 
            // ultraDockManager1
            // 
            this.ultraDockManager1.CompressUnpinnedTabs = false;
            dockableControlPane1.Closed = true;
            dockableControlPane1.Control = this.txtOutputMessages;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(-1, 95);
            dockableControlPane1.Minimized = true;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(379, 143, 100, 21);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Proceso";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(1092, 95);
            this.ultraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.ultraDockManager1.HostControl = this;
            // 
            // _frmMasterUnpinnedTabAreaLeft
            // 
            this._frmMasterUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._frmMasterUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._frmMasterUnpinnedTabAreaLeft.Location = new System.Drawing.Point(8, 57);
            this._frmMasterUnpinnedTabAreaLeft.Name = "_frmMasterUnpinnedTabAreaLeft";
            this._frmMasterUnpinnedTabAreaLeft.Owner = this.ultraDockManager1;
            this._frmMasterUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 366);
            this._frmMasterUnpinnedTabAreaLeft.TabIndex = 12;
            // 
            // _frmMasterUnpinnedTabAreaRight
            // 
            this._frmMasterUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._frmMasterUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._frmMasterUnpinnedTabAreaRight.Location = new System.Drawing.Point(1086, 57);
            this._frmMasterUnpinnedTabAreaRight.Name = "_frmMasterUnpinnedTabAreaRight";
            this._frmMasterUnpinnedTabAreaRight.Owner = this.ultraDockManager1;
            this._frmMasterUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 366);
            this._frmMasterUnpinnedTabAreaRight.TabIndex = 13;
            // 
            // _frmMasterUnpinnedTabAreaTop
            // 
            this._frmMasterUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._frmMasterUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._frmMasterUnpinnedTabAreaTop.Location = new System.Drawing.Point(8, 57);
            this._frmMasterUnpinnedTabAreaTop.Name = "_frmMasterUnpinnedTabAreaTop";
            this._frmMasterUnpinnedTabAreaTop.Owner = this.ultraDockManager1;
            this._frmMasterUnpinnedTabAreaTop.Size = new System.Drawing.Size(1078, 0);
            this._frmMasterUnpinnedTabAreaTop.TabIndex = 14;
            // 
            // _frmMasterUnpinnedTabAreaBottom
            // 
            this._frmMasterUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._frmMasterUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._frmMasterUnpinnedTabAreaBottom.Location = new System.Drawing.Point(8, 423);
            this._frmMasterUnpinnedTabAreaBottom.Name = "_frmMasterUnpinnedTabAreaBottom";
            this._frmMasterUnpinnedTabAreaBottom.Owner = this.ultraDockManager1;
            this._frmMasterUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1078, 0);
            this._frmMasterUnpinnedTabAreaBottom.TabIndex = 15;
            // 
            // _frmMasterAutoHideControl
            // 
            this._frmMasterAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._frmMasterAutoHideControl.Location = new System.Drawing.Point(1, 387);
            this._frmMasterAutoHideControl.Name = "_frmMasterAutoHideControl";
            this._frmMasterAutoHideControl.Owner = this.ultraDockManager1;
            this._frmMasterAutoHideControl.Size = new System.Drawing.Size(1092, 10);
            this._frmMasterAutoHideControl.TabIndex = 16;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Controls.Add(this.dockableWindow1);
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowDockingArea1.Location = new System.Drawing.Point(1, 297);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.ultraDockManager1;
            this.windowDockingArea1.Size = new System.Drawing.Size(1092, 100);
            this.windowDockingArea1.TabIndex = 18;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.txtOutputMessages);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 5);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.ultraDockManager1;
            this.dockableWindow1.Size = new System.Drawing.Size(1092, 95);
            this.dockableWindow1.TabIndex = 39;
            // 
            // bwkLlenaCacheCombos
            // 
            this.bwkLlenaCacheCombos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwkLlenaCacheCombos_DoWork);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // cbTextSearch
            // 
            this.cbTextSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTextSearch.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cbTextSearch.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            appearance2.Image = global::SAMBHS.Windows.WinClient.UI.Resource.system_search;
            editorButton1.Appearance = appearance2;
            editorButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013ScrollbarButton;
            editorButton1.Key = "search";
            this.cbTextSearch.ButtonsRight.Add(editorButton1);
            this.cbTextSearch.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.cbTextSearch.DropDownListWidth = 200;
            this.cbTextSearch.Location = new System.Drawing.Point(806, 8);
            this.cbTextSearch.Name = "cbTextSearch";
            this.cbTextSearch.NullText = "Inicio rápido...";
            appearance3.FontData.ItalicAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.Gray;
            this.cbTextSearch.NullTextAppearance = appearance3;
            this.cbTextSearch.Size = new System.Drawing.Size(144, 21);
            this.cbTextSearch.TabIndex = 33;
            ultraToolTipInfo1.Enabled = Infragistics.Win.DefaultableBoolean.True;
            ultraToolTipInfo1.ToolTipTextFormatted = "Busca un Formulario, <span style=\"font-weight:bold;\">Desde&edsp;&edsp;aqui</span>" +
    "";
            ultraToolTipInfo1.ToolTipTitle = "Info";
            this.ultraToolTipManager1.SetUltraToolTip(this.cbTextSearch, ultraToolTipInfo1);
            this.cbTextSearch.AfterCloseUp += new System.EventHandler(this.cbTextSearch_AfterCloseUp);
            this.cbTextSearch.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.cbTextSearch_EditorButtonClick);
            this.cbTextSearch.Enter += new System.EventHandler(this.cbTextSearch_Enter);
            // 
            // pNotificationBar
            // 
            this.pNotificationBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pNotificationBar.Controls.Add(this.linkCerrarBar);
            this.pNotificationBar.Controls.Add(this.linkReiniciar);
            this.pNotificationBar.Controls.Add(this.pbActualizacionImg);
            this.pNotificationBar.Controls.Add(this.lblDownloadNotification);
            this.pNotificationBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pNotificationBar.Location = new System.Drawing.Point(8, 57);
            this.pNotificationBar.Name = "pNotificationBar";
            this.pNotificationBar.Size = new System.Drawing.Size(1078, 25);
            this.pNotificationBar.TabIndex = 27;
            this.pNotificationBar.Visible = false;
            // 
            // linkCerrarBar
            // 
            this.linkCerrarBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkCerrarBar.AutoSize = true;
            this.linkCerrarBar.Location = new System.Drawing.Point(1037, 6);
            this.linkCerrarBar.Name = "linkCerrarBar";
            this.linkCerrarBar.Size = new System.Drawing.Size(35, 13);
            this.linkCerrarBar.TabIndex = 3;
            this.linkCerrarBar.TabStop = true;
            this.linkCerrarBar.Text = "Cerrar";
            this.linkCerrarBar.Visible = false;
            this.linkCerrarBar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCerrarBar_LinkClicked);
            // 
            // linkReiniciar
            // 
            this.linkReiniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkReiniciar.AutoSize = true;
            this.linkReiniciar.Location = new System.Drawing.Point(954, 6);
            this.linkReiniciar.Name = "linkReiniciar";
            this.linkReiniciar.Size = new System.Drawing.Size(78, 13);
            this.linkReiniciar.TabIndex = 2;
            this.linkReiniciar.TabStop = true;
            this.linkReiniciar.Text = "Reiniciar ahora";
            this.linkReiniciar.Visible = false;
            this.linkReiniciar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReiniciar_LinkClicked);
            // 
            // pbActualizacionImg
            // 
            this.pbActualizacionImg.Image = global::SAMBHS.Windows.WinClient.UI.Resource.loadingfinal1;
            this.pbActualizacionImg.Location = new System.Drawing.Point(3, 3);
            this.pbActualizacionImg.Name = "pbActualizacionImg";
            this.pbActualizacionImg.Size = new System.Drawing.Size(22, 19);
            this.pbActualizacionImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbActualizacionImg.TabIndex = 1;
            this.pbActualizacionImg.TabStop = false;
            // 
            // lblDownloadNotification
            // 
            this.lblDownloadNotification.AutoSize = true;
            this.lblDownloadNotification.Location = new System.Drawing.Point(31, 6);
            this.lblDownloadNotification.Name = "lblDownloadNotification";
            this.lblDownloadNotification.Size = new System.Drawing.Size(169, 13);
            this.lblDownloadNotification.TabIndex = 0;
            this.lblDownloadNotification.Text = "Descargando Actualización... 50%";
            // 
            // t_BuscaActualizaciones
            // 
            this.t_BuscaActualizaciones.Interval = 300000;
            this.t_BuscaActualizaciones.Tick += new System.EventHandler(this.t_BuscaActualizaciones_Tick);
            // 
            // _frmMaster_Toolbars_Dock_Area_Left
            // 
            this._frmMaster_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmMaster_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmMaster_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._frmMaster_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmMaster_Toolbars_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._frmMaster_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 57);
            this._frmMaster_Toolbars_Dock_Area_Left.Name = "_frmMaster_Toolbars_Dock_Area_Left";
            this._frmMaster_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(8, 366);
            this._frmMaster_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.IsGlassSupported = false;
            this.ultraToolbarsManager1.Office2007UICompatibility = false;
            this.ultraToolbarsManager1.Ribbon.FileMenuStyle = Infragistics.Win.UltraWinToolbars.FileMenuStyle.None;
            this.ultraToolbarsManager1.Ribbon.TabItemToolbar.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            labelTool3,
            popupMenuTool1});
            this.ultraToolbarsManager1.Ribbon.Visible = true;
            appearance4.FontData.BoldAsString = "True";
            appearance4.ForeColor = System.Drawing.Color.White;
            labelTool4.SharedPropsInternal.AppearancesSmall.Appearance = appearance4;
            labelTool4.SharedPropsInternal.Caption = "lblPeriodo";
            labelTool4.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool2.SharedPropsInternal.CustomizerCaption = " ";
            popupMenuTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool2.SharedPropsInternal.Caption = "Acerca de";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            labelTool4,
            popupMenuTool2,
            buttonTool2});
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _frmMaster_Toolbars_Dock_Area_Right
            // 
            this._frmMaster_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmMaster_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmMaster_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._frmMaster_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmMaster_Toolbars_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmMaster_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1086, 57);
            this._frmMaster_Toolbars_Dock_Area_Right.Name = "_frmMaster_Toolbars_Dock_Area_Right";
            this._frmMaster_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(8, 366);
            this._frmMaster_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _frmMaster_Toolbars_Dock_Area_Top
            // 
            this._frmMaster_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmMaster_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmMaster_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._frmMaster_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmMaster_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmMaster_Toolbars_Dock_Area_Top.Name = "_frmMaster_Toolbars_Dock_Area_Top";
            this._frmMaster_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1094, 57);
            this._frmMaster_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _frmMaster_Toolbars_Dock_Area_Bottom
            // 
            this._frmMaster_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmMaster_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmMaster_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._frmMaster_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmMaster_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 423);
            this._frmMaster_Toolbars_Dock_Area_Bottom.Name = "_frmMaster_Toolbars_Dock_Area_Bottom";
            this._frmMaster_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1094, 0);
            this._frmMaster_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // frmMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1094, 450);
            this.Controls.Add(this._frmMasterAutoHideControl);
            this.Controls.Add(this.cbTextSearch);
            this.Controls.Add(this.pNotificationBar);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._frmMasterUnpinnedTabAreaTop);
            this.Controls.Add(this._frmMasterUnpinnedTabAreaBottom);
            this.Controls.Add(this._frmMasterUnpinnedTabAreaLeft);
            this.Controls.Add(this._frmMasterUnpinnedTabAreaRight);
            this.Controls.Add(this._frmMaster_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._frmMaster_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._frmMaster_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._frmMaster_Toolbars_Dock_Area_Top);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmMaster";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NETCONTA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMaster_FormClosing);
            this.Load += new System.EventHandler(this.frmMaster_Load);
            this.Resize += new System.EventHandler(this.frmMaster_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.txtOutputMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).EndInit();
            this.windowDockingArea1.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.dockableWindow1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTextSearch)).EndInit();
            this.pNotificationBar.ResumeLayout(false);
            this.pNotificationBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbActualizacionImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.SupportDialogs.RibbonCustomizationProvider.UltraRibbonCustomizationProvider ultraRibbonCustomizationProvider1;
        private Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager ultraTabbedMdiManager1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar statusStrip1;
        public System.ComponentModel.BackgroundWorker bwkMasterProgressbar;
        private System.ComponentModel.BackgroundWorker bwkBuscaActualizaciones;
        private System.Windows.Forms.Timer t_RevisaConexion;
        private System.ComponentModel.BackgroundWorker bwkRevisaConexion;
        private Infragistics.Win.UltraWinDock.AutoHideControl _frmMasterAutoHideControl;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtOutputMessages;
        private Infragistics.Win.UltraWinDock.UltraDockManager ultraDockManager1;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmMasterUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmMasterUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmMasterUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmMasterUnpinnedTabAreaBottom;
        private System.ComponentModel.BackgroundWorker bwkLlenaCacheCombos;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.Panel pNotificationBar;
        private System.Windows.Forms.PictureBox pbActualizacionImg;
        private System.Windows.Forms.Label lblDownloadNotification;
        private System.Windows.Forms.LinkLabel linkCerrarBar;
        private System.Windows.Forms.LinkLabel linkReiniciar;
        private System.Windows.Forms.Timer t_BuscaActualizaciones;
        private Infragistics.Win.AppStyling.Runtime.AppStylistRuntime appStylistRuntime1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbTextSearch;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmMaster_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmMaster_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmMaster_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmMaster_Toolbars_Dock_Area_Top;
    }
}