namespace FrbaCrucero.AbmCrucero
{
    partial class FueraDeServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FueraDeServicio));
            this.dtFinFueraServicio = new System.Windows.Forms.DateTimePicker();
            this.dtIncioFueraServicio = new System.Windows.Forms.DateTimePicker();
            this.lbFinFueraServicio = new System.Windows.Forms.Label();
            this.lbInicioFueraServicio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtFinFueraServicio
            // 
            this.dtFinFueraServicio.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtFinFueraServicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFinFueraServicio.Location = new System.Drawing.Point(202, 101);
            this.dtFinFueraServicio.Name = "dtFinFueraServicio";
            this.dtFinFueraServicio.Size = new System.Drawing.Size(164, 22);
            this.dtFinFueraServicio.TabIndex = 69;
            // 
            // dtIncioFueraServicio
            // 
            this.dtIncioFueraServicio.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtIncioFueraServicio.Enabled = false;
            this.dtIncioFueraServicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIncioFueraServicio.Location = new System.Drawing.Point(202, 56);
            this.dtIncioFueraServicio.Name = "dtIncioFueraServicio";
            this.dtIncioFueraServicio.Size = new System.Drawing.Size(164, 22);
            this.dtIncioFueraServicio.TabIndex = 68;
            // 
            // lbFinFueraServicio
            // 
            this.lbFinFueraServicio.AutoSize = true;
            this.lbFinFueraServicio.Location = new System.Drawing.Point(18, 106);
            this.lbFinFueraServicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFinFueraServicio.Name = "lbFinFueraServicio";
            this.lbFinFueraServicio.Size = new System.Drawing.Size(146, 17);
            this.lbFinFueraServicio.TabIndex = 67;
            this.lbFinFueraServicio.Text = "Fin Fuera de Servicio:";
            // 
            // lbInicioFueraServicio
            // 
            this.lbInicioFueraServicio.AutoSize = true;
            this.lbInicioFueraServicio.Location = new System.Drawing.Point(18, 61);
            this.lbInicioFueraServicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInicioFueraServicio.Name = "lbInicioFueraServicio";
            this.lbInicioFueraServicio.Size = new System.Drawing.Size(159, 17);
            this.lbInicioFueraServicio.TabIndex = 66;
            this.lbInicioFueraServicio.Text = "Inicio Fuera de Servicio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 151);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 70;
            this.label1.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(202, 146);
            this.txtMotivo.Margin = new System.Windows.Forms.Padding(4);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(226, 22);
            this.txtMotivo.TabIndex = 71;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitulo.Location = new System.Drawing.Point(13, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(257, 31);
            this.lblTitulo.TabIndex = 72;
            this.lblTitulo.Text = "Poner Fuera de Servicio";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(328, 197);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 73;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 197);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 74;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FueraDeServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 238);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFinFueraServicio);
            this.Controls.Add(this.dtIncioFueraServicio);
            this.Controls.Add(this.lbFinFueraServicio);
            this.Controls.Add(this.lbInicioFueraServicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FueraDeServicio";
            this.Text = "FueraDeServicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFinFueraServicio;
        private System.Windows.Forms.DateTimePicker dtIncioFueraServicio;
        private System.Windows.Forms.Label lbFinFueraServicio;
        private System.Windows.Forms.Label lbInicioFueraServicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancel;
    }
}