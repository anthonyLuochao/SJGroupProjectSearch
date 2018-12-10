using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SJIP_LIMMV1.Models.DTO
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SensorBoxInfo, SearchDTO>();
        }
    }
}