using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace QuanLyThi.UserControl
{
    class Utilities
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
        /// <summary>
        /// Lấy và trả về một ô dữ liệu bất kỳ trong datagrid.
        /// </summary>
        /// <param name="dg">datagrid chứa ô dữ liệu cần lấy</param>
        /// <param name="row">Dòng chứa ô dữ liệu cần lấy</param>
        /// <param name="column">Cột chứa ô dữ liệu cần lấy</param>
        /// <returns>Ô dữ liệu lấy được.</returns>
        public static DataGridCell GetCell(DataGrid dg, int row, int column)
        {
            DataGridRow rowContainer = GetRow(dg, row);
            
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);

                // Try to get the cell but it may possibly be virtualized.
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    // Now try to bring into view and retreive the cell.
                    dg.ScrollIntoView(rowContainer, dg.Columns[column]);
                    cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                }
                return cell;
            }
            return null;
        }
        /// <summary>
        /// Lấy và trả về một dòng dữ liệu bất kỳ trong datagrid
        /// </summary>
        /// <param name="dg">Datagrid chứa dữ liệu cần lấy</param>
        /// <param name="index">Chỉ số dòng cần lấy.</param>
        /// <returns>Dòng dữ liệu lấy được.</returns>
        public static DataGridRow GetRow(DataGrid dg, int index)
        {
            DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                // May be virtualized, bring into view and try again.
                dg.UpdateLayout();
                dg.ScrollIntoView(dg.Items[index]);
                row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }
    }
}
