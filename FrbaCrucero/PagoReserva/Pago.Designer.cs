namespace FrbaCrucero.PagoReserva
{
    partial class Pago
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroReserva = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMedioPago = new System.Windows.Forms.ComboBox();
            this.dgPasajes = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbCodRecorrido = new System.Windows.Forms.Label();
            this.lbCodCrucero = new System.Windows.Forms.Label();
            this.lbFechaSalida = new System.Windows.Forms.Label();
            this.lbFechaLlegada = new System.Windows.Forms.Label();
            this.Tipo_cabina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nro_cabina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.lbPrecioTotal = new System.Windows.Forms.Label();
            this.cbCantCuotas = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPasajes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(51, 24);
            this.lblTitulo.TabIndex = 90;
            this.lblTitulo.Text = "Pago";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "Nro. Reserva";
            // 
            // txtNroReserva
            // 
            this.txtNroReserva.Location = new System.Drawing.Point(102, 47);
            this.txtNroReserva.Name = "txtNroReserva";
            this.txtNroReserva.Size = new System.Drawing.Size(100, 20);
            this.txtNroReserva.TabIndex = 92;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 93;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Medio de Pago";
            // 
            // cbMedioPago
            // 
            this.cbMedioPago.FormattingEnabled = true;
            this.cbMedioPago.Location = new System.Drawing.Point(152, 374);
            this.cbMedioPago.Name = "cbMedioPago";
            this.cbMedioPago.Size = new System.Drawing.Size(100, 21);
            this.cbMedioPago.TabIndex = 95;
            this.cbMedioPago.TextChanged += new System.EventHandler(this.cbMedioPago_TextChanged);
            // 
            // dgPasajes
            // 
            this.dgPasajes.AllowUserToAddRows = false;
            this.dgPasajes.AllowUserToDeleteRows = false;
            this.dgPasajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPasajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo_cabina,
            this.Nro_cabina,
            this.Piso,
            this.Precio});
            this.dgPasajes.Location = new System.Drawing.Point(102, 149);
            this.dgPasajes.Name = "dgPasajes";
            this.dgPasajes.ReadOnly = true;
            this.dgPasajes.Size = new System.Drawing.Size(445, 178);
            this.dgPasajes.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Cod. Recorrido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 98;
            this.label4.Text = "Cod. Crucero";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(354, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Fecha Salida";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(502, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 100;
            this.label6.Text = "Fecha Llegada (aprox.)";
            // 
            // lbCodRecorrido
            // 
            this.lbCodRecorrido.AutoSize = true;
            this.lbCodRecorrido.Location = new System.Drawing.Point(23, 116);
            this.lbCodRecorrido.Name = "lbCodRecorrido";
            this.lbCodRecorrido.Size = new System.Drawing.Size(0, 13);
            this.lbCodRecorrido.TabIndex = 101;
            // 
            // lbCodCrucero
            // 
            this.lbCodCrucero.AutoSize = true;
            this.lbCodCrucero.Location = new System.Drawing.Point(193, 116);
            this.lbCodCrucero.Name = "lbCodCrucero";
            this.lbCodCrucero.Size = new System.Drawing.Size(0, 13);
            this.lbCodCrucero.TabIndex = 102;
            // 
            // lbFechaSalida
            // 
            this.lbFechaSalida.AutoSize = true;
            this.lbFechaSalida.Location = new System.Drawing.Point(358, 116);
            this.lbFechaSalida.Name = "lbFechaSalida";
            this.lbFechaSalida.Size = new System.Drawing.Size(0, 13);
            this.lbFechaSalida.TabIndex = 103;
            // 
            // lbFechaLlegada
            // 
            this.lbFechaLlegada.AutoSize = true;
            this.lbFechaLlegada.Location = new System.Drawing.Point(506, 116);
            this.lbFechaLlegada.Name = "lbFechaLlegada";
            this.lbFechaLlegada.Size = new System.Drawing.Size(0, 13);
            this.lbFechaLlegada.TabIndex = 104;
            // 
            // Tipo_cabina
            // 
            this.Tipo_cabina.HeaderText = "Tipo de Cabina";
            this.Tipo_cabina.Name = "Tipo_cabina";
            this.Tipo_cabina.ReadOnly = true;
            this.Tipo_cabina.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Nro_cabina
            // 
            this.Nro_cabina.HeaderText = "Nro. Cabina";
            this.Nro_cabina.Name = "Nro_cabina";
            this.Nro_cabina.ReadOnly = true;
            // 
            // Piso
            // 
            this.Piso.HeaderText = "Piso cabina";
            this.Piso.Name = "Piso";
            this.Piso.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Precio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 105;
            this.label7.Text = "Precio Total";
            // 
            // lbPrecioTotal
            // 
            this.lbPrecioTotal.AutoSize = true;
            this.lbPrecioTotal.Location = new System.Drawing.Point(325, 348);
            this.lbPrecioTotal.Name = "lbPrecioTotal";
            this.lbPrecioTotal.Size = new System.Drawing.Size(0, 13);
            this.lbPrecioTotal.TabIndex = 106;
            // 
            // cbCantCuotas
            // 
            this.cbCantCuotas.FormattingEnabled = true;
            this.cbCantCuotas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "6",
            "9",
            "12"});
            this.cbCantCuotas.Location = new System.Drawing.Point(439, 374);
            this.cbCantCuotas.Name = "cbCantCuotas";
            this.cbCantCuotas.Size = new System.Drawing.Size(100, 21);
            this.cbCantCuotas.TabIndex = 108;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(354, 377);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 107;
            this.label8.Text = "Cant. Cuotas";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(365, 427);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 109;
            this.button2.Text = "Aceptar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(204, 427);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 110;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Pago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 470);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbCantCuotas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbPrecioTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbFechaLlegada);
            this.Controls.Add(this.lbFechaSalida);
            this.Controls.Add(this.lbCodCrucero);
            this.Controls.Add(this.lbCodRecorrido);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgPasajes);
            this.Controls.Add(this.cbMedioPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNroReserva);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Pago";
            this.Text = "Pago";
            ((System.ComponentModel.ISupportInitialize)(this.dgPasajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroReserva;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMedioPago;
        private System.Windows.Forms.DataGridView dgPasajes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbCodRecorrido;
        private System.Windows.Forms.Label lbCodCrucero;
        private System.Windows.Forms.Label lbFechaSalida;
        private System.Windows.Forms.Label lbFechaLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_cabina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nro_cabina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbPrecioTotal;
        private System.Windows.Forms.ComboBox cbCantCuotas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}