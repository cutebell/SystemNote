using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoteBook
{
    internal class Search
    {
        private ListBox _Index;
        internal ListBox Index
        {
            set { _Index = value; }
        }

        internal Search(ListBox Index)
        {
            _Index = Index;
        }

        internal void search(String target)
        {
            int startIndex = _Index.SelectedIndex + 1;
            int setIndex = 0;

            setIndex = searchSub(target, startIndex, _Index.Items.Count - 1);
            if (0 <= setIndex)
            {
                _Index.SelectedIndex = setIndex;
                return;
            }

            _Index.SelectedIndex = searchSub(target, 0, _Index.SelectedIndex);
        }

        private int searchSub(String target,int start ,int end)
        {
            String item = String.Empty;
            int pos = 0;
            for (int i = start; i <= end; i++)
            {
                item = (String)_Index.Items[i];
                pos = item.IndexOf(target);
                if (0 <= pos)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
