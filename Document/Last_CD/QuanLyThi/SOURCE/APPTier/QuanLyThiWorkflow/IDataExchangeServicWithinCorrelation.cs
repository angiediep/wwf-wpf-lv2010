using System;
using System.Workflow.Activities;

namespace QuanLyThiWorkflow
{
    /// <summary>
    /// Khai báo các phương thức và sự kiện dùng cho việc liên lạc
    /// giữa ứng dụng và workflow.
    /// </summary>
    [ExternalDataExchange]
    [CorrelationParameter("workItemName")]
	public interface IDataExchangeServicWithinCorrelation
	{
        /// <summary>
        /// Phương thức được gọi từ workflow. Các workitem sẽ gọi phương thức
        /// này để khai báo tên. Dựa vào cái tên này mà ứng dụng có thể chuyển
        /// sự kiện đến các workitem mong muốn.
        /// </summary>
        /// <param name="workItemName"></param>
        [CorrelationInitializer]
        void RegisterName(string workItemName);
        /// <summary>
        /// Event bắt đầu một công việc
        /// </summary>
        [CorrelationAlias("workItemName", "e.WorkItemName")]
        event EventHandler<DataEventArgs> Start;

        /// <summary>
        /// Event kết thúc một công việc
        /// </summary>
        [CorrelationAlias("workItemName", "e.WorkItemName")]
        event EventHandler<DataEventArgs> Finish;
	}
}
