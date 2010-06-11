
using System;
using System.Collections.Generic;
using System.Workflow.Activities;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Tracking;
using DataLayer.DAO;
using DataLayer.DTO;
using QuanLyThiWorkflow;

namespace BUSLayer
{
public class BusDotThi
{

	public BusDotThi()
	{
	}
	#region "ExportFile" 
	public DtoDotThi getDataById(int Id)
	{
		DtoDotThi data = null;
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			data = dDOTTHI.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
    public DtoDotThi getDataByWorkflowInstance(Guid instanceID)
    {
        try
        {
            DtoDotThi result = null;
            DaoDotThi dao = new DaoDotThi();
            result = dao.getDataByWorkflowInstance(instanceID.ToString());
            return result;
        }
        catch
        {
            return null;
        }
    }
	public List<DtoDotThi> getListDataBytenDotThi(string tenDotThi)
	{
		List<DtoDotThi> lst = null;
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			lst = dDOTTHI.getListDataBytenDotThi(tenDotThi);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoDotThi> getListDataByngayThi(DateTime ngayThi)
	{
		List<DtoDotThi> lst = null;
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			lst = dDOTTHI.getListDataByngayThi(ngayThi);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// Lấy danh sách đợt thi bị trễ hạn. (Ngày phát chứng chỉ muộn hơn so với quy định)
    /// </summary>
    /// <returns>danh sách đợt thi trễ hạn. Trường hợp có lỗi xảy ra, trả về null</returns>
    public List<DtoDotThi> getListDataDelayed()
    {
        try
        {
            DaoDotThi dao = new DaoDotThi();
            List<DtoDotThi> lst = dao.getListDataDelayed();
            return lst;
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// Lấy danh sách đợt thi có công việc bị trễ hạn.
    /// </summary>
    /// <returns>Danh sách đợt thi.
    /// Trường hợp lỗi trả về null</returns>
    public List<DtoDotThi> getListDataWithinDelayedWorkItem()
    {
        try
        {
            DaoDotThi dao = new DaoDotThi();
            List<DtoDotThi> lst = dao.getListDataWithinDelayedWorkItem();
            return lst;
        }
        catch
        {
            return null;
        }
    }
	public List<DtoDotThi> getDataList()
	{
		List<DtoDotThi> lst = null;
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			lst = dDOTTHI.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoDotThi> getDataListSortBy(string col, bool flag)
	{
		List<DtoDotThi> lst = null;
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			lst = dDOTTHI.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}


    /// <summary>
    /// Thêm một đợt thi mới.
    /// </summary>
    /// <param name="data">Thông tin đợt thi cần tạo</param>
    /// <returns>
    /// 1: Thêm thành công. Không phát sinh lỗi.
    /// 0: Thêm không thành công. Lỗi không xác định.
    /// -1:THêm không thành công. Lỗi Ngày thi nhỏ hơn ngày hiện hành.
    /// -2: Thêm thành công nhưng có một số phân công đã hết hiệu lực. nhắc người quản lý phân công lại.
    /// </returns>
	public int insertData(DtoDotThi data)
	{

        DaoDotThi dao = new DaoDotThi();
        int result = 0;
        try
        {
            result = dao.insertData(data);

            WorkflowRuntime runtime = new WorkflowRuntime();
            WorkflowInstance instance;
            instance = runtime.CreateWorkflow(typeof(QuanLyThiWorkflow.QuyTrinhThi));

            ExternalDataExchangeService DataExchangeService = new ExternalDataExchangeService();
            runtime.AddService(DataExchangeService);
            DataExchangeServiceWithinCorrelation localService = new DataExchangeServiceWithinCorrelation();
            DataExchangeService.AddService(localService);
            DataConnector connector = new DataConnector();
            SqlTrackingService trackingService = new SqlTrackingService(connector.getTrackingConnectionString());
            runtime.AddService(trackingService);

            instance.Start();
            instance.Unload();
            if (result > 0)
            {
                data.WORKFLOWINSTANCEID = instance.InstanceId.ToString();
                dao.updateDataBymaDT(data, result);
            }
        }
        catch
        {
            if (result > 0)
                dao.deleteData(dao.getDataById(result));
            return 0;
        }
        if (result <= 0)
            return result;
        return 1;
	}
	public bool deleteData(DtoDotThi data)
	{
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			dDOTTHI.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBytenDotThi(string tenDotThi)
	{
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			dDOTTHI.deleteDataBytenDotThi(tenDotThi);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByngayThi(DateTime ngayThi)
	{
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			dDOTTHI.deleteDataByngayThi(ngayThi);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBysoLuongThiSinh(int soLuongThiSinh)
	{
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			dDOTTHI.deleteDataBysoLuongThiSinh(soLuongThiSinh);
		}
		catch
		{
			return false;
		}
		return true;
	}
    public bool deleteDataByworkflowInstanceID(string workflowInstanceID)
    {
        try
        {
            DaoDotThi dDOTTHI = new DaoDotThi();
            dDOTTHI.deleteDataByworkflowInstanceID(workflowInstanceID);
        }
        catch
        {
            return false;
        }
        return true;
    }

	public bool updateData(DtoDotThi data)
	{
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			dDOTTHI.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaDT(DtoDotThi data,int maDT)
	{
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			dDOTTHI.updateDataBymaDT(data,maDT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytenDotThi(DtoDotThi data,string tenDotThi)
	{
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			dDOTTHI.updateDataBytenDotThi(data,tenDotThi);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayThi(DtoDotThi data,DateTime ngayThi)
	{
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			dDOTTHI.updateDataByngayThi(data,ngayThi);
		}
		catch
		{
			return false;
		}
		return true;
	}
	#endregion
    
    
}

}
