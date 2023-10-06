using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalCommander
{
    public class ListViewItemComparer : IComparer
    { 
        int col;
        int o;

        public ListViewItemComparer(int column, int order)//konstruktor
        {
            col = column;
            o = order;
        }

        public int Compare(object x, object y)
        {
            if (col == 1)//jesli wg 2 kol, to trzeba przekonwertować na datę
            {
                if (o == 1)
                {
                    return DateTime.Compare(Convert.ToDateTime(((ListViewItem)x).SubItems[col].Text), (Convert.ToDateTime(((ListViewItem)y).SubItems[col].Text)));
                }
                else
                    return DateTime.Compare(Convert.ToDateTime(((ListViewItem)y).SubItems[col].Text), (Convert.ToDateTime(((ListViewItem)x).SubItems[col].Text)));
            }

            else
            {
                if (o == 1)
                    return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                else
                    return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
            }
            }
        
    }
}
