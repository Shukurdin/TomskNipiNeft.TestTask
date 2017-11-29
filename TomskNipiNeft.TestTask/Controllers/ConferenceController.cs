using System;
using System.Net;
using System.Web.Mvc;
using NLog;
using TestTask.BLL.DTO;
using TestTask.BLL.Extensions;
using TestTask.BLL.Interfaces;
using TomskNipiNeft.TestTask.Util;

namespace TomskNipiNeft.TestTask.Controllers
{
    [RoutePrefix("conference")]
    public class ConferenceController : Controller
    {
        private readonly ISectionService _service;
        private readonly Logger _logger;

        public ConferenceController(ISectionService service)
        {
            _service = service;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [HttpGet]
        [Route("info")]
        public ActionResult GetAllSection()
        {
            return GetContent(_service.GetSections(true).ToJson());
        }
        
        [HttpGet]
        [Route("{section}/info")]
        public ActionResult GetSection(string section)
        {
            var sectionDto = _service.GetSection(section);
            if (sectionDto == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return GetContent(sectionDto.ToJson());
        }

        [HttpPut]
        [Route("{section}/info")]
        public ActionResult PutSectionInfo(string section, [ModelBinder(typeof(JsonNetModelBinder))] SectionInfoDto info)
        {
            if (info == null || info.IsEmpty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            try
            {
                _service.AddOrUpdate(new SectionDto { Abbreviation = section, SectionInfo = info });
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        private ContentResult GetContent(string json)
        {
            return new ContentResult
            {
                Content = json,
                ContentType = "application/json"
            };
        }
    }
}