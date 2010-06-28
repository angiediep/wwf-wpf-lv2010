
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using DataLayer.DAO;
using DataLayer.DTO;
namespace BUSLayer
{
public class BusNhanVienThuaHanh
{

	public BusNhanVienThuaHanh()
	{
	}
	#region "ExportFile" 

    /// <summary>
    /// This method provides function 'login' for NhanVienThuaHanh.
    /// </summary>
    /// <param name="strUsername">the login name.</param>
    /// <param name="strPassword">the password</param>
    /// <returns>true:  login success.
    ///         false: login fail.</returns>
    public bool login(String strUsername, String strPassword)
    {
        if (null == strUsername || null == strPassword)
            return false;
        if (0 == strUsername.Trim().Length || 0 == strPassword.Trim().Length)
            return false;
        //remove the SQL Injection.
        strUsername.Replace('\'',' ');
        strPassword.Replace('\'', ' ');

        DaoNhanVienThuaHanh daoNhanVienThuaHanh = new DaoNhanVienThuaHanh();
        return daoNhanVienThuaHanh.login(strUsername, strPassword);
    }
	public DtoNhanVienThuaHanh getDataById(int Id)
	{
		DtoNhanVienThuaHanh data = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			data = dNhanVienThuaHanh.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<DtoNhanVienThuaHanh> getListDataBytenDangNhap(string tenDangNhap)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataBytenDangNhap(tenDangNhap);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getListDataBymatKhau(string matKhau)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataBymatKhau(matKhau);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getListDataBySALT(int SALT)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataBySALT(SALT);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getListDataByemail(string email)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataByemail(email);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getListDataBytenNV(string tenNV)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataBytenNV(tenNV);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getDataList()
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getDataListSortBy(string col, bool flag)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// lấy danh sách nhân viên đã hoàn thành công việc 
    /// </summary>
    /// <remarks>lấy danh sách nhân viên đã hoàn thành công việc trong tất cả các đợt thi nào.</remarks>
    /// <param name="completingStatus"> Tình trạng hoàn thành công việc.
    /// 1: chỉ lấy những nhân viên hoàn thành công việc trễ hạn
    /// 0: chỉ lấy những nhân viên hoàn thành công việc đúng hạn
    /// -1: chỉ lấy những nhân viên hoàn thành công việc sớm hạn
    /// </param>
    /// <returns></returns>
    public List<DtoNhanVienThuaHanh> getListDataCompletedWork(int completingStatus)
    {
        if (completingStatus > 1 || completingStatus < -1)
            throw new Exception("tham số completingStatus chỉ có thể mang 3 giá trị 0,1,-1.");
        try
        {
            DaoNhanVienThuaHanh dao = new DaoNhanVienThuaHanh();
            return dao.getListDataCompletedWork(0, completingStatus, DateTime.MinValue, DateTime.MinValue);
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// lấy danh sách nhân viên đã hoàn thành công việc 
    /// </summary>
    /// <remarks>lấy danh sách nhân viên đã hoàn thành công việc trong một đợt thi cụ thể.</remarks>
    /// <param name="maDT">mã đợt thi.</param>
    /// <param name="completingStatus">Tình trạng hoàn thành công việc.
    /// 1: chỉ lấy những nhân viên hoàn thành công việc trễ hạn
    /// 0: chỉ lấy những nhân viên hoàn thành công việc đúng hạn
    /// -1: chỉ lấy những nhân viên hoàn thành công việc sớm hạn
    /// </param>
    /// <returns></returns>
    public List<DtoNhanVienThuaHanh> getListDataCompletedWork(int maDT, int completingStatus)
    {
        if (completingStatus > 1 || completingStatus < -1)
            throw new Exception("tham số completingStatus chỉ có thể mang 3 giá trị 0,1,-1.");
        if (maDT <= 0)
            throw new Exception("tham số maDT không hợp lệ");

        try
        {
            DaoNhanVienThuaHanh dao = new DaoNhanVienThuaHanh();
            return dao.getListDataCompletedWork(maDT, completingStatus, DateTime.MinValue, DateTime.MinValue);
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// Lấy danh sách nhân viên đã hoàn thành công việc.
    /// </summary>
    /// <remarks>Lấy danh sách nhân viên đã hoàn thành công việc của bất kỳ đợt thi nào
    /// trong một khoảng thời gian cụ thể.</remarks>
    /// <param name="from">Ngày đầu tiên của khoảng thời gian cần xét.
    /// Hai tham số from và to phải đồng thời null hoặc not null</param>
    /// <param name="to">Ngày cuối cùng của khoảng thời gian cần xét
    /// Hai tham số from và to phải đồng thời null hoặc not null</param>
    /// <param name="completingStatus">Tình trạng hoàn thành công việc.
    /// 1: chỉ lấy những nhân viên hoàn thành công việc trễ hạn
    /// 0: chỉ lấy những nhân viên hoàn thành công việc đúng hạn
    /// -1: chỉ lấy những nhân viên hoàn thành công việc sớm hạn
    /// </param>
    /// <returns></returns>
    public List<DtoNhanVienThuaHanh> getListDataCompletedWork(DateTime from, DateTime to, int completingStatus)
    {
        if (completingStatus > 1 || completingStatus < -1)
            throw new Exception("tham số completingStatus chỉ có thể mang 3 giá trị 0,1,-1.");
        if ((from == null && to != null) || (from != null && to == null))
            throw new Exception("Hai tham số from và to phải đồng thời null hoặc not null");
        try
        {
            DaoNhanVienThuaHanh dao = new DaoNhanVienThuaHanh();
            return dao.getListDataCompletedWork(0, completingStatus, from, to);
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// Lấy danh sách nhân viên đã hoàn thành công việc.
    /// </summary>
    /// <remarks>Lấy danh sách nhân viên đã hoàn thành công việc thuộc một đợt thi cụ thể
    /// trong một khoảng thời gian cụ thể.</remarks>
    /// <param name="maDT">mã đợt thi đang xét.</param>
    /// <param name="from">Ngày đầu tiên của khoảng thời gian cần xét.
    /// Hai tham số from và to phải đồng thời null hoặc not null</param>
    /// <param name="to">Ngày cuối cùng của khoảng thời gian cần xét
    /// Hai tham số from và to phải đồng thời null hoặc not null</param>
    /// <param name="completingStatus">Tình trạng hoàn thành công việc.
    /// 1: chỉ lấy những nhân viên hoàn thành công việc trễ hạn
    /// 0: chỉ lấy những nhân viên hoàn thành công việc đúng hạn
    /// -1: chỉ lấy những nhân viên hoàn thành công việc sớm hạn
    /// </param>
    /// <returns></returns>
    public List<DtoNhanVienThuaHanh> getListDataCompletedWork(int maDT, DateTime from, DateTime to, int completingStatus)
    {
        if (maDT <= 0)
            throw new Exception("tham số maDT không hợp lệ");

        if (completingStatus > 1 || completingStatus < -1)
            throw new Exception("tham số completingStatus chỉ có thể mang 3 giá trị 0,1,-1.");
        if ((from == null && to != null) || (from != null && to == null))
            throw new Exception("Hai tham số from và to phải đồng thời null hoặc not null");
        try
        {
            DaoNhanVienThuaHanh dao = new DaoNhanVienThuaHanh();
            return dao.getListDataCompletedWork(maDT, completingStatus, from, to);
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// Lấy danh sách nhân viên đã bắt đầu công việc
    /// </summary>
    /// <remarks>Lấy danh sách nhân viên đã bắt đầu công việc trong tất cả các đợt thi.</remarks>
    /// <param name="startingStatus">Tình trạng bắt đầu công việc.
    /// 1: chỉ lấy những nhân viên bắt đầu công việc trễ hạn
    /// 0: chỉ lấy những nhân viên bắt đầu công việc đúng hạn
    /// -1: chỉ lấy những nhân viên bắt đầu công việc sớm hạn
    /// </param>
    /// <returns></returns>
    public List<DtoNhanVienThuaHanh> getListDataStartedWork(int startingStatus)
    {
        if (startingStatus > 1 || startingStatus < -1)
            throw new Exception("tham số completingStatus chỉ có thể mang 3 giá trị 0,1,-1.");

        try
        {
            DaoNhanVienThuaHanh dao = new DaoNhanVienThuaHanh();
            return dao.getListDataStartedWork(0, startingStatus, DateTime.MinValue, DateTime.MinValue);
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// Lấy danh sách nhân viên đã bắt đầu công việc
    /// </summary>
    /// <remarks>Lấy danh sách nhân viên đã bắt đầu công việc trong một đợt thi cụ thể</remarks>
    ///<param name="maDT">Mã đợt thi đang xét.</param>
    /// <param name="startingStatus">Tình trạng bắt đầu công việc.
    /// 1: chỉ lấy những nhân viên bắt đầu công việc trễ hạn
    /// 0: chỉ lấy những nhân viên bắt đầu công việc đúng hạn
    /// -1: chỉ lấy những nhân viên bắt đầu công việc sớm hạn
    /// </param>
    /// <returns></returns>
    public List<DtoNhanVienThuaHanh> getListDataStartedWork(int maDT, int startingStatus)
    {
        if (startingStatus > 1 || startingStatus < -1)
            throw new Exception("tham số completingStatus chỉ có thể mang 3 giá trị 0,1,-1.");
        if (maDT <= 0)
            throw new Exception("tham số maDT không hợp lệ");

        try
        {
            DaoNhanVienThuaHanh dao = new DaoNhanVienThuaHanh();
            return dao.getListDataStartedWork(maDT, startingStatus, DateTime.MinValue, DateTime.MinValue);
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// Lấy danh sách nhân viên đã bắt đầu công việc
    /// </summary>
    /// <remarks>Lấy danh sách nhân viên đã bắt đầu công việc của bất kỳ đợt thi nào
    /// trong một khoảng thời gian xác định</remarks>
    /// <param name="from">Ngày đầu tiên của khoảng thời gian cần xét.
    /// Hai tham số from và to phải đồng thời null hoặc not null</param>
    /// <param name="to">Ngày cuối cùng của khoảng thời gian cần xét
    /// <param name="startingStatus">Tình trạng bắt đầu công việc.
    /// 1: chỉ lấy những nhân viên bắt đầu công việc trễ hạn
    /// 0: chỉ lấy những nhân viên bắt đầu công việc đúng hạn
    /// -1: chỉ lấy những nhân viên bắt đầu công việc sớm hạn
    /// </param>
    /// <returns></returns>
    public List<DtoNhanVienThuaHanh> getListDataStartedWork(DateTime from, DateTime to, int startingStatus)
    {
        if (startingStatus > 1 || startingStatus < -1)
            throw new Exception("tham số completingStatus chỉ có thể mang 3 giá trị 0,1,-1.");
        if ((from == null && to != null) || (from != null && to == null))
            throw new Exception("Hai tham số from và to phải đồng thời null hoặc not null");

        try
        {
            DaoNhanVienThuaHanh dao = new DaoNhanVienThuaHanh();
            return dao.getListDataStartedWork(0, startingStatus, from, to);
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// Lấy danh sách nhân viên đã bắt đầu công việc
    /// </summary>
    /// <remarks>Lấy danh sách nhân viên đã bắt đầu công việc thuộc một đợt thi cụ thể
    /// trong một khoảng thời gian xác định</remarks>
    /// <param name="maDT">mã đợt thi</param>
    /// <param name="from">Ngày đầu tiên của khoảng thời gian cần xét.
    /// Hai tham số from và to phải đồng thời null hoặc not null</param>
    /// <param name="to">Ngày cuối cùng của khoảng thời gian cần xét
    /// <param name="startingStatus">Tình trạng bắt đầu công việc.
    /// 1: chỉ lấy những nhân viên bắt đầu công việc trễ hạn
    /// 0: chỉ lấy những nhân viên bắt đầu công việc đúng hạn
    /// -1: chỉ lấy những nhân viên bắt đầu công việc sớm hạn
    /// </param>
    /// <returns></returns>
    public List<DtoNhanVienThuaHanh> getListDataStartedWork(int maDT, DateTime from, DateTime to, int startingStatus)
    {
        if (maDT <= 0)
            throw new Exception("tham số maDT không hợp lệ");

        if (startingStatus > 1 || startingStatus < -1)
            throw new Exception("tham số completingStatus chỉ có thể mang 3 giá trị 0,1,-1.");
        if ((from == null && to != null) || (from != null && to == null))
            throw new Exception("Hai tham số from và to phải đồng thời null hoặc not null");

        try
        {
            DaoNhanVienThuaHanh dao = new DaoNhanVienThuaHanh();
            return dao.getListDataStartedWork(maDT, startingStatus, from, to);
        }
        catch
        {
            return null;
        }
    }
    ///<summary>
    /// đếm số lần mà một nhân viên bắt đầu công việc trong một đợt thi cụ thể với tình
    /// trạng bắt đầu công việc cho trước.
    /// </summary>
    /// <param name="manv">Mã nhân viên bắt đầu công việc.
    /// 0: đếm các công việc được thực hiện bởi nhân viên bất kỳ.
    /// 1: chỉ đếm các công việc do một nhân viên cụ thể thực hiện
    /// </param>
    /// <param name="madt">
    /// mã đợt thi.
    /// 0: xét toàn bộ đợt thi.
    /// >0: xét một đợt thi cụ thể.
    /// </param>
    /// <param name="macv">
    /// mã công việc cần đếm số lần hoàn thành.
    /// </param>
    /// <param name="completingStatus">Tình trạng bắt đầu công việc.
    /// 1: trễ hạn
    /// 0: đúng hạn
    /// -1: sớm hạn</param>
    /// <param name="fromDate">Ngày bắt đầu giới hạn.
    /// = DateTime.MinValue: Xét các công việc được bắt đầu vào bất kỳ thời gian nào.
    /// != DateTime.MinValue: chỉ xét các đợt thi bắt đầu sau ngày này
    /// Chú ý: fromDate, toDate phải đồng thời null hoặc khác null.</param>
    /// <param name="toDate">Ngày kết thúc giới hạn.
    /// = DateTime.MinValue: Xét các công việc được bắt đầu vào bất kỳ thời gian nào.
    /// != DateTime.MinValue: chỉ xét các đợt thi bắt đầu trước ngày này.
    /// Chú ý: fromDate, toDate phải đồng thời null hoặc khác null.</param>
    /// <returns></returns>
    public int getNumOfWorkCompletion(int manv, int madt, int macv, int completingStatus, DateTime from, DateTime to)
    {
        try
        {
            DaoNhanVienThuaHanh dao = new DaoNhanVienThuaHanh();
            return dao.getNumOfWorkCompletion(manv, madt, macv, completingStatus, from, to);
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// đếm số lần mà một nhân viên bắt đầu công việc trong một đợt thi cụ thể với tình
    /// trạng bắt đầu công việc cho trước.
    /// </summary>
    /// <param name="manv">Mã nhân viên bắt đầu công việc.
    /// 0: đếm các công việc do bất kỳ nhân viên nào thực hiện
    /// 1: chỉ đếm các công việc do một nhân viên cụ thể thực hiện
    /// </param>
    /// <param name="madt">
    /// mã đợt thi.
    /// 0: xét toàn bộ đợt thi.
    /// >0: xét một đợt thi cụ thể.
    /// </param>
    /// <param name="macv">
    /// mã công việc cần đếm số lần hoàn thành.
    /// </param>
    /// <param name="completingStatus">Tình trạng bắt đầu công việc.
    /// 1: trễ hạn
    /// 0: đúng hạn
    /// -1: sớm hạn</param>
    /// <param name="fromDate">Ngày bắt đầu giới hạn.
    /// = DateTime.MinValue: Xét các công việc được bắt đầu vào bất kỳ thời gian nào.
    /// != DateTime.MinValue: chỉ xét các đợt thi bắt đầu sau ngày này
    /// Chú ý: fromDate, toDate phải đồng thời null hoặc khác null.</param>
    /// <param name="toDate">Ngày kết thúc giới hạn.
    /// = DateTime.MinValue: Xét các công việc được bắt đầu vào bất kỳ thời gian nào.
    /// != DateTime.MinValue: chỉ xét các đợt thi bắt đầu trước ngày này.
    /// Chú ý: fromDate, toDate phải đồng thời null hoặc khác null.</param>

    /// <returns></returns>
    public int getNumOfWorkStarting(int manv, int madt, int macv, int startingStatus, DateTime fromDate, DateTime toDate)
    {
        try
        {
            DaoNhanVienThuaHanh dao = new DaoNhanVienThuaHanh();
            return dao.getNumOfWorkStarting(manv, madt, macv, startingStatus, fromDate, toDate);
        }
        catch
        {
            return 0;
        }
    }

    /// <summary>
    /// Thêm mới một nhân viên thừa hành.
    /// </summary>
    /// <param name="data">Đối tượng chứa thông tin nhân viên cần đăng ký</param>
    /// <returns>Id > 0: thêm thành công.
    ///         ID == -1: tên đăng nhập đã tồn tại trong hệ thống.
    ///         ID == -2: Địa chỉ email đã tồn tại trong hệ thống.
    ///         ID == 0: Thêm không thành công, lỗi không xác định.</returns>
	public int insertData(DtoNhanVienThuaHanh data)
	{
        //Kiểm tra sự tồn tại của tên đăng nhập trong hệ thống:
        BusQuanLy busQuanLy = new BusQuanLy();
        List<DtoNhanVienThuaHanh> users = getListDataBytenDangNhap(data.TENDANGNHAP);
        List<DtoQuanLy> quanlys = busQuanLy.getDataList();
        if (users.Count != 0 || quanlys.Count != 0)
        {
            return -1;
        }
        //Kiểm tra sự tồn tại của địa chỉ email trong hệ thống:
        users = getListDataByemail(data.EMAIL);
        quanlys = busQuanLy.getDataList();
        if (users.Count != 0 || quanlys.Count != 0)
        {
            return -2;
        }

		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			return dNhanVienThuaHanh.insertData(data);
		}
		catch
		{
			return 0;
		}
	}
	public bool deleteData(DtoNhanVienThuaHanh data)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBytenDangNhap(string tenDangNhap)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBytenDangNhap(tenDangNhap);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBymatKhau(string matKhau)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBymatKhau(matKhau);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBySALT(int SALT)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBySALT(SALT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByemail(string email)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataByemail(email);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBytenNV(string tenNV)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBytenNV(tenNV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBydienThoai(string dienThoai)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBydienThoai(dienThoai);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateData(DtoNhanVienThuaHanh data)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaNV(DtoNhanVienThuaHanh data,int maNV)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBymaNV(data,maNV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytenDangNhap(DtoNhanVienThuaHanh data,string tenDangNhap)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBytenDangNhap(data,tenDangNhap);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymatKhau(DtoNhanVienThuaHanh data,string matKhau)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBymatKhau(data,matKhau);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBySALT(DtoNhanVienThuaHanh data,int SALT)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBySALT(data,SALT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByemail(DtoNhanVienThuaHanh data,string email)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataByemail(data,email);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytenNV(DtoNhanVienThuaHanh data,string tenNV)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBytenNV(data,tenNV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	#endregion

    public string getTenNVByMaNV(int p)
    {
        return new DaoTienDo().getTenNVByMaNV(p);
    }

    public List<string> getNVTreHan()
    {
        return new DaoNhanVienThuaHanh().getNVTreHan();
    }

    public List<string> getNVTreHan(string tenDT)
    {
        return new DaoNhanVienThuaHanh().getNVTreHan(tenDT);
    }

    public int getMaNVByTenNV(string tenNV)
    {
        return new DaoNhanVienThuaHanh().getMaNVByTenNV(tenNV);
    }
}

}
