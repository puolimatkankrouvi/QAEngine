﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAEngine.Models.ThreadModels
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public String Title { get; set; }
        public String Text { get; set; }

        public ApplicationUser poster { get; set; }


    }
}