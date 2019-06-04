namespace FrbaCrucero.AbmRecorrido
{
    partial class Recorrido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recorrido));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdNo = new System.Windows.Forms.RadioButton();
            this.rdSi = new System.Windows.Forms.RadioButton();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnDeleteTramo = new System.Windows.Forms.Button();
            this.btnAddTramo = new System.Windows.Forms.Button();
            this.cbTramos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTramos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(91, 24);
            this.lblTitulo.TabIndex = 20;
            this.lblTitulo.Text = "Recorrido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Vigente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Código:";
            // 
            // rdNo
            // 
            this.rdNo.AutoSize = true;
            this.rdNo.Location = new System.Drawing.Point(127, 85);
            this.rdNo.Name = "rdNo";
            this.rdNo.Size = new System.Drawing.Size(39, 17);
            this.rdNo.TabIndex = 23;
            this.rdNo.TabStop = true;
            this.rdNo.Text = "No";
            this.rdNo.UseVisualStyleBackColor = true;
            // 
            // rdSi
            // 
            this.rdSi.AutoSize = true;
            this.rdSi.Location = new System.Drawing.Point(87, 85);
            this.rdSi.Name = "rdSi";
            this.rdSi.Size = new System.Drawing.Size(34, 17);
            this.rdSi.TabIndex = 22;
            this.rdSi.TabStop = true;
            this.rdSi.Text = "Si";
            this.rdSi.UseVisualStyleBackColor = true;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(91, 46);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(136, 20);
            this.txtCodigo.TabIndex = 21;
            // 
            // btnDeleteTramo
            // 
            this.btnDeleteTramo.Location = new System.Drawing.Point(21, 161);
            this.btnDeleteTramo.Name = "btnDeleteTramo";
            this.btnDeleteTramo.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTramo.TabIndex = 31;
            this.btnDeleteTramo.Text = "Eliminar";
            this.btnDeleteTramo.UseVisualStyleBackColor = true;
            this.btnDeleteTramo.Click += new System.EventHandler(this.btnDeleteTramo_Click);
            // 
            // btnAddTramo
            // 
            this.btnAddTramo.Location = new System.Drawing.Point(285, 161);
            this.btnAddTramo.Name = "btnAddTramo";
            this.btnAddTramo.Size = new System.Drawing.Size(75, 23);
            this.btnAddTramo.TabIndex = 30;
            this.btnAddTramo.Text = "Agregar";
            this.btnAddTramo.UseVisualStyleBackColor = true;
            this.btnAddTramo.Click += new System.EventHandler(this.btnAddTramo_Click);
            // 
            // cbTramos
            // 
            this.cbTramos.FormattingEnabled = true;
            this.cbTramos.Location = new System.Drawing.Point(87, 120);
            this.cbTramos.Name = "cbTramos";
            this.cbTramos.Size = new System.Drawing.Size(273, 21);
            this.cbTramos.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Tramos:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(21, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(285, 323);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Tramos asignados:";
            // 
            // lbTramos
            // 
            this.lbTramos.FormattingEnabled = true;
            this.lbTramos.Location = new System.Drawing.Point(21, 213);
            this.lbTramos.Name = "lbTramos";
            this.lbTramos.Size = new System.Drawing.Size(339, 95);
            this.lbTramos.TabIndex = 32;
            // 
            // Recorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 367);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTramos);
            this.Controls.Add(this.btnDeleteTramo);
            this.Controls.Add(this.btnAddTramo);
            this.Controls.Add(this.cbTramos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdNo);
            this.Controls.Add(this.rdSi);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Recorrido";
            this.Text = "Recorrido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdNo;
        private System.Windows.Forms.RadioButton rdSi;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnDeleteTramo;
        private System.Windows.Forms.Button btnAddTramo;
        private System.Windows.Forms.ComboBox cbTramos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbTramos;
    }
}