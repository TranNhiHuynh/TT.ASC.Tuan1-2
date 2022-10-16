using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using TT.ASC.DATA;
namespace MVC4.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Bai1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai1(FormCollection cl)
        {
            int day = int.Parse(cl["day"].ToString());
            int month = int.Parse(cl["month"].ToString());
            int year = int.Parse(cl["year"].ToString());
            int hours = int.Parse(cl["hours"].ToString());
            int minute = int.Parse(cl["minute"].ToString());
            int second = int.Parse(cl["second"].ToString());
            DateTime curDate = BaiTapASC.FormatDateTime(day, month, year, hours, minute, second);   
            ViewData["myDate"] = curDate;
            return View();
        }
        [HttpGet]
        public ActionResult Bai2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai2(FormCollection cl)
        {
            int number = int.Parse(cl["txtNumber"].ToString());
            ViewBag.readNumber = BaiTapASC.ReadNumber(number.ToString());
            return View();
        }
        public ActionResult Bai3()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai3(FormCollection cl)
        {
          long number = long.Parse(cl["txtNumber"].ToString());
            ViewBag.readNumber = BaiTapASC.ReadNumberToMoney(number);
            return View();
        }

        public ActionResult Bai4()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai4(FormCollection cl)
        {
            int number = int.Parse(cl["txtLength"].ToString());
            ViewBag.strRandom = BaiTapASC.RandomString(number);
            return View();
        }
        public ActionResult Bai5()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai5(FormCollection cl)
        {
            int month = int.Parse(cl["txtMonth"].ToString());
            int year = int.Parse(cl["txtYear"].ToString());

            ViewBag.firstDayOfMonth = BaiTapASC.FirstDayOfMonth(year, month);
            ViewBag.month = month;
            ViewBag.year = year;
            return View();
        }
        public ActionResult Bai6()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai6(FormCollection cl)
        {
            int month = int.Parse(cl["txtMonth"].ToString());
            int year = int.Parse(cl["txtYear"].ToString());

            ViewBag.lastDayOfMonth = BaiTapASC.LastDayOfMonth(year, month);
            ViewBag.month = month;
            ViewBag.year = year;
            return View();
        }
        public ActionResult Bai7()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai7(FormCollection cl)
        {
            int day = int.Parse(cl["txtDay"].ToString());
            int month = int.Parse(cl["txtMonth"].ToString());
            int year = int.Parse(cl["txtYear"].ToString());

            ViewBag.firstDayOfWeek = BaiTapASC.FirstDayOfWeek(year, month,day);
            ViewBag.day = day;
            ViewBag.month = month;
            ViewBag.year = year;
            return View();
        }
        public ActionResult Bai8()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai8(FormCollection cl)
        {
            int day = int.Parse(cl["txtDay"].ToString());
            int month = int.Parse(cl["txtMonth"].ToString());
            int year = int.Parse(cl["txtYear"].ToString());

            ViewBag.lastDayOfWeek = BaiTapASC.LastDayOfWeek(year, month, day);
            ViewBag.day = day;
            ViewBag.month = month;
            ViewBag.year = year;
            return View();
        }
        public ActionResult Bai9()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai9(FormCollection cl)
        { 

            ViewBag.countSpace = BaiTapASC.CountSpace(cl["txtGmail"].ToString());
            return View();
        }
        public ActionResult Bai10()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai10(FormCollection cl)
        {

            ViewBag.checkGmail = BaiTapASC.CheckGmail(cl["txtGmail"].ToString());
            return View();
        }

        public ActionResult Bai11()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai11(FormCollection cl)
        {
            string firstName = "";
            string lastName = "";
            BaiTapASC.DivName(cl["txtName"].ToString(),ref firstName,ref lastName);
            ViewBag.firstName = firstName;
            ViewBag.lastName = lastName;
            return View();
        }

        public ActionResult Bai12()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai12(FormCollection cl)
        {
            double round = 0, truncate = 0, ceiling = 0, floor = 0;
            BaiTapASC.RoundNumber(double.Parse(cl["txtNumber"].ToString()), ref round, ref truncate, ref ceiling, ref floor);
            ViewBag.round = round;
            ViewBag.truncate = truncate;
            ViewBag.ceiling = ceiling;
            ViewBag.floor = floor;
            return View();
        }
        public ActionResult Bai13()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bai13(FormCollection cl)
        {
            return View();
        }

        public ActionResult QLSV()
        {
            QuanLy QL = new QuanLy();
            List<LopHoc> lstLopHoc = QL.CreateListLopHoc(10);
            List<SinhVien> lstSV = QL.CreateListSinhVien(20, lstLopHoc);
            ViewData["LstLopHoc"] = lstLopHoc;
            ViewData["LstSinhVien"] = lstSV;
            return View();
        }
        [HttpPost]
        public ActionResult QLSV(FormCollection cl)
        {
            double round = 0, truncate = 0, ceiling = 0, floor = 0;
            BaiTapASC.RoundNumber(double.Parse(cl["txtNumber"].ToString()), ref round, ref truncate, ref ceiling, ref floor);
            ViewBag.round = round;
            ViewBag.truncate = truncate;
            ViewBag.ceiling = ceiling;
            ViewBag.floor = floor;
            return View();
        }
    }
}