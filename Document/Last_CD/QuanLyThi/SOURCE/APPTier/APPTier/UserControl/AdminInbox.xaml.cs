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
using BUSLayer;
using QuanLyThi;
using DataLayer.DTO;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for UserInbox.xaml
    /// </summary>
    public partial class AdminInbox : UserControl
    {
        List<DtoThongBao> lstMSG;
        List<int> maTB;

        public AdminInbox()
        {
            this.InitializeComponent();
            maTB = new List<int>();
            lstMSG = new List<DtoThongBao>();
            setListMsg();
        }

        public void setListMsg()
        {
            List<DtoThongBao> listTB = new BusThongBao().getAdminMsg();
            if (listTB != null)
            {
                foreach (DtoThongBao dto in listTB)
                {
                    maTB.Add(dto.MATB);

                    string header = getMsgHeader(dto.NOIDUNG);
                    ListBoxItem item = new ListBoxItem();
                    item.Content = header;
                    lbxEmails.Items.Add(item);

                    lstMSG.Add(dto);
                }   
            }
        }

        private string getMsgHeader(string content)
        {
            string res = string.Empty;

            int x = 0;
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == ' ')
                    x++;
                if (x == 5)
                {
                    x = i;
                    break;
                }
            }
            if (x != 0)
                res = content.Remove(x) + " ...";

            return res;
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int idx = lbxEmails.SelectedIndex;
            if (idx != -1)
            {
                new BusThongBao().deleteDataBymaTD(maTB[idx]);
                lbxEmails.Items.RemoveAt(idx);
                tbxEmailContent.Text = "";

                List<int> list = new BusTienDo().getAllTDOfNV(new BusNhanVienThuaHanh().getMaNVByTenNV(Constants.strUserName));
                int totalUnreadMsg = 0;
                for (int i = 0; i < list.Count; i++)
                    totalUnreadMsg += new BusThongBao().getNoOfUnreadMsg(list[i]);
                //((Button)((this.get as UserHomepage).FindName("btnNewMsg"))).Content = "Thông điệp mới (" + totalUnreadMsg + ")";
            }
        }

        private void lbxEmails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idx = lbxEmails.SelectedIndex;
            if (idx != -1)
            {
                tbxEmailContent.Text = lstMSG[idx].NOIDUNG;
                if (lstMSG[idx].TRANGTHAI == 1)
                    new BusThongBao().updateReadMsg(maTB[idx]);
            }
        }
    }
}