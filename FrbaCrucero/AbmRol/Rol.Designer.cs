namespace FrbaCrucero.AbmRol
{
    partial class Rol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rol));
            this.btnDeleteFuncion = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddFuncion = new System.Windows.Forms.Button();
            this.cbFunciones = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbFunciones = new System.Windows.Forms.ListBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdNo = new System.Windows.Forms.RadioButton();
            this.rdSi = new System.Windows.Forms.RadioButton();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDeleteFuncion
            // 
            this.btnDeleteFuncion.Location = new System.Drawing.Point(47, 165);
            this.btnDeleteFuncion.Name = "btnDeleteFuncion";
            this.btnDeleteFuncion.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFuncion.TabIndex = 27;
            this.btnDeleteFuncion.Text = "Eliminar";
            this.btnDeleteFuncion.UseVisualStyleBackColor = true;
            this.btnDeleteFuncion.Click += new System.EventHandler(this.btnDeleteFuncion_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(68, 329);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(149, 329);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Funciones Asignadas:";
            // 
            // btnAddFuncion
            // 
            this.btnAddFuncion.Location = new System.Drawing.Point(149, 165);
            this.btnAddFuncion.Name = "btnAddFuncion";
            this.btnAddFuncion.Size = new System.Drawing.Size(75, 23);
            this.btnAddFuncion.TabIndex = 23;
            this.btnAddFuncion.Text = "Agregar";
            this.btnAddFuncion.UseVisualStyleBackColor = true;
            this.btnAddFuncion.Click += new System.EventHandler(this.btnAddFuncion_Click);
            // 
            // cbFunciones
            // 
            this.cbFunciones.FormattingEnabled = true;
            this.cbFunciones.Location = new System.Drawing.Point(84, 124);
            this.cbFunciones.Name = "cbFunciones";
            this.cbFunciones.Size = new System.Drawing.Size(140, 21);
            this.cbFunciones.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Funciones:";
            // 
            // lbFunciones
            // 
            this.lbFunciones.FormattingEnabled = true;
            this.lbFunciones.Location = new System.Drawing.Point(22, 219);
            this.lbFunciones.Name = "lbFunciones";
            this.lbFunciones.Size = new System.Drawing.Size(202, 95);
            this.lbFunciones.TabIndex = 20;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(37, 24);
            this.lblTitulo.TabIndex = 19;
            this.lblTitulo.Text = "Rol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Vigente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Descripción:";
            // 
            // rdNo
            // 
            this.rdNo.AutoSize = true;
            this.rdNo.Location = new System.Drawing.Point(128, 92);
            this.rdNo.Name = "rdNo";
            this.rdNo.Size = new System.Drawing.Size(39, 17);
            this.rdNo.TabIndex = 16;
            this.rdNo.TabStop = true;
            this.rdNo.Text = "No";
            this.rdNo.UseVisualStyleBackColor = true;
            // 
            // rdSi
            // 
            this.rdSi.AutoSize = true;
            this.rdSi.Location = new System.Drawing.Point(88, 92);
            this.rdSi.Name = "rdSi";
            this.rdSi.Size = new System.Drawing.Size(34, 17);
            this.rdSi.TabIndex = 15;
            this.rdSi.TabStop = true;
            this.rdSi.Text = "Si";
            this.rdSi.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(88, 53);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(136, 20);
            this.txtDescripcion.TabIndex = 14;
            // 
            // Rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 378);
            this.Controls.Add(this.btnDeleteFuncion);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddFuncion);
            this.Controls.Add(this.cbFunciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbFunciones);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdNo);
            this.Controls.Add(this.rdSi);
            this.Controls.Add(this.txtDescripcion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Rol";
            this.Text = "Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteFuncion;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddFuncion;
        private System.Windows.Forms.ComboBox cbFunciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbFunciones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdNo;
        private System.Windows.Forms.RadioButton rdSi;
        private System.Windows.Forms.TextBox txtDescripcion;
    }
}