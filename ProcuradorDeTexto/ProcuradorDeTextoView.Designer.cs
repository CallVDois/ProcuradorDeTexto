namespace ProcuradorDeTexto
{
    partial class ProcuradorDeTextoView
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            dgvArquivosEncontrados = new DataGridView();
            Linha = new DataGridViewTextBoxColumn();
            Diretorio = new DataGridViewTextBoxColumn();
            lblLinhasEncontrados = new Label();
            btnProcurar = new Button();
            tbCaminho = new TextBox();
            tbExtensao = new TextBox();
            lblTexto = new Label();
            tbTexto = new TextBox();
            lblCaminho = new Label();
            lblExtensao = new Label();
            progressBar1 = new ProgressBar();
            lblArquivosEncontradosNumero = new Label();
            button1 = new Button();
            tcResultados = new TabControl();
            tpArquivosEncontrados = new TabPage();
            tpArquivosEmUso = new TabPage();
            dgvArquivosEmUso = new DataGridView();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            lblArquivosEmUso = new Label();
            lblArquivosEmUsoNumero = new Label();
            cbIgnoreCase = new CheckBox();
            lblAjuda = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dgvArquivosEncontrados).BeginInit();
            tcResultados.SuspendLayout();
            tpArquivosEncontrados.SuspendLayout();
            tpArquivosEmUso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArquivosEmUso).BeginInit();
            SuspendLayout();
            // 
            // dgvArquivosEncontrados
            // 
            dgvArquivosEncontrados.AllowUserToAddRows = false;
            dgvArquivosEncontrados.AllowUserToDeleteRows = false;
            dgvArquivosEncontrados.AllowUserToResizeColumns = false;
            dgvArquivosEncontrados.AllowUserToResizeRows = false;
            dgvArquivosEncontrados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArquivosEncontrados.Columns.AddRange(new DataGridViewColumn[] { Linha, Diretorio });
            dgvArquivosEncontrados.Location = new Point(2, 2);
            dgvArquivosEncontrados.Name = "dgvArquivosEncontrados";
            dgvArquivosEncontrados.ReadOnly = true;
            dgvArquivosEncontrados.RowHeadersVisible = false;
            dgvArquivosEncontrados.RowTemplate.Height = 25;
            dgvArquivosEncontrados.Size = new Size(558, 178);
            dgvArquivosEncontrados.TabIndex = 15;
            dgvArquivosEncontrados.CellMouseDoubleClick += dgvArquivosEncontrados_CellMouseClick;
            // 
            // Linha
            // 
            Linha.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Linha.HeaderText = "Linha";
            Linha.Name = "Linha";
            Linha.ReadOnly = true;
            Linha.Resizable = DataGridViewTriState.False;
            Linha.Width = 61;
            // 
            // Diretorio
            // 
            Diretorio.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Diretorio.HeaderText = "Diretorio";
            Diretorio.MinimumWidth = 494;
            Diretorio.Name = "Diretorio";
            Diretorio.ReadOnly = true;
            Diretorio.Resizable = DataGridViewTriState.False;
            Diretorio.Width = 494;
            // 
            // lblLinhasEncontrados
            // 
            lblLinhasEncontrados.AutoSize = true;
            lblLinhasEncontrados.Location = new Point(178, 115);
            lblLinhasEncontrados.Name = "lblLinhasEncontrados";
            lblLinhasEncontrados.Size = new Size(113, 15);
            lblLinhasEncontrados.TabIndex = 14;
            lblLinhasEncontrados.Text = "Linhas encontrados:";
            // 
            // btnProcurar
            // 
            btnProcurar.Location = new Point(12, 135);
            btnProcurar.Name = "btnProcurar";
            btnProcurar.Size = new Size(100, 23);
            btnProcurar.TabIndex = 13;
            btnProcurar.Text = "Procurar";
            btnProcurar.UseVisualStyleBackColor = true;
            btnProcurar.Click += btnProcurar_Click;
            // 
            // tbCaminho
            // 
            tbCaminho.ForeColor = SystemColors.GrayText;
            tbCaminho.Location = new Point(12, 89);
            tbCaminho.Name = "tbCaminho";
            tbCaminho.Size = new Size(557, 23);
            tbCaminho.TabIndex = 12;
            tbCaminho.Text = "C:\\Users\\user\\Desktop              ";
            tbCaminho.Enter += textBox_Enter;
            tbCaminho.Leave += textBox_Leave;
            // 
            // tbExtensao
            // 
            tbExtensao.ForeColor = SystemColors.GrayText;
            tbExtensao.Location = new Point(12, 30);
            tbExtensao.Name = "tbExtensao";
            tbExtensao.Size = new Size(221, 23);
            tbExtensao.TabIndex = 11;
            tbExtensao.Text = "json                     ";
            tbExtensao.Enter += textBox_Enter;
            tbExtensao.Leave += textBox_Leave;
            // 
            // lblTexto
            // 
            lblTexto.AutoSize = true;
            lblTexto.Location = new Point(239, 12);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(38, 15);
            lblTexto.TabIndex = 21;
            lblTexto.Text = "Texto:";
            // 
            // tbTexto
            // 
            tbTexto.ForeColor = SystemColors.GrayText;
            tbTexto.Location = new Point(239, 30);
            tbTexto.Name = "tbTexto";
            tbTexto.Size = new Size(330, 23);
            tbTexto.TabIndex = 20;
            tbTexto.Text = "Text to search                 ";
            tbTexto.Enter += textBox_Enter;
            tbTexto.Leave += textBox_Leave;
            // 
            // lblCaminho
            // 
            lblCaminho.AutoSize = true;
            lblCaminho.Location = new Point(12, 71);
            lblCaminho.Name = "lblCaminho";
            lblCaminho.Size = new Size(38, 15);
            lblCaminho.TabIndex = 19;
            lblCaminho.Text = "Pasta:";
            // 
            // lblExtensao
            // 
            lblExtensao.AutoSize = true;
            lblExtensao.Location = new Point(12, 12);
            lblExtensao.Name = "lblExtensao";
            lblExtensao.Size = new Size(57, 15);
            lblExtensao.TabIndex = 18;
            lblExtensao.Text = "Extensão:";
            // 
            // progressBar1
            // 
            progressBar1.Enabled = false;
            progressBar1.Location = new Point(131, 135);
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(438, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 17;
            // 
            // lblArquivosEncontradosNumero
            // 
            lblArquivosEncontradosNumero.AutoSize = true;
            lblArquivosEncontradosNumero.Location = new Point(288, 115);
            lblArquivosEncontradosNumero.Name = "lblArquivosEncontradosNumero";
            lblArquivosEncontradosNumero.Size = new Size(13, 15);
            lblArquivosEncontradosNumero.TabIndex = 16;
            lblArquivosEncontradosNumero.Text = "0";
            // 
            // button1
            // 
            button1.Location = new Point(542, 89);
            button1.Name = "button1";
            button1.Size = new Size(27, 23);
            button1.TabIndex = 22;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tcResultados
            // 
            tcResultados.Controls.Add(tpArquivosEncontrados);
            tcResultados.Controls.Add(tpArquivosEmUso);
            tcResultados.Location = new Point(12, 164);
            tcResultados.Name = "tcResultados";
            tcResultados.SelectedIndex = 0;
            tcResultados.Size = new Size(570, 210);
            tcResultados.TabIndex = 23;
            // 
            // tpArquivosEncontrados
            // 
            tpArquivosEncontrados.Controls.Add(dgvArquivosEncontrados);
            tpArquivosEncontrados.Location = new Point(4, 24);
            tpArquivosEncontrados.Name = "tpArquivosEncontrados";
            tpArquivosEncontrados.Padding = new Padding(3);
            tpArquivosEncontrados.Size = new Size(562, 182);
            tpArquivosEncontrados.TabIndex = 0;
            tpArquivosEncontrados.Text = "Arquivos encontrados";
            tpArquivosEncontrados.UseVisualStyleBackColor = true;
            // 
            // tpArquivosEmUso
            // 
            tpArquivosEmUso.Controls.Add(dgvArquivosEmUso);
            tpArquivosEmUso.Location = new Point(4, 24);
            tpArquivosEmUso.Name = "tpArquivosEmUso";
            tpArquivosEmUso.Padding = new Padding(3);
            tpArquivosEmUso.Size = new Size(562, 182);
            tpArquivosEmUso.TabIndex = 1;
            tpArquivosEmUso.Text = "Arquivos em uso";
            tpArquivosEmUso.UseVisualStyleBackColor = true;
            // 
            // dgvArquivosEmUso
            // 
            dgvArquivosEmUso.AllowUserToAddRows = false;
            dgvArquivosEmUso.AllowUserToDeleteRows = false;
            dgvArquivosEmUso.AllowUserToResizeColumns = false;
            dgvArquivosEmUso.AllowUserToResizeRows = false;
            dgvArquivosEmUso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArquivosEmUso.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn2 });
            dgvArquivosEmUso.Location = new Point(2, 2);
            dgvArquivosEmUso.Name = "dgvArquivosEmUso";
            dgvArquivosEmUso.ReadOnly = true;
            dgvArquivosEmUso.RowHeadersVisible = false;
            dgvArquivosEmUso.RowTemplate.Height = 25;
            dgvArquivosEmUso.Size = new Size(558, 178);
            dgvArquivosEmUso.TabIndex = 16;
            dgvArquivosEmUso.CellDoubleClick += dgvArquivosEmUso_CellDoubleClick;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTextBoxColumn2.HeaderText = "Diretorio";
            dataGridViewTextBoxColumn2.MinimumWidth = 555;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn2.Width = 555;
            // 
            // lblArquivosEmUso
            // 
            lblArquivosEmUso.AutoSize = true;
            lblArquivosEmUso.Location = new Point(382, 115);
            lblArquivosEmUso.Name = "lblArquivosEmUso";
            lblArquivosEmUso.Size = new Size(99, 15);
            lblArquivosEmUso.TabIndex = 24;
            lblArquivosEmUso.Text = "Arquivos em uso:";
            // 
            // lblArquivosEmUsoNumero
            // 
            lblArquivosEmUsoNumero.AutoSize = true;
            lblArquivosEmUsoNumero.Location = new Point(478, 115);
            lblArquivosEmUsoNumero.Name = "lblArquivosEmUsoNumero";
            lblArquivosEmUsoNumero.Size = new Size(13, 15);
            lblArquivosEmUsoNumero.TabIndex = 25;
            lblArquivosEmUsoNumero.Text = "0";
            // 
            // cbIgnoreCase
            // 
            cbIgnoreCase.AutoSize = true;
            cbIgnoreCase.Location = new Point(239, 59);
            cbIgnoreCase.Name = "cbIgnoreCase";
            cbIgnoreCase.Size = new Size(86, 19);
            cbIgnoreCase.TabIndex = 26;
            cbIgnoreCase.Text = "Ignore case";
            cbIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // lblAjuda
            // 
            lblAjuda.AutoSize = true;
            lblAjuda.Location = new Point(555, 166);
            lblAjuda.Name = "lblAjuda";
            lblAjuda.Size = new Size(18, 15);
            lblAjuda.TabIndex = 28;
            lblAjuda.TabStop = true;
            lblAjuda.Text = " ? ";
            lblAjuda.LinkClicked += lblAjuda_LinkClicked;
            // 
            // ProcuradorDeTextoView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblAjuda);
            Controls.Add(cbIgnoreCase);
            Controls.Add(lblArquivosEmUsoNumero);
            Controls.Add(lblArquivosEmUso);
            Controls.Add(tcResultados);
            Controls.Add(button1);
            Controls.Add(lblLinhasEncontrados);
            Controls.Add(btnProcurar);
            Controls.Add(tbCaminho);
            Controls.Add(tbExtensao);
            Controls.Add(lblTexto);
            Controls.Add(tbTexto);
            Controls.Add(lblCaminho);
            Controls.Add(lblExtensao);
            Controls.Add(progressBar1);
            Controls.Add(lblArquivosEncontradosNumero);
            Name = "ProcuradorDeTextoView";
            Size = new Size(992, 609);
            Click += ProcuradorDeTextoView_Click;
            ((System.ComponentModel.ISupportInitialize)dgvArquivosEncontrados).EndInit();
            tcResultados.ResumeLayout(false);
            tpArquivosEncontrados.ResumeLayout(false);
            tpArquivosEmUso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvArquivosEmUso).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvArquivosEncontrados;
        private Label lblLinhasEncontrados;
        private Button btnProcurar;
        private TextBox tbCaminho;
        private TextBox tbExtensao;
        private Label lblTexto;
        private TextBox tbTexto;
        private Label lblCaminho;
        private Label lblExtensao;
        private ProgressBar progressBar1;
        private Label lblArquivosEncontradosNumero;
        private Button button1;
        private DataGridViewTextBoxColumn Linha;
        private DataGridViewTextBoxColumn Diretorio;
        private TabControl tcResultados;
        private TabPage tpArquivosEncontrados;
        private TabPage tpArquivosEmUso;
        private DataGridView dgvArquivosEmUso;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Label lblArquivosEmUso;
        private Label lblArquivosEmUsoNumero;
        private CheckBox cbIgnoreCase;
        private LinkLabel lblAjuda;
    }
}
