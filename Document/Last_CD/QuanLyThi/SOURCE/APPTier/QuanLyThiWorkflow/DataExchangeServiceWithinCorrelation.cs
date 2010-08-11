using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyThiWorkflow
{
	public class DataExchangeServiceWithinCorrelation : IDataExchangeServicWithinCorrelation
	{

        #region IDataExchangeServicWithinCorrelation Members

        public void RegisterName(string workItemName)
        {
            //Phương thức này chỉ dùng cho việc đăng ký tên của workItem với
            //ứng dụng. Việc đăng ký được làm tự động bởi Corelation 
            //Không cần làm gì thêm trong phương thức này nữa.
        }

        public event EventHandler<DataEventArgs> Start;

        public event EventHandler<DataEventArgs> Finish;

        #endregion
        #region Public member (Not at IReceivedEvent )
        /// <summary>
        /// This method is called by the host application to raise the 
        /// Start event that is handled by the workflow instance.
        /// </summary>
        /// <param name="args"></param>
        public void OnStart(DataEventArgs args)
        {
            if (Start != null)
            {
                //do not pass 'this' (must pass null) as the sender otherwise the event cannot
                //be delivered. Every part of the event must be serializable,
                //including the sender.
                //
                // If you pass 'this' as the sender, WF will attempt to serialize
                //and pass a copy of the local service object (EventService) to the workflow.
                //In the best case, if your service class does happen to be 
                //serializable, a serialized copy will be passed to the workflow.
                //That is probably not your intent. In the worst case when the 
                //service class is not serializable, an EventDeliveryFailedException
                //will be thrown, and the event will not be delivered. It is for
                //this reason that the example code simply passes null as the 
                //sender. You are allowed to pass anything you want as the sender,
                //as long as it is serializable.
                Start(null, args);
            }
        }
        /// <summary>
        /// This method is called by the host application to raise the 
        /// Finish event that is handled by the workflow instance. 
        /// </summary>
        /// <param name="args"></param>
        public void OnFinish(DataEventArgs args)
        {
            if (Finish != null)
            {
                //do not pass 'this' (must pass null) as the sender otherwise the event cannot
                //be delivered. Every part of the event must be serializable,
                //including the sender.
                //
                // If you pass 'this' as the sender, WF will attempt to serialize
                //and pass a copy of the local service object (EventService) to the workflow.
                //In the best case, if your service class does happen to be 
                //serializable, a serialized copy will be passed to the workflow.
                //That is probably not your intent. In the worst case when the 
                //service class is not serializable, an EventDeliveryFailedException
                //will be thrown, and the event will not be delivered. It is for
                //this reason that the example code simply passes null as the 
                //sender. You are allowed to pass anything you want as the sender,
                //as long as it is serializable.
                Finish(null, args);
            }
        }
        #endregion
    }
}
