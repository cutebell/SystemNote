using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoteBook
{
    internal class Function
    {
        private RichTextBox textArea;

        internal Function(RichTextBox _textArea)
        {
            textArea = _textArea;
        }

        /// <summary>
        /// 元に戻す
        /// </summary>
        internal void undo()
        {
            textArea.Undo();
        }

        /// <summary>
        /// コピー機能
        /// </summary>
        internal void copy()
        {
            textArea.Copy();
        }

        /// <summary>
        /// 削除機能
        /// </summary>
        internal void delete()
        {
            // 文字が選択されていなければ何もしない
            if (0 >= textArea.SelectionLength)
            {
                return;
            }
            textArea.SelectedText = String.Empty;
        }

        /// <summary>
        /// 切り取り機能
        /// </summary>
        internal void cut()
        {
            textArea.Cut();
        }

        /// <summary>
        /// 貼り付け機能
        /// </summary>
        internal void paste()
        {
            textArea.Paste();
        }

        /// <summary>
        /// 末尾に貼り付け
        /// </summary>
        internal void appendText()
        {
            textArea.AppendText(Clipboard.GetText());
        }

        /// <summary>
        /// 全て選択
        /// </summary>
        internal void selectAll()
        {
            textArea.SelectAll();
        }

        /// <summary>
        /// 選択状態を解除
        /// </summary>
        internal void deSelectAll()
        {
            textArea.DeselectAll();
        }

        /// <summary>
        /// クリア
        /// </summary>
        internal void clear()
        {
            textArea.Clear();
        }

        /// <summary>
        /// 直前の動作を再実行
        /// </summary>
        internal void redo()
        {
            textArea.Redo();
        }

        /// <summary>
        /// 直前の動作情報を消去
        /// </summary>
        internal void clearUndo()
        {
            textArea.ClearUndo();
        }
    }
}
