using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Models.DTO
{
    public class SocialLifeSkillDTO
    {        
        [StringLength(50)]
        public string SchoolId { get; set; }

        public int ClassId { get; set; }

        public bool IsKyNangThucHanhXH { get; set; }

        [StringLength(4000)]
        public string SumaryContent { get; set; }

        [StringLength(300)]
        public string CompanyContact { get; set; }

        [StringLength(100)]
        public string License { get; set; }

        [StringLength(100)]
        public string FileKeHoach { get; set; }        
        public DateTime DateFrom { get; set; }
      
        public DateTime DateTo { get; set; }

        [StringLength(50)]
        public string Creatot { get; set; }

        public int JobtitleId { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(300)]
        public string ProgramName { get; set; }
    }
}