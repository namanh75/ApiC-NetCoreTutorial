namespace MISA.WEB07.TNANH.MultiLayer.Common.Entities
{
    public class StorageRoom
    {
        #region Property of StorageRoom

        /// <summary>
        /// ID kho phòng
        /// </summary>
        public Guid StorageRoomID { get; set; }

        /// <summary>
        /// Mã kho phòng
        /// </summary>
        public string StorageRoomCode { get; set; }

        /// <summary>
        /// Tên kho phòng
        /// </summary>
        public string StorageRoomName { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa gần nhất
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa gần nhất
        /// </summary>
        public string ModifiedBy { get; set; }

        #endregion
    }
}
