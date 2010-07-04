using BUSLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.DTO;
using System.Collections.Generic;

namespace UnitTest
{
    
    
    /// <summary>
    ///This is a test class for BusGhiChuTest and is intended
    ///to contain all BusGhiChuTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BusGhiChuTest
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
        ///A test for getDataByMaTD
        ///</summary>
        [TestMethod()]
        public void getDataByMaTDTest()
        {
            BusGhiChu bus = new BusGhiChu();
            DtoGhiChu dto = bus.getDataByMaTD(1);
            Assert.IsNotNull(dto);
        }

        /// <summary>
        ///A test for getListDataByMaCVMaDT
        ///</summary>
        [TestMethod()]
        public void getListDataByMaCVMaDTTest()
        {
            BusGhiChu bus = new BusGhiChu();
            DtoGhiChu dto = bus.getListDataByMaCVMaDT(1,1);
            Assert.IsNotNull(dto);
        }
    }
}
