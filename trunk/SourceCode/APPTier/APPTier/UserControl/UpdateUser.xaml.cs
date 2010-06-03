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

            DataGridTemplateColumn item = new DataGridTemplateColumn();
            DataTemplate temp = new DataTemplate();
            temp.DataType = typeof(Button);

            FrameworkElementFactory spFactory = new FrameworkElementFactory(typeof(Button));
            spFactory.Name = "Edit";
            spFactory.SetValue(Button.ContentProperty, "Sửa");
            spFactory.SetValue(Button.NameProperty, "btnEdit");
            //spFactory.SetValue(Button.WidthProperty, "66");
          
            temp.VisualTree = spFactory;
            item.CellTemplate = temp;
            dtgvUser.Columns.Add(item);

            DataGridTextColumn item2 = new DataGridTextColumn();
            dtgvUser.Columns.Add(item2);

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
            dtgvUser.Columns[1].Header = "Số thứ tự";
            dtgvUser.Columns[2].Header = "Mã nhân viên";
            dtgvUser.Columns[3].Header = "Tên đăng nhập";
            dtgvUser.Columns[4].Header = "Mật khẩu";
            dtgvUser.Columns[5].Header = "SALT";
            dtgvUser.Columns[6].Header = "Email";
            dtgvUser.Columns[7].Header = "Họ và tên ";
            dtgvUser.Columns[8].Header = "Điện thoại";

            for (int i = 0; i < dtgvUser.Items.Count; i++)
            {
                
            }
            /*
             * Ẩn các cột không cho xem
             */
            dtgvUser.Columns[3].Visibility = Visibility.Hidden;
            dtgvUser.Columns[4].Visibility = Visibility.Hidden;
            dtgvUser.Columns[1].Visibility = Visibility.Hidden;

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

    }
}