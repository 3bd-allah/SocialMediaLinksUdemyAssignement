using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SocialMediaLinks.ConfigurationOptions;
using System.Text.Json;

namespace SocialMediaLinks.Controllers
{
    [ApiController]
    public class ValuesController(IOptions<SocialMediaLinksOptions>? options, IWebHostEnvironment environment) : Controller
    {
        [Route("/social-media")]
        public IActionResult SocialMediaLinks()
        {
            if (environment.EnvironmentName == "Development")
            {
                return new JsonResult(new
                {
                    Facebook = options.Value.Facebook,
                    Twitter = options.Value.Twitter,
                    Youtube = options.Value.Youtube,
                });

            }
            else
            {
                SocialMediaLinksOptions socialMediaLinks = new SocialMediaLinksOptions()
                {
                    Facebook = options.Value.Facebook,
                    Twitter = options.Value.Twitter,
                    Youtube = options.Value.Youtube,
                    Instagram = options.Value.Instagram,
                };
                return new JsonResult(socialMediaLinks);
            }
            //SocialMediaLinksOptions socialMediaLinks = new SocialMediaLinksOptions()
            //{
            //    Facebook = options.Value.Facebook,
            //    Twitter = options.Value.Twitter,
            //    Youtube = options.Value.Youtube,
            //    Instagram = options.Value.Instagram,
            //};
            //return Ok(socialMediaLinks);
        }
    }
}
