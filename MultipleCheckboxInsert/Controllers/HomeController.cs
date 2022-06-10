using MultipleCheckboxInsert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultipleCheckboxInsert.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext databaseContext = new DatabaseContext();
        public ActionResult Index()
        {
            var data = new QuestionAndAnswers
            {
                listquestion = databaseContext.tblQuestions.ToList(),
                listanswer = databaseContext.tblAnswers.ToList()
            };
            return View(data);
        }

        [HttpPost]
        public JsonResult Insert(List<SelectedAnswer> obj)
        {

            tblResult data = new tblResult();
            foreach (var Ques in obj)
            {
                //data.tblQuestionID = Ques.tblQuestionID;               
                var GetID = databaseContext.tblResults.Where(s => s.tblQuestionID == Ques.tblQuestionID).ToList();
                if (GetID.Count > 0)
                {
                    var update = databaseContext.DeleteQuestionAndAnswer(Ques.tblQuestionID);
                    string[] arrAns = Ques.Answers.Split(',');
                    foreach (var item in arrAns)
                    {
                        data.tblQuestionID = Ques.tblQuestionID;
                        data.SelectedAnswer = Convert.ToInt32(item);
                        databaseContext.tblResults.Add(data);
                        databaseContext.SaveChanges();
                    }

                }
                else
                {
                    string[] arrAns = Ques.Answers.Split(',');
                    data.tblQuestionID = Ques.tblQuestionID;
                    foreach (var item in arrAns)
                    {
                        data.SelectedAnswer = Convert.ToInt32(item);
                        databaseContext.tblResults.Add(data);
                        databaseContext.SaveChanges();
                    }
                }

            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public JsonResult GetAllRecord()
        //{
        //    var data = databaseContext.GetAllQuestionAnswer().ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public JsonResult AllQuestionAndAnswer()
        {
            var data = databaseContext.JoinQuestionAnswerResultCheckbox().ToList();
            //var Get = (from cr in data
            //         group cr.Answer by cr.tblQuestionID into g
            //         select new { tblQuestionID = g.Key, Answers = string.Join(",", g.ToArray()) }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
       public JsonResult GetAll()
        {
            var Data = databaseContext.AllQuestionAndAnswer().ToList();

            return Json(Data, JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult Dashboard()
        {

            return View();
        }


        public ActionResult CountryStateCityBind()
        {

            return View();
        }
    }
}