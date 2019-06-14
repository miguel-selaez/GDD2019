namespace FrbaCrucero.CompraReservaPasaje
{
    partial class CompraReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompraReserva));
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cbPuertoOrigen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPuertoLlegada = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgViajes = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Crucero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PuertoOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PuertoLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblPagina = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgViajes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtInicio
            // 
            this.dtInicio.CustomFormat = "dd/MM/yyyy";
            this.dtInicio.Enabled = false;
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicio.Location = new System.Drawing.Point(62, 51);
            this.dtInicio.Margin = new System.Windows.Forms.Padding(2);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(160, 20);
            this.dtInicio.TabIndex = 67;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Fecha:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(281, 24);
            this.lblTitulo.TabIndex = 68;
            this.lblTitulo.Text = "Compras y/o Reserva de Pasajes";
            // 
            // cbPuertoOrigen
            // 
            this.cbPuertoOrigen.AutoCompleteCustomSource.AddRange(new string[] {
            "Todos",
            "Si",
            "No"});
            this.cbPuertoOrigen.FormattingEnabled = true;
            this.cbPuertoOrigen.Items.AddRange(new object[] {
            "Todos"});
            this.cbPuertoOrigen.Location = new System.Drawing.Point(332, 50);
            this.cbPuertoOrigen.Name = "cbPuertoOrigen";
            this.cbPuertoOrigen.Size = new System.Drawing.Size(164, 21);
            this.cbPuertoOrigen.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Puerto de Origen:";
            // 
            // cbPuertoLlegada
            // 
            this.cbPuertoLlegada.AutoCompleteCustomSource.AddRange(new string[] {
            "Todos",
            "Si",
            "No"});
            this.cbPuertoLlegada.FormattingEnabled = true;
            this.cbPuertoLlegada.Items.AddRange(new object[] {
            "Todos"});
            this.cbPuertoLlegada.Location = new System.Drawing.Point(614, 50);
            this.cbPuertoLlegada.Name = "cbPuertoLlegada";
            this.cbPuertoLlegada.Size = new System.Drawing.Size(164, 21);
            this.cbPuertoLlegada.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(511, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Puerto de Llegada:";
            // 
            // dgViajes
            // 
            this.dgViajes.AllowUserToAddRows = false;
            this.dgViajes.AllowUserToDeleteRows = false;
            this.dgViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Crucero,
            this.PuertoOrigen,
            this.PuertoLlegada,
            this.FechaSalida,
            this.FechaLlegada,
            this.Editar});
            this.dgViajes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgViajes.Location = new System.Drawing.Point(16, 141);
            this.dgViajes.MultiSelect = false;
            this.dgViajes.Name = "dgViajes";
            this.dgViajes.Size = new System.Drawing.Size(759, 222);
            this.dgViajes.TabIndex = 73;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(258, 94);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 75;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(483, 94);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 74;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código de Viaje";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Crucero
            // 
            this.Crucero.HeaderText = "Crucero";
            this.Crucero.Name = "Crucero";
            this.Crucero.ReadOnly = true;
            // 
            // PuertoOrigen
            // 
            this.PuertoOrigen.HeaderText = "Puerto de Origen";
            this.PuertoOrigen.Name = "PuertoOrigen";
            this.PuertoOrigen.ReadOnly = true;
            // 
            // PuertoLlegada
            // 
            this.PuertoLlegada.HeaderText = "Puerto de Llegada";
            this.PuertoLlegada.Name = "PuertoLlegada";
            this.PuertoLlegada.ReadOnly = true;
            // 
            // FechaSalida
            // 
            this.FechaSalida.HeaderText = "Fecha de Salida";
            this.FechaSalida.Name = "FechaSalida";
            this.FechaSalida.ReadOnly = true;
            // 
            // FechaLlegada
            // 
            this.FechaLlegada.HeaderText = "Fecha de Llegada";
            this.FechaLlegada.Name = "FechaLlegada";
            this.FechaLlegada.ReadOnly = true;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.Text = "Seleccionar";
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Location = new System.Drawing.Point(375, 389);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(61, 13);
            this.lblPagina.TabIndex = 78;
            this.lblPagina.Text = "actual/total";
            this.lblPagina.Visible = false;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(537, 384);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 77;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Visible = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Enabled = false;
            this.btnAnterior.Location = new System.Drawing.Point(213, 384);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 76;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Visible = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // CompraReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 411);
            this.Controls.Add(this.lblPagina);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgViajes);
            this.Controls.Add(this.cbPuertoLlegada);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPuertoOrigen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompraReserva";
            this.Text = "CompraReserva";
            ((System.ComponentModel.ISupportInitialize)(this.dgViajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cbPuertoOrigen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPuertoLlegada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgViajes;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Crucero;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuertoOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuertoLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaLlegada;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
    }
}