using AutoMapper;
using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationCreativeExp, CreativeExpDTO>();
            CreateMap<CreativeExpDTO, RegistrationCreativeExp>();
            CreateMap<SocialLifeSkill, SocialLifeSkillDTO>();
            CreateMap<SocialLifeSkillDTO, SocialLifeSkill>();
            CreateMap<RegistrationDTO, Registration>();
            CreateMap<Registration, RegistrationDTO>();
            CreateMap<HoatDongNgoaiKhoaDTO, HoatDongNgoaiKhoa>();
            CreateMap<HoatDongNgoaiKhoa, HoatDongNgoaiKhoaDTO>();
        }
    }
}