namespace FrbaCrucero.GeneracionViaje
{
    partial class ListadoViajes
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
            this.cbVigencia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoCrucero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoRecorrido = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgViajes = new System.Windows.Forms.DataGridView();
            this.CodigoCrucero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoRecorrido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vigente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgViajes)).BeginInit();
            this.SuspendLayout();
            // 
            // cbVigencia
            // 
            this.cbVigencia.AutoCompleteCustomSource.AddRange(new string[] {
            "Todos",
            "Si",
            "No"});
            this.cbVigencia.FormattingEnabled = true;
            this.cbVigencia.Items.AddRange(new object[] {
            "Todos",
            "Si",
            "No"});
            this.cbVigencia.Location = new System.Drawing.Point(131, 103);
            this.cbVigencia.Name = "cbVigencia";
            this.cbVigencia.Size = new System.Drawing.Size(100, 21);
            this.cbVigencia.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Vigente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Código crucero:";
            // 
            // txtCodigoCrucero
            // 
            this.txtCodigoCrucero.Location = new System.Drawing.Point(131, 38);
            this.txtCodigoCrucero.Name = "txtCodigoCrucero";
            this.txtCodigoCrucero.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoCrucero.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Código recorrido:";
            // 
            // txtCodigoRecorrido
            // 
            this.txtCodigoRecorrido.Location = new System.Drawing.Point(131, 72);
            this.txtCodigoRecorrido.Name = "txtCodigoRecorrido";
            this.txtCodigoRecorrido.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoRecorrido.TabIndex = 29;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(26, 134);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 33;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(346, 134);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 32;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgViajes
            // 
            this.dgViajes.AllowUserToAddRows = false;
            this.dgViajes.AllowUserToDeleteRows = false;
            this.dgViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoCrucero,
            this.CodigoRecorrido,
            this.Vigente,
            this.Editar});
            this.dgViajes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgViajes.Location = new System.Drawing.Point(12, 163);
            this.dgViajes.MultiSelect = false;
            this.dgViajes.Name = "dgViajes";
            this.dgViajes.Size = new System.Drawing.Size(428, 150);
            this.dgViajes.TabIndex = 31;
            // 
            // CodigoCrucero
            // 
            this.CodigoCrucero.HeaderText = "Código crucero";
            this.CodigoCrucero.Name = "CodigoCrucero";
            // 
            // CodigoRecorrido
            // 
            this.CodigoRecorrido.HeaderText = "Código recorrido";
            this.CodigoRecorrido.Name = "CodigoRecorrido";
            // 
            // Vigente
            // 
            this.Vigente.HeaderText = "Vigente";
            this.Vigente.Name = "Vigente";
            this.Vigente.ReadOnly = true;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.Text = "Seleccionar";
            // 
            // ListadoViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 342);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgViajes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoRecorrido);
            this.Controls.Add(this.cbVigencia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigoCrucero);
            this.Name = "ListadoViajes";
            this.Text = "ListadoViajes";
            ((System.ComponentModel.ISupportInitialize)(this.dgViajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbVigencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoCrucero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoRecorrido;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgViajes;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCrucero;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoRecorrido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vigente;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
    }
}