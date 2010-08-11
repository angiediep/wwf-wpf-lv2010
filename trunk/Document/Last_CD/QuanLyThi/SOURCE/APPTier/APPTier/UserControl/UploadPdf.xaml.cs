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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using BUSLayer;
using DataLayer.DTO;
using Microsoft.Win32;
using System.IO;
using QuanLyThi;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class UploadPdf : Window
    {
        private int m_TD;
        private int m_Res;

        public int Res
        {
            get { return m_Res; }
            set { m_Res = value; }
        }

        public UploadPdf(int maTD)
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
            m_TD = maTD;
            m_Res = -1;
        }

        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            this.DragMove();
        }

        private void btnMinimize_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// chọn file pdf để upload
        /// </summary>
        /// <returns></returns>
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            string currentPath = Environment.CurrentDirectory;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "PDF Documents (*.pdf)|*.PDF";
            dlg.ShowDialog();
            tbxUpload.Text = dlg.FileName;

            Environment.CurrentDirectory = currentPath;
        }

        /// <summary>
        /// xử lý upload file pdf theo đường dẫn đã được quy định sẵn ứng với mỗi user
        /// </summary>
        /// <returns></returns>
        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            string sourcepath = tbxUpload.Text;
            string filename = System.IO.Path.GetFileName(sourcepath);
            string ext = System.IO.Path.GetExtension(sourcepath);
            if (ext == ".pdf")
            {
                DataLayer.DAO.DataConnector connector = new DataLayer.DAO.DataConnector();
                connector.getQuyTrinhThiConnectionString();
                string servername = connector.ServerNameToUpload;
                string username = Constants.strUserName;

                // path1: duong dan toi folder UserName
                string path1 = System.IO.Path.Combine(servername, username);
                if (Directory.Exists(path1) == false)
                    Directory.CreateDirectory(path1);
                BusTienDo busTD = new BusTienDo();
                string ngaythi = new BusDotThi().getNgayThiByMaDT(busTD.getMaDTByMaTD(m_TD)).ToShortDateString().Replace("/", ".");

                // path2: duong dan toi folder DotThi_<ngaythi>
                string path2 = System.IO.Path.Combine(path1, "DotThi_" + ngaythi);
                if (Directory.Exists(path2) == false)
                    Directory.CreateDirectory(path2);
                string tenCV = new BusCongViec().getTenCVByMaCV(busTD.getMaCVByMaTD(m_TD));

                // path3: duong dan toi file <TenCV>_<TenFile>.pdf
                string path3 = System.IO.Path.Combine(path2, tenCV + "_" + filename);

                try
                {
                    // Ensure that the target does not exist.
                    if (Directory.Exists(path3))
                        File.Delete(path3);

                    // Copy the file.
                    File.Copy(sourcepath, path3, true);
                    //  this.lblMessage.Text = sourcepath + "copied to" + path3;
                    new BusTienDo().finishWork(m_TD);
                    m_Res = 1;
                    MessageBox.Show("Tập tin được tải thành công");

                    this.Close();


                }
                catch (Exception ee)
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình Upload tài liệu. Thử lại vào lần sau.\n" + ee.Message);
                }
            }
        }
    }
}