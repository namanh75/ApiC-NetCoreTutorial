using System.ComponentModel.DataAnnotations;

namespace MISA.WEB07.TNANH.MultiLayer.Common.Entities
{
    /// <summary>
    /// Nhân viên
    /// </summary>
    public class Officer
    {
        #region Property of Officers

        /// <summary>
        /// ID nhân viên
        /// </summary>
        [Key]
        public Guid OfficerID { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        //[Required(ErrorMessage = "e004")]
        public string? OfficerCode { get; set; }

        /// <summary>
        /// Họ và tên nhân viên
        /// </summary>
        //[Required(ErrorMessage = "e005")]
        public string? FullName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Số CMND/CCCD
        /// </summary>
        //[Required(ErrorMessage = "e006")]
        public string? IdentifyNumber { get; set; }

        /// <summary>
        /// Ngày cấp CMND/CCCD
        /// </summary>
        public DateTime? DateGranted { get; set; }

        /// <summary>
        /// Nơi cấp CMND/CCCD
        /// </summary>
        public string? PlaceGranted { get; set; }

        /// <summary>
        /// Địa chỉ email
        /// </summary>
        //[Required(ErrorMessage = "e007")]
        //[EmailAddress(ErrorMessage = "e009")]
        public string? Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        //[Required(ErrorMessage = "e008")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// ID tổ chuyên môn
        /// </summary>
        public Guid? GroupID { get; set; }

        /// <summary>
        /// Tên tổ chuyên môn
        /// </summary>

        public string? GroupName { get; set; }

        /// <summary>
        /// ID môn học
        /// </summary>
        public Guid? SubjectID { get; set; }

        /// <summary>
        /// Tên môn học
        /// </summary>

        public string? SubjectName { get; set; }
        /// <summary>
        /// ID kho phòng
        /// </summary>
        public Guid? StorageRoomID { get; set; }

        /// <summary>
        /// Tên kho phòng
        /// </summary>

        public string? StorageRoomName { get; set; }

        /// <summary>
        /// Đào tạo QLTB
        /// </summary>
        public int? EquipmentManagementTraining { get; set; }

        /// <summary>
        /// Tình trạng làm việc
        /// </summary>
        public int? WorkStatus { get; set; }

        /// <summary>
        /// Ngày nghỉ việc
        /// </summary>
        public DateTime? QuitDate { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa gần nhất
        /// </summary>
        public string? ModifiedBy { get; set; }

        #endregion
    }
}
