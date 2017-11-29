using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using TestTask.BLL.DTO;
using TestTask.BLL.Interfaces;
using TomskNipiNeft.TestTask.Models;

namespace TomskNipiNeft.TestTask.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ISectionService _service;
        private readonly IMapper _mapper;

        public HomeController(ISectionService service)
        {
            _service = service;

            _mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<SectionVm, SectionDto>();
                cfg.CreateMap<SectionDto, SectionVm>();
                cfg.CreateMap<SectionInfoVm, SectionInfoDto>();
                cfg.CreateMap<SectionInfoDto, SectionInfoVm>();
            }).CreateMapper();

        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;
            var sectionVmList = _mapper.Map<IEnumerable<SectionDto>, List<SectionVm>>(_service.GetSections());
            var sectionsPerPage = sectionVmList.Skip((page - 1) * pageSize).Take(pageSize);
            var pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = sectionVmList.Count };
            var vm = new SectionPageViewModel { PageInfo = pageInfo, Sections = sectionsPerPage };
            return View("Index", vm);
        }
        
        public ActionResult Details(int? id)
        {
            var sectionInfoDto = _service.GetSectionInfo(id);
            var sectionInfoVm = _mapper.Map<SectionInfoDto, SectionInfoVm>(sectionInfoDto);
            return View("Details", sectionInfoVm);
        }
    }
}