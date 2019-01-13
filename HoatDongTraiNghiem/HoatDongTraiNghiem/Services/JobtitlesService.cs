using HoatDongTraiNghiem.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class JobtitlesService : IDisposable
    {
        public void Dispose()
        {
            
        }

        public List<Jobtitle> GetJobtitles()
        {
            using (HoatDongTraiNghiemDB _db = new HoatDongTraiNghiemDB())
            {
                var jobtitles = _db.Jobtitles.Where(s => s.IsActive == true).ToList();
                return jobtitles;
            }
            
        }
    }
}