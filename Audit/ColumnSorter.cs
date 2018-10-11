using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Audit
{
    public class ColumnSorter : IComparer
    {
        public int CurrentColumn = 0;
        public int Compare(object x, object y)
        {
            ListViewItem columnA = (ListViewItem)x;
            ListViewItem columnB = (ListViewItem)y;

            return String.Compare(columnA.SubItems[CurrentColumn].Text,
                                  columnB.SubItems[CurrentColumn].Text);
        }

        public ColumnSorter()
        {
        }
    }

    public class ListViewColumnSorter : IComparer
    {
        public CaseInsensitiveComparer ObjectCompare;
        public int ColumnToSort;
        public SortOrder OrderOfSort;
        public int CurrentColumn;

        public ListViewColumnSorter()
        {
            // Initialize the column to '0'  
            ColumnToSort = 0;

            // Initialize the sort order to 'none'  
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object  
            ObjectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects  
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items  
            try
            {
                string sItemX;
                string sItemY;

                try
                {
                    sItemX = listviewX.SubItems[ColumnToSort].Text;
                }
                catch (Exception)
                {
                    sItemX = "";
                }

                try
                {
                    sItemY = listviewY.SubItems[ColumnToSort].Text;
                }
                catch (Exception)
                {
                    sItemY = "";
                }

                compareResult = ObjectCompare.Compare(sItemX, sItemY);
            }
            catch (Exception e)
            {
                string sError = e.Message;

                return 0;
            }

            // Calculate correct return value based on object comparison  
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation  
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation  
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal  
                return 0;
            }
        }

        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }  
}
