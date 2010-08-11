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
using ModelReader;
using System.Drawing;
using System.Collections;
using System.Collections.ObjectModel;
using BUSLayer;
using DataLayer.DTO;
using System.ComponentModel;
using System.IO;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for AssignUser.xaml
    /// </summary>
    public partial class PDFViewer : UserControl
    {
        List<DtoNhanVienThuaHanh> list;
        string[] files;

        public PDFViewer()
        {
            this.InitializeComponent();

            List<string> listNV = new List<string>();
            BusNhanVienThuaHanh x = new BusNhanVienThuaHanh();
            list = x.getDataList();
            foreach (DtoNhanVienThuaHanh nv in list)
            {
                string tennv = nv.TENNV;
                ListBoxItem item = new ListBoxItem();
                item.Content = tennv;
                lbxUser.Items.Add(item);
            }
        }


        /// <summary>
        /// load file pdf tương ứng với mỗi user
        /// </summary>
        /// <returns></returns>
        private void lbxUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataLayer.DAO.DataConnector conn = new DataLayer.DAO.DataConnector();
            conn.getQuyTrinhThiConnectionString();
            string username = list[lbxUser.SelectedIndex].TENDANGNHAP;
            string servername = conn.ServerNameToUpload;

            // duong dan toi folder UserName
            string path = System.IO.Path.Combine(servername, username);
            if (Directory.Exists(path) == true)
            {
                pdfViewer.Source = new Uri(path);
                //string[] filename = null;
                //files = Directory.GetFiles(path);
                //filename = new string[files.Length];
                //for (int i = 0; i < files.Length; i++)
                //    filename[i] = (System.IO.Path.GetFileName(files[i]));
            }
        }

        private void lblFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ////////////////////////////////////// BO ? ////////////////////////
            //if (lblFile.SelectedIndex != -1)
            //{
            //    string filename = files[lblFile.SelectedIndex];
            //    pdfViewer.Source = new Uri(filename);
            //}
        }
    }
}