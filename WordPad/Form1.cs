using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPad
{
    public partial class Wordpad : MetroFramework.Forms.MetroForm
    {
        public Wordpad()
        {
            InitializeComponent();
            txtContent.Focus();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        String path;

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            txtContent.Clear();
            metroProgressBar1.Visible = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroProgressBar1.Visible = true;
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text Documents|*.txt",Multiselect = false, ValidateNames = true };
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        path = ofd.FileName;
                        Task<string> text = sr.ReadToEndAsync();
                        txtContent.Text = text.Result;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error in Open Code", "Check", MessageBoxButtons.OK);
                }
            }
            metroProgressBar1.Visible = false;
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroProgressBar1.Visible = true;
            if (string.IsNullOrEmpty(path))
            {
                SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true };
                if(sfd.ShowDialog()==DialogResult.OK)
                {
                    try
                    {
                        path = sfd.FileName;
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            await sw.WriteLineAsync(txtContent.Text);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error in Save Code", "Check", MessageBoxButtons.OK);
                    }
                }
                
            }
            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        await sw.WriteLineAsync(txtContent.Text);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error in Save As Code", "Check", MessageBoxButtons.OK);
                }
            }
            metroProgressBar1.Visible = false;
        }

        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroProgressBar1.Visible = true;
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        await sw.WriteLineAsync(txtContent.Text);
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Error in Save As Code", "Check", MessageBoxButtons.OK);
                }
            }
            metroProgressBar1.Visible = false;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            pdoc.DocumentName = "fileName";
            pd.Document = pdoc;
            pd.AllowSelection = true;
            pd.AllowSomePages = true;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                pdoc.Print();
            }
        }
        
        private void pagesetupToolStripMenuItem1_Click(object sender, EventArgs e)
        { 
            PageSetupDialog psd = new PageSetupDialog();
            PrintDocument pdoc = new PrintDocument();
            psd.PageSettings = new PageSettings();
            psd.PrinterSettings = pdoc.PrinterSettings;
            psd.ShowDialog();
            if (psd.PageSettings != null)
            {
                pdoc.DefaultPageSettings = psd.PageSettings;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                txtContent.Font = fd.Font;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtContent.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtContent.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtContent.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtContent.Undo();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtContent.SelectAll();
        }

        private void metroProgressSpinner1_Click(object sender, EventArgs e)
        {

        }

        private void metroProgressSpinner1_MouseHover(object sender, EventArgs e)
        {
            metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Orange;
        }

        private void metroProgressSpinner1_MouseLeave(object sender, EventArgs e)
        {
            metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Blue;
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }

        private void backgroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                txtContent.BackColor = cd.Color;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void boldtoolStripButton_Click(object sender, EventArgs e)
        {
            if (!(Font.Bold))
            {
                Font = new Font(Font, FontStyle.Bold);
            }
            else
            {
                Font = new Font(Font, FontStyle.Regular);
            }
        }

        private void italictoolStripButton_Click(object sender, EventArgs e)
        {
            if (!(Font.Italic))
            {
                Font = new Font(Font, FontStyle.Italic);
            }
            else
            {
                Font = new Font(Font, FontStyle.Regular);
            }
        }

        private void underlinetoolStripButton_Click(object sender, EventArgs e)
        {
            if (!(Font.Underline))
            {
                Font = new Font(Font, FontStyle.Underline);
            }
            else
            {
                Font = new Font(Font, FontStyle.Regular);
            }
        }

        private void strikeouttoolStripButton_Click(object sender, EventArgs e)
        {
            if (!(Font.Strikeout))
            {
                Font = new Font(Font, FontStyle.Strikeout);
            }
            else
            {
                Font = new Font(Font, FontStyle.Regular);
            }
        }
    }
}