using System.Collections.Generic;
using BUSLayer;
using DataLayer.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    
    
    /// <summary>
    ///This is a test class for BusTienDoTest and is intended
    ///to contain all BusTienDoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BusTienDoTest
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
///A test for getListDataBymaDT
///</summary>
[TestMethod()]
public void getListDataBymaDTTest()
{
    BusTienDo target = new BusTienDo(); // TODO: Initialize to an appropriate value
    int maDT = 1; // TODO: Initialize to an appropriate value
    List<DtoTienDo> expected = null; // TODO: Initialize to an appropriate value
    List<DtoTienDo> actual;
    actual = target.getListDataBymaDT(maDT);
    Assert.AreNotEqual(expected, actual,"null");
    
}

/// <summary>
///A test for getListDataByMaNV
///</summary>
[TestMethod()]
public void getListDataByMaNVTest()
{
    BusTienDo bus = new BusTienDo();
    List<DtoTienDo> lst = bus.getListDataByMaNV(1, DateTime.Today.AddDays(-1000), DateTime.Today);
    Assert.IsNotNull(lst);
    Assert.AreNotEqual(0, lst.Count);
}

/// <summary>
///A test for getListDataCompleted
///</summary>
[TestMethod()]
public void getListDataCompletedTest()
{
    BusTienDo bus = new BusTienDo();
    List<DtoTienDo> lst = bus.getListDataCompleted();
    Assert.IsNotNull(lst);
    Assert.AreNotEqual(0, lst.Count);
}

/// <summary>
///A test for getListDataCompletedByMaDT
///</summary>
[TestMethod()]
public void getListDataCompletedByMaDTTest()
{
    BusTienDo bus = new BusTienDo();
    List<DtoTienDo> lst = bus.getListDataCompletedByMaDT(1);
    Assert.IsNotNull(lst);
    Assert.AreNotEqual(0, lst.Count);
}

/// <summary>
///A test for getListDataOnGoing
///</summary>
[TestMethod()]
public void getListDataOnGoingTest()
{
    BusTienDo bus = new BusTienDo();
    List<DtoTienDo> lst = bus.getListDataOnGoing();
    Assert.IsNotNull(lst);
    Assert.AreNotEqual(0, lst.Count);
}

/// <summary>
///A test for getListDataOnGoingByMaDT
///</summary>
[TestMethod()]
public void getListDataOnGoingByMaDTTest()
{
    BusTienDo bus = new BusTienDo();
    List<DtoTienDo> lst = bus.getListDataOnGoingByMaDT(1);
    Assert.IsNotNull(lst);
    Assert.AreEqual(0, lst.Count);
}

/// <summary>
///A test for getListDataUpcoming
///</summary>
[TestMethod()]
public void getListDataUpcomingTest()
{
    BusTienDo bus = new BusTienDo();
    List<DtoTienDo> lst = bus.getListDataUpcoming();
    Assert.IsNotNull(lst);
    Assert.AreNotEqual(0, lst.Count);
}

/// <summary>
///A test for getListDataUpcomingByMaDT
///</summary>
[TestMethod()]
public void getListDataUpcomingByMaDTTest()
{
    BusTienDo bus = new BusTienDo();
    List<DtoTienDo> lst = bus.getListDataUpcomingByMaDT(48);
    Assert.IsNotNull(lst);
    Assert.AreNotEqual(0, lst.Count);
}

/// <summary>
///A test for getListDataCompletedByMaNV
///</summary>
[TestMethod()]
public void getListDataCompletedByMaNVTest()
{
    BusTienDo bus = new BusTienDo();
    List<DtoTienDo> lst = bus.getListDataByMaNV(1);
    Assert.IsNotNull(lst);
    Assert.AreNotEqual(0, lst.Count);
}

/// <summary>
///A test for getListDataOnGoingByMaNV
///</summary>
[TestMethod()]
public void getListDataOnGoingByMaNVTest()
{
    BusTienDo bus = new BusTienDo();
    List<DtoTienDo> lst = bus.getListDataOnGoingByMaNV(1);
    Assert.AreEqual(0, lst.Count);
}

/// <summary>
///A test for getListDataUpcomingByMaNV
///</summary>
[TestMethod()]
public void getListDataUpcomingByMaNVTest()
{
    BusTienDo bus = new BusTienDo();
    List<DtoTienDo> lst = bus.getListDataUpcomingByMaNV(1);
    Assert.IsNotNull(lst);
    Assert.AreNotEqual(0, lst.Count);
}
    }
}
