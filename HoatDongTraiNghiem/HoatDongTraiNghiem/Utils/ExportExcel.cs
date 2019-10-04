using HoatDongTraiNghiem.Models.DAO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HoatDongTraiNghiem.Utils
{
    public class ExportExcel
    {
        public static Task GenerateXLSRegistrationCreativeExp(List<RegistrationCreativeExp> registrationCreativeExps, DateTime dateFrom, DateTime dateTo, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet 
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("trainghiemsangtao");
                    ws.Cells[2, 1].Value = "DANH SÁCH TRẢI NGHIỆM SÁNG TẠO";
                    ws.Cells["A2:I2"].Merge = true;
                    ws.Cells[3, 1].Value = registrationCreativeExps.ElementAt(0).Program.Name.ToUpper();
                    ws.Cells["A3:I3"].Merge = true;
                    if (dateFrom != null && dateTo != null)
                    {
                        ws.Cells[4, 1].Value = "Từ ngày " + dateFrom.Day.ToString("d2") + "/" + dateFrom.Month.ToString("d2") + "/" + dateFrom.Year + " tới ngày " + dateTo.Day.ToString("d2") + "/" + dateTo.Month.ToString("d2") + "/" + dateTo.Year;
                    }                 
                    ws.Cells["A4:I4"].Merge = true;
                    ws.Cells[6, 1].Value = "STT";
                    ws.Cells[6, 2].Value = "TÊN TRƯỜNG";
                    ws.Cells[6, 3].Value = "LỚP";
                    ws.Cells[6, 4].Value = "SỐ LƯỢNG";
                    ws.Cells[6, 5].Value = "NGÀY THAM GIA";
                    ws.Cells[6, 6].Value = "BUỔI";
                    ws.Cells[6, 7].Value = "ĐỊA ĐIỂM";
                    ws.Cells[6, 8].Value = "TÊN CHỦ ĐỀ";
                    ws.Cells[6, 9].Value = "NGÀY ĐĂNG KÍ";
                    ws.Cells[6, 10].Value = "TÊN NGƯỜI PHỤ TRÁCH";
                    ws.Cells[6, 11].Value = "CHỨC VỤ";
                    ws.Cells[6, 12].Value = "SỐ ĐIỆN THOẠI";
                    ws.Cells[6, 13].Value = "EMAIL";

                    for (int i = 0; i < registrationCreativeExps.Count(); i++)
                    {
                        ws.Cells[i + 7, 1].Value = i + 1;
                        ws.Cells[i + 7, 2].Value = registrationCreativeExps.ElementAt(i).SchoolName;
                        ws.Cells[i + 7, 3].Value = registrationCreativeExps.ElementAt(i).ClassId;
                        ws.Cells[i + 7, 4].Value = registrationCreativeExps.ElementAt(i).StudentQuantity;
                        ws.Cells[i + 7, 5].Value = registrationCreativeExps.ElementAt(i).DateRegisted.Value.ToString("dd/MM/yyyy");
                        ws.Cells[i + 7, 6].Value = registrationCreativeExps.ElementAt(i).SessionADay.Name;
                        ws.Cells[i + 7, 7].Value = registrationCreativeExps.ElementAt(i).Program.Name;
                        ws.Cells[i + 7, 8].Value = registrationCreativeExps.ElementAt(i).ActivitiTitle;
                        ws.Cells[i + 7, 9].Value = registrationCreativeExps.ElementAt(i).CreatedAt.Value.ToString("dd/MM/yyyy");
                        ws.Cells[i + 7, 10].Value = registrationCreativeExps.ElementAt(i).Creator;
                        ws.Cells[i + 7, 11].Value = registrationCreativeExps.ElementAt(i).Jobtitle.Name;
                        ws.Cells[i + 7, 12].Value = registrationCreativeExps.ElementAt(i).PhoneNumber;
                        ws.Cells[i + 7, 13].Value = registrationCreativeExps.ElementAt(i).Email;

                    }
                    using (ExcelRange rng = ws.Cells["A2:I2"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 18;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A3:I3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A4:I4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A6:M6"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }


                    pck.SaveAs(new FileInfo(filePath));
                }
            });
        }
        public static Task GenerateXLSSocialLifeSkill(List<SocialLifeSkill> socialLifeSkills, DateTime dateFrom, DateTime dateTo, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet 
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("kynangxahoi,kynangsong");
                    ws.Cells[2, 1].Value = "DANH SÁCH KỸ NĂNG SỐNG, KỸ NĂNG XÃ HỘI";
                    ws.Cells["A2:I2"].Merge = true;
                    if (dateTo != null && dateFrom != null)
                    {
                        ws.Cells[4, 1].Value = "Từ ngày " + dateFrom.Day.ToString("d2") + "/" + dateFrom.Month.ToString("d2") + "/" + dateFrom.Year + " tới ngày " + dateTo.Day.ToString("d2") + "/" + dateTo.Month.ToString("d2") + "/" + dateTo.Year;
                    }                    
                    ws.Cells["A4:I4"].Merge = true;
                    ws.Cells[6, 1].Value = "STT";
                    ws.Cells[6, 2].Value = "TÊN TRƯỜNG";
                    ws.Cells[6, 3].Value = "LỚP";
                    ws.Cells[6, 4].Value = "NGÀY BẮT ĐẦU";
                    ws.Cells[6, 5].Value = "NGÀY KẾT THÚC";
                    ws.Cells[6, 6].Value = "NỘI DUNG THỰC HIỆN HOẠT ĐỘNG";
                    ws.Cells[6, 7].Value = "TÓM TẮT NỘI DUNG THỰC HIỆN";
                    ws.Cells[6, 8].Value = "KỸ NĂNG";
                    ws.Cells[6, 9].Value = "ĐƠN VỊ PHỐI HỢP";
                    ws.Cells[6, 10].Value = "GIẤY PHÉP HOẠT ĐỘNG";
                    ws.Cells[6, 11].Value = "TÊN NGƯỜI PHỤ TRÁCH";
                    ws.Cells[6, 12].Value = "CHỨC VỤ";
                    ws.Cells[6, 13].Value = "SỐ ĐIỆN THOẠI";
                    ws.Cells[6, 14].Value = "EMAIL";

                    for (int i = 0; i < socialLifeSkills.Count(); i++)
                    {
                        ws.Cells[i + 7, 1].Value = i + 1;
                        ws.Cells[i + 7, 2].Value = socialLifeSkills.ElementAt(i).SchoolName;
                        ws.Cells[i + 7, 3].Value = socialLifeSkills.ElementAt(i).ClassId;
                        ws.Cells[i + 7, 4].Value = socialLifeSkills.ElementAt(i).DateFrom.Value.ToString("dd/MM/yyyy");
                        ws.Cells[i + 7, 5].Value = socialLifeSkills.ElementAt(i).DateTo.Value.ToString("dd/MM/yyyy");
                        ws.Cells[i + 7, 6].Value = socialLifeSkills.ElementAt(i).ProgramName;
                        ws.Cells[i + 7, 7].Value = socialLifeSkills.ElementAt(i).SumaryContent;
                        ws.Cells[i + 7, 8].Value = socialLifeSkills.ElementAt(i).IsKyNangThucHanhXH == true ? "Kỹ năng sống" : "Kỹ năng khác";
                        ws.Cells[i + 7, 9].Value = socialLifeSkills.ElementAt(i).CompanyContact;
                        ws.Cells[i + 7, 10].Value = socialLifeSkills.ElementAt(i).License;
                        ws.Cells[i + 7, 11].Value = socialLifeSkills.ElementAt(i).Creatot;
                        ws.Cells[i + 7, 12].Value = socialLifeSkills.ElementAt(i).Jobtitle.Name;
                        ws.Cells[i + 7, 13].Value = socialLifeSkills.ElementAt(i).PhoneNumber;
                        ws.Cells[i + 7, 14].Value = socialLifeSkills.ElementAt(i).Email;
                    }
                    using (ExcelRange rng = ws.Cells["A2:I2"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 18;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A3:I3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A4:I4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A6:N6"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }


                    pck.SaveAs(new FileInfo(filePath));
                }
            });
        }
        public static Task GenerateXLSHoatDongNgoaiKhoa(List<HoatDongNgoaiKhoa> hoatDongNgoaiKhoas, DateTime dateFrom, DateTime dateTo, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet 
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("kynangxahoi,kynangsong");
                    ws.Cells[2, 1].Value = "DANH SÁCH HOẠT ĐỘNG NGOẠI KHÓA";
                    ws.Cells["A2:I2"].Merge = true;
                    if (dateTo != null && dateFrom != null)
                    {
                        ws.Cells[4, 1].Value = "Từ ngày " + dateFrom.Day.ToString("d2") + "/" + dateFrom.Month.ToString("d2") + "/" + dateFrom.Year + " tới ngày " + dateTo.Day.ToString("d2") + "/" + dateTo.Month.ToString("d2") + "/" + dateTo.Year;
                    }
                    ws.Cells["A4:I4"].Merge = true;
                    ws.Cells[6, 1].Value = "STT";
                    ws.Cells[6, 2].Value = "TÊN TRƯỜNG";
                    ws.Cells[6, 3].Value = "LỚP";
                    ws.Cells[6, 4].Value = "NGÀY ĐĂNG KÍ";                    
                    ws.Cells[6, 5].Value = "NỘI DUNG THỰC HIỆN HOẠT ĐỘNG";                                                                            
                    ws.Cells[6, 6].Value = "TÊN NGƯỜI PHỤ TRÁCH";
                    ws.Cells[6, 7].Value = "CHỨC VỤ";
                    ws.Cells[6, 8].Value = "SỐ ĐIỆN THOẠI";
                    ws.Cells[6, 9].Value = "EMAIL";

                    for (int i = 0; i < hoatDongNgoaiKhoas.Count(); i++)
                    {
                        ws.Cells[i + 7, 1].Value = i + 1;
                        ws.Cells[i + 7, 2].Value = hoatDongNgoaiKhoas.ElementAt(i).SchoolName;
                        ws.Cells[i + 7, 3].Value = hoatDongNgoaiKhoas.ElementAt(i).ClassId;
                        ws.Cells[i + 7, 4].Value = hoatDongNgoaiKhoas.ElementAt(i).DateRegisted.Value.ToString("dd/MM/yyyy");                   
                        ws.Cells[i + 7, 5].Value = hoatDongNgoaiKhoas.ElementAt(i).ActivityName;                                             
                        ws.Cells[i + 7, 6].Value = hoatDongNgoaiKhoas.ElementAt(i).Creator;
                        ws.Cells[i + 7, 7].Value = hoatDongNgoaiKhoas.ElementAt(i).Jobtitle.Name;
                        ws.Cells[i + 7, 8].Value = hoatDongNgoaiKhoas.ElementAt(i).PhoneNumber;
                        ws.Cells[i + 7, 9].Value = hoatDongNgoaiKhoas.ElementAt(i).Email;
                    }
                    using (ExcelRange rng = ws.Cells["A2:I2"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 18;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A3:I3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A4:I4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A6:N6"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }


                    pck.SaveAs(new FileInfo(filePath));
                }
            });
        }
        public static Task GenerateXLSHoatDongHocTapTraiNghiem(List<Registration> registrations, List<SubjectsRegisted> subjectsRegisteds, DateTime dateFrom, DateTime dateTo, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet 
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("trainghiemsangtao");
                    ws.Cells[2, 1].Value = "DANH SÁCH NỘI DUNG KHÁC";
                    ws.Cells["A2:I2"].Merge = true;
                    ws.Cells["A3:I3"].Merge = true;
                    ws.Cells[4, 1].Value = "Từ ngày " + dateFrom.Day.ToString("d2") + "/" + dateFrom.Month.ToString("d2") + "/" + dateFrom.Year + " tới ngày " + dateTo.Day.ToString("d2") + "/" + dateTo.Month.ToString("d2") + "/" + dateTo.Year;
                    ws.Cells["A4:I4"].Merge = true;
                    ws.Cells[6, 1].Value = "STT";
                    ws.Cells[6, 2].Value = "TÊN TRƯỜNG";
                    ws.Cells[6, 3].Value = "LỚP";
                    ws.Cells[6, 4].Value = "SỐ LƯỢNG";
                    ws.Cells[6, 5].Value = "NGÀY THAM GIA";
                    ws.Cells[6, 6].Value = "Nội dung thực hiện hoạt động".ToUpper();
                    ws.Cells[6, 7].Value = "Vi trí kiến thức".ToUpper();
                    ws.Cells[6, 8].Value = "Tóm tắt nội dung".ToUpper();
                    ws.Cells[6, 9].Value = "Địa điểm".ToUpper();
                    ws.Cells[6, 10].Value = "TÊN NGƯỜI PHỤ TRÁCH";
                    ws.Cells[6, 11].Value = "CHỨC VỤ";
                    ws.Cells[6, 12].Value = "SỐ ĐIỆN THOẠI";
                    ws.Cells[6, 13].Value = "EMAIL";
                    ws.Cells[6, 14].Value = "NGÀY TẠO";
                    string subject = "";
                    List<SubjectsRegisted> subjectsRegistedBelongTo = new List<SubjectsRegisted>();
                    for (int i = 0; i < registrations.Count(); i++)
                    {
                        ws.Cells[i + 7, 1].Value = i + 1;
                        ws.Cells[i + 7, 2].Value = registrations.ElementAt(i).SchoolName;
                        ws.Cells[i + 7, 3].Value = registrations.ElementAt(i).ClassId;
                        ws.Cells[i + 7, 4].Value = registrations.ElementAt(i).StudentQuantity;
                        ws.Cells[i + 7, 5].Value = registrations.ElementAt(i).DateRegisted.Value.ToString("dd/MM/yyyy");
                        ws.Cells[i + 7, 6].Value = registrations.ElementAt(i).ProgramName;
                        ws.Cells[i + 7, 7].Value = registrations.ElementAt(i).ViTriKienThuc;
                        ws.Cells[i + 7, 8].Value = registrations.ElementAt(i).TomTatNoiDungCT;
                        ws.Cells[i + 7, 9].Value = registrations.ElementAt(i).Province.Type + " " + registrations.ElementAt(i).Province.Name;
                        subjectsRegistedBelongTo = subjectsRegisteds.Where(s => s.RegistrationId == registrations.ElementAt(i).Id).ToList();

                        for (int j = 0; j < subjectsRegistedBelongTo.Count(); j++)
                        {
                            subject = string.Join(", ", subjectsRegistedBelongTo.Select(s => s.Subject.Name));
                        }
                        ws.Cells[i + 7, 10].Value = subject;
                        ws.Cells[i + 7, 12].Value = registrations.ElementAt(i).Creator;
                        ws.Cells[i + 7, 13].Value = registrations.ElementAt(i).Jobtitle.Name;
                        ws.Cells[i + 7, 14].Value = registrations.ElementAt(i).PhoneNumber;
                        ws.Cells[i + 7, 15].Value = registrations.ElementAt(i).Email;
                        ws.Cells[i + 7, 16].Value = registrations.ElementAt(i).CreatedAt.Value.ToString("dd/MM/yyyy");
                    }
                    using (ExcelRange rng = ws.Cells["A2:I2"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 18;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A3:I3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A4:I4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A6:O6"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }


                    pck.SaveAs(new FileInfo(filePath));
                }
            });
        }
    }
}