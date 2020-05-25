using NoteBook.Properties;
using System;
using System.IO;
using System.Windows.Forms;
using Config = NoteBook.Properties.Settings;

namespace NoteBook
{
    public partial class Form1 : Form
    {
        private XMLAccess XML;
 
        private MyConTextMenu _menu;

        private Function function;

        private Search search;

        private string attributeName;

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void setFont()
        {
            this.Font = Config.Default.font;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            if (false == File.Exists(Config.Default.noteXMLPath))
            {
                MessageBox.Show(this, "データを格納するxmlのパスを指定します", "初期設定", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if(DialogResult.OK.Equals(this.saveFileDialog1.ShowDialog(this)))
                {
                    Config.Default.noteXMLPath = this.saveFileDialog1.FileName;
                    using (StreamWriter streamWriter = File.CreateText(Config.Default.noteXMLPath))
                    {
                        streamWriter.WriteLine(Resources.note);
                        streamWriter.Close();
                    }
                    Config.Default.Save();
                }
                else
                {
                    Application.Exit();
                    return;
                }
            }

            XML = new XMLAccess(Config.Default.noteXMLPath);
            if (false == XML.InitSuccessFlg)
            {
                Application.Exit();
                return;
            }

            // 編集機能クラス
            function = new Function(richTextBox1);
            // コンテキストメニュークラス
            _menu = new MyConTextMenu(function);
            // 右クリックメニュー設定
            richTextBox1.ContextMenuStrip = _menu.menu;
            // 検索機能
            search = new Search(listBox1_Index);
            this.setFont();
            SystemFunction_INIT();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_Index_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox o = (ListBox)sender;
            if (0 > listBox1_Index.SelectedIndex)
            {
                richTextBox1.Clear();
                return;
            }
            this.attributeName = o.SelectedItem.ToString();
            this.toolStripStatusLabel1.Text = this.attributeName;
            richTextBox1.Lines = XML.getValue(attributeName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_Index_KeyDown(object sender, KeyEventArgs e)
        {
            if(Keys.Delete.Equals(e.KeyCode))
            {
                function_Delete();
            }
            else if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        function_Save();
                        break;

                    case Keys.D:
                        function_Delete();
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SystemFunction_INIT()
        {
            listBox1_Index.Items.Clear();
            listBox1_Index.Items.AddRange(XML.getAllIndex());
            listBox1_Index.Sorted = true;
            search.Index = listBox1_Index;
        }

        /// <summary>
        /// 
        /// </summary>
        private void function_Save()
        {
            if(String.IsNullOrEmpty(this.attributeName))
            {
                MessageBox.Show("編集中のタイトルがありません。");
                return;
            }
            XML.deleteXML(this.attributeName);
            XML.saveXML();
            foreach (String val in richTextBox1.Lines)
            {
                XML.appendXML(this.attributeName, val);
            }

            XML.saveXML();
            SystemFunction_INIT();
        }

        /// <summary>
        /// 
        /// </summary>
        private void function_Delete()
        {
            if (0 > listBox1_Index.SelectedIndex)
            {
                return;
            }
            XML.deleteXML(listBox1_Index.SelectedItem.ToString());
            XML.saveXML();
            richTextBox1.Text = String.Empty;
            SystemFunction_INIT();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_serch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    search.search(textBox1_serch.Text);
                    break;

                default:
                    break;
            }
        }

        private void 上書き保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.function_Save();
        }

        private void 新規作成NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTitle newTitle = new NewTitle();
            newTitle.ShowDialog(this);
            if (DialogResult.OK == newTitle.DialogResult)
            {
                if (String.IsNullOrEmpty(newTitle.newTitle))
                {
                    MessageBox.Show("新規タイトルが空です");
                    return;
                }
                else
                {
                    this.listBox1_Index.Items.Add(newTitle.newTitle);
                    XML.appendXML(newTitle.newTitle, String.Empty);
                    this.listBox1_Index.SelectedItem = newTitle.newTitle;
                }
            }
        }

        private void 名前を付けて保存AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTitle newTitle = new NewTitle();
            newTitle.newTitle = this.attributeName;
            if (DialogResult.OK == newTitle.ShowDialog(this))
            {
                if (String.IsNullOrEmpty(newTitle.newTitle))
                {
                    MessageBox.Show("新規タイトルが空です");
                    return;
                }
                else
                {
                    this.listBox1_Index.Items.Add(newTitle.newTitle);
                    foreach (String val in richTextBox1.Lines)
                    {
                        XML.appendXML(newTitle.newTitle, val);
                    }

                    XML.saveXML();
                    SystemFunction_INIT();
                    this.listBox1_Index.SelectedItem = newTitle.newTitle;
                }
            }
        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void フォントToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fontDialog1.Font = Config.Default.font;
            if (DialogResult.OK == this.fontDialog1.ShowDialog(this))
            {
                Config.Default.font = this.fontDialog1.Font;
                Config.Default.Save();
                this.setFont();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search.search(textBox1_serch.Text);
        }

        private void パスワードメーカーToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  パスワードメーカー.Form1 passwordMaker = new パスワードメーカー.Form1();
          //  if(DialogResult.OK == passwordMaker.ShowDialog(this))
          //  {
          //      this.richTextBox1.AppendText(Environment.NewLine);
          //      this.richTextBox1.AppendText(passwordMaker.password);
          //  }

        }
    }
}
