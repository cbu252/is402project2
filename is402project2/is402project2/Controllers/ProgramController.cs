using is402project2.DAL;
using is402project2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace is402project2.Controllers
{
    public class ProgramController : Controller
    {
        SFCCContext db = new SFCCContext();

        // GET: Program
        public ActionResult Program()
        {
            //IEnumerable<program> programs = db.Database.SqlQuery<program>("SELECT programName, programID, programDay, programTime, participantAge, programDescription, volunteerID, internID FROM program");

            var programs = db.Programs;

            return View(programs.ToList());
        }

        public ActionResult ProgramView(int id)
        {
            //How do I change this so it passes as an IEnumerable??????

            programQuestions ProgramQuestions = new programQuestions();

            ProgramQuestions.Program = db.Programs.Find(id);

            //List<programQuestions> collection = new List<programQuestions>((IEnumerable<programQuestions>)ProgramQuestions);

            //string SQLStatment = "SELECT programName, programID, programDay, programTime, participantAge, programDescription, volunteerID, internID FROM program WHERE programID = '" + id + "'";

            //IEnumerable<programQuestions> ProgramQuestions = db.Database.SqlQuery<programQuestions>("SELECT programName, programID, programDay, programTime, participantAge, programDescription, volunteerID, internID, internFirstName, internLastName FROM program WHERE programID = '" + id + "'");

            ViewBag.Name = ProgramQuestions.Program.programName;
            ViewBag.WeekdayTime = ProgramQuestions.Program.programDay;
            ViewBag.AgeGroup = ProgramQuestions.Program.participantAge;
            ViewBag.Description = ProgramQuestions.Program.programDescription;
            //ViewBag.InternName = ProgramQuestions.Intern.internFirstName + ' ' + ProgramQuestions.Intern.internLastName;

            return View(ProgramQuestions);
        }

        public ActionResult FandQ(int id)
        {
            programQuestions FAQ = new programQuestions();

            FAQ.Program = db.Programs.Find(id);
            FAQ.Intern = db.Interns.ToList();
            FAQ.Questions = db.Question.ToList();
            FAQ.Volunteer = db.Volunteers.ToList();

            ViewBag.ID = id;
            //IEnumerable<programQuestions> ProgramQuestions = db.Database.SqlQuery<programQuestions>("SELECT programName, programID, programDay, programTime, participantAge, programDescription, volunteerID, internID, internFirstName, internLastName FROM program WHERE programID = '" + id + "'");

            return View(FAQ);
        }

        //This is the handle editing the questions and responses????

        // GET: questions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "questionID,question,answer,programID")] questions questions)
        {
            if (ModelState.IsValid)
            {
                db.Question.Add(questions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questions);
        }

        // GET: questions/Edit/5
        public ActionResult Edit(string answer)
        {
            //if (answer == null)
            //{

            //}

            questions questions = db.Database.SqlQuery<questions>("SELECT questionID, question, answer, programID FROM questions WHERE answer = '" + answer + "'").FirstOrDefault();

            //if (questions == null)
            //{
            //    return HttpNotFound();()
            //}
            return View(questions);
        }

        // POST: questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "questionID,question,answer,programID")] questions questions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questions);
        }


        //programquestion model
        //{
        //}
    }
}