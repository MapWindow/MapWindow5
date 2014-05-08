namespace MapWindow.Forms
{
    partial class MainForm
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Syncfusion.Windows.Forms.Tools.CaptionButtonsCollection ccbLegend = new Syncfusion.Windows.Forms.Tools.CaptionButtonsCollection();
            Syncfusion.Windows.Forms.Tools.CaptionButtonsCollection ccbProgressTextbox = new Syncfusion.Windows.Forms.Tools.CaptionButtonsCollection();
            Syncfusion.Windows.Forms.Tools.TreeNodeAdv treeNodeAdv2 = new Syncfusion.Windows.Forms.Tools.TreeNodeAdv();
            Syncfusion.Windows.Forms.CaptionImage captionImage2 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionLabel captionLabel2 = new Syncfusion.Windows.Forms.CaptionLabel();
            this.dockingManager1 = new Syncfusion.Windows.Forms.Tools.DockingManager(this.components);
            this.Legend = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            this.ProgressTextbox = new System.Windows.Forms.TextBox();
            this.dockingClientPanel1 = new Syncfusion.Windows.Forms.Tools.DockingClientPanel();
            this.axMap1 = new AxMapWinGIS.AxMap();
            this.statusStripEx1 = new Syncfusion.Windows.Forms.Tools.StatusStripEx();
            this.statusStripProjection = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.statusStripDivider2 = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.statusStripMapUnits = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.statusStripDivider1 = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.statusStripCoordinates = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.statusStripTilesProvider = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolButtonNewProject = new System.Windows.Forms.ToolStripButton();
            this.toolButtonAddLayer = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dockingManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Legend)).BeginInit();
            this.dockingClientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).BeginInit();
            this.statusStripEx1.SuspendLayout();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockingManager1
            // 
            this.dockingManager1.ActiveCaptionFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager1.DockLayoutStream = ((System.IO.MemoryStream)(resources.GetObject("dockingManager1.DockLayoutStream")));
            this.dockingManager1.DragProviderStyle = Syncfusion.Windows.Forms.Tools.DragProviderStyle.VS2012;
            this.dockingManager1.HostControl = this;
            this.dockingManager1.InActiveCaptionBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212))))));
            this.dockingManager1.InActiveCaptionFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager1.MetroButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dockingManager1.MetroCaptionColor = System.Drawing.Color.White;
            this.dockingManager1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(159)))), ((int)(((byte)(183)))));
            this.dockingManager1.ReduceFlickeringInRtl = false;
            this.dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"));
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"));
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"));
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"));
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"));
            this.dockingManager1.SetDockLabel(this.Legend, "Legend");
            this.dockingManager1.SetEnableDocking(this.Legend, true);
            ccbLegend.MergeWith(this.dockingManager1.CaptionButtons, false);
            this.dockingManager1.SetCustomCaptionButtons(this.Legend, ccbLegend);
            this.dockingManager1.SetDockLabel(this.ProgressTextbox, "Messages");
            this.dockingManager1.SetEnableDocking(this.ProgressTextbox, true);
            this.dockingManager1.SetAutoHideOnLoad(this.ProgressTextbox, true);
            ccbProgressTextbox.MergeWith(this.dockingManager1.CaptionButtons, false);
            this.dockingManager1.SetCustomCaptionButtons(this.ProgressTextbox, ccbProgressTextbox);
            // 
            // Legend
            // 
            this.Legend.BackColor = System.Drawing.Color.White;
            this.Legend.BeforeTouchSize = new System.Drawing.Size(148, 612);
            this.Legend.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.Legend.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Legend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Legend.CanSelectDisabledNode = false;
            this.Legend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            // 
            // 
            // 
            this.Legend.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Legend.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.Legend.HelpTextControl.Name = "helpText";
            this.Legend.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            this.Legend.HelpTextControl.TabIndex = 0;
            this.Legend.HelpTextControl.Text = "help text";
            this.Legend.HotTracking = true;
            this.Legend.ItemHeight = 24;
            this.Legend.Location = new System.Drawing.Point(1, 19);
            this.Legend.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.Legend.MetroScrollBars = true;
            this.Legend.Name = "Legend";
            treeNodeAdv2.CheckState = System.Windows.Forms.CheckState.Checked;
            treeNodeAdv2.ChildStyle.EnsureDefaultOptionedChild = true;
            treeNodeAdv2.EnsureDefaultOptionedChild = true;
            treeNodeAdv2.Expanded = true;
            treeNodeAdv2.MultiLine = true;
            treeNodeAdv2.PlusMinusSize = new System.Drawing.Size(9, 9);
            treeNodeAdv2.ShowLine = true;
            treeNodeAdv2.ShowOptionButton = false;
            treeNodeAdv2.Text = "Layers";
            this.Legend.Nodes.AddRange(new Syncfusion.Windows.Forms.Tools.TreeNodeAdv[] {
            treeNodeAdv2});
            this.Legend.ScaleFactor = 1F;
            this.Legend.SelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220))))));
            this.Legend.SelectedNodeForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.Legend.ShowCheckBoxes = true;
            this.Legend.ShowFocusRect = false;
            this.Legend.Size = new System.Drawing.Size(148, 612);
            this.Legend.Style = Syncfusion.Windows.Forms.Tools.TreeStyle.Metro;
            this.Legend.TabIndex = 3;
            this.Legend.Text = "treeViewAdv1";
            // 
            // 
            // 
            this.Legend.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.Legend.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Legend.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.Legend.ToolTipControl.Name = "toolTip";
            this.Legend.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            this.Legend.ToolTipControl.TabIndex = 1;
            this.Legend.ToolTipControl.Text = "toolTip";
            this.Legend.TransparentControls = true;
            // 
            // ProgressTextbox
            // 
            this.ProgressTextbox.Location = new System.Drawing.Point(1, 19);
            this.ProgressTextbox.Multiline = true;
            this.ProgressTextbox.Name = "ProgressTextbox";
            this.ProgressTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProgressTextbox.Size = new System.Drawing.Size(912, 65);
            this.ProgressTextbox.TabIndex = 5;
            // 
            // dockingClientPanel1
            // 
            this.dockingClientPanel1.Controls.Add(this.axMap1);
            this.dockingClientPanel1.Location = new System.Drawing.Point(154, 46);
            this.dockingClientPanel1.Name = "dockingClientPanel1";
            this.dockingClientPanel1.Size = new System.Drawing.Size(914, 543);
            this.dockingClientPanel1.SizeToFit = true;
            this.dockingClientPanel1.TabIndex = 0;
            // 
            // axMap1
            // 
            this.axMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMap1.Enabled = true;
            this.axMap1.Location = new System.Drawing.Point(0, 0);
            this.axMap1.Name = "axMap1";
            this.axMap1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMap1.OcxState")));
            this.axMap1.Size = new System.Drawing.Size(914, 543);
            this.axMap1.TabIndex = 0;
            this.axMap1.MouseMoveEvent += new AxMapWinGIS._DMapEvents_MouseMoveEventHandler(this.AxMap1MouseMoveEvent);
            this.axMap1.FileDropped += new AxMapWinGIS._DMapEvents_FileDroppedEventHandler(this.AxMap1FileDropped);
            // 
            // statusStripEx1
            // 
            this.statusStripEx1.AutoSize = false;
            this.statusStripEx1.BeforeTouchSize = new System.Drawing.Size(1068, 20);
            this.statusStripEx1.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Bottom;
            this.statusStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripProjection,
            this.statusStripDivider2,
            this.statusStripMapUnits,
            this.statusStripDivider1,
            this.statusStripCoordinates,
            this.statusStripTilesProvider,
            this.statusStripProgressLabel,
            this.statusStripProgressBar});
            this.statusStripEx1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStripEx1.Location = new System.Drawing.Point(0, 678);
            this.statusStripEx1.MetroColor = System.Drawing.Color.Empty;
            this.statusStripEx1.Name = "statusStripEx1";
            this.statusStripEx1.ShowItemToolTips = true;
            this.statusStripEx1.Size = new System.Drawing.Size(1068, 20);
            this.statusStripEx1.TabIndex = 1;
            this.statusStripEx1.Text = "statusStripEx1";
            this.statusStripEx1.VisualStyle = Syncfusion.Windows.Forms.Tools.StatusStripExStyle.Metro;
            // 
            // statusStripProjection
            // 
            this.statusStripProjection.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.statusStripProjection.Name = "statusStripProjection";
            this.statusStripProjection.Size = new System.Drawing.Size(61, 15);
            this.statusStripProjection.Text = "Projection";
            this.statusStripProjection.ToolTipText = "The projection of the map";
            // 
            // statusStripDivider2
            // 
            this.statusStripDivider2.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.statusStripDivider2.Name = "statusStripDivider2";
            this.statusStripDivider2.Size = new System.Drawing.Size(16, 15);
            this.statusStripDivider2.Text = " | ";
            // 
            // statusStripMapUnits
            // 
            this.statusStripMapUnits.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.statusStripMapUnits.Name = "statusStripMapUnits";
            this.statusStripMapUnits.Size = new System.Drawing.Size(61, 15);
            this.statusStripMapUnits.Text = "Map Units";
            this.statusStripMapUnits.ToolTipText = "The map units for the map";
            // 
            // statusStripDivider1
            // 
            this.statusStripDivider1.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.statusStripDivider1.Name = "statusStripDivider1";
            this.statusStripDivider1.Size = new System.Drawing.Size(16, 15);
            this.statusStripDivider1.Text = " | ";
            // 
            // statusStripCoordinates
            // 
            this.statusStripCoordinates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusStripCoordinates.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.statusStripCoordinates.Name = "statusStripCoordinates";
            this.statusStripCoordinates.Size = new System.Drawing.Size(71, 15);
            this.statusStripCoordinates.StatusString = "Show the coordinates";
            this.statusStripCoordinates.Text = "Coordinates";
            this.statusStripCoordinates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusStripCoordinates.ToolTipText = "The coordinates at the mouse pointer";
            // 
            // statusStripTilesProvider
            // 
            this.statusStripTilesProvider.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusStripTilesProvider.DoubleClickEnabled = true;
            this.statusStripTilesProvider.Name = "statusStripTilesProvider";
            this.statusStripTilesProvider.Size = new System.Drawing.Size(78, 15);
            this.statusStripTilesProvider.Text = "Tiles provider";
            this.statusStripTilesProvider.ToolTipText = "The tiles provider, double click to change.";
            this.statusStripTilesProvider.DoubleClick += new System.EventHandler(this.StatusStripTilesProviderDoubleClick);
            // 
            // statusStripProgressLabel
            // 
            this.statusStripProgressLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusStripProgressLabel.Name = "statusStripProgressLabel";
            this.statusStripProgressLabel.Size = new System.Drawing.Size(52, 15);
            this.statusStripProgressLabel.Text = "Progress";
            // 
            // statusStripProgressBar
            // 
            this.statusStripProgressBar.Name = "statusStripProgressBar";
            this.statusStripProgressBar.Size = new System.Drawing.Size(100, 14);
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonNewProject,
            this.toolButtonAddLayer});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Office12Mode = false;
            this.toolStripEx1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.ShowItemToolTips = true;
            this.toolStripEx1.ShowLauncher = false;
            this.toolStripEx1.Size = new System.Drawing.Size(1068, 46);
            this.toolStripEx1.Stretch = true;
            this.toolStripEx1.TabIndex = 2;
            // 
            // toolButtonNewProject
            // 
            this.toolButtonNewProject.BackColor = System.Drawing.Color.White;
            this.toolButtonNewProject.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonNewProject.Image")));
            this.toolButtonNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonNewProject.Name = "toolButtonNewProject";
            this.toolButtonNewProject.Size = new System.Drawing.Size(35, 43);
            this.toolButtonNewProject.Text = "New";
            this.toolButtonNewProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolButtonNewProject.ToolTipText = "New project";
            this.toolButtonNewProject.Click += new System.EventHandler(this.ToolStripButton1Click);
            // 
            // toolButtonAddLayer
            // 
            this.toolButtonAddLayer.BackColor = System.Drawing.Color.White;
            this.toolButtonAddLayer.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonAddLayer.Image")));
            this.toolButtonAddLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonAddLayer.Name = "toolButtonAddLayer";
            this.toolButtonAddLayer.Size = new System.Drawing.Size(33, 43);
            this.toolButtonAddLayer.Text = "Add";
            this.toolButtonAddLayer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolButtonAddLayer.ToolTipText = "Add layer, opens a new form";
            this.toolButtonAddLayer.Click += new System.EventHandler(this.ToolButtonAddLayerClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderThickness = 2;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            this.CaptionBarHeight = 48;
            this.CaptionButtonColor = System.Drawing.Color.DimGray;
            this.CaptionFont = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            captionImage2.BackColor = System.Drawing.Color.Transparent;
            captionImage2.Image = ((System.Drawing.Image)(resources.GetObject("captionImage2.Image")));
            captionImage2.Location = new System.Drawing.Point(6, 0);
            captionImage2.Name = "CaptionImage2";
            captionImage2.Size = new System.Drawing.Size(48, 48);
            this.CaptionImages.Add(captionImage2);
            captionLabel2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            captionLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            captionLabel2.Location = new System.Drawing.Point(60, 2);
            captionLabel2.Name = "CaptionLabel1";
            captionLabel2.Size = new System.Drawing.Size(400, 46);
            captionLabel2.Text = "MapWindow Open Source GIS";
            this.CaptionLabels.Add(captionLabel2);
            this.ClientSize = new System.Drawing.Size(1068, 698);
            this.Controls.Add(this.toolStripEx1);
            this.Controls.Add(this.statusStripEx1);
            this.Controls.Add(this.dockingClientPanel1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::MapWindow.Properties.Settings.Default, "MainForm_location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("StartPosition", global::MapWindow.Properties.Settings.Default, "MainForm_startLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("WindowState", global::MapWindow.Properties.Settings.Default, "MainForm_windowState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.DropShadow = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::MapWindow.Properties.Settings.Default.MainForm_location;
            this.MetroColor = System.Drawing.Color.Silver;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = global::MapWindow.Properties.Settings.Default.MainForm_startLocation;
            this.WindowState = global::MapWindow.Properties.Settings.Default.MainForm_windowState;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dockingManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Legend)).EndInit();
            this.dockingClientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).EndInit();
            this.statusStripEx1.ResumeLayout(false);
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.DockingManager dockingManager1;
        private Syncfusion.Windows.Forms.Tools.DockingClientPanel dockingClientPanel1;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripButton toolButtonNewProject;
        private Syncfusion.Windows.Forms.Tools.StatusStripEx statusStripEx1;
        private System.Windows.Forms.ToolStripProgressBar statusStripProgressBar;
        private Syncfusion.Windows.Forms.Tools.TreeViewAdv Legend;
        private AxMapWinGIS.AxMap axMap1;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusStripProjection;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusStripCoordinates;
        private System.Windows.Forms.ToolStripStatusLabel statusStripTilesProvider;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusStripMapUnits;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusStripDivider2;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusStripDivider1;
        private System.Windows.Forms.ToolStripButton toolButtonAddLayer;
        private System.Windows.Forms.TextBox ProgressTextbox;
        private System.Windows.Forms.ToolStripStatusLabel statusStripProgressLabel;
    }
}

