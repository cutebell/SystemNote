using GoogleDriveAccess;
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

        private GoogleDriveAccessService googleDriveAccessService;

        private String fileID;

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.googleDriveAccessService = new GoogleDriveAccessService("Drive API .NET SystemNote");
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
            String tmpFileName = String.Empty;
            try
            {
                this.fileID = this.googleDriveAccessService.GetFileID(Config.Default.noteXMLPath);
                if (String.IsNullOrEmpty(this.fileID))
                {
                    using (MemoryStream memoryStream = new MemoryStream(Resources.note))
                    {
                        fileID = this.googleDriveAccessService.Create(memoryStream, Config.Default.noteXMLPath, "application/xml");
                    }
                }

                tmpFileName = this.googleDriveAccessService.GetFile(fileID);

                XML = new XMLAccess(tmpFileName);
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
            finally
            {
                if (File.Exists(tmpFileName))
                {
                    File.Delete(tmpFileName);
                }
            }
            
        }

        private void CommitXMLData()
        {
            String tmpFileName = this.googleDriveAccessService.GetFile(fileID);
            try
            {
                this.XML.saveXML(tmpFileName);
                using(FileStream fileStream = new FileStream(tmpFileName, FileMode.Open))
                {
                    this.googleDriveAccessService.Update(this.fileID, fileStream, Settings.Default.noteXMLPath, "application/xml");
                }

            }
            finally
            {
                if (File.Exists(tmpFileName))
                {
                    File.Delete(tmpFileName);
                }
            }
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
            if (String.IsNullOrEmpty(this.attributeName))
            {
                MessageBox.Show("編集中のタイトルがありません。");
                return;
            }
            XML.deleteXML(this.attributeName);

            this.CommitXMLData();
            foreach (String val in richTextBox1.Lines)
            {
                XML.appendXML(this.attributeName, val);
            }

            this.CommitXMLData();
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
            this.CommitXMLData();

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

                    this.CommitXMLData();
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
            PasswordMaker.MainForm mainForm = new PasswordMaker.MainForm();
            if(DialogResult.OK == mainForm.ShowDialog(this))
            {
                this.richTextBox1.AppendText(Environment.NewLine);
                this.richTextBox1.AppendText(mainForm.Password);
            }

        }
    }
}
