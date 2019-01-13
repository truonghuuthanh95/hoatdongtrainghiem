using HoatDongTraiNghiem.Models.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class SocialLifeSkillService : IDisposable
    {
        public SocialLifeSkill CreateSocialLifeSkills(SocialLifeSkill socialLifeSkill)
        {
            using (var _db= new HoatDongTraiNghiemDB())
            {
                _db.SocialLifeSkills.Add(socialLifeSkill);
                _db.SaveChanges();
                return socialLifeSkill;
            }
        }
        public SocialLifeSkill UpdateSocialLifeSkills(SocialLifeSkill socialLifeSkill)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                _db.Entry(socialLifeSkill).State = EntityState.Modified;
                _db.SaveChanges();
                return socialLifeSkill;
            }
        }
        public void Dispose()
        {
            
        }

        public List<SocialLifeSkill> GetSocialLifeSkillsBySchoolId(string schoolId)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var list = _db.SocialLifeSkills.Where(s => s.SchoolId == schoolId).OrderBy(s => s.DateFrom).ToList();
                return list;
            }
        }
        public List<SocialLifeSkill> GetSocialLifeSkills(DateTime dateFrom, DateTime dateTo)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var list = _db.SocialLifeSkills.Where(s => s.DateFrom >= dateFrom && s.DateFrom <= dateTo).OrderBy(s => s.DateFrom).ToList();
                return list;
            }
        }
        public SocialLifeSkill GetSocialLifeSkillsById(int id)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
               var social = _db.SocialLifeSkills.Where(s => s.Id == id).SingleOrDefault();              
                return social;
            }
        }
    }
}