using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Y.ZSZ.BLL;
using Y.ZSZ.DTO.OptionDTO;

namespace Y.ZSZ.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HouseAppointmentBLL bll = new HouseAppointmentBLL();
            //long aa= bll.ADD(new HouseAppointmentOption
            //{

            //});
            bll.GetById(1);
            //Console.Write(aa);
        }
    }
}
