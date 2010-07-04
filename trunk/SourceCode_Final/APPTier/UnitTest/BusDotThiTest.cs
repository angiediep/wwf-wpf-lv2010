using BUSLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using DataLayer.DAO;
namespace UnitTest
{
    
    
    /// <summary>
    ///This is a test class for BusDotThiTest and is intended
    ///to contain all BusDotThiTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BusDotThiTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for insertData
        ///</summary>
        [TestMethod()]
        public void insertDataTest()
        {
            BusDotThi bus = new BusDotThi();
            DtoDotThi dto = new DtoDotThi();
            dto.NGAYTHI = DateTime.Today;
            dto.SOLUONGTHISINH = 0;
            dto.TENDOTTHI = "Chứng chỉ mạng CIsco";
            dto.WORKFLOWINSTANCEID = "";
            int result = bus.insertData(dto);
            Assert.AreEqual(1, result, "ko thành công");
        }

        /// <summary>
        ///A test for updateDataBytenDotThi
        ///</summary>
        [TestMethod()]
        public void updateDataBytenDotThiTest()
        {
            BusDotThi bus = new BusDotThi();
            DtoDotThi dto = bus.getDataById(1);
            bool result = bus.updateDataBytenDotThi(dto, dto.TENDOTTHI);
            
            Assert.AreEqual(true,result,"fail");
        }

        /// <summary>
        ///A test for updateDataByngayThi
        ///</summary>
        [TestMethod()]
        public void updateDataByngayThiTest()
        {
            BusDotThi bus = new BusDotThi();
            DtoDotThi dto = bus.getDataById(1);
            
            bool result = bus.updateDataByngayThi(dto, dto.NGAYTHI);

            Assert.AreEqual(true, result, "fail");
        }

        /// <summary>
        ///A test for updateDataBymaDT
        ///</summary>

        /// <summary>
        ///A test for updateData
        ///</summary>
        [TestMethod()]
        public void updateDataTest()
        {
            BusDotThi bus = new BusDotThi();
            DtoDotThi dto = bus.getDataById(1);
            bool result = bus.updateData(dto);

          
            Assert.AreEqual(true, result, "fail");
        }


        /// <summary>
        ///A test for getListDataBytenDotThi
        ///</summary>
        [TestMethod()]
        public void getListDataBytenDotThiTest()
        {
            BusDotThi bus = new BusDotThi();
            DtoDotThi dto = new DtoDotThi();
            dto = bus.getDataById(1);
            List<DtoDotThi> lst = bus.getListDataBytenDotThi(dto.TENDOTTHI);
            if (lst == null || lst.Count == 0)
                Assert.Fail("Null");
            foreach (DtoDotThi dto1 in lst)
                if (!dto.TENDOTTHI.Equals(dto1.TENDOTTHI))
                    Assert.Fail("Ten khong trung khop");
            
        }

        /// <summary>
        ///A test for getListDataByngayThi
        ///</summary>
        [TestMethod()]
        public void getListDataByngayThiTest()
        {
            BusDotThi bus = new BusDotThi();
            DtoDotThi dto = new DtoDotThi();
            dto = bus.getDataById(1);
            List<DtoDotThi> lst = bus.getListDataByngayThi(dto.NGAYTHI);
            if (lst == null || lst.Count == 0)
                Assert.Fail("Null");
            foreach (DtoDotThi dto1 in lst)
                if (!dto.NGAYTHI.Equals(dto1.NGAYTHI))
                    Assert.Fail("Ten khong trung khop");
        }

        /// <summary>
        ///A test for getListContainCompletedLateWorkItem
        ///</summary>
        [TestMethod()]
        public void getListContainCompletedLateWorkItemTest()
        {
            BusDotThi bus = new BusDotThi();
            DtoDotThi dto = bus.getDataById(1);
            BusTienDo busTD = new BusTienDo();
            List<DtoTienDo> lst = busTD.getListDataBymaDT(dto.MADT);
            if (lst == null || lst.Count == 0)
                Assert.Inconclusive("LST Null");
            foreach (DtoTienDo dtoTD in lst)
            {
                dtoTD.NGAYKETTHUCTHUCTE =  dtoTD.NGAYKETTHUCTHUCTE.AddDays(10);
                busTD.updateData(dtoTD);
            }

            List<DtoDotThi> lst2 = bus.getListContainCompletedLateWorkItem();

            //restore:
            foreach (DtoTienDo dtoTD in lst)
            {
                dtoTD.NGAYKETTHUCTHUCTE = dtoTD.NGAYKETTHUCTHUCTE.AddDays(-10);
                busTD.updateData(dtoTD);
            }

            if (lst2 == null || lst2.Count == 0)
                Assert.Fail("Null");
        }

