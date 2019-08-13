using Archysoft.Domain.Model.Services.Abstract;
using Archysoft.Web.Api.Controllers;
using Moq;

namespace Archysoft.UnitTests.Web.Api.ProfileControllerTests
{
    public class ProfileControllerSut
    {
        public  ProfileController Instance { get; set; }

        public  Mock<IProfileService> ProfileService { get; set; }

        public ProfileControllerSut()
        {
            ProfileService = new Mock<IProfileService>();
            Instance=new ProfileController(ProfileService.Object);
        }
    }
}
