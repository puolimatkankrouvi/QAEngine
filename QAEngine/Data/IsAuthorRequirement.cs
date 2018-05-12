using Microsoft.AspNetCore.Authorization;
using QAEngine.Models.ThreadModels;
using System.Threading.Tasks;

namespace QAEngine.Data{
    public class IsAuthorRequirement : IAuthorizationRequirement
    {
    }
}