        /// <summary>
        ///A test for getListContainCompletedEarlyWorkItem
        ///</summary>
        [TestMethod()]
        public void getListContainCompletedEarlyWorkItemTest()
        {
            BusDotThi bus = new BusDotThi();
            DtoDotThi dto = bus.getDataById(1);
            BusTienDo busTD = new BusTienDo();
            List<DtoTienDo> lst = busTD.getListDataBymaDT(dto.MADT);
            if (lst == null || lst.Count == 0)
                Assert.Inconclusive("LST Null");
            foreach (DtoTienDo dtoTD in lst)
            {
                dtoTD.NGAYKETTHUCTHUCTE = dtoTD.NGAYKETTHUCTHUCTE.AddDays(-10);
                busTD.updateData(dtoTD);
            }

            List<DtoDotThi> lst2 = bus.getListContainCompletedEarlyWorkItem();

            //restore:
            foreach (DtoTienDo dtoTD in lst)
            {
                dtoTD.NGAYKETTHUCTHUCTE = dtoTD.NGAYKETTHUCTHUCTE.AddDays(10);
                busTD.updateData(dtoTD);
            }

            if (lst2 == null || lst2.Count == 0)
                Assert.Fail("Null");
        }

        /// <summary>
        ///A test for getDataListSortBy
        ///</summary>
        [TestMethod()]
        public void getDataListSortByTest()
        {
            BusDotThi target = new BusDotThi(); // TODO: Initialize to an appropriate value
            string col = string.Empty; // TODO: Initialize to an appropriate value
            bool flag = false; // TODO: Initialize to an appropriate value
            List<DtoDotThi> expected = null; // TODO: Initialize to an appropriate value
            List<DtoDotThi> actual;
            actual = target.getDataListSortBy(col, flag);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for getDataList
        ///</summary>
        [TestMethod()]
        public void getDataListTest()
        {
            BusDotThi target = new BusDotThi(); // TODO: Initialize to an appropriate value
            List<DtoDotThi> expected = null; // TODO: Initialize to an appropriate value
            List<DtoDotThi> actual;
            actual = target.getDataList();
            Assert.AreNotEqual(expected, actual);

        }

        /// <summary>
        ///A test for getDataByWorkflowInstance
        ///</summary>
        [TestMethod()]
        public void getDataByWorkflowInstanceTest()
        {
            BusDotThi bus = new BusDotThi();
            DtoDotThi dto = bus.getDataById(1);
            if (dto == null || dto.WORKFLOWINSTANCEID == null || dto.WORKFLOWINSTANCEID == "")
                Assert.Inconclusive("Check the testing codes again");
            Guid guID = new Guid(dto.WORKFLOWINSTANCEID);
            DtoDotThi dto2 = bus.getDataByWorkflowInstance(guID);
            Assert.AreEqual(dto2.MADT, dto.MADT);

        }

        /// <summary>
        ///A test for getDataById
        ///</summary>
        [TestMethod()]
        public void getDataByIdTest()
        {
            BusDotThi target = new BusDotThi(); // TODO: Initialize to an appropriate value
            int Id = 0; // TODO: Initialize to an appropriate value
            DtoDotThi expected = null; // TODO: Initialize to an appropriate value
            DtoDotThi actual;
            actual = target.getDataById(Id);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getCompletedLateList
        ///</summary>
        [TestMethod()]
        public void getCompletedLateListTest()
        {
            BusDotThi bus = new BusDotThi();
            DtoDotThi dto = bus.getDataById(1);
            BusTienDo busTD = new BusTienDo();
            List<DtoTienDo> lst = busTD.getListDataBymaDT(dto.MADT);
            if (lst == null || lst.Count == 0)
                Assert.Inconclusive("LST Null");
            foreach (DtoTienDo dtoTD in lst)
            {
                dtoTD.NGAYKETTHUCTHUCTE = dtoTD.NGAYKETTHUCTHUCTE.AddDays(10);
                busTD.updateData(dtoTD);
            }

            List<DtoDotThi> lst2 = bus.getCompletedLateList();

            //restore:
            foreach (DtoTienDo dtoTD in lst)
            {
                dtoTD.NGAYKETTHUCTHUCTE = dtoTD.NGAYKETTHUCTHUCTE.AddDays(-10);
                busTD.updateData(dtoTD);
            }

            if (lst2 == null || lst2.Count == 0)
                Assert.Fail("Null");
        }

        /// <summary>
        ///A test for getCompletedEarlyList
        ///</summary>
        [TestMethod()]
        public void getCompletedEarlyListTest()
        {
            return;
            //Set lại ngày kết thúc thực tế của công việc ký tên và đóng dấu trực tiếp trong csdl
            //trước khi chạy test này.
            BusDotThi bus = new BusDotThi();
            DtoDotThi dto = bus.getDataById(1);
            BusTienDo busTD = new BusTienDo();
            List<DtoTienDo> lst = busTD.getListDataBymaDT(dto.MADT);
            if (lst == null || lst.Count == 0)
                Assert.Inconclusive("LST Null");
            foreach (DtoTienDo dtoTD in lst)
            {
                dtoTD.NGAYKETTHUCTHUCTE = dtoTD.NGAYKETTHUCTHUCTE.AddDays(-10);
                busTD.updateData(dtoTD);
            }

            List<DtoDotThi> lst2 = bus.getCompletedEarlyList();

            //restore:
            foreach (DtoTienDo dtoTD in lst)
            {
                dtoTD.NGAYKETTHUCTHUCTE = dtoTD.NGAYKETTHUCTHUCTE.AddDays(10);
                busTD.updateData(dtoTD);
            }

            if (lst2 == null || lst2.Count == 0)
                Assert.Fail("Null");
        }



        /// <summary>
        ///A test for getListDataCompleted
        ///</summary>
        [TestMethod()]
        public void getListDataCompletedTest()
        {
            BusDotThi bus = new BusDotThi();
            List<DtoDotThi> lst = bus.getListDataCompleted();
            //Assert.IsNotNull(lst);
            Assert.AreNotEqual(0, lst.Count);
        }

        /// <summary>
        ///A test for getListDataUpComming
        ///</summary>
        [TestMethod()]
        public void getListDataUpCommingTest()
        {
            BusDotThi bus = new BusDotThi();
            List<DtoDotThi> lst = bus.getListDataUpComming();
           // Assert.IsNotNull(lst);
            Assert.AreNotEqual(0, lst.Count);
        }

        /// <summary>
        ///A test for getListDataOnGoing
        ///</summary>
        [TestMethod()]
        public void getListDataOnGoingTest()
        {
            BusDotThi bus = new BusDotThi();
            List<DtoDotThi> lst = bus.getListDataOnGoing();
            //Assert.IsNotNull(lst);
            Assert.AreNotEqual(0, lst.Count);
        }

        /// <summary>
        ///A test for getListDataBytenDotThi
        ///</summary>
        [TestMethod()]
        public void getListDataBytenDotThiTest1()
        {
            BusDotThi target = new BusDotThi(); // TODO: Initialize to an appropriate value
            string tenDotThi = string.Empty; // TODO: Initialize to an appropriate value
            List<DtoDotThi> expected = null; // TODO: Initialize to an appropriate value
            List<DtoDotThi> actual;
            actual = target.getListDataBytenDotThi(tenDotThi);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getListDataByMaNV
        ///</summary>
        [TestMethod()]
        public void getListDataByMaNVTest()
        {
            BusDotThi bus = new BusDotThi();
            List<DtoDotThi> lst = bus.getListDataByMaNV(1);
            Assert.IsNotNull(lst);
            Assert.AreNotEqual(0, lst.Count);

        }
    }
}
