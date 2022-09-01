namespace MISA.WEB07.TNANH.MultiLayer.DL
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        /// CreatedBy: Tran Nam Anh (24/8/2022)
        public IEnumerable<dynamic> GetAllRecords();

        /// <summary>
        /// Lấy thông tin của bản ghi theo ID
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <returns>
        /// Thông tin của bản ghi
        /// </returns>
        public dynamic GetRecordByID(Guid id);

        /// <summary>
        /// Thêm mới môt bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi</param>
        /// <returns>
        /// ID của bản ghi
        /// </returns>
        /// CreatedBy: Tran Nam Anh (30/8/2022)
        public Guid InsertOneRecord(T record);

        /// <summary>
        /// Cập nhật 1 bản ghi
        /// </summary>
        /// <param name="record">Thông tin của bản ghi cần sửa</param>
        /// <returns>
        /// ID của bản ghi được chỉnh sửa
        /// </returns>
        /// CreatedBy: Tran Nam Anh (31/8/2022)
        public int UpdateOneRecord(Guid id, T record);

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần xóa</param>
        /// <returns>
        ///  1 - có một bản ghi bị xóa
        ///  0 - không có bản ghi nào bị xóa
        /// </returns>
        /// CreatedBy: Tran Nam Anh (26/8/2022)
        public int DeleteOneRecord(Guid id);

    }
}
