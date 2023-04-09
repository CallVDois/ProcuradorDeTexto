using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ProcuradorDeTexto
{
    public partial class ProcuradorDeTextoView : UserControl
    {

        bool sucesso;
        List<string> exemplos = new List<string>();
        ConcurrentBag<DataGridViewRow> arquivosEncontrados = new ConcurrentBag<DataGridViewRow>();
        ConcurrentBag<DataGridViewRow> arquivosEmUso = new ConcurrentBag<DataGridViewRow>();

        public ProcuradorDeTextoView()
        {
            InitializeComponent();

            exemplos.Add("tbTexto," + tbTexto.Text);
            exemplos.Add("tbCaminho," + tbCaminho.Text);
            exemplos.Add("tbExtensao," + tbExtensao.Text);

            tbExtensao.TabStop = false;
            tbCaminho.TabStop = false;
            tbTexto.TabStop = false;
        }

        private async void btnProcurar_Click(object sender, EventArgs e)
        {

            btnProcurar.Enabled = false;
            lblArquivosEmUsoNumero.Text = "0";
            lblArquivosEncontradosNumero.Text = "0";

            dgvArquivosEncontrados.Rows.Clear();
            dgvArquivosEmUso.Rows.Clear();
            progressBar1.MarqueeAnimationSpeed = 35;

            await Task.Run(() =>
            {
                sucesso = Procurar();
            });

            dgvArquivosEncontrados.Rows.AddRange(arquivosEncontrados.ToArray());
            dgvArquivosEmUso.Rows.AddRange(arquivosEmUso.ToArray());

            arquivosEncontrados.Clear();

            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Style = ProgressBarStyle.Marquee;

            btnProcurar.Enabled = true;

            if (sucesso && lblArquivosEncontradosNumero.Equals("0"))
            {
                MessageBox.Show("Nada foi encontrado.");
            }

            if (dgvArquivosEmUso.Rows.Count > 1)
            {
                MessageBox.Show("Alguns arquivos estavam em uso e não puderam ser verificados.");
            }

            if (sucesso && dgvArquivosEmUso.Rows.Count == 0 && dgvArquivosEncontrados.Rows.Count == 0)
            {
                MessageBox.Show("Nada foi encontrado.");
            }
        }

        private bool Procurar()
        {
            int quantidadeArquivosEncontrados = 0;
            int quantidadeArquivosEmUso = 0;
            string caminho = tbCaminho.Text;
            string extensao = tbExtensao.Text;
            string textoParaProcurar = tbTexto.Text;
            try
            {
                string[] arquivos = Directory.GetFiles(caminho, "*." + extensao, SearchOption.AllDirectories);

                Parallel.ForEach(arquivos, arquivo =>
                {
                    try
                    {
                        string[] linhas = File.ReadAllLines(arquivo);

                        for (int i = 0; i < linhas.Length; i++)
                        {
                            if (cbIgnoreCase.Checked)
                            {
                                if (linhas[i].ToLower().Contains(textoParaProcurar.ToLower()))
                                {
                                    FileInfo fileInfo = new FileInfo(arquivo);

                                    DataGridViewRow novaLinha = new DataGridViewRow();
                                    novaLinha.CreateCells(dgvArquivosEncontrados, i + 1, arquivo);
                                    arquivosEncontrados.Add(novaLinha);
                                    quantidadeArquivosEncontrados++;
                                    lblArquivosEncontradosNumero.Text = quantidadeArquivosEncontrados.ToString();
                                }
                            }
                            else
                            {
                                if (linhas[i].Contains(textoParaProcurar))
                                {
                                    FileInfo fileInfo = new FileInfo(arquivo);

                                    DataGridViewRow novaLinha = new DataGridViewRow();
                                    novaLinha.CreateCells(dgvArquivosEncontrados, i + 1, arquivo);
                                    arquivosEncontrados.Add(novaLinha);
                                    quantidadeArquivosEncontrados++;
                                    lblArquivosEncontradosNumero.Text = quantidadeArquivosEncontrados.ToString();
                                }
                            }
                        }
                    }
                    catch (System.IO.IOException ex)
                    {
                        DataGridViewRow novaLinha = new DataGridViewRow();
                        novaLinha.CreateCells(dgvArquivosEmUso, arquivo);
                        arquivosEmUso.Add(novaLinha);
                        quantidadeArquivosEmUso++;
                        lblArquivosEmUsoNumero.Text = quantidadeArquivosEmUso.ToString();
                    }
                });
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                MessageBox.Show($"Diretorio não encontrado: \"{tbCaminho.Text}\"");
                return false;
            }
            catch (Exception ex)
            {

            }
            return true;
        }

        private void ProcuradorDeTextoView_Click(object sender, EventArgs e)
        {
            lblAjuda.Focus();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            List<string> exemplos3 = new List<string>();
            if (textBox != null)
            {
                foreach (string linha in exemplos)
                {
                    string[] exemplos2 = linha.Split(new string[] { "," }, StringSplitOptions.None);
                    foreach (string exemplo in exemplos2)
                    {
                        exemplos3.Add(exemplo);
                    }
                }
                if (exemplos3.Contains(textBox.Text))
                {
                    textBox.Text = "";
                    textBox.ForeColor = SystemColors.WindowText;
                }
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            string name = ((TextBox)sender).Name;
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox.Text == "")
                {
                    string teste = exemplos.FirstOrDefault(palavra => palavra.Contains(name));
                    int posicao = teste.IndexOf(",");
                    string textoparaexibir = teste.Substring(posicao + 1);
                    textBox.Text = textoparaexibir; // Define o texto de exemplo novamente
                    textBox.ForeColor = SystemColors.GrayText; // Define a cor do texto de exemplo
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog.ShowNewFolderButton = true;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string pastaSelecionada = folderBrowserDialog.SelectedPath;
                tbCaminho.Text = pastaSelecionada;
                tbCaminho.ForeColor = SystemColors.WindowText;
            }
        }

        private void dgvArquivosEncontrados_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string filePath = dgvArquivosEncontrados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (File.Exists(filePath))
                {
                    string argument = "/select, \"" + filePath + "\"";
                    Process.Start("explorer.exe", argument);
                }
            }
        }

        private void lblAjuda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Clique duas vezes no diretório para abrir a pasta do arquivo", "Informações");
        }

        private void dgvArquivosEmUso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string filePath = dgvArquivosEmUso.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (File.Exists(filePath))
                {
                    string argument = "/select, \"" + filePath + "\"";
                    Process.Start("explorer.exe", argument);
                }
            }
        }
    }

}
