namespace Vista
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.ribbonControlAdv1 = new Syncfusion.Windows.Forms.Tools.RibbonControlAdv();
            this.tabbedGroupedmdiManager1 = new Syncfusion.Windows.Forms.Tools.TabbedGroupedMDIManager();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlAdv1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControlAdv1
            // 
            this.ribbonControlAdv1.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Top;
            this.ribbonControlAdv1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ribbonControlAdv1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControlAdv1.MenuButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ribbonControlAdv1.MenuButtonText = "";
            this.ribbonControlAdv1.MenuButtonWidth = 56;
            this.ribbonControlAdv1.MenuColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.ribbonControlAdv1.Name = "ribbonControlAdv1";
            this.ribbonControlAdv1.OfficeColorScheme = Syncfusion.Windows.Forms.Tools.ToolStripEx.ColorScheme.Managed;
            // 
            // 
            // 
            this.ribbonControlAdv1.OfficeMenu.Name = "";
            this.ribbonControlAdv1.OfficeMenu.ShowItemToolTips = true;
            this.ribbonControlAdv1.OfficeMenu.Size = new System.Drawing.Size(12, 65);
            this.ribbonControlAdv1.QuickPanelImageLayout = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ribbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.None;
            this.ribbonControlAdv1.RibbonStyle = Syncfusion.Windows.Forms.Tools.RibbonStyle.Office2016;
            this.ribbonControlAdv1.SelectedTab = null;
            this.ribbonControlAdv1.ShowRibbonDisplayOptionButton = true;
            this.ribbonControlAdv1.Size = new System.Drawing.Size(577, 100);
            this.ribbonControlAdv1.SystemText.QuickAccessDialogDropDownName = "Start menu";
            this.ribbonControlAdv1.SystemText.RenameDisplayLabelText = "&Display Name:";
            this.ribbonControlAdv1.TabIndex = 2;
            this.ribbonControlAdv1.Text = "ribbonControlAdv1";
            this.ribbonControlAdv1.ThemeName = "Office2016";
            // 
            // tabbedGroupedmdiManager1
            // 
            this.tabbedGroupedmdiManager1.AttachedTo = null;
            this.tabbedGroupedmdiManager1.CloseButtonBackColor = System.Drawing.Color.White;
            this.tabbedGroupedmdiManager1.CloseButtonToolTip = "";
            this.tabbedGroupedmdiManager1.DropDownButtonToolTip = "";
            this.tabbedGroupedmdiManager1.ImageSize = new System.Drawing.Size(16, 16);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 287);
            this.Controls.Add(this.ribbonControlAdv1);
            this.IsMdiContainer = true;
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlAdv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.RibbonControlAdv ribbonControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabbedGroupedMDIManager tabbedGroupedmdiManager1;
    }
}