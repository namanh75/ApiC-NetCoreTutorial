namespace MISA.WEB07.TNANH.MultiLayer.Common.Entities
{
    public class Group
    {
        #region Property of Groups

        /// <summary>
        /// ID tổ chuyên môn
        /// </summary>
        public Guid GroupID { get; set; }

        /// <summary>
        /// Mã tổ chuyên môn
        /// </summary>
        public string GroupCode { get; set; }

        /// <summary>
        /// Tên tổ chuyên môn
        /// </summary>
        public string GroupName { get; set; }

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
