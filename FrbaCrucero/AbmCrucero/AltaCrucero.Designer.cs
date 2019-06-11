namespace FrbaCrucero.AbmCrucero
{
    partial class AltaCrucero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaCrucero));
            this.btnEliminarCabina = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregarCabina = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgCabinas = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdNo = new System.Windows.Forms.RadioButton();
            this.rdSi = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.dtAlta = new System.Windows.Forms.DateTimePicker();
            this.btnFueraServicio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCabinas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminarCabina
            // 
            this.btnEliminarCabina.Location = new System.Drawing.Point(461, 142);
            this.btnEliminarCabina.Name = "btnEliminarCabina";
            this.btnEliminarCabina.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarCabina.TabIndex = 41;
            this.btnEliminarCabina.Text = "Eliminar";
            this.btnEliminarCabina.UseVisualStyleBackColor = true;
            this.btnEliminarCabina.Click += new System.EventHandler(this.btnEliminarCabina_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(238, 353);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(461, 353);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Cabinas:";
            // 
            // btnAgregarCabina
            // 
            this.btnAgregarCabina.Location = new System.Drawing.Point(374, 142);
            this.btnAgregarCabina.Name = "btnAgregarCabina";
            this.btnAgregarCabina.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarCabina.TabIndex = 37;
            this.btnAgregarCabina.Text = "Agregar";
            this.btnAgregarCabina.UseVisualStyleBackColor = true;
            this.btnAgregarCabina.Click += new System.EventHandler(this.btnAgregarCabina_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitulo.Location = new System.Drawing.Point(13, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(75, 24);
            this.lblTitulo.TabIndex = 33;
            this.lblTitulo.Text = "Crucero";
            // 
            // dgCabinas
            // 
            this.dgCabinas.AllowUserToAddRows = false;
            this.dgCabinas.AllowUserToDeleteRows = false;
            this.dgCabinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCabinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Piso,
            this.Tipo,
            this.Editar});
            this.dgCabinas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgCabinas.Location = new System.Drawing.Point(19, 182);
            this.dgCabinas.Margin = new System.Windows.Forms.Padding(2);
            this.dgCabinas.MultiSelect = false;
            this.dgCabinas.Name = "dgCabinas";
            this.dgCabinas.RowTemplate.Height = 24;
            this.dgCabinas.Size = new System.Drawing.Size(518, 155);
            this.dgCabinas.TabIndex = 42;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Piso
            // 
            this.Piso.HeaderText = "Piso";
            this.Piso.Name = "Piso";
            this.Piso.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Text = "Editar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Modelo:";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(119, 76);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(160, 20);
            this.txtModelo.TabIndex = 47;
            // 
            // cbMarca
            // 
            this.cbMarca.AutoCompleteCustomSource.AddRange(new string[] {
            "Todos",
            "Si",
            "No"});
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Items.AddRange(new object[] {
            "Todos"});
            this.cbMarca.Location = new System.Drawing.Point(374, 43);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(164, 21);
            this.cbMarca.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Marca:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(119, 41);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(160, 20);
            this.txtCodigo.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Vigente:";
            // 
            // rdNo
            // 
            this.rdNo.AutoSize = true;
            this.rdNo.Location = new System.Drawing.Point(426, 79);
            this.rdNo.Name = "rdNo";
            this.rdNo.Size = new System.Drawing.Size(39, 17);
            this.rdNo.TabIndex = 52;
            this.rdNo.TabStop = true;
            this.rdNo.Text = "No";
            this.rdNo.UseVisualStyleBackColor = true;
            // 
            // rdSi
            // 
            this.rdSi.AutoSize = true;
            this.rdSi.Location = new System.Drawing.Point(374, 79);
            this.rdSi.Name = "rdSi";
            this.rdSi.Size = new System.Drawing.Size(34, 17);
            this.rdSi.TabIndex = 51;
            this.rdSi.TabStop = true;
            this.rdSi.Text = "Si";
            this.rdSi.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Fecha de Alta:";
            // 
            // dtAlta
            // 
            this.dtAlta.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtAlta.Enabled = false;
            this.dtAlta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAlta.Location = new System.Drawing.Point(119, 114);
            this.dtAlta.Margin = new System.Windows.Forms.Padding(2);
            this.dtAlta.Name = "dtAlta";
            this.dtAlta.Size = new System.Drawing.Size(160, 20);
            this.dtAlta.TabIndex = 65;
            // 
            // btnFueraServicio
            // 
            this.btnFueraServicio.Location = new System.Drawing.Point(320, 353);
            this.btnFueraServicio.Name = "btnFueraServicio";
            this.btnFueraServicio.Size = new System.Drawing.Size(136, 23);
            this.btnFueraServicio.TabIndex = 66;
            this.btnFueraServicio.Text = "Poner Fuera de Servicio";
            this.btnFueraServicio.UseVisualStyleBackColor = true;
            this.btnFueraServicio.Click += new System.EventHandler(this.btnFueraServicio_Click);
            // 
            // AltaCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 386);
            this.Controls.Add(this.btnFueraServicio);
            this.Controls.Add(this.dtAlta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdNo);
            this.Controls.Add(this.rdSi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.cbMarca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.dgCabinas);
            this.Controls.Add(this.btnEliminarCabina);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAgregarCabina);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AltaCrucero";
            this.Text = "Crucero";
            ((System.ComponentModel.ISupportInitialize)(this.dgCabinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminarCabina;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregarCabina;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgCabinas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdNo;
        private System.Windows.Forms.RadioButton rdSi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DateTimePicker dtAlta;
        private System.Windows.Forms.Button btnFueraServicio;
    }
}