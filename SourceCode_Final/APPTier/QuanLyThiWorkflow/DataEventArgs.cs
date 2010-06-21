using System;
using System.Workflow.Activities;

namespace QuanLyThiWorkflow
{
    [Serializable]
	public class DataEventArgs : ExternalDataEventArgs
	{
        public string WorkItemName { get; set; }
        public DataEventArgs(Guid instanceID, string workItemName)
            : base(instanceID)
        {
            this.WorkItemName = workItemName;
        }
	}
}
