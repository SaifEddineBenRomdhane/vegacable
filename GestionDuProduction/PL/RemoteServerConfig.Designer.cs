namespace GestionDuProduction.PL
{
    partial class RemoteServerConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteServerConfig));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties9 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties10 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lblNom = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtIP = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.txtPort = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.txtNom = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.txtPass = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.bunifuButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnCnx = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.SuspendLayout();
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(129)))), ((int)(((byte)(3)))));
            this.rectangleShape2.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(349, 238);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2});
            this.shapeContainer1.Size = new System.Drawing.Size(351, 239);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNom.Location = new System.Drawing.Point(14, 15);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(236, 22);
            this.lblNom.TabIndex = 117;
            this.lblNom.Text = "Config Remote Connection ";
            // 
            // txtIP
            // 
            this.txtIP.AcceptsReturn = false;
            this.txtIP.AcceptsTab = false;
            this.txtIP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtIP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtIP.BackColor = System.Drawing.Color.Transparent;
            this.txtIP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtIP.BackgroundImage")));
            this.txtIP.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            this.txtIP.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtIP.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(38)))), ((int)(((byte)(157)))));
            this.txtIP.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.txtIP.BorderRadius = 1;
            this.txtIP.BorderThickness = 0;
            this.txtIP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtIP.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.DefaultText = "";
            this.txtIP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.txtIP.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtIP.HideSelection = true;
            this.txtIP.IconLeft = null;
            this.txtIP.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txtIP.IconPadding = 10;
            this.txtIP.IconRight = null;
            this.txtIP.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txtIP.Location = new System.Drawing.Point(31, 62);
            this.txtIP.MaxLength = 32767;
            this.txtIP.MinimumSize = new System.Drawing.Size(100, 34);
            this.txtIP.Modified = false;
            this.txtIP.Name = "txtIP";
            this.txtIP.PasswordChar = '\0';
            this.txtIP.ReadOnly = false;
            this.txtIP.SelectedText = "";
            this.txtIP.SelectionLength = 0;
            this.txtIP.SelectionStart = 0;
            this.txtIP.ShortcutsEnabled = true;
            this.txtIP.Size = new System.Drawing.Size(178, 34);
            this.txtIP.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txtIP.TabIndex = 155;
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIP.TextMarginLeft = 5;
            this.txtIP.TextPlaceholder = "192.168.1.1";
            this.txtIP.UseSystemPasswordChar = false;
            // 
            // txtPort
            // 
            this.txtPort.AcceptsReturn = false;
            this.txtPort.AcceptsTab = false;
            this.txtPort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPort.BackColor = System.Drawing.Color.Transparent;
            this.txtPort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtPort.BackgroundImage")));
            this.txtPort.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            this.txtPort.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtPort.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(38)))), ((int)(((byte)(157)))));
            this.txtPort.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.txtPort.BorderRadius = 1;
            this.txtPort.BorderThickness = 0;
            this.txtPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPort.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.DefaultText = "";
            this.txtPort.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.txtPort.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPort.HideSelection = true;
            this.txtPort.IconLeft = null;
            this.txtPort.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txtPort.IconPadding = 10;
            this.txtPort.IconRight = null;
            this.txtPort.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txtPort.Location = new System.Drawing.Point(217, 62);
            this.txtPort.MaxLength = 32767;
            this.txtPort.MinimumSize = new System.Drawing.Size(100, 34);
            this.txtPort.Modified = false;
            this.txtPort.Name = "txtPort";
            this.txtPort.PasswordChar = '\0';
            this.txtPort.ReadOnly = false;
            this.txtPort.SelectedText = "";
            this.txtPort.SelectionLength = 0;
            this.txtPort.SelectionStart = 0;
            this.txtPort.ShortcutsEnabled = true;
            this.txtPort.Size = new System.Drawing.Size(101, 34);
            this.txtPort.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txtPort.TabIndex = 156;
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPort.TextMarginLeft = 5;
            this.txtPort.TextPlaceholder = "1433";
            this.txtPort.UseSystemPasswordChar = false;
            // 
            // txtNom
            // 
            this.txtNom.AcceptsReturn = false;
            this.txtNom.AcceptsTab = false;
            this.txtNom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtNom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtNom.BackColor = System.Drawing.Color.Transparent;
            this.txtNom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtNom.BackgroundImage")));
            this.txtNom.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            this.txtNom.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtNom.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(38)))), ((int)(((byte)(157)))));
            this.txtNom.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.txtNom.BorderRadius = 1;
            this.txtNom.BorderThickness = 0;
            this.txtNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNom.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNom.DefaultText = "";
            this.txtNom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.txtNom.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtNom.HideSelection = true;
            this.txtNom.IconLeft = null;
            this.txtNom.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txtNom.IconPadding = 10;
            this.txtNom.IconRight = null;
            this.txtNom.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txtNom.Location = new System.Drawing.Point(31, 102);
            this.txtNom.MaxLength = 32767;
            this.txtNom.MinimumSize = new System.Drawing.Size(100, 34);
            this.txtNom.Modified = false;
            this.txtNom.Name = "txtNom";
            this.txtNom.PasswordChar = '\0';
            this.txtNom.ReadOnly = false;
            this.txtNom.SelectedText = "";
            this.txtNom.SelectionLength = 0;
            this.txtNom.SelectionStart = 0;
            this.txtNom.ShortcutsEnabled = true;
            this.txtNom.Size = new System.Drawing.Size(287, 34);
            this.txtNom.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txtNom.TabIndex = 157;
            this.txtNom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNom.TextMarginLeft = 5;
            this.txtNom.TextPlaceholder = "Server User Name";
            this.txtNom.UseSystemPasswordChar = false;
            // 
            // txtPass
            // 
            this.txtPass.AcceptsReturn = false;
            this.txtPass.AcceptsTab = false;
            this.txtPass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPass.BackColor = System.Drawing.Color.Transparent;
            this.txtPass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtPass.BackgroundImage")));
            this.txtPass.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            this.txtPass.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtPass.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(38)))), ((int)(((byte)(157)))));
            this.txtPass.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.txtPass.BorderRadius = 1;
            this.txtPass.BorderThickness = 0;
            this.txtPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPass.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.DefaultText = "";
            this.txtPass.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.txtPass.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPass.HideSelection = true;
            this.txtPass.IconLeft = null;
            this.txtPass.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txtPass.IconPadding = 10;
            this.txtPass.IconRight = null;
            this.txtPass.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txtPass.Location = new System.Drawing.Point(31, 142);
            this.txtPass.MaxLength = 32767;
            this.txtPass.MinimumSize = new System.Drawing.Size(100, 34);
            this.txtPass.Modified = false;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.ReadOnly = false;
            this.txtPass.SelectedText = "";
            this.txtPass.SelectionLength = 0;
            this.txtPass.SelectionStart = 0;
            this.txtPass.ShortcutsEnabled = true;
            this.txtPass.Size = new System.Drawing.Size(287, 34);
            this.txtPass.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txtPass.TabIndex = 158;
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPass.TextMarginLeft = 5;
            this.txtPass.TextPlaceholder = "***********";
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // bunifuButton1
            // 
            this.bunifuButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.BackgroundImage")));
            this.bunifuButton1.ButtonText = "Annuler";
            this.bunifuButton1.ButtonTextMarginLeft = 0;
            this.bunifuButton1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.bunifuButton1.DisabledFillColor = System.Drawing.Color.Gray;
            this.bunifuButton1.DisabledForecolor = System.Drawing.Color.White;
            this.bunifuButton1.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IconPadding = 10;
            this.bunifuButton1.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.bunifuButton1.IdleBorderRadius = 1;
            this.bunifuButton1.IdleBorderThickness = 0;
            this.bunifuButton1.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.bunifuButton1.IdleIconLeftImage = null;
            this.bunifuButton1.IdleIconRightImage = null;
            this.bunifuButton1.Location = new System.Drawing.Point(233, 182);
            this.bunifuButton1.Name = "bunifuButton1";
            stateProperties9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            stateProperties9.BorderRadius = 1;
            stateProperties9.BorderThickness = 1;
            stateProperties9.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            stateProperties9.IconLeftImage = null;
            stateProperties9.IconRightImage = null;
            this.bunifuButton1.onHoverState = stateProperties9;
            this.bunifuButton1.Size = new System.Drawing.Size(83, 35);
            this.bunifuButton1.TabIndex = 167;
            this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton1.Click += new System.EventHandler(this.bunifuButton1_Click);
            // 
            // btnCnx
            // 
            this.btnCnx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCnx.BackColor = System.Drawing.Color.Transparent;
            this.btnCnx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCnx.BackgroundImage")));
            this.btnCnx.ButtonText = "Connecter";
            this.btnCnx.ButtonTextMarginLeft = 0;
            this.btnCnx.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.btnCnx.DisabledFillColor = System.Drawing.Color.Gray;
            this.btnCnx.DisabledForecolor = System.Drawing.Color.White;
            this.btnCnx.ForeColor = System.Drawing.Color.White;
            this.btnCnx.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnCnx.IconPadding = 10;
            this.btnCnx.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnCnx.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.btnCnx.IdleBorderRadius = 1;
            this.btnCnx.IdleBorderThickness = 0;
            this.btnCnx.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.btnCnx.IdleIconLeftImage = null;
            this.btnCnx.IdleIconRightImage = null;
            this.btnCnx.Location = new System.Drawing.Point(147, 182);
            this.btnCnx.Name = "btnCnx";
            stateProperties10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            stateProperties10.BorderRadius = 1;
            stateProperties10.BorderThickness = 1;
            stateProperties10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            stateProperties10.IconLeftImage = null;
            stateProperties10.IconRightImage = null;
            this.btnCnx.onHoverState = stateProperties10;
            this.btnCnx.Size = new System.Drawing.Size(83, 35);
            this.btnCnx.TabIndex = 168;
            this.btnCnx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCnx.Click += new System.EventHandler(this.btnCnx_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.shapeContainer1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // RemoteServerConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(351, 239);
            this.Controls.Add(this.btnCnx);
            this.Controls.Add(this.bunifuButton1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RemoteServerConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RemoteServerConfig_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Bunifu.Framework.UI.BunifuCustomLabel lblNom;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtIP;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtPort;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtNom;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtPass;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnCnx;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}