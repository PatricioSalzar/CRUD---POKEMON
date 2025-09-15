
namespace winform_app
{
    partial class frmPokemons
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
            this.dgvPokemons = new System.Windows.Forms.DataGridView();
            this.pbPokemon = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btbModificar = new System.Windows.Forms.Button();
            this.btnEliniminarfisico = new System.Windows.Forms.Button();
            this.btnEliminarLogico = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.txtbFiltro = new System.Windows.Forms.TextBox();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.lblcampo = new System.Windows.Forms.Label();
            this.cbocampo = new System.Windows.Forms.ComboBox();
            this.lblcriterio = new System.Windows.Forms.Label();
            this.cbocriterio = new System.Windows.Forms.ComboBox();
            this.lblfiltroavanzado = new System.Windows.Forms.Label();
            this.txtfiltroavanzado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokemons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPokemons
            // 
            this.dgvPokemons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPokemons.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPokemons.Location = new System.Drawing.Point(13, 50);
            this.dgvPokemons.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPokemons.Name = "dgvPokemons";
            this.dgvPokemons.RowHeadersWidth = 51;
            this.dgvPokemons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPokemons.Size = new System.Drawing.Size(789, 286);
            this.dgvPokemons.TabIndex = 0;
            this.dgvPokemons.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPokemons_CellContentClick);
            this.dgvPokemons.SelectionChanged += new System.EventHandler(this.dgvPokemons_SelectionChanged);
            // 
            // pbPokemon
            // 
            this.pbPokemon.Location = new System.Drawing.Point(809, 50);
            this.pbPokemon.Name = "pbPokemon";
            this.pbPokemon.Size = new System.Drawing.Size(351, 287);
            this.pbPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPokemon.TabIndex = 1;
            this.pbPokemon.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(13, 357);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btbModificar
            // 
            this.btbModificar.Location = new System.Drawing.Point(94, 357);
            this.btbModificar.Name = "btbModificar";
            this.btbModificar.Size = new System.Drawing.Size(92, 23);
            this.btbModificar.TabIndex = 3;
            this.btbModificar.Text = "MODIFICAR";
            this.btbModificar.UseVisualStyleBackColor = true;
            this.btbModificar.Click += new System.EventHandler(this.btbModificar_Click);
            // 
            // btnEliniminarfisico
            // 
            this.btnEliniminarfisico.Location = new System.Drawing.Point(192, 357);
            this.btnEliniminarfisico.Name = "btnEliniminarfisico";
            this.btnEliniminarfisico.Size = new System.Drawing.Size(155, 23);
            this.btnEliniminarfisico.TabIndex = 4;
            this.btnEliniminarfisico.Text = "ELIMINAR FISICO";
            this.btnEliniminarfisico.UseVisualStyleBackColor = true;
            this.btnEliniminarfisico.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEliminarLogico
            // 
            this.btnEliminarLogico.Location = new System.Drawing.Point(353, 357);
            this.btnEliminarLogico.Name = "btnEliminarLogico";
            this.btnEliminarLogico.Size = new System.Drawing.Size(155, 23);
            this.btnEliminarLogico.TabIndex = 5;
            this.btnEliminarLogico.Text = "ELIMINAR LOGICO";
            this.btnEliminarLogico.UseVisualStyleBackColor = true;
            this.btnEliminarLogico.Click += new System.EventHandler(this.btnEliminarLogico_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(13, 24);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(108, 16);
            this.lblFiltro.TabIndex = 6;
            this.lblFiltro.Text = "FILTRO RAPIDO";
            // 
            // txtbFiltro
            // 
            this.txtbFiltro.Location = new System.Drawing.Point(127, 21);
            this.txtbFiltro.Name = "txtbFiltro";
            this.txtbFiltro.Size = new System.Drawing.Size(193, 22);
            this.txtbFiltro.TabIndex = 7;
            this.txtbFiltro.TextChanged += new System.EventHandler(this.txtbFiltro_TextChanged);
            this.txtbFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFiltro_KeyPress);
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(727, 389);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(75, 23);
            this.btnFiltro.TabIndex = 8;
            this.btnFiltro.Text = "BUSCAR";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // lblcampo
            // 
            this.lblcampo.AutoSize = true;
            this.lblcampo.Location = new System.Drawing.Point(16, 401);
            this.lblcampo.Name = "lblcampo";
            this.lblcampo.Size = new System.Drawing.Size(55, 16);
            this.lblcampo.TabIndex = 9;
            this.lblcampo.Text = "CAMPO";
            // 
            // cbocampo
            // 
            this.cbocampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocampo.FormattingEnabled = true;
            this.cbocampo.Location = new System.Drawing.Point(99, 393);
            this.cbocampo.Name = "cbocampo";
            this.cbocampo.Size = new System.Drawing.Size(121, 24);
            this.cbocampo.TabIndex = 10;
            this.cbocampo.SelectedIndexChanged += new System.EventHandler(this.cbocampo_SelectedIndexChanged);
            // 
            // lblcriterio
            // 
            this.lblcriterio.AutoSize = true;
            this.lblcriterio.Location = new System.Drawing.Point(259, 401);
            this.lblcriterio.Name = "lblcriterio";
            this.lblcriterio.Size = new System.Drawing.Size(70, 16);
            this.lblcriterio.TabIndex = 11;
            this.lblcriterio.Text = "CRITERIO";
            // 
            // cbocriterio
            // 
            this.cbocriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocriterio.FormattingEnabled = true;
            this.cbocriterio.Location = new System.Drawing.Point(342, 393);
            this.cbocriterio.Name = "cbocriterio";
            this.cbocriterio.Size = new System.Drawing.Size(121, 24);
            this.cbocriterio.TabIndex = 12;
            this.cbocriterio.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // lblfiltroavanzado
            // 
            this.lblfiltroavanzado.AutoSize = true;
            this.lblfiltroavanzado.Location = new System.Drawing.Point(504, 396);
            this.lblfiltroavanzado.Name = "lblfiltroavanzado";
            this.lblfiltroavanzado.Size = new System.Drawing.Size(54, 16);
            this.lblfiltroavanzado.TabIndex = 13;
            this.lblfiltroavanzado.Text = "FILTRO";
            // 
            // txtfiltroavanzado
            // 
            this.txtfiltroavanzado.Location = new System.Drawing.Point(580, 393);
            this.txtfiltroavanzado.Name = "txtfiltroavanzado";
            this.txtfiltroavanzado.Size = new System.Drawing.Size(100, 22);
            this.txtfiltroavanzado.TabIndex = 14;
            // 
            // frmPokemons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 433);
            this.Controls.Add(this.txtfiltroavanzado);
            this.Controls.Add(this.lblfiltroavanzado);
            this.Controls.Add(this.cbocriterio);
            this.Controls.Add(this.lblcriterio);
            this.Controls.Add(this.cbocampo);
            this.Controls.Add(this.lblcampo);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.txtbFiltro);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.btnEliminarLogico);
            this.Controls.Add(this.btnEliniminarfisico);
            this.Controls.Add(this.btbModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pbPokemon);
            this.Controls.Add(this.dgvPokemons);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPokemons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pokemons";
            this.Load += new System.EventHandler(this.frmPokemons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokemons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPokemon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPokemons;
        private System.Windows.Forms.PictureBox pbPokemon;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btbModificar;
        private System.Windows.Forms.Button btnEliniminarfisico;
        private System.Windows.Forms.Button btnEliminarLogico;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox txtbFiltro;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.Label lblcampo;
        private System.Windows.Forms.ComboBox cbocampo;
        private System.Windows.Forms.Label lblcriterio;
        private System.Windows.Forms.ComboBox cbocriterio;
        private System.Windows.Forms.Label lblfiltroavanzado;
        private System.Windows.Forms.TextBox txtfiltroavanzado;
    }
}

