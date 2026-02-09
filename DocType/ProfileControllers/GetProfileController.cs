using DocType.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocType.ProfileControllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GetProfileController : ControllerBase 
    {
        private readonly IProfileService _profileService;
        public GetProfileController(IProfileService profile)
        {
            _profileService = profile;
        }
       
    }
}
