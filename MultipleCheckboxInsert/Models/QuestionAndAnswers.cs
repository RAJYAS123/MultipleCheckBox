using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleCheckboxInsert.Models
{
    public class QuestionAndAnswers
    {
        public int tblQuestionID { get; set; }
        public string Question { get; set; }
        public int tblAnswersID { get; set; }
        public string Answer { get; set; }
        
        public List<tblQuestion> listquestion { get; set; }
        public List<tblAnswer> listanswer { get; set; }
        public List<tblResult> listresult { get; set; }
    }
}