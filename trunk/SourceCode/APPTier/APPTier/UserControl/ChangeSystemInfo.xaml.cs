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
using DataLayer.DAO;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for ChangeSystemInfo.xaml
    /// </summary>
    public partial class ChangeSystemInfo : UserControl
    {
        private DataConnector m_dcSystemInfo;
        public ChangeSystemInfo()
        {
            this.InitializeComponent();
            m_dcSystemInfo = new DataConnector();
            m_dcSystemInfo.ReadBinary("dbinfo.dat");
            reset();
        }

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            DataConnector dc = new DataConnector();
            dc.strServerName = this.tbxServerName.Text.Trim();
            dc.strDatabaseName = this.tbxDatabaseName.Text.Trim();
            dc.strUserID = this.tbxUserID.Text.Trim();
            dc.strPass = this.tbxPass.Text.Trim();
            string temp = dc.WriteBinary("dbinfo.dat");
            
            if (temp != null)
            {
                MessageBox.Show(temp, "Lỗi", MessageBoxButton.OK);
            }

        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            MessageBoxResult msg = MessageBox.Show("Bạn có chắc bạn muốn hủy thông tin trên không?", "Hủy", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                reset();
            }

        }

        private void btnReset_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            reset();
        }

        public void reset()
        {
            this.tbxServerName.Text = m_dcSystemInfo.strServerName;
            this.tbxDatabaseName.Text = m_dcSystemInfo.strDatabaseName;
            this.tbxUserID.Text = m_dcSystemInfo.strUserID;
            this.tbxPass.Text = m_dcSystemInfo.strPass;
            this.tbxServerName.Focus();
        }
    }
}