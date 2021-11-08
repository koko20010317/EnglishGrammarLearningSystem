using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishGrammarLearningSystem.Models
{
    public class PretestViewModels
    {
        public int QLID { get; set; }
        public int QID { get; set; }
        public string Question { get; set; }
        public string Options { get; set; }
        public string UserAns { get; set; }
        public string QLAns { get; set; }


        public string UserID { get; set; }
        public int score { get; set; }
        public string UserLevel { get; set; }
        

    }
}