namespace GestionDuProduction
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.txtName = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.txtPass = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.btnConx = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.AcceptsReturn = false;
            this.txtName.AcceptsTab = false;
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtName.BackgroundImage")));
            this.txtName.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            this.txtName.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtName.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(38)))), ((int)(((byte)(157)))));
            this.txtName.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            this.txtName.BorderRadius = 1;
            this.txtName.BorderThickness = 1;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtName.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.DefaultText = "";
            this.txtName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.txtName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtName.HideSelection = true;
            this.txtName.IconLeft = null;
            this.txtName.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txtName.IconPadding = 10;
            this.txtName.IconRight = null;
            this.txtName.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txtName.Location = new System.Drawing.Point(83, 134);
            this.txtName.MaxLength = 32767;
            this.txtName.MinimumSize = new System.Drawing.Size(100, 35);
            this.txtName.Modified = false;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ReadOnly = false;
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.ShortcutsEnabled = true;
            this.txtName.Size = new System.Drawing.Size(200, 39);
            this.txtName.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txtName.TabIndex = 0;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.TextMarginLeft = 5;
            this.txtName.TextPlaceholder = "";
            this.txtName.UseSystemPasswordChar = false;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
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
            this.txtPass.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            this.txtPass.BorderRadius = 1;
            this.txtPass.BorderThickness = 1;
            this.txtPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPass.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.DefaultText = "";
            this.txtPass.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.txtPass.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPass.HideSelection = true;
            this.txtPass.IconLeft = null;
            this.txtPass.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txtPass.IconPadding = 10;
            this.txtPass.IconRight = null;
            this.txtPass.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txtPass.Location = new System.Drawing.Point(83, 212);
            this.txtPass.MaxLength = 32767;
            this.txtPass.MinimumSize = new System.Drawing.Size(100, 35);
            this.txtPass.Modified = false;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.ReadOnly = false;
            this.txtPass.SelectedText = "";
            this.txtPass.SelectionLength = 0;
            this.txtPass.SelectionStart = 0;
            this.txtPass.ShortcutsEnabled = true;
            this.txtPass.Size = new System.Drawing.Size(200, 38);
            this.txtPass.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txtPass.TabIndex = 1;
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPass.TextMarginLeft = 5;
            this.txtPass.TextPlaceholder = "";
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            // 
            // btnConx
            // 
            this.btnConx.BackColor = System.Drawing.Color.Transparent;
            this.btnConx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConx.BackgroundImage")));
            this.btnConx.ButtonText = "Connection";
            this.btnConx.ButtonTextMarginLeft = 0;
            this.btnConx.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.btnConx.DisabledFillColor = System.Drawing.Color.Gray;
            this.btnConx.DisabledForecolor = System.Drawing.Color.White;
            this.btnConx.ForeColor = System.Drawing.Color.White;
            this.btnConx.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnConx.IconPadding = 10;
            this.btnConx.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnConx.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnConx.IdleBorderRadius = 1;
            this.btnConx.IdleBorderThickness = 0;
            this.btnConx.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnConx.IdleIconLeftImage = null;
            this.btnConx.IdleIconRightImage = null;
            this.btnConx.Location = new System.Drawing.Point(83, 281);
            this.btnConx.Name = "btnConx";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties1.BorderRadius = 1;
            stateProperties1.BorderThickness = 1;
            stateProperties1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties1.IconLeftImage = null;
            stateProperties1.IconRightImage = null;
            this.btnConx.onHoverState = stateProperties1;
            this.btnConx.Size = new System.Drawing.Size(200, 37);
            this.btnConx.TabIndex = 2;
            this.btnConx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConx.Click += new System.EventHandler(this.btnConx_Click);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(84, 108);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(121, 19);
            this.bunifuCustomLabel1.TabIndex = 3;
            this.bunifuCustomLabel1.Text = "Nom utilisateur";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(84, 186);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(108, 19);
            this.bunifuCustomLabel2.TabIndex = 4;
            this.bunifuCustomLabel2.Text = "Mot de passe";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(101)))), ((int)(((byte)(112)))));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(84, 330);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(168, 19);
            this.bunifuCustomLabel3.TabIndex = 5;
            this.bunifuCustomLabel3.Text = "Configurer Le Serveur";
            this.bunifuCustomLabel3.Click += new System.EventHandler(this.bunifuCustomLabel3_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::GestionDuProduction.Properties.Resources.login;
            this.ClientSize = new System.Drawing.Size(682, 412);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.btnConx);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtName;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtPass;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnConx;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
    }
}