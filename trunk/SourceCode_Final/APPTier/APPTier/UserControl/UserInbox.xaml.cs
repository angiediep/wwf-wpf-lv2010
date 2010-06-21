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
	public partial class UserInbox : UserControl
	{
        List<DtoThongBao> lstMSG;
        List<int> maTB;

        public UserInbox()
        {
            this.InitializeComponent();
            maTB = new List<int>();
            lstMSG = new List<DtoThongBao>();
        }

        public void setListMsg()
        {
            List<int> list = new BusTienDo().getAllTDOfNV(new BusNhanVienThuaHanh().getMaNVByTenNV(Constants.strUserName));
            List<string> msgHeaders = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                List<DtoThongBao> tb = new BusThongBao().getUnreadMsg(list[i]);
                foreach (DtoThongBao dto in tb)
                {
                    maTB.Add(dto.MATB);
                    msgHeaders.Add(getMsgHeader(dto.NOIDUNG));
                    lstMSG.Add(dto);
                }
            }
            lbxEmails.ItemsSource = msgHeaders;
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
            new BusThongBao().deleteDataBymaTD(maTB[idx]);
		}

        private void lbxEmails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idx = lbxEmails.SelectedIndex;
            tbxEmailContent.Text = lstMSG[idx].NOIDUNG;
            if (lstMSG[idx].TRANGTHAI == 1)
                new BusThongBao().updateReadMsg(maTB[idx]);
        }

        private void lbxEmails_Loaded(object sender, RoutedEventArgs e)
        {
        }
	}
}