using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace is402project2.Controllers
{
    public class ProgramController : Controller
    {
        // GET: Program
        public ActionResult Program()
        {
            List<SelectListItem> programList = new List<SelectListItem>();
            //adds the programs to the programList
            //In future it can grab from the model instead of hard coding
            programList.Add(new SelectListItem { Text = "Music", Value = "1" });
            programList.Add(new SelectListItem { Text = "Personal Finance", Value = "2" });
            programList.Add(new SelectListItem { Text = "Zumba", Value = "3" });

            //ViewModel viewModel = new ViewModel();
            ViewBag.ProgramList = programList;

            return View();
        }

        public ActionResult ProgramView(string ProgramList)
        {
            if (ProgramList.Equals("1"))
            {
                ViewBag.ProName = "Music";
                ViewBag.InternName = "Jessica Keele";
                ViewBag.AgeGroup = "All Ages";
                ViewBag.WeekdayTime = "Specfic to Class - Contact for Details";
                ViewBag.ProDesc = "Come learn to play an instrument! We have a variety of classes for all levels of students.";
            }
            else if (ProgramList.Equals("2"))
            {
                ViewBag.ProName = "Personal Finance";
                ViewBag.InternName = "Tom Sawyer";
                ViewBag.AgeGroup = "Adults";
                ViewBag.WeekdayTime = "Saturdays at 10:00AM";
                ViewBag.ProDesc = "Do you need help with your fianances? Come to our personal finance class and get help planning your life.";
            }
            else if (ProgramList.Equals("3"))
            {
                ViewBag.ProName = "Zumba";
                ViewBag.InternName = "Casandra Ramirez";
                ViewBag.AgeGroup = "Adults";
                ViewBag.WeekdayTime = "Tuesdays at 7:00AM";
                ViewBag.ProDesc = "Get up and DANCE! If you need a great time and a way to get moving, come dance with us!";
            }

            return View();
        }
    }
}