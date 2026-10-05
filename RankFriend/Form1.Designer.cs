namespace RankFriend
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblPosicao;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.NumericUpDown nudPosicao;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.DataGridView dgvAmigos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblPosicao = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.nudPosicao = new System.Windows.Forms.NumericUpDown();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.dgvAmigos = new System.Windows.Forms.DataGridView();
            this.erroProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudPosicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmigos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erroProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(288, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(278, 46);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Ranking Friends";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNome.Location = new System.Drawing.Point(51, 101);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(61, 23);
            this.lblNome.TabIndex = 7;
            this.lblNome.Text = "Nome:";
            // 
            // lblPosicao
            // 
            this.lblPosicao.AutoSize = true;
            this.lblPosicao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPosicao.Location = new System.Drawing.Point(446, 101);
            this.lblPosicao.Name = "lblPosicao";
            this.lblPosicao.Size = new System.Drawing.Size(71, 23);
            this.lblPosicao.TabIndex = 5;
            this.lblPosicao.Text = "Posição:";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNome.Location = new System.Drawing.Point(114, 98);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(297, 30);
            this.txtNome.TabIndex = 6;
            // 
            // nudPosicao
            // 
            this.nudPosicao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudPosicao.Location = new System.Drawing.Point(520, 98);
            this.nudPosicao.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPosicao.Name = "nudPosicao";
            this.nudPosicao.Size = new System.Drawing.Size(91, 30);
            this.nudPosicao.TabIndex = 4;
            this.nudPosicao.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdicionar.Location = new System.Drawing.Point(51, 149);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(137, 37);
            this.btnAdicionar.TabIndex = 3;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEditar.Location = new System.Drawing.Point(206, 149);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(137, 37);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExcluir.Location = new System.Drawing.Point(360, 149);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(137, 37);
            this.btnExcluir.TabIndex = 1;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // dgvAmigos
            // 
            this.dgvAmigos.AllowUserToAddRows = false;
            this.dgvAmigos.AllowUserToDeleteRows = false;
            this.dgvAmigos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAmigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAmigos.Location = new System.Drawing.Point(51, 219);
            this.dgvAmigos.MultiSelect = false;
            this.dgvAmigos.Name = "dgvAmigos";
            this.dgvAmigos.ReadOnly = true;
            this.dgvAmigos.RowHeadersVisible = false;
            this.dgvAmigos.RowHeadersWidth = 51;
            this.dgvAmigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAmigos.Size = new System.Drawing.Size(766, 299);
            this.dgvAmigos.TabIndex = 0;
            this.dgvAmigos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAmigos_CellClick);
            // 
            // erroProvider
            // 
            this.erroProvider.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 565);
            this.Controls.Add(this.dgvAmigos);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.nudPosicao);
            this.Controls.Add(this.lblPosicao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ranking dos Amigos";
            ((System.ComponentModel.ISupportInitialize)(this.nudPosicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmigos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erroProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ErrorProvider erroProvider;
    }
}