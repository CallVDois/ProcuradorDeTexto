using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using ProcuradorDeTexto.utils;

namespace ProcuradorDeTexto
{
    public partial class ProcuradorDeTextoView : UserControl
    {

        List<string> exemplos = new List<string>();
        ConcurrentBag<String[]> arquivosEncontrados = new ConcurrentBag<String[]>();
        ConcurrentBag<String[]> arquivosEmUso = new ConcurrentBag<String[]>();

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
            bool sucesso = false;

            dgvArquivosEncontrados.Rows.Clear();
            dgvArquivosEmUso.Rows.Clear();
            ButtonUtils.UpdateButton(btnProcurar);
            LabelUtils.UpdateLabelString(lblArquivosEncontradosNumero, "0");
            LabelUtils.UpdateLabelString(lblArquivosEmUsoNumero, "0");
            ProgressBarUtils.UpdateProgressBar(progressBar1);

            await Task.Run(() =>
            {
                sucesso = Procurar();
            });

            arquivosEncontrados.ToList()
                .AsParallel()
                .ForAll(arquivo =>
                {

                    dgvArquivosEncontrados.BeginInvoke(() =>
                    {
                        this.dgvArquivosEncontrados.Rows.Add(arquivo);
                    });


                });

            arquivosEmUso.ToList()
                .AsParallel()
                .ForAll(arquivo =>
                {
                    dgvArquivosEmUso.BeginInvoke(() =>
                    {
                        this.dgvArquivosEmUso.Rows.Add(arquivo);
                    });
                });

            LabelUtils.UpdateLabelConcurrentBag(lblArquivosEncontradosNumero, arquivosEncontrados);
            LabelUtils.UpdateLabelConcurrentBag(lblArquivosEmUsoNumero, arquivosEmUso);
            ProgressBarUtils.UpdateProgressBar(progressBar1);
            ButtonUtils.UpdateButton(btnProcurar);

            if (sucesso && arquivosEncontrados.Count == 0 && arquivosEmUso.Count == 0)
            {
                MessageBox.Show("Nada foi encontrado.");
            }

            if (arquivosEmUso.Count > 0)
            {
                MessageBox.Show("Alguns arquivos estavam em uso e não puderam ser verificados.");
            }

            arquivosEncontrados.Clear();
            arquivosEmUso.Clear();
        }

        private bool Procurar()
        {
            string caminho = tbCaminho.Text;
            string extensao = tbExtensao.Text;
            string textoParaProcurar = tbTexto.Text;

            try
            {
                Directory.GetFiles(caminho, "*." + extensao, SearchOption.AllDirectories)
                    .ToList()
                    .ForEach(arquivo =>
                    {
                        int i = 0;
                        try
                        {
                            File.ReadAllLines(arquivo)
                                .ToList()
                                .ForEach(linha =>
                                {
                                    i++;
                                    bool contem;
                                    if (cbIgnoreCase.Checked)
                                    {
                                        contem = linha.ContainsIgnoreCase(textoParaProcurar);
                                    }
                                    else
                                    {
                                        contem = linha.Contains(textoParaProcurar);
                                    }
                                    if (contem)
                                    {
                                        arquivosEncontrados.Add(new string[] { i.ToString(), arquivo });
                                    }
                                });
                        }
                        catch (System.IO.IOException ex)
                        {
                            arquivosEmUso.Add(new string[] { arquivo });
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
            TextBox textBox = sender as TextBox;
            string name = textBox.Name;
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
