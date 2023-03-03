using _01_ShopQuery.Contract.Slide;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShopManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidesController : ControllerBase
    {
        private readonly ISlideQuery _slideQuery;

        public SlidesController(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }
        [HttpGet]
        public IEnumerable<SlideModel> GetSlides()
        {
            return _slideQuery.GetSlide();
        }
    }
}
