using BUSLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.DTO;
using System.Collections.Generic;
using System;
namespace UnitTest
{
    
    
    /// <summary>
    ///This is a test class for BusCongViecTest and is intended
    ///to contain all BusCongViecTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BusCongViecTest
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
        ///A test for getDataById
        ///</summary>
        [TestMethod()]
        public void getDataByIdTest()
        {
            BusCongViec bus = new BusCongViec();
            DtoCongViec dto = bus.getDataById(1);
            Assert.IsNotNull(dto);
        }

        /// <summary>
        ///A test for getListDataBytenCV
        ///</summary>
        [TestMethod()]
        public void getListDataBytenCVTest()
        {
            BusCongViec target = new BusCongViec(); // TODO: Initialize to an appropriate value
            string tenCV = string.Empty; // TODO: Initialize to an appropriate value
            List<DtoCongViec> expected = null; // TODO: Initialize to an appropriate value
            List<DtoCongViec> actual;
            actual = target.getListDataBytenCV(tenCV);
            Assert.AreEqual(0, actual.Count, actual.Count);
        }

        /// <summary>
        ///A test for deleteData
        ///</summary>
        [TestMethod()]
        public void deleteDataTest()
        {
            /*
            BusCongViec bus = new BusCongViec();
            DtoCongViec dto = bus.getDataById(1);
            bool r = bus.deleteData(dto);
            Assert.IsTrue(r, r.ToString());
             */
        }

        /// <summary>
        ///A test for updateData
        ///</summary>
        [TestMethod()]
        public void updateDataTest()
        {
            BusCongViec bus = new BusCongViec();
            DtoCongViec dto = bus.getDataById(6);
            bool r = bus.updateData(dto);
            Assert.IsTrue(r, r.ToString());
        }

        /// <summary>
        ///A test for getNumOfLateCompletion
        ///</summary>
        [TestMethod()]
        public void getNumOfLateCompletionTest()
        {
            BusTienDo busTD = new BusTienDo();
            List<DtoTienDo> lst = busTD.getListDataBymaCV(1);
            foreach (DtoTienDo dtoTD in lst)
            {
                dtoTD.NGAYKETTHUCTHUCTE = dtoTD.NGAYKETTHUCTHUCTE.AddDays(100);
                bool r = busTD.updateData(dtoTD);
                if (!r)
                    Assert.Inconclusive("Khong ro ket qua");
            }
            BusCongViec bus = new BusCongViec();
            int num = bus.getNumOfLateCompletion(1);
            
            //restore:
            foreach (DtoTienDo dtoTD in lst)
            {
                dtoTD.NGAYKETTHUCTHUCTE = dtoTD.NGAYKETTHUCTHUCTE.AddDays(-100);
                bool r = busTD.updateData(dtoTD);
                if (!r)
                    Assert.Inconclusive("Khong ro ket qua");
            }
            Assert.AreNotEqual(0, num, num.ToString());
        }

        /// <summary>
        ///A test for getNumOfExecution
        ///</summary>
        [TestMethod()]
        public void getNumOfExecutionTest()
        {
            BusCongViec bus = new BusCongViec();
            int num = bus.getNumOfExecution(1);
            Assert.AreNotEqual(0, num, num.ToString());
        }

        /// <summary>
        ///A test for getNumOfEarlyCompletion
        ///</summary>
        [TestMethod()]
        public void getNumOfEarlyCompletionTest()
        {
            BusTienDo busTD = new BusTienDo();
            List<DtoTienDo> lst = busTD.getListDataBymaCV(1);
            foreach (DtoTienDo dtoTD in lst)
            {
                dtoTD.NGAYKETTHUCTHUCTE = dtoTD.NGAYKETTHUCQUYDINH.AddDays(-1);
                bool r = busTD.updateData(dtoTD);
              
            }
            BusCongViec bus = new BusCongViec();
            int num = bus.getNumOfEarlyCompletion(1);

            //restore:
            foreach (DtoTienDo dtoTD in lst)
            {
                bool r = busTD.updateData(dtoTD);
            }
            Assert.AreNotEqual(0, num, num.ToString());
        }


        /// <summary>
        ///A test for getListDataByMaNV
        ///</summary>
        [TestMethod()]
        public void getListDataByMaNVTest()
        {
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> lst = bus.getListDataByMaNV(1);
            Assert.IsNotNull(lst);
            Assert.AreNotEqual(0, lst.Count);
        }
    }
}
