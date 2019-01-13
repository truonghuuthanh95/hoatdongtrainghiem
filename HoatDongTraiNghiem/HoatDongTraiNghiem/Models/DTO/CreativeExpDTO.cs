using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Models.DTO
{
    public class CreativeExpDTO
    {
        public string SchoolId { get; set; }

        public int StudentQuantity { get; set; }

        [StringLength(50)]
        public string Creator { get; set; }

        public int JobTiteId { get; set; }

        public int ProgramId { get; set; }
      
        public DateTime DateRegisted { get; set; }            

        public int ClassId { get; set; }

        public int DaySessionId { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(500)]
        public string ActivitiTitle { get; set; }
    }
}