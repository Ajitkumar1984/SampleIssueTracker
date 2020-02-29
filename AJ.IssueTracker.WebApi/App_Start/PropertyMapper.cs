using AJ.IssueTracker.Common.DTO;
using AJ.IssueTracker.DataAccess.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJ.IssueTracker.WebApi.App_Start
{
    public class PropertyMapper
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IssueDTO, Issue>();
                cfg.CreateMap<Issue, IssueDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<IssueNote, IssueNoteDTO>();
                cfg.CreateMap<IssueNoteDTO, IssueNote>();
            });
            return config;
        }
    }
}