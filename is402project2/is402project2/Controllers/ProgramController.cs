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
using System.Web.Security;

namespace is402project2.Controllers
{
    public class ProgramController : Controller
    {
        SFCCContext db = new SFCCContext();

        //This will get the programs information and pass it to the view in a list. 
        // GET: Program
        public ActionResult Program()
        {
            var programs = db.Programs;

            return View(programs.ToList());
        }


        //This will go to the program view and view that programs info and allow you to access the FAQ page.
        public ActionResult ProgramView(int id)
        {
            programQuestions ProgramQuestions = new programQuestions();

            ProgramQuestions.Program = db.Programs.Find(id);

            ViewBag.Name = ProgramQuestions.Program.programName;
            ViewBag.WeekdayTime = ProgramQuestions.Program.programDay;
            ViewBag.AgeGroup = ProgramQuestions.Program.participantAge;
            ViewBag.Description = ProgramQuestions.Program.programDescription;
            //ViewBag.InternName = ProgramQuestions.Intern.internFirstName + ' ' + ProgramQuestions.Intern.internLastName;

            return View(ProgramQuestions);
        }


        //This will allows the user to view the FAQ page.... I know I called it FandQ..... it was 1:30am... :) 
        [Authorize] //This will make it so the user must be authorized/logged in with google to access this page
        public ActionResult FandQ(int id)
        {
            programQuestions FAQ = new programQuestions();

            FAQ.Program = db.Programs.Find(id);
            FAQ.Intern = db.Interns.ToList();
            FAQ.Questions = db.Question.ToList();
            FAQ.Volunteer = db.Volunteers.ToList();

            ViewBag.ID = id;
           
            return View(FAQ);
        }
  
        //This is the handle adding new questions to the model
        // GET: questions/Create
        public ActionResult Create(int progid, int questionid)
        {
            int iNumQuestion = questionid + 1;
            int iNumProgram = progid;

            db.Database.ExecuteSqlCommand("INSERT INTO questions (questionID, programID) VALUES (" + iNumQuestion + ", " + progid + ")");

            questions newquestion = db.Database.SqlQuery <questions>("SELECT questionID, question, answer, programID FROM questions WHERE questionID = " + iNumQuestion + " AND programID = " + iNumProgram +"").FirstOrDefault();

            return View(newquestion);

        }

        //This will post the new questions
        // POST: questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "answer,programID,question,questionID")] questions questions)
        {
            if (ModelState.IsValid)
            {
                db.Question.Add(questions);
                db.Database.ExecuteSqlCommand("INSERT INTO questions (questionID, question, answer, programID) VALUES (" + questions.questionID + ", '" + questions.question + "', '" +questions.answer + "', " + questions.programID +")");
                db.SaveChanges();
                return RedirectToAction("FandQ/" + questions.programID);
            }

            return View(questions);
        }

        //This will allow the user to edit a question. 
        // GET: questions/Edit/5
        public ActionResult Edit(string question)
        { 
            questions questions = db.Database.SqlQuery<questions>("SELECT questionID, question, answer, programID FROM questions WHERE question = '" + question + "'").FirstOrDefault();

            return View(questions);
        }


        //This will get the information from the inputed answer and put it into the database, then return the user to the FAQ page. 
        // POST: questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "questionID,question,answer,programID")]questions questions)
        {
            if (ModelState.IsValid)
            {
                //string anwser = Request.Form("answer");
                db.Entry(questions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FandQ/" + questions.programID);
            }
            return View(questions);
        }
    }
}