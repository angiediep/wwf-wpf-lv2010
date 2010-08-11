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
    public partial class ChangeWorkTimeByExamDetail : Window
    {
        int m_MaDT = -1;
        int m_MaCV = -1;
        int res = -1;
        DateTime m_nbd = new DateTime();
        DateTime m_nkt = new DateTime();

        public int Res
        {
            get { return res; }
            set { res = value; }
        }

        public ChangeWorkTimeByExamDetail()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
            btnUpdate.Visibility = Visibility.Hidden;
        }

        public ChangeWorkTimeByExamDetail(int maDT, int maCV)
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
            m_MaDT = maDT;
            m_MaCV = maCV;

            List<string> res = new BusTienDo().getDataByMaDTAndMaCV(maDT, maCV);
            tbxDotThi.Text = res[0];
            tbxPassword.Text = res[1];
            tbxSoluongthisinh.Text = res[2];
            m_nbd = DateTime.Parse(res[1]);
            m_nkt = DateTime.Parse(res[2]);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.Parse(tbxSoluongthisinh.Text).Subtract(DateTime.Parse(tbxPassword.Text)).Days < 0)
            {
                MessageBox.Show("Lỗi! Ngày kết thúc phải sau hoặc bằng ngày bắt đầu!");
            }
            else
            {
                TimeSpan giatri1 = DateTime.Parse(tbxPassword.Text).Date.Subtract(m_nbd.Date);
                TimeSpan giatri2 = DateTime.Parse(tbxSoluongthisinh.Text).Date.Subtract(m_nkt.Date);
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
                else if (m_MaCV > 1 && m_MaCV < 7)
                {
                    //Kiem tra co kha nang bi anh huong den ngay thi khong, neu co thi thong bao loi ngay
                    DtoTienDo td_ = new DtoTienDo();
                    td_.MACV = m_MaCV;
                    td_.MADT = m_MaDT;
                    td_.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[1]).Add(giatri1);
                    td_.NGAYKETTHUCQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[2]).Add(giatri2);
                    if (td_.NGAYBATDAUQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, 1)[1]).Date).Days < 0)
                    {
                        MessageBox.Show("Lỗi! Không thể thay đổi bằng giá trị mới, vì công việc không thể bắt đầu trước ngày" + DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, 1)[1]).ToShortDateString());
                        return;
                    }
                    if (td_.NGAYBATDAUQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, 7)[1]).Date).Days >= 0 || td_.NGAYKETTHUCQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, 7)[2]).Date).Days >= 0)
                    {
                        MessageBox.Show("Lỗi! Không thể thay đổi bằng giá trị mới, vì sẽ ảnh hưởng đến ngày thi");
                        return;
                    }
                    for (int i = m_MaCV + 1; i < 7; i++)
                    {
                        DtoTienDo td = new DtoTienDo();
                        td.MACV = i;
                        td.MADT = m_MaDT;
                        td.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, i)[1]).Add(giatri2);
                        td.NGAYKETTHUCQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, i)[2]).Add(giatri2);
                        if (td.NGAYBATDAUQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, 7)[1]).Date).Days >= 0)
                        {
                            MessageBox.Show("Lỗi! Không thể thay đổi bằng giá trị mới, vì sẽ ảnh hưởng đến ngày thi");
                            return;
                        }
                        else if (td.NGAYKETTHUCQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, 7)[1]).Date).Days >= 0)
                        {
                            MessageBox.Show("Lỗi! Không thể thay đổi bằng giá trị mới, vì sẽ ảnh hưởng đến ngày thi");
                            return;
                        }
                    }
                    //Khi khong co truong hop nao ma co kha nang gay anh huong het thi moi cho phep thay doi truoc ngay thi
                    DtoTienDo _td = new DtoTienDo();
                    _td.MACV = m_MaCV;
                    _td.MADT = m_MaDT;
                    _td.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[1]).Add(giatri1);
                    _td.NGAYKETTHUCQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[2]).Add(giatri2);
                    new BusTienDo().updateDataByMaCVAndMaDT(_td);
                    for (int i = m_MaCV + 1; i < 7; i++)
                    {
                        DtoTienDo td = new DtoTienDo();
                        td.MACV = i;
                        td.MADT = m_MaDT;
                        td.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, i)[1]).Add(giatri2);
                        td.NGAYKETTHUCQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, i)[2]).Add(giatri2);
                        new BusTienDo().updateDataByMaCVAndMaDT(td);
                    }
                }
                else
                {
                    int isTre = 0;
                    //Kiem tra neu cv dau tien bi lui lacv ChamThi bi lui truoc ngay thi
                    DtoTienDo td_ = new DtoTienDo();
                    td_.MACV = m_MaCV;
                    td_.MADT = m_MaDT;
                    td_.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[1]).Add(giatri1);
                    td_.NGAYKETTHUCQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[2]).Add(giatri2);
                    DtoTienDo td2 = new DtoTienDo();
                    td2.MACV = max;
                    td2.MADT = m_MaDT;
                    td2.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[1]).Add(giatri2);
                    td2.NGAYKETTHUCQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[2]).Add(giatri2);
                    if (td2.NGAYBATDAUQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[2]).Date).Days >= 0)
                    {
                        isTre = 2;
                    }
                    else if (td_.NGAYBATDAUQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, 7)[2]).Date).Days < 0)
                    {
                        isTre = -1;
                    }
                    else if (td_.NGAYBATDAUQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, max)[1]).Date).Days >= 0 || td_.NGAYKETTHUCQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, max)[2]).Date).Days >= 0)
                    {
                        isTre = 2;
                    }
                    //Kiem tra co ngay nao gay tre ko, neu co thi set co tre = 1 ngay
                    else
                    {
                        for (int i = m_MaCV + 1; i <= max; i++)
                        {
                            DtoTienDo td = new DtoTienDo();
                            td.MACV = i;
                            td.MADT = m_MaDT;
                            td.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, i)[1]).Add(giatri2);
                            td.NGAYKETTHUCQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, i)[2]).Add(giatri2);
                            if (td.NGAYBATDAUQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, max)[1]).Date).Days >= 0)
                            {
                                isTre = 1;
                            }
                            else if (td.NGAYKETTHUCQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, max)[1]).Date).Days >= 0 && td.NGAYKETTHUCQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, max)[2]).Date).Days < 0)
                            {
                                isTre = 1;
                            }
                            else if (td.NGAYKETTHUCQUYDINH.Date.Subtract(DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, max)[2]).Date).Days >= 0)
                            {
                                isTre = 2;
                            }
                        }
                    }

                    // neu ko tre
                    if (isTre == 0)
                    {
                        DtoTienDo _td = new DtoTienDo();
                        _td.MACV = m_MaCV;
                        _td.MADT = m_MaDT;
                        _td.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[1]).Add(giatri1);
                        _td.NGAYKETTHUCQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[2]).Add(giatri2);
                        new BusTienDo().updateDataByMaCVAndMaDT(_td);
                        for (int i = m_MaCV + 1; i < max; i++)
                        {
                            DtoTienDo td = new DtoTienDo();
                            td.MACV = i;
                            td.MADT = m_MaDT;
                            td.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, i)[1]).Add(giatri2);
                            td.NGAYKETTHUCQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, i)[2]).Add(giatri2);
                            new BusTienDo().updateDataByMaCVAndMaDT(td);
                        }
                        _td.MACV = max;
                        _td.MADT = m_MaDT;
                        _td.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, max)[1]).Add(giatri2);
                        new BusTienDo().updateDataByMaCVAndMaDT(_td);
                    }
                    //neu bi lui ngay thi
                    else if (isTre == -1)
                    {
                        MessageBox.Show("Lỗi! Không thể thay đổi bằng giá trị mới vì sẽ ảnh hưởng đến ngày thi");
                    }
                    //neu tre
                    else if (isTre == 2)
                    {
                        MessageBox.Show("Lỗi! Không thể thay đổi bằng giá trị mới vì sẽ ảnh hưởng đến ngày phát chứng chỉ");
                    }
                    //tre nhung chua sao
                    else
                    {
                        DtoTienDo _td = new DtoTienDo();
                        _td.MACV = m_MaCV;
                        _td.MADT = m_MaDT;
                        _td.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[1]).Add(giatri1);
                        _td.NGAYKETTHUCQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, m_MaCV)[2]).Add(giatri2);
                        new BusTienDo().updateDataByMaCVAndMaDT(_td);
                        for (int i = m_MaCV + 1; i < max; i++)
                        {
                            DtoTienDo td = new DtoTienDo();
                            td.MACV = i;
                            td.MADT = m_MaDT;
                            td.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, i)[1]).Add(giatri2);
                            td.NGAYKETTHUCQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, i)[2]).Add(giatri2);
                            new BusTienDo().updateDataByMaCVAndMaDT(td);
                        }
                        _td.MACV = max;
                        _td.MADT = m_MaDT;
                        _td.NGAYBATDAUQUYDINH = DateTime.Parse(new BusTienDo().getDataByMaDTAndMaCV(m_MaDT, max)[1]).Add(giatri2);
                        new BusTienDo().updateDataByMaCVAndMaDT(_td);
                    }
                }
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