﻿using System;
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
using Microsoft.Windows.Controls;
using System.Data;
using BUSLayer;

namespace APPTier
{
	/// <summary>
	/// Interaction logic for UpdateExam.xaml
	/// </summary>
	public partial class UpdateExam : UserControl
	{
		public UpdateExam()
		{
            this.InitializeComponent();
            LoadMainData();            
		}
        /// <summary>
        /// Load dữ liệu các đợt thi.
        /// </summary>
        public void LoadMainData()
        {
            BusDotThi busDotThi = new BusDotThi();
            //Add cột thứ tự:
            DataGridTextColumn column = new DataGridTextColumn();
            dtgvExam.Columns.Add(column);
            dtgvExam.ItemsSource = busDotThi.getDataList();
            dtgvExam.InitializingNewItem += new InitializingNewItemEventHandler(dtgvExam_InitializingNewItem);
            //dtgvExam.
        }

      
        void dtgvExam_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            MessageBox.Show("ok");
        }
		private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            //MessageBoxResult msg = MessageBox.Show("Bạn có chắc bạn muốn lưu thông tin đã cập nhật không?", "Cập nhật Nhân viên", MessageBoxButton.YesNo);
            //if (msg == MessageBoxResult.No)
            //{
            //    BusDotThi exams = new BusDotThi();
            //    DataTable dt = new DataTable();
            //    dt = exams.getDataTable();
            //    this.dtgvExam.ItemsSource = dt.DefaultView;
            //}
            //else
            //{
            //    //Luu thong tin da cap nhat xuong
            //    //Hien thi lai thong tin
            //}
            
		}

		private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            //MessageBoxResult msg = MessageBox.Show("Bạn có chắc bạn muốn hủy cập nhật thông tin không?","Cập nhật Đợt thi", MessageBoxButton.YesNo);
            //if (msg == MessageBoxResult.Yes)
            //{
            //    BusDotThi exams = new BusDotThi();
            //    DataTable dt = new DataTable();
            //    dt = exams.getDataTable();
            //    this.dtgvExam.ItemsSource = dt.DefaultView;
            //}
		}
	}
}