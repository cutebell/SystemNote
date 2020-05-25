using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  System.Windows.Forms;

namespace NoteBook
{
    internal class MyConTextMenu
    {
        private Function function;
        private ContextMenuStrip _Menu;

        /// <summary>
        /// 元に戻す
        /// </summary>
        private ToolStripMenuItem MenuUndo;

        /// <summary>
        /// 切り取り
        /// </summary>
        private ToolStripMenuItem MenuCut;

        /// <summary>
        /// コピー
        /// </summary>
        private ToolStripMenuItem MenuCopy;

        /// <summary>
        /// 貼り付け
        /// </summary>
        private ToolStripMenuItem MenuPaste;

        /// <summary>
        /// 削除
        /// </summary>
        private ToolStripMenuItem MenuDelete;

       
        
        internal ContextMenuStrip menu
        {
            get { return _Menu; }
        }

        internal MyConTextMenu(Function _function)
        {
            // 機能クラス設定
            function = _function;

            // メニュー作成
            _Menu = new ContextMenuStrip();

            MenuUndo = new ToolStripMenuItem();
            MenuUndo.Text = "元に戻す";
            MenuUndo.Click += new EventHandler(MenuUndo_Click);

            MenuCut = new ToolStripMenuItem();
            MenuCut.Text = "切り取り";
            MenuCut.Click += new EventHandler(MenuCut_Click);

            MenuCopy = new ToolStripMenuItem();
            MenuCopy.Text = "コピー";
            MenuCopy.Click += new EventHandler(MenuCopy_Click);

            MenuPaste = new ToolStripMenuItem();
            MenuPaste.Text = "貼り付け";
            MenuPaste.Click += new EventHandler(MenuPaste_Click);

            MenuDelete = new ToolStripMenuItem();
            MenuDelete.Text = "削除";
            MenuDelete.Click += new EventHandler(MenuDelete_Click);

            _Menu.Items.Add(MenuUndo);
            _Menu.Items.Add(MenuCut);
            _Menu.Items.Add(MenuCopy);
            _Menu.Items.Add(MenuPaste);
            _Menu.Items.Add(MenuDelete);
        }

        /// <summary>
        /// 元に戻す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MenuUndo_Click(object sender, EventArgs e)
        {
            function.undo();
        }

        /// <summary>
        /// 切り取り
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuCut_Click(object sender, EventArgs e)
        {
            function.cut();
        }

        /// <summary>
        /// コピー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuCopy_Click(object sender, EventArgs e)
        {
            function.copy();
        }

        /// <summary>
        /// 貼り付け
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPaste_Click(object sender, EventArgs e)
        {
            function.paste();
        }

        /// <summary>
        /// 削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuDelete_Click(object sender, EventArgs e)
        {
            function.delete();
        }
    }
}
