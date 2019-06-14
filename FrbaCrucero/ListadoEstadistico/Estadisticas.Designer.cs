namespace FrbaCrucero.ListadoEstadistico
{
    partial class Estadisticas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estadisticas));
            this.dgRecorridosPasajes = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgRecorridosCabinas = new System.Windows.Forms.DataGridView();
            this.dgCrucerosFueraServicio = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSemestres = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.rpvIdRecorrido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rpvCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rclIdRecorrido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rclIdViaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rclCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfsIdCrucero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfsCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecorridosPasajes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecorridosCabinas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCrucerosFueraServicio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgRecorridosPasajes
            // 
            this.dgRecorridosPasajes.AllowUserToAddRows = false;
            this.dgRecorridosPasajes.AllowUserToDeleteRows = false;
            this.dgRecorridosPasajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRecorridosPasajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rpvIdRecorrido,
            this.rpvCantidad});
            this.dgRecorridosPasajes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgRecorridosPasajes.Location = new System.Drawing.Point(16, 130);
            this.dgRecorridosPasajes.MultiSelect = false;
            this.dgRecorridosPasajes.Name = "dgRecorridosPasajes";
            this.dgRecorridosPasajes.Size = new System.Drawing.Size(416, 150);
            this.dgRecorridosPasajes.TabIndex = 11;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitulo.Location = new System.Drawing.Point(12, 94);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(371, 24);
            this.lblTitulo.TabIndex = 18;
            this.lblTitulo.Text = "Top 5 Recorridos con más pasajes vendidos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(12, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Top 5 Recorridos con más cabinas libres por viaje";
            // 
            // dgRecorridosCabinas
            // 
            this.dgRecorridosCabinas.AllowUserToAddRows = false;
            this.dgRecorridosCabinas.AllowUserToDeleteRows = false;
            this.dgRecorridosCabinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRecorridosCabinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rclIdRecorrido,
            this.rclIdViaje,
            this.rclCantidad});
            this.dgRecorridosCabinas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgRecorridosCabinas.Location = new System.Drawing.Point(16, 310);
            this.dgRecorridosCabinas.MultiSelect = false;
            this.dgRecorridosCabinas.Name = "dgRecorridosCabinas";
            this.dgRecorridosCabinas.Size = new System.Drawing.Size(416, 150);
            this.dgRecorridosCabinas.TabIndex = 20;
            // 
            // dgCrucerosFueraServicio
            // 
            this.dgCrucerosFueraServicio.AllowUserToAddRows = false;
            this.dgCrucerosFueraServicio.AllowUserToDeleteRows = false;
            this.dgCrucerosFueraServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCrucerosFueraServicio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cfsIdCrucero,
            this.cfsCantidad});
            this.dgCrucerosFueraServicio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgCrucerosFueraServicio.Location = new System.Drawing.Point(16, 499);
            this.dgCrucerosFueraServicio.MultiSelect = false;
            this.dgCrucerosFueraServicio.Name = "dgCrucerosFueraServicio";
            this.dgCrucerosFueraServicio.Size = new System.Drawing.Size(417, 150);
            this.dgCrucerosFueraServicio.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(12, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "Top 5 Cruceros con más días fuera de servicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Semestre:";
            // 
            // cbSemestres
            // 
            this.cbSemestres.FormattingEnabled = true;
            this.cbSemestres.Location = new System.Drawing.Point(110, 18);
            this.cbSemestres.Name = "cbSemestres";
            this.cbSemestres.Size = new System.Drawing.Size(121, 21);
            this.cbSemestres.TabIndex = 54;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(335, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 55;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // rpvIdRecorrido
            // 
            this.rpvIdRecorrido.HeaderText = "Id Recorrido";
            this.rpvIdRecorrido.Name = "rpvIdRecorrido";
            // 
            // rpvCantidad
            // 
            this.rpvCantidad.HeaderText = "Cantidad";
            this.rpvCantidad.Name = "rpvCantidad";
            this.rpvCantidad.ReadOnly = true;
            // 
            // rclIdRecorrido
            // 
            this.rclIdRecorrido.HeaderText = "Id Recorrido";
            this.rclIdRecorrido.Name = "rclIdRecorrido";
            // 
            // rclIdViaje
            // 
            this.rclIdViaje.HeaderText = "Id Viaje";
            this.rclIdViaje.Name = "rclIdViaje";
            // 
            // rclCantidad
            // 
            this.rclCantidad.HeaderText = "Cantidad";
            this.rclCantidad.Name = "rclCantidad";
            // 
            // cfsIdCrucero
            // 
            this.cfsIdCrucero.HeaderText = "Id Crucero";
            this.cfsIdCrucero.Name = "cfsIdCrucero";
            // 
            // cfsCantidad
            // 
            this.cfsCantidad.HeaderText = "Cantidad";
            this.cfsCantidad.Name = "cfsCantidad";
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 669);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbSemestres);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgCrucerosFueraServicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgRecorridosCabinas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgRecorridosPasajes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Estadisticas";
            this.Text = "Estadisticas";
            ((System.ComponentModel.ISupportInitialize)(this.dgRecorridosPasajes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecorridosCabinas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCrucerosFueraServicio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgRecorridosPasajes;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgRecorridosCabinas;
        private System.Windows.Forms.DataGridView dgCrucerosFueraServicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSemestres;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn rpvIdRecorrido;
        private System.Windows.Forms.DataGridViewTextBoxColumn rpvCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn rclIdRecorrido;
        private System.Windows.Forms.DataGridViewTextBoxColumn rclIdViaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn rclCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfsIdCrucero;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfsCantidad;
    }
}