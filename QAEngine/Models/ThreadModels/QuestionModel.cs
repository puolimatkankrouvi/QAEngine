using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QAEngine.Models.ThreadModels
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public String Title { get; set; }
        public String Text { get; set; }

        public String Username { get; set; }

        [ForeignKey("Username")]
        public ApplicationUser Poster {get; set;}
    }
}
