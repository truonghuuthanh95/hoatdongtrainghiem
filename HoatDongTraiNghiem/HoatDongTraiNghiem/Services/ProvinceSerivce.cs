using HoatDongTraiNghiem.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class ProvinceSerivce : IDisposable
    {
        public void Dispose()
        {
            
        }

        public List<Province> GetProvinces()
        {
            using (HoatDongTraiNghiemDB _db = new HoatDongTraiNghiemDB())
            {
                var provinces = _db.Provinces.Where(s => s.CountryId == 237).OrderBy(s => s.Name).ToList();
                return provinces;
            }
            
        }
    }
}