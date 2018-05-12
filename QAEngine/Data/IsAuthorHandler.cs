using Microsoft.AspNetCore.Authorization;
using QAEngine.Data;
using QAEngine.Models.ThreadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAEngine
{
    public class IsAuthorHandler :
                        AuthorizationHandler<IsAuthorRequirement, QuestionModel>
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsAuthorRequirement requirement,
            QuestionModel question
        )
        {
            var poster = db.Users.FirstOrDefault(u => u.Id == question.Username);

            question.Poster = poster;

            if (context.User.Identity?.Name == question.Poster.UserName)
            {
                context.Succeed(requirement);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);

        }
    }
}
