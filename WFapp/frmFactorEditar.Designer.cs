namespace GP.WFapp
{
    partial class FrmFactorEditar
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.valorDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbSeleccionados = new System.Windows.Forms.DataGridView();
            this.lbNoSeleccionados = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.valorDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbSeleccionados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbNoSeleccionados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(108, 61);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(237, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(79, 318);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(189, 318);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(306, 318);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Valores Seleccionados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Valores no Seleccionados";
            // 
            // valorDTOBindingSource
            // 
            this.valorDTOBindingSource.DataSource = typeof(GP.DTO.DTO.ValorDTO);
            // 
            // lbSeleccionados
            // 
            this.lbSeleccionados.AllowUserToAddRows = false;
            this.lbSeleccionados.AllowUserToDeleteRows = false;
            this.lbSeleccionados.AllowUserToResizeColumns = false;
            this.lbSeleccionados.AllowUserToResizeRows = false;
            this.lbSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lbSeleccionados.Location = new System.Drawing.Point(54, 146);
            this.lbSeleccionados.MultiSelect = false;
            this.lbSeleccionados.Name = "lbSeleccionados";
            this.lbSeleccionados.RowHeadersVisible = false;
            this.lbSeleccionados.Size = new System.Drawing.Size(149, 166);
            this.lbSeleccionados.TabIndex = 9;
            this.lbSeleccionados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lbSeleccionados_CellContentClick);
            // 
            // lbNoSeleccionados
            // 
            this.lbNoSeleccionados.AllowUserToAddRows = false;
            this.lbNoSeleccionados.AllowUserToDeleteRows = false;
            this.lbNoSeleccionados.AllowUserToResizeColumns = false;
            this.lbNoSeleccionados.AllowUserToResizeRows = false;
            this.lbNoSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lbNoSeleccionados.Location = new System.Drawing.Point(306, 146);
            this.lbNoSeleccionados.MultiSelect = false;
            this.lbNoSeleccionados.Name = "lbNoSeleccionados";
            this.lbNoSeleccionados.RowHeadersVisible = false;
            this.lbNoSeleccionados.Size = new System.Drawing.Size(156, 166);
            this.lbNoSeleccionados.TabIndex = 10;
            this.lbNoSeleccionados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lbNoSeleccionados_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(236, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FrmFactorEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 360);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbNoSeleccionados);
            this.Controls.Add(this.lbSeleccionados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Name = "FrmFactorEditar";
            this.Text = "Editar Factor";
            this.Load += new System.EventHandler(this.frmFactorEditar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.valorDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbSeleccionados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbNoSeleccionados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource valorDTOBindingSource;
        private System.Windows.Forms.DataGridView lbSeleccionados;
        private System.Windows.Forms.DataGridView lbNoSeleccionados;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}