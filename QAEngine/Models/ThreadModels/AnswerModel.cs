using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QAEngine.Models.ThreadModels
{
    public partial class AnswerModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }

        public DateTime Date { get; set; }

        public String Title { get; set; }
        public String Text { get; set; }
        public String Username { get; set; }

        [ForeignKey("Username")]
        public ApplicationUser Poster { get; set; }

        [ForeignKey("QuestionId")]
        public QuestionModel Question { get; set; }
    }
}
