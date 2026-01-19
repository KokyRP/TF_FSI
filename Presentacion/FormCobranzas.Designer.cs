namespace Presentacion
{
    partial class FormCobranzas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCobranzas));
            this.tbDNICliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCobranzasPorDni = new System.Windows.Forms.Button();
            this.dgClienteCobranzas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgClienteCobranzas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDNICliente
            // 
            this.tbDNICliente.BackColor = System.Drawing.Color.White;
            this.tbDNICliente.Location = new System.Drawing.Point(63, 321);
            this.tbDNICliente.Name = "tbDNICliente";
            this.tbDNICliente.Size = new System.Drawing.Size(232, 20);
            this.tbDNICliente.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Clientes y sus cobranzas";
            // 
            // btnCobranzasPorDni
            // 
            this.btnCobranzasPorDni.BackColor = System.Drawing.Color.White;
            this.btnCobranzasPorDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobranzasPorDni.ForeColor = System.Drawing.Color.Black;
            this.btnCobranzasPorDni.Location = new System.Drawing.Point(301, 321);
            this.btnCobranzasPorDni.Name = "btnCobranzasPorDni";
            this.btnCobranzasPorDni.Size = new System.Drawing.Size(75, 23);
            this.btnCobranzasPorDni.TabIndex = 6;
            this.btnCobranzasPorDni.Text = "Filtrar";
            this.btnCobranzasPorDni.UseVisualStyleBackColor = false;
            this.btnCobranzasPorDni.Click += new System.EventHandler(this.btnCobranzasPorDni_Click);
            // 
            // dgClienteCobranzas
            // 
            this.dgClienteCobranzas.BackgroundColor = System.Drawing.Color.White;
            this.dgClienteCobranzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClienteCobranzas.Location = new System.Drawing.Point(31, 67);
            this.dgClienteCobranzas.Name = "dgClienteCobranzas";
            this.dgClienteCobranzas.Size = new System.Drawing.Size(345, 238);
            this.dgClienteCobranzas.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "DNI";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentacion.Properties.Resources.logocobranzas;
            this.pictureBox1.Location = new System.Drawing.Point(29, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 42);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // FormCobranzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(117)))), ((int)(((byte)(167)))));
            this.ClientSize = new System.Drawing.Size(395, 381);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDNICliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCobranzasPorDni);
            this.Controls.Add(this.dgClienteCobranzas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCobranzas";
            this.Text = "Cobranzas";
            ((System.ComponentModel.ISupportInitialize)(this.dgClienteCobranzas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDNICliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCobranzasPorDni;
        private System.Windows.Forms.DataGridView dgClienteCobranzas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}