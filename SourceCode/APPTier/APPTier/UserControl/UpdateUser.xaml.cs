using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using BUSLayer;
using DataLayer.DTO;
using Microsoft.Windows.Controls;
using QuanLyThi;
using QuanLyThi.UserControl;
using System.Text.RegularExpressions;
namespace APPTier
{
    /// <summary>
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : UserControl
    {
        /// <summary>
        /// Danh sách nhân viên được load từ csdl.
        /// </summary>
        List<DtoNhanVienThuaHanh> m_lstOriginal = new List<DtoNhanVienThuaHanh>();
        /// <summary>
        /// Danh sách nhân viên hiện thời trong datagrid
        /// </summary>
        List<DtoNhanVienThuaHanh> m_lstCurrent = new List<DtoNhanVienThuaHanh>();
        /// <summary>
        /// Danh sách nhân viên được cập nhật, đang chờ lưu.
        /// </summary>
        List<DtoNhanVienThuaHanh> m_lstEdited = new List<DtoNhanVienThuaHanh>();
        /// <summary>
        /// Danh sách nhân viên bị xóa. Đang chờ xóa khỏi csdl.
        /// </summary>
        List<DtoNhanVienThuaHanh> m_lstDeleted = new List<DtoNhanVienThuaHanh>();
        public UpdateUser()
        {
            this.InitializeComponent();
            BusNhanVienThuaHanh users = new BusNhanVienThuaHanh();
            m_lstOriginal = users.getDataList();
            LoadMainData();
        }
        /// <summary>
        /// Load lại toàn bộ dữ liệu lên datagrid.
        /// </summary>
        public void ReloadData()
        {
            BusNhanVienThuaHanh users = new BusNhanVienThuaHanh();
            m_lstOriginal = users.getDataList();
            m_lstDeleted.Clear();
            m_lstEdited.Clear();
            m_lstCurrent.Clear();
            dtgvUser.Columns.Clear();
            LoadMainData();
            dtgvUser_Loaded(null, null);
        }
        /// <summary>
        /// Thêm dữ liệu phụ vào datagrid. Dữ liệu này bao gồm: số thứ tự, button
        /// xóa cho mỗi dòng.
        /// </summary>
        public void AddExtraData()
        {
            /* 
           * Thêm dữ liệu cho cột thứ tự và cột deleteButton
           */
            for (int i = 0; i < dtgvUser.Items.Count - 1; i++)
            {
                DataGridCell cell = new DataGridCell();
                cell = Utilities.GetCell(dtgvUser, i, 0);
                cell.Content = i + 1;
                cell.VerticalContentAlignment = VerticalAlignment.Center;
                cell.IsEditing = false;

                Button button = new Button();
                button.Content = "Xóa";
                button.Click += new RoutedEventHandler(btnDelete_Click);
                cell = Utilities.GetCell(dtgvUser, i, 8);
                cell.Content = button;
                cell.IsEditing = false;
            }
            DataGridCell endCell = Utilities.GetCell(dtgvUser, dtgvUser.Items.Count - 1, 0);
            endCell.IsEditing = false;
            endCell = Utilities.GetCell(dtgvUser, dtgvUser.Items.Count - 1, 8);
            endCell.IsEditing = false;
            /*
             * Ẩn các cột không cho xem
             */
            dtgvUser.Columns[1].Visibility = Visibility.Hidden; //mã nhân viên
            dtgvUser.Columns[3].Visibility = Visibility.Hidden; //mật khẩu
            dtgvUser.Columns[4].Visibility = Visibility.Hidden; //salt

        }
        /// <summary>
        /// Nạp dữ liệu nhân viên vào datagrid
        /// </summary>
        public void LoadMainData()
        {
            //add cột thứ tự:
            DataGridTextColumn column = new DataGridTextColumn();
            dtgvUser.Columns.Add(column);

            m_lstCurrent.Clear();
            m_lstCurrent = m_lstOriginal.GetRange(0, m_lstOriginal.Count);
            dtgvUser.ItemsSource = m_lstCurrent;

            dtgvUser.Loaded += new RoutedEventHandler(dtgvUser_Loaded);
            dtgvUser.RowEditEnding += new EventHandler<DataGridRowEditEndingEventArgs>(dtgvUser_RowEditEnding);
            dtgvUser.CanUserSortColumns = false;
            
            dtgvUser.CanUserAddRows = true;
            dtgvUser.CanUserDeleteRows = false;
        }
        /// <summary>
        /// Thực hiện thao tác lưu trữ thông tin các nhân viên mới xuống cơ sở dữ liệu nếu có.
        /// </summary>
        /// <returns>1: thành công, 0: thất bại</returns>
        public int PerformAdding()
        {
            BusNhanVienThuaHanh bus = new BusNhanVienThuaHanh();
            DtoNhanVienThuaHanh dto = new DtoNhanVienThuaHanh();
            int error = 0;
            string strMessage = "";
            for (int i = m_lstOriginal.Count - m_lstDeleted.Count; i < m_lstCurrent.Count; i++)
            {
                #region Kiểm tra thông tin đầu vào
                dto = m_lstCurrent[i];
                dto.MATKHAU = "123456"; //mật khẩu mặc định.
                /*
                 * Kiểm tra dữ liệu đầu vào có null hay không. Nếu null thì không cho lưu.
                 */
                
                if (null == dto.TENDANGNHAP || null == dto.MATKHAU ||
                    null == dto.TENNV || null == dto.DIENTHOAI ||
                    null == dto.EMAIL)
                {

                    strMessage = "Dữ liệu không được nhập đầy đủ tại dòng " + (i + 1).ToString() + "\n\r";
                    strMessage += "Vui lòng kiểm tra và thử lại sau";
                    error = 1;
                    goto QUIT;
                }

                dto.TENDANGNHAP = dto.TENDANGNHAP.Trim().Replace('\'', ' ');
                dto.TENNV = dto.TENNV.Trim().Replace('\'', ' ');
                dto.DIENTHOAI = dto.DIENTHOAI.Trim().Replace('\'', ' ');
                dto.EMAIL = dto.EMAIL.Trim().Replace('\'', ' ');
               
                
                /*
                 * Kiểm tra thông tin đầu vào hợp lệ hay không. Nếu không hợp lệ thì không cho lưu.
                 */
                if (0 == dto.TENDANGNHAP.Length || 0 == dto.MATKHAU.Length ||
                    0 == dto.TENNV.Length || 0 == dto.DIENTHOAI.Length ||
                    0 == dto.EMAIL.Length)
                {

                    strMessage = "Dữ liệu không được nhập đầy đủ tại dòng " + (i + 1).ToString() + "\n\r";
                    strMessage += "Vui lòng kiểm tra và thử lại sau";
                    error = 1;
                    goto QUIT;
                }
                if (!Regex.IsMatch(dto.EMAIL, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
                {
                    strMessage = "Email không hợp lệ tại dòng " + (i + 1).ToString() + "\n\r";
                    strMessage += "Vui lòng kiểm tra và thử lại sau";
                    error = 1;
                    goto QUIT;
                }

                #endregion
                /*
                 * Lưu thông tin đăng kí xuống cơ sở dữ liệu
                 */
                MyHashAlg hash = new MyHashAlg();

                dto.SALT = MyHashAlg.CreateRandomSalt();
                dto.MATKHAU = hash.Hash(dto.SALT, dto.MATKHAU);

                int result = bus.insertData(dto);

                #region Kiểm tra kết quả lưu trữ
                if (result == -1)
                {
                    strMessage = "Có lỗi tại dòng " + (i + 1).ToString() + "\n\r";
                    strMessage += "Tên đăng nhập đã tồn tại trong hệ thống. Vui lòng chọn tên khác";
                    error = 1;
                    goto QUIT;
                }
                if (result == -2)
                {
                    strMessage = "Có lỗi tại dòng " + (i + 1).ToString() + "\n\r";
                    strMessage += "Địa chỉ email đã tồn tại trong hệ thống. Vui lòng chọn email khác";
                    error = 1;
                    goto QUIT;
                }
                if (result == 0)
                {
                    strMessage = "Có lỗi tại dòng " + (i + 1).ToString() + "\n\r";
                    strMessage += "Đăng ký không thành công. Vui lòng liên hệ với quản lý để được giúp đỡ.";
                    error = 1;
                    goto QUIT;
                }
                #endregion
            }
            #region Thông báo lỗi nếu có
        QUIT:
            if (error == 1)
            {
                MessageBox.Show(strMessage,"Lỗi",MessageBoxButton.OK);
                return 0;
            }
            strMessage = "Đã thêm thành công " + (m_lstCurrent.Count - m_lstOriginal.Count) + " nhân viên mới";
            MessageBox.Show(strMessage,"Thông báo",MessageBoxButton.OK);
            return 1;
            #endregion
        }
        /// <summary>
        /// Thực hiện thao tác xóa thông tin các nhân viên trong hàng đợi khỏi csdl.
        /// </summary>
        public void PerformDeleting()
        {
            DtoNhanVienThuaHanh dtoNhanVienThuaHanh = new DtoNhanVienThuaHanh();
            BusNhanVienThuaHanh busNhanVienThuaHanh = new BusNhanVienThuaHanh();
            int resut = 10;
            for (int i = 0; i < m_lstDeleted.Count; i++)
            {
                dtoNhanVienThuaHanh = (DtoNhanVienThuaHanh)m_lstDeleted[i];
                resut = busNhanVienThuaHanh.deleteData(dtoNhanVienThuaHanh);
                if (resut != 1)
                    break;
            }
            string strMessage = "";
            if (resut == 0)
                MessageBox.Show("Xóa không thành công. Lỗi không xác định.");
            else
                if (resut == -1)
                {
                    strMessage = "Không thể xóa nhân viên " + dtoNhanVienThuaHanh.TENNV;
                    strMessage += "\n\r Nhân viên này hiện có tham gia hoặc đã tham gia vào các đợt thi nào đó.";
                    MessageBox.Show(strMessage, "Lỗi", MessageBoxButton.OK);
                }
        }
        /// <summary>
        /// Thực hiện thao tác cập nhật thông tin nhân viên vào csdl.
        /// </summary>
        public void PerformUpdating()
        {
            DtoNhanVienThuaHanh dtoNhanVienThuaHanh;
            BusNhanVienThuaHanh busNhanVienThuaHanh = new BusNhanVienThuaHanh();
            for (int i = 0; i < m_lstEdited.Count; i++)
            {
                dtoNhanVienThuaHanh = (DtoNhanVienThuaHanh)m_lstEdited[i];
                busNhanVienThuaHanh.updateData(dtoNhanVienThuaHanh);
            }
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
        /// Được gọi sau khi edit xong một dòng.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dtgvUser_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        { 
            AddExtraData();
            if (m_lstCurrent.Count == m_lstOriginal.Count)
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

            if (m_lstCurrent.Count <= 0)
                return;

            //Nếu dòng bị delete là dòng được load từ csdl, thì thêm vào hàng đợi xóa.
            if ((m_lstOriginal.Count - m_lstDeleted.Count) > dtgvUser.SelectedIndex)
            {
                DtoNhanVienThuaHanh nv = (DtoNhanVienThuaHanh)dtgvUser.SelectedItem;
                m_lstDeleted.Add(nv);
            }
            m_lstCurrent.RemoveAt(dtgvUser.SelectedIndex);

            dtgvUser.Items.Refresh();
            AddExtraData();

        }
        /// <summary>
        /// Lưu kết quả thay đổi dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBoxResult.No;
            string strMessage = "";
            if (m_lstEdited.Count > 0)
            {
                strMessage = "Bạn vừa thực hiện một số thao tác cập nhật thông tin nhân viên.\n\r";
                strMessage += "Bạn có chắc chắn lưu những sửa đổi không?";
                messageBoxResult = MessageBox.Show(strMessage, "Nhắc lưu", MessageBoxButton.YesNo);
            }
            if (messageBoxResult == MessageBoxResult.No)
                goto SAVE_CREATING;
            PerformUpdating();
        SAVE_CREATING:
            messageBoxResult = MessageBoxResult.No;
            if (m_lstOriginal.Count < (m_lstCurrent.Count + m_lstDeleted.Count))
            {
                strMessage = "Bạn vừa thực hiện một số thao tác thêm nhân viên mới.\n\r";
                strMessage += "Bạn có chắc chắn muốn lưu những thông tin này không?";
                messageBoxResult = MessageBox.Show(strMessage, "Nhắc lưu", MessageBoxButton.YesNo);
            }
            if (messageBoxResult == MessageBoxResult.No)
                goto SAVE_DELETING;
            if (PerformAdding() == 0)
                return;
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
            PerformDeleting();
        QUIT:
            ReloadData();
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
            m_lstCurrent.Clear();

            dtgvUser.Columns.Clear();
            LoadMainData();
            dtgvUser_Loaded(null, null);

        }
    }
}