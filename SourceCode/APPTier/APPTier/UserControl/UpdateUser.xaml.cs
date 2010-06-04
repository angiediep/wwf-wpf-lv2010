using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using BUSLayer;
using DataLayer.DTO;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
using QuanLyThi;
namespace APPTier
{
    /// <summary>
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : UserControl
    {
        public UpdateUser()
        {
            this.InitializeComponent();

            #region button edit
            DataGridTemplateColumn item = new DataGridTemplateColumn();
            DataTemplate temp = new DataTemplate();
            temp.DataType = typeof(Button);

            FrameworkElementFactory spFactory = new FrameworkElementFactory(typeof(Button));
            spFactory.Name = "Edit";
            spFactory.SetValue(Button.ContentProperty, "Sửa");
            spFactory.SetValue(Button.NameProperty, "btnEdit");
            spFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnEdit_Click));

            temp.VisualTree = spFactory;
            item.CellTemplate = temp;
            dtgvUser.Columns.Add(item);
            #endregion

            #region button delete
            DataGridTemplateColumn item2 = new DataGridTemplateColumn();
            DataTemplate temp2 = new DataTemplate();
            temp2.DataType = typeof(Button);

            FrameworkElementFactory spFactory2 = new FrameworkElementFactory(typeof(Button));
            spFactory2.Name = "Delete";
            spFactory2.SetValue(Button.ContentProperty, "Xóa");
            spFactory2.SetValue(Button.NameProperty, "btnDelete");
            spFactory2.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnDelete_Click));

            temp2.VisualTree = spFactory2;
            item2.CellTemplate = temp2;
            dtgvUser.Columns.Add(item2);
            #endregion

            DataGridTextColumn item3 = new DataGridTextColumn();
            dtgvUser.Columns.Add(item3);

            BusNhanVienThuaHanh users = new BusNhanVienThuaHanh();
            //DataTable dt = new DataTable();
            List<DtoNhanVienThuaHanh> lst = new List<DtoNhanVienThuaHanh>();
            lst = users.getDataList();
            dtgvUser.ItemsSource = lst;

            dtgvUser.Loaded += new RoutedEventHandler(dtgvUser_Loaded);
        }

        /// <summary>
        /// Được gọi sau khi dữ liệu được load lên datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dtgvUser_Loaded(object sender, RoutedEventArgs e)
        {
            /*
             * Đặt tên column trong datagrid
             */
            dtgvUser.Columns[0].Header = "Chỉnh sửa";
            dtgvUser.Columns[1].Header = "Xóa";
            dtgvUser.Columns[2].Header = "Số thứ tự";
            dtgvUser.Columns[3].Header = "Mã nhân viên";
            dtgvUser.Columns[4].Header = "Tên đăng nhập";
            dtgvUser.Columns[5].Header = "Mật khẩu";
            dtgvUser.Columns[6].Header = "Mã xác nhận";
            dtgvUser.Columns[7].Header = "Email";
            dtgvUser.Columns[8].Header = "Họ và tên ";
            dtgvUser.Columns[9].Header = "Điện thoại";

            /* them so thu tu cho cot 
             * nhung chi them luc load, chua co lam cho them tu dong
             */
            for (int i = 0; i < dtgvUser.Items.Count; i++)
            {
                DataGridCell cell, _cell = new DataGridCell();
                cell = GetCell(dtgvUser, i, 2);
                _cell = GetCell(dtgvUser, i, 4);
                cell.Content = _cell.Content;
                cell.VerticalContentAlignment = VerticalAlignment.Center;
            }


            /*
             * Ẩn các cột không cho xem
             */
            dtgvUser.Columns[5].Visibility = Visibility.Hidden;
            dtgvUser.Columns[6].Visibility = Visibility.Hidden;
            dtgvUser.Columns[3].Visibility = Visibility.Hidden;

        }


        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            MessageBoxResult msg = MessageBox.Show("Bạn có chắc bạn muốn hủy cập nhật thông tin không?", "Cập nhật Nhân viên", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                loadUserList();
            }

        }

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            MessageBoxResult msg = MessageBox.Show("Bạn có chắc bạn muốn lưu thông tin đã cập nhật không?", "Cập nhật Nhân viên", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.No)
            {
                loadUserList();
            }
            else
            {
                //Luu thong tin da cap nhat xuong
                //Hien thi lai thong tin
            }

        }

        void loadUserList()
        {
        }

        public DataGridCell GetCell(DataGrid dg, int row, int column)
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

        public DataGridRow GetRow(DataGrid dg, int index)
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

        private void btnEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            /* add code update/add new NhanVien  here
             */
            DtoNhanVienThuaHanh nv = new DtoNhanVienThuaHanh();
            nv = (DtoNhanVienThuaHanh)dtgvUser.SelectedItem; 
            
            //Luu xuong database

        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            /* add code delete NhanVien here
             */
            MessageBoxResult msg = MessageBox.Show("Quá trình xóa thành công", "Xóa Nhân viên", MessageBoxButton.OK);
        }

    }
}