using HoatDongTraiNghiem.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class KHHTLinhVucService : IDisposable
    {
        public void Dispose()
        {
            
        }
        public KHKTLinhVucThamGia GetHKTLinhVucThamGiaById(int id)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                KHKTLinhVucThamGia kHKTLinhVucThamGia = _db.KHKTLinhVucThamGias.Where(s => s.Id == id).SingleOrDefault();
                return kHKTLinhVucThamGia;
            }
            
        }

        public List<KHKTLinhVucThamGia> GetKHKTLinhVucThamGias()
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                List<KHKTLinhVucThamGia> kHKTLinhVucThamGias = _db.KHKTLinhVucThamGias.Where(s => s.IsActive == true).ToList();
                return kHKTLinhVucThamGias;

            }

        }
    }
}