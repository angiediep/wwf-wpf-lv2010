﻿using System.Collections.Generic;
using BUSLayer;
using DataLayer.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
