using ClosedXML.Excel;
using MISA.WEB07.TNANH.MultiLayer.BL.Exceptions;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities.DTO;
using MISA.WEB07.TNANH.MultiLayer.Common.Enums;
using MISA.WEB07.TNANH.MultiLayer.DL;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MISA.WEB07.TNANH.MultiLayer.BL
{
    public class OfficerBL : BaseBL<Officer>, IOfficerBL
    {
        #region Field

        private IOfficerDL _officerDL;

        public List<string> Errors = new List<string>();

        #endregion

        #region Constructor

        public OfficerBL(IOfficerDL officerDL) : base(officerDL)
        {
            _officerDL = officerDL;
        }

        #endregion

        #region Methods

        /// <summary>
        /// lấy phân trang
        /// </summary>
        /// <param name="Offset">Ví trí bắt đầu lấy</param>
        /// <param name="Limit">Số nhân viên lấy</param>
        /// <returns>
        /// Số bản ghi giới hạn 
        /// </returns>
        public PagingData GetPagingOfficer(int Offset, int Limit, string condition)
        {
            return _officerDL.GetPagingOfficer(Offset, Limit, condition);
        }

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách ID của các bản ghi cần xóa</param>
        /// <param name="size">Độ dài mảng</param>
        /// <returns>
        /// Số bản ghi bị ảnh hưởng
        /// </returns>
        /// CreatedBy: Trần Nam Anh (8/9/2022)
        public int DeleteManyOfficers(Guid[] ids, int size)
        {
            return _officerDL.DeleteManyOfficers(ids, size);
        }

        /// <summary>
        /// Lấy file excel danh sách cán bộ nhân viên 
        /// </summary>
        /// <param name="Offset">Vị trí bắt đầu lấy</param>
        /// <param name="Limit">Số nhân viên muốn lấy</param>
        /// <param name="filter">Điều kiện</param>
        /// <returns>
        /// File excel danh sách cán bộ nhân viên
        /// </returns>
        /// CreatedBy: Trần Nam Anh (10/9/2022)
        public XLWorkbook GetDownLoad(int Offset, int Limit, string filter)
        {
            using (var wbook = new XLWorkbook())
            {
                //khởi tạo trang tính
                var ws = wbook.Worksheets.Add("Sheet1");

                //lấy giá trị từ Database 
                var OfficerList = _officerDL.GetPagingOfficer(Offset, Limit, filter).Data;

                ///Gán giá trị file Excel
                //j=1, 2: tiêu đề
                ws.Cell(1, 1).Value = "DANH SÁCH CÁN BỘ - GIÁO VIÊN";
                //j=3: tên các cột
                ws.Cell(3, 1).Value = "STT";
                ws.Cell(3, 2).Value = "Số hiệu cán bộ";
                ws.Cell(3, 3).Value = "Họ và tên";
                ws.Cell(3, 4).Value = "Số điện thoại";
                ws.Cell(3, 5).Value = "Tổ chuyên môn";
                ws.Cell(3, 6).Value = "Quản lý thiết bị môn";
                ws.Cell(3, 7).Value = "Quản lý kho - phòng";
                ws.Cell(3, 8).Value = "Đào tạo QLTB";
                ws.Cell(3, 9).Value = "Đang làm việc";
                //j=4: vị trí dòng bắt đầu dữ liệu người dùng
                int j = 1;
                foreach (Officer officer in OfficerList)
                {
                    if (j <= Limit && officer != null)
                    {
                        ws.Cell(j + 3, 1).Value = $"{j}";
                        ws.Cell(j + 3, 2).Value = $"{officer.OfficerCode}";
                        ws.Cell(j + 3, 3).Value = $"{officer.FullName}";
                        ws.Cell(j + 3, 4).Value = $"'{officer.PhoneNumber}";
                        ws.Cell(j + 3, 5).Value = $"{officer.GroupName}";
                        ws.Cell(j + 3, 6).Value = $"{officer.SubjectName}";
                        ws.Cell(j + 3, 7).Value = $"{officer.StorageRoomName}";
                        ws.Cell(j + 3, 8).Value = $"{changeToX(officer.EquipmentManagementTraining)}";
                        ws.Cell(j + 3, 9).Value = $"{changeToX(officer.WorkStatus)}";

                        ws.Cell(j + 3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(j + 3, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        ws.Cell(j + 3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(j + 3, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(j + 3, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        j++;
                    }

                }

                ///style cho file Excel
                //áp dụng style: tiêu đề
                ws.Cell("A1").Style.Font.FontSize = 16;
                ws.Cell("A1").Style.Font.Bold = true;
                ws.Range("A2:I2").Style.Font.FontSize = 16;
                ws.Range("A1:I1").Merge();
                ws.Range("A2:I2").Merge();

                //Áp dụng style: độ rộng cột
                ws.Column("A").Width = 4.22;
                ws.Column("B").Width = 15.22;
                ws.Column("C").Width = 25.89;
                ws.Column("D").Width = 13.22;
                ws.Column("E").Width = 15.22;
                ws.Column("F").Width = 25.89;
                ws.Column("G").Width = 25.89;
                ws.Column("H").Width = 15.22;
                ws.Column("I").Width = 17.22;

                //Áp dụng style: in đậm tên cột và áp dụng màu nền
                ws.Range("A3:I3").Style.Font.Bold = true;
                ws.Range("A3:I3").Style.Fill.BackgroundColor = XLColor.FromColor(Color.Gray);

                //Áp dụng style: căn giữa
                ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range("A3:I3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                //Áp dụng style: table
                var table = ws.Range(3, 1, Limit + 3, 9).CreateTable();
                table.Theme = XLTableTheme.TableStyleLight8;
                ws.Range(3, 1, Limit + 3, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(3, 1, Limit + 3, 9).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                table.ShowTotalsRow = false;

                // Lưu tên file
                wbook.SaveAs("Danh sách cán bộ nhân viên.xlsx");

                return wbook;
            }
        }
        public string changeToX(int? n)
        {
            if (n == 1) return "x";
            else return "";
        }

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>
        /// 1 mã nhân viên mới
        /// </returns>
        public string NewOfficerCode()
        {
            List<Officer> officers = _officerDL.NewOfficerCode();
            double max_officer = 0;
            foreach (var r in officers)
            {
                double officerCode = double.Parse(r.OfficerCode.Substring(4));
                if (officerCode > max_officer) max_officer = officerCode;
            }
            max_officer = max_officer + 1;
            return $"NV{max_officer}";
        }

        protected override void Validate(Method method, Officer officer)
        {
            //Check mã nhân viên bị trống
            if (string.IsNullOrEmpty(officer.OfficerCode))
            {
                Errors.Add("EmptyCode");

            }

            //Check mã nhân viên trùng
            else if (_officerDL.CheckDuplicateCode(method, officer.OfficerCode, officer.OfficerID))
            {
                Errors.Add("DuplicateCode");

            }

            //Check họ tên bị trống
            if (string.IsNullOrEmpty(officer.FullName))
            {
                Errors.Add("OfficerName");
            }

            //Ngày nghỉ việc không được lớn hơn ngày hiện tại
            if (officer.QuitDate > DateTime.Now)
            {
                Errors.Add("Date");
            }

            //Số điện thoại chỉ được chứa các chữ số
            if (IsNumber(officer.PhoneNumber) == false)
            {
                Errors.Add("PhoneNumber");
            }

            //Email không đúng định dạng
            if (IsEmail(officer.Email) == false && !string.IsNullOrEmpty(officer.Email))
            {
                Errors.Add("Email");
            }

            if (Errors.Count > 0)
            {
                throw new ValidateException(Errors);
            }
        }

        #endregion

        #region ValidateProperties

        //kiểm tra số điện thoại có sai định dạng hay không
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        //kiểm tra email có đúng định dạng hay không
        public bool IsEmail(string eValue)
        {
            var email = new EmailAddressAttribute();
            var emailCheck = email.IsValid(eValue);
            return emailCheck;
        }

        #endregion
    }
}
