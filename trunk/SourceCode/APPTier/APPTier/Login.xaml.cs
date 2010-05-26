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
using System.Windows.Shapes;
using BUSLayer;
using DataLayer.DTO;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public static string m_userkey;

        public Login()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
        }

        private void btnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            string Username = tbxUsername.Text;
            string Password = tbxPassword.Password;
            MyHashAlg hash = new MyHashAlg();
            BusNhanVien user = new BusNhanVien();
            m_userkey = Password;
            try
            {
                if (this.tbxUsername.Text == "")
                {
                    MessageBoxResult msg = MessageBox.Show("Bạn chưa nhập tên tài khoản!", "Lỗi", MessageBoxButton.OK);
                }
                else if (this.tbxPassword.Password == "")
                {
                    MessageBoxResult msg = MessageBox.Show("Bạn chưa nhập mật khẩu!", "Lỗi", MessageBoxButton.OK);
                }
                else
                {
                    //Hash password
                    //Kiểm tra Database giá trị hash và tên tài khoản
                    //Nếu không hợp lệ sẽ báo lỗi
                    //Nếu hợp lệ, kiểm tra loại user
                    List<DtoNhanVien> userList = user.getListDataBytenNV(Username);
                    if (userList.Count > 0)
                    {
                        int Salt = userList[0].SALT;
                        if (Salt == -1)
                        {
                            MessageBoxResult msg = MessageBox.Show("Tài khoản không hợp lệ!", "Lỗi", MessageBoxButton.OK);
                        }
                        else
                        {
                            string passphrase = hash.Hash(Salt, Password); //cai dc luu trong csdl
                            if (userList[0].MATKHAU != passphrase)
                            {
                                MessageBoxResult msg = MessageBox.Show("Tài khoản không hợp lệ!", "Lỗi", MessageBoxButton.OK);
                            }
                            else
                            {
                                if (userList[0].MANV == 1)
                                {
                                    AdminHomepage adminHomepage = new AdminHomepage();
                                    adminHomepage.Show();
                                    this.Close();
                                }
                                else
                                {
                                    UserHomepage userHomepage = new UserHomepage();
                                    userHomepage.Show();
                                    this.Close();
                                }
                            }

                        }
                        //Nếu là nhân viên, mở cửa sổ Nhân viên với các chức năng tương ứng

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult msg = MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK);
            }
        }

        private void btnRegister_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Register reg = new Register();
            reg.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            MessageBoxResult msg = MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thoát", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            this.DragMove();
        }

        private void btnMinimize_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            MessageBoxResult msg = MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thoát", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}