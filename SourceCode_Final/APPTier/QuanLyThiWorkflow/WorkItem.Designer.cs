using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace QuanLyThiWorkflow
{
	public partial class WorkItem
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.FinishWork = new System.Workflow.Activities.HandleExternalEventActivity();
            this.StartWork = new System.Workflow.Activities.HandleExternalEventActivity();
            this.RegisterEvent = new System.Workflow.Activities.CallExternalMethodActivity();
            // 
            // FinishWork
            // 
            correlationtoken1.Name = "WorkItemToken";
            correlationtoken1.OwnerActivityName = "WorkItem";
            this.FinishWork.CorrelationToken = correlationtoken1;
            this.FinishWork.EventName = "Finish";
            this.FinishWork.InterfaceType = typeof(QuanLyThiWorkflow.IDataExchangeServicWithinCorrelation);
            this.FinishWork.Name = "FinishWork";
            // 
            // StartWork
            // 
            this.StartWork.CorrelationToken = correlationtoken1;
            this.StartWork.EventName = "Start";
            this.StartWork.InterfaceType = typeof(QuanLyThiWorkflow.IDataExchangeServicWithinCorrelation);
            this.StartWork.Name = "StartWork";
            // 
            // RegisterEvent
            // 
            this.RegisterEvent.CorrelationToken = correlationtoken1;
            this.RegisterEvent.InterfaceType = typeof(QuanLyThiWorkflow.IDataExchangeServicWithinCorrelation);
            this.RegisterEvent.MethodName = "RegisterName";
            this.RegisterEvent.Name = "RegisterEvent";
            activitybind1.Name = "WorkItem";
            activitybind1.Path = "Name";
            workflowparameterbinding1.ParameterName = "workItemName";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.RegisterEvent.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // WorkItem
            // 
            this.Activities.Add(this.RegisterEvent);
            this.Activities.Add(this.StartWork);
            this.Activities.Add(this.FinishWork);
            this.Name = "WorkItem";
            this.CanModifyActivities = false;

		}

		#endregion

        private HandleExternalEventActivity StartWork;
        private HandleExternalEventActivity FinishWork;
        private CallExternalMethodActivity RegisterEvent;





    }
}
