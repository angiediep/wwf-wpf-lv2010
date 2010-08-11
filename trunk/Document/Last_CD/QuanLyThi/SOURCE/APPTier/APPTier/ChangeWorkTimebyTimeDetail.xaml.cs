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

namespace APPTier
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class ChangeWorkTimebyTimeDetail : Window
    {
        int m_MaCV = -1;
        int res = -1;
        int m_ngayBatDau = 0;
        int m_ngayKetThuc = 0;

        public int Res
        {
            get { return res; }
            set { res = value; }
        }

        public ChangeWorkTimebyTimeDetail()
        {
            this.InitializeComponent();
        }

        public ChangeWorkTimebyTimeDetail(int maCV)
        {
            this.InitializeComponent();
            // Insert code required on object creation below this point.
            m_MaCV = maCV;

            DtoCongViec cv = new BusCongViec().getDataById(m_MaCV);
            tbxNgayBatDau.Text = cv.NGAYBATDAU.ToString();
            tbxNgayKetThuc.Text = cv.NGAYKETTHUC.ToString();
            m_ngayBatDau = cv.NGAYBATDAU;
            m_ngayKetThuc = cv.NGAYKETTHUC;
            tbxTenCV.Text = cv.MOTA;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(tbxNgayKetThuc.Text) - int.Parse(tbxNgayBatDau.Text) < 0)
            {
                MessageBox.Show("Lỗi! Ngày kết thúc phải sau hoặc bằng ngày bắt đầu!");
            }
            else
            {
                int nbd = int.Parse(tbxNgayBatDau.Text);
                int nkt = int.Parse(tbxNgayKetThuc.Text);
                int giatri1 = nbd - m_ngayBatDau;
                int giatri2 = nkt - m_ngayKetThuc;
                List<DtoCongViec> cv = new BusCongViec().getDataList();
                int max = 1;
                for (int i = 0; i < cv.Count; i++)
                {
                    if (max < cv[i].MACV)
                        max = cv[i].MACV;
                }
                if (m_MaCV == 7)
                {
                    MessageBox.Show("Không được thay đổi ngày thi");
                }
                else if (m_MaCV < 7)
                {
                    //Kiem tra co kha nang bi anh huong den ngay thi khong, neu co thi thong bao loi ngay
                    if (new BusCongViec().getDataById(m_MaCV).NGAYBATDAU + giatri1 - new BusCongViec().getDataById(1).NGAYBATDAU < 0)
                    {
                        MessageBox.Show("Lỗi! Không thể thay đổi bằng giá trị mới, vì công việc không thể bắt đầu khi công việc đầu tiên chưa được thực hiện.");
                        return;
                    }
                    if (new BusCongViec().getDataById(m_MaCV).NGAYBATDAU + giatri1 - new BusCongViec().getDataById(7).NGAYBATDAU >= 0 || new BusCongViec().getDataById(m_MaCV).NGAYKETTHUC + giatri2 - new BusCongViec().getDataById(7).NGAYBATDAU >= 0)
                    {
                        MessageBox.Show("Lỗi! Không thể thay đổi bằng giá trị mới, vì sẽ ảnh hưởng đến ngày thi.");
                        return;
                    }
                    for (int i = m_MaCV + 1; i < 7; i++)
                    {
                        if (new BusCongViec().getDataById(i).NGAYBATDAU + giatri2 - new BusCongViec().getDataById(7).NGAYBATDAU >= 0)
                        {
                            MessageBox.Show("Lỗi! Không thể thay đổi bằng giá trị mới, vì sẽ ảnh hưởng đến ngày thi");
                            return;
                        }
                        else if (new BusCongViec().getDataById(i).NGAYKETTHUC + giatri2 - new BusCongViec().getDataById(7).NGAYBATDAU >= 0)
                        {
                            MessageBox.Show("Lỗi! Không thể thay đổi bằng giá trị mới, vì sẽ ảnh hưởng đến ngày thi");
                            return;
                        }
                    }
                    //Khi khong co truong hop nao ma co kha nang gay anh huong het thi moi cho phep thay doi truoc ngay thi
                    new BusCongViec().updateNBDvaNKTByMaCV(new BusCongViec().getDataById(m_MaCV).NGAYBATDAU + giatri1, new BusCongViec().getDataById(m_MaCV).NGAYKETTHUC + giatri2, m_MaCV);
                    for (int i = m_MaCV + 1; i < 7; i++)
                    {
                        new BusCongViec().updateNBDvaNKTByMaCV(new BusCongViec().getDataById(i).NGAYBATDAU + giatri2, new BusCongViec().getDataById(i).NGAYKETTHUC + giatri2, i);
                    }

                }
                else
                {
                    int isTre = 0;
                    //Kiem tra neu cv bi lui truoc ngay thi
                    if (new BusCongViec().getDataById(max).NGAYBATDAU + giatri2 >= new BusCongViec().getDataById(max).NGAYKETTHUC)
                    {
                        isTre= 2;
                    }
                    else if (new BusCongViec().getDataById(m_MaCV).NGAYBATDAU + giatri1 - new BusCongViec().getDataById(7).NGAYKETTHUC < 0)
                    {
                        isTre = -1;
                    }
                    else if (new BusCongViec().getDataById(m_MaCV).NGAYBATDAU + giatri1 - new BusCongViec().getDataById(max).NGAYKETTHUC >= 0 || new BusCongViec().getDataById(m_MaCV).NGAYKETTHUC + giatri2 - new BusCongViec().getDataById(max).NGAYKETTHUC >= 0)
                    {
                        isTre = 2;
                    }
                    else
                    {
                        for (int i = m_MaCV + 1; i <= max; i++)
                        {
                            //Kiem tra co ngay nao gay tre ko, neu co thi set co tre = 1 ngay
                            if (new BusCongViec().getDataById(i).NGAYBATDAU + giatri2 - new BusCongViec().getDataById(max).NGAYBATDAU >= 0)
                            {
                                isTre = 1;
                            }
                            //Kiem tra co ngay nao gay tre ko, neu co thi set co tre = 1 ngay
                            else if (new BusCongViec().getDataById(i).NGAYKETTHUC + giatri2 - new BusCongViec().getDataById(max).NGAYBATDAU >= 0 && new BusCongViec().getDataById(i).NGAYKETTHUC + giatri2 - new BusCongViec().getDataById(max).NGAYKETTHUC < 0)
                            {
                                isTre = 1;
                            }
                            else if (new BusCongViec().getDataById(i).NGAYKETTHUC + giatri2 - new BusCongViec().getDataById(max).NGAYKETTHUC >= 0)
                            {
                                isTre = 2;
                            }
                        }
                    }

                    // neu ko tre
                    if (isTre == 0)
                    {
                        new BusCongViec().updateNBDvaNKTByMaCV(new BusCongViec().getDataById(m_MaCV).NGAYBATDAU + giatri1, new BusCongViec().getDataById(m_MaCV).NGAYKETTHUC + giatri2, m_MaCV);
                        for (int i = m_MaCV + 1; i < max; i++)
                        {
                            new BusCongViec().updateNBDvaNKTByMaCV(new BusCongViec().getDataById(i).NGAYBATDAU + giatri2, new BusCongViec().getDataById(i).NGAYKETTHUC + giatri2, i);
                        }
                        new BusCongViec().updateNBDvaNKTByMaCV(new BusCongViec().getDataById(max).NGAYBATDAU + giatri2, new BusCongViec().getDataById(max).NGAYKETTHUC, max);
                    }
                    //neu bi lui ngay thi
                    else if (isTre == -1)
                    {
                        MessageBox.Show("Lỗi! Không thể thay đổi bằng giá trị mới vì sẽ ảnh hưởng đến ngày thi");
                    }
                    //neu tre qua
                    else if (isTre == 2)
                    {
                        MessageBox.Show("Lỗi! Không thể thay đổi bằng giá trị mới vì sẽ ảnh hưởng đến ngày phát chứng chỉ");
                    }
                        //tre nhung chua sao
                    else
                    {
                        new BusCongViec().updateNBDvaNKTByMaCV(new BusCongViec().getDataById(m_MaCV).NGAYBATDAU + giatri1, new BusCongViec().getDataById(m_MaCV).NGAYKETTHUC + giatri2, m_MaCV);
                        for (int i = m_MaCV + 1; i < max; i++)
                        {
                            new BusCongViec().updateNBDvaNKTByMaCV(new BusCongViec().getDataById(i).NGAYBATDAU + giatri2, new BusCongViec().getDataById(i).NGAYKETTHUC + giatri2, i);
                        }
                        new BusCongViec().updateNBDvaNKTByMaCV(new BusCongViec().getDataById(max).NGAYBATDAU + giatri2, new BusCongViec().getDataById(max).NGAYKETTHUC, max);

                    }
                }

                //new BusTienDo().updateNBDQDAndNKTQD(m_MaCV, nbd, nkt); ??????
                res = 0;
                this.Close();
            }
        }

        private void btnMinimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}