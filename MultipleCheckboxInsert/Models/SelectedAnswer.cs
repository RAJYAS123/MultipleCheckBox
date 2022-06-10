using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleCheckboxInsert.Models
{
    public class SelectedAnswer
    {
        public int tblResultID { get; set; }
        public int tblQuestionID { get; set; }
        public string Answers { get; set; }
    }
}