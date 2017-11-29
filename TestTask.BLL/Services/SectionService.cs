using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TestTask.BLL.DTO;
using TestTask.BLL.Infrastructure;
using TestTask.BLL.Interfaces;
using TestTask.DAL.Entities;
using TestTask.DAL.Interfaces;

namespace TestTask.BLL.Services
{
    public class SectionService : ISectionService
    {
        private readonly IMapper _mapper;

        public IRepositoryManager RepositoryManager { get; set; }

        public SectionService(IRepositoryManager repositoryManager)
        {
            RepositoryManager = repositoryManager;

            _mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Section, SectionDto>();
                cfg.CreateMap<SectionDto, Section>();
                cfg.CreateMap<SectionInfo, SectionInfoDto>();
                cfg.CreateMap<SectionInfoDto, SectionInfo>();
            }).CreateMapper();

        }

        public SectionDto GetSection(int? id)
        {
            if(id == null || id < 1)
                throw new ValidationException("Id can not be null or less than 1!", "");

            var section = RepositoryManager.SectionRepository.Get(id.Value);
            return _mapper.Map<Section, SectionDto>(section);
        }

        public SectionDto GetSection(string abbreviation)
        {
            if (string.IsNullOrWhiteSpace(abbreviation))
                throw new ValidationException("abbreviation can not be empty!", "");

            var section = RepositoryManager.SectionRepository.GetAllWithInfo()
                .FirstOrDefault(s => s.Abbreviation.Equals(abbreviation));

            return _mapper.Map<Section, SectionDto>(section);
        }

        public SectionInfoDto GetSectionInfo(int? id)
        {
            if(id == null || id < 1)
                throw new ValidationException("Id can not be null or less than 1!", "");

            var sectionInfo = RepositoryManager.SectionInfoRepository.Get(id.Value);
            return _mapper.Map<SectionInfo, SectionInfoDto>(sectionInfo);
        }

        public IEnumerable<SectionDto> GetSections(bool includeInfo = false)
        {
            var sections = includeInfo ? RepositoryManager.SectionRepository.GetAllWithInfo() 
                : RepositoryManager.SectionRepository.GetAll();
            return _mapper.Map<IEnumerable<Section>, List<SectionDto>>(sections);
        }

        public void AddOrUpdate(SectionDto sectionDto)
        {
            if (sectionDto?.SectionInfo == null)
                throw new ValidationException(
                    "Section and information of the section should not be null!", "");

            var sectionsInDb = RepositoryManager.SectionRepository.GetAll().Where(s => 
                                s.Abbreviation.Equals(sectionDto.Abbreviation)).ToList();

            if (sectionsInDb.Count > 1)
                throw new InvalidOperationException(
                    $"Several entities with this abbreviation were found {sectionDto.Abbreviation}.");

            var section = _mapper.Map<SectionDto, Section>(sectionDto);

            if (sectionsInDb.Count == 0)
            {
                RepositoryManager.SectionRepository.Create(section);
            }  
            else
            {
                section.SectionInfo.Id = sectionsInDb[0].Id;
                RepositoryManager.SectionInfoRepository.Update(section.SectionInfo);
            }

            RepositoryManager.Save();
        }
    }
}