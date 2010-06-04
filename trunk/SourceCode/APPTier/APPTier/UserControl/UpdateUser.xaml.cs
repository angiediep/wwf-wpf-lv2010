using System;
using System.Collections.Generic;
using System.Collections;
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
        List<DtoNhanVienThuaHanh> m_lstOriginal = new List<DtoNhanVienThuaHanh>();
        List<DtoNhanVienThuaHanh> m_lstEdited = new List<DtoNhanVienThuaHanh>();
        List<DtoNhanVienThuaHanh> m_lstDeleted = new List<DtoNhanVienThuaHanh>();
        /// <summary>
        /// Thêm dữ liệu phụ vào dataagrid. Dữ liệu này bao gồm: số thứ tự, button
        /// xóa cho mỗi dòng.
        /// </summary>
        public void AddExtraData()
        {
            /* 
           * Thêm dữ liệu cho cột thứ tự và cột deleteButton
           */
            for (int i = 0; i < dtgvUser.Items.Count; i++)
            {
                DataGridCell cell = new DataGridCell();
                cell = GetCell(dtgvUser, i, 0);
                cell.Content = i + 1;
                cell.VerticalContentAlignment = VerticalAlignment.Center;

                Button button = new Button();
                button.Content = "Xóa";
                button.Click += new RoutedEventHandler(btnDelete_Click);
                cell = GetCell(dtgvUser, i, 8);
                cell.Content = button;
            }

            /*
             * Ẩn các cột không cho xem
             */
            dtgvUser.Columns[1].Visibility = Visibility.Hidden; //mã nhân viên
            dtgvUser.Columns[3].Visibility = Visibility.Hidden; //mật khẩu
            dtgvUser.Columns[4].Visibility = Visibility.Hidden; //salt

        }
        public UpdateUser()
        {
            this.InitializeComponent();

            LoadMainData();
        }
        /// <summary>
        /// Lấy dữ liệu nhân viên từ database
        /// </summary>
        public void LoadMainData()
        {
            //add cột thứ tự:
            DataGridTextColumn column = new DataGridTextColumn();
            dtgvUser.Columns.Add(column);

            BusNhanVienThuaHanh users = new BusNhanVienThuaHanh();
            m_lstOriginal = users.getDataList();

            dtgvUser.ItemsSource = m_lstOriginal;

            dtgvUser.Loaded += new RoutedEventHandler(dtgvUser_Loaded);
            dtgvUser.RowEditEnding += new EventHandler<DataGridRowEditEndingEventArgs>(dtgvUser_RowEditEnding);
            dtgvUser.CanUserSortColumns = false;
            
            dtgvUser.CanUserAddRows = false;
            dtgvUser.CanUserDeleteRows = false;
        }


       


        /// <summary>
        /// Được gọi sau khi dữ liệu được load lên datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dtgvUser_Loaded(object sender, RoutedEventArgs e)
        {
            //Add cột delete button:
            DataGridTextColumn column = new DataGridTextColumn();
            dtgvUser.Columns.Add(column);
            /*
             * Đặt tên column trong datagrid
             */
            dtgvUser.Columns[0].Header = "Số thứ tự";
            dtgvUser.Columns[1].Header = "Mã nhân viên";
            dtgvUser.Columns[2].Header = "Tên đăng nhập";
            dtgvUser.Columns[3].Header = "Mật khẩu";
            dtgvUser.Columns[4].Header = "Mã xác nhận";
            dtgvUser.Columns[5].Header = "Email";
            dtgvUser.Columns[6].Header = "Họ và tên ";
            dtgvUser.Columns[7].Header = "Điện thoại";
            dtgvUser.Columns[8].Header = "Xóa";
            AddExtraData();
        }


        /// <summary>
        /// Lưu kết quả thay đổi dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DtoNhanVienThuaHanh dtoNhanVienThuaHanh;
            BusNhanVienThuaHanh busNhanVienThuaHanh = new BusNhanVienThuaHanh();
            MessageBoxResult messageBoxResult = MessageBoxResult.Yes;
            string strMessage = "";
            if (m_lstEdited.Count > 0)
            {
                strMessage = "Bạn vừa thực hiện một số thao tác cập nhật thông tin nhân viên.\n\r";
                strMessage += "Bạn có chắc chắn lưu những sửa đổi không?";
                messageBoxResult = MessageBox.Show(strMessage, "Nhắc lưu", MessageBoxButton.YesNo);
            }
            if (messageBoxResult == MessageBoxResult.No)
                goto SAVE_DELETING;
            for (int i = 0; i < m_lstEdited.Count; i++)
            {
                dtoNhanVienThuaHanh = (DtoNhanVienThuaHanh)m_lstEdited[i];
                busNhanVienThuaHanh.updateData(dtoNhanVienThuaHanh);
            }
        SAVE_DELETING:
            messageBoxResult = MessageBoxResult.No;
            if (m_lstDeleted.Count > 0)
            {
                strMessage = "Bạn vừa thực hiện một số thao tác xóa thông tin nhân viên.\n\r";
                strMessage += "Bạn có chắc chắn xóa vĩnh viễn không?";
                messageBoxResult = MessageBox.Show(strMessage, "Nhắc lưu", MessageBoxButton.YesNo);
            }
            if (messageBoxResult == MessageBoxResult.No)
                goto QUIT;
            for (int i = 0; i < m_lstDeleted.Count; i++)
            {
                dtoNhanVienThuaHanh = (DtoNhanVienThuaHanh)m_lstDeleted[i];
                busNhanVienThuaHanh.deleteData(dtoNhanVienThuaHanh);
            }
        QUIT:
            m_lstDeleted.Clear();
            m_lstEdited.Clear();
            return;
        }
        /// <summary>
        /// Hủy bỏ thao tác thay đổi dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBoxResult.No;
            if (m_lstEdited.Count > 0 || m_lstDeleted.Count > 0)
            {
                String str = "Bạn vừa thực hiện một số thao tác thay đổi dữ liệu nhân viên.\n\r";
                str += "Bạn có chắc chắn muốn hủy các thao tác này hay không?";
                messageBoxResult = MessageBox.Show(str, "Nhắc lưu", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.No)
                    return;
            }
            m_lstDeleted.Clear();
            m_lstEdited.Clear();
            m_lstOriginal.Clear();

            dtgvUser.Columns.Clear();
            LoadMainData();
            dtgvUser_Loaded(null, null);

        }
        /// <summary>
        /// Lấy và trả về một ô dữ liệu bất kỳ trong datagrid.
        /// </summary>
        /// <param name="dg">datagrid chứa ô dữ liệu cần lấy</param>
        /// <param name="row">Dòng chứa ô dữ liệu cần lấy</param>
        /// <param name="column">Cột chứa ô dữ liệu cần lấy</param>
        /// <returns>Ô dữ liệu lấy được.</returns>
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
        /// <summary>
        /// Lấy và trả về một dòng dữ liệu bất kỳ trong datagrid
        /// </summary>
        /// <param name="dg">Datagrid chứa dữ liệu cần lấy</param>
        /// <param name="index">Chỉ số dòng cần lấy.</param>
        /// <returns>Dòng dữ liệu lấy được.</returns>
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
        /// Được gọi sau khi edit xong một dòng.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dtgvUser_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            m_lstEdited.Add((DtoNhanVienThuaHanh)dtgvUser.SelectedItem);
        }
        /// <summary>
        /// Xử lý xóa tạm thời một dòng dữ liệu. Dữ liệu cần xóa sẽ được lưu ra một danh sách.
        /// Khi người dùng lưu hành động xóa thì sẽ xóa thật sự dưới cơ sở dữ liệu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DtoNhanVienThuaHanh nv = (DtoNhanVienThuaHanh)dtgvUser.SelectedItem;
            m_lstDeleted.Add(nv);
            if (dtgvUser.Items.Count > 0)
                m_lstOriginal.RemoveAt(dtgvUser.SelectedIndex);
            dtgvUser.Items.Refresh();
            AddExtraData();

        }

    }
}