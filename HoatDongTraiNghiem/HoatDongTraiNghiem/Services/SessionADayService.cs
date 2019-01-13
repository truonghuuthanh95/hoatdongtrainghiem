using HoatDongTraiNghiem.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class SessionADayService
    {
        public IQueryable<SessionADay> GetSessionADays()
        {
            using (HoatDongTraiNghiemDB _db = new HoatDongTraiNghiemDB())
            {
                var sessionADays = _db.SessionADays;
                return sessionADays;
            }
            
        }
    }
}