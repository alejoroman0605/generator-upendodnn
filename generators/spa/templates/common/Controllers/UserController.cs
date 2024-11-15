using <%= fullNamespace %>.ViewModels;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security;
using DotNetNuke.Web.Api;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace <%= fullNamespace %>.Controllers
{
    [SupportedModules("<%= friendlyName %>")]
    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
    [ValidateAntiForgeryToken]
    public class UserController : DnnApiController
    {
        public UserController() { }

        public HttpResponseMessage Dummy()
        {
            return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, "Dummy called");
        }
        public HttpResponseMessage GetList()
        {

            var userlist = DotNetNuke.Entities.Users.UserController.GetUsers(this.PortalSettings.PortalId);
            var users = userlist.Cast<UserInfo>().ToList()
                   .Select(user => new UserViewModel(user))
                   .ToList();

            return Request.CreateResponse(users);
        }
    }
}
