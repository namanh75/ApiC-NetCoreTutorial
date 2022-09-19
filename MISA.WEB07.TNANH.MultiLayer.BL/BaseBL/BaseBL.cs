using MISA.WEB07.TNANH.MultiLayer.Common.Enums;
using MISA.WEB07.TNANH.MultiLayer.DL;

namespace MISA.WEB07.TNANH.MultiLayer.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả các bản ghi</returns>
        /// CreatedBYb: Tran Nam Anh (24/8/2022)
        public virtual IEnumerable<dynamic> GetAllRecords()
        {
            return _baseDL.GetAllRecords();
        }

        /// <summary>
        /// Lấy thông tin của bản ghi theo ID
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <returns>
        /// Thông tin của bản ghi
        /// </returns>
        public dynamic GetRecordByID(Guid id)
        {
            return _baseDL.GetRecordByID(id);
        }

        /// <summary>
        /// Thêm mới môt bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi</param>
        /// <returns>
        /// ID của bản ghi
        /// </returns>
        /// CreatedBy: Tran Nam Anh (30/8/2022)
        public Guid InsertOneRecord(T record)
        {
            Validate(Method.Add, record);
            return _baseDL.InsertOneRecord(record);
        }

        /// <summary>
        /// Cập nhật 1 bản ghi
        /// </summary>
        /// <param name="record">Thông tin của bản ghi cần sửa</param>
        /// <returns>
        /// ID của bản ghi được chỉnh sửa
        /// </returns>
        /// CreatedBy: Tran Nam Anh (1/9/2022)
        public int UpdateOneRecord(Guid id, T record)
        {

            Validate(Method.Edit, record);
            return _baseDL.UpdateOneRecord(id, record);
        }

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần xóa</param>
        /// <returns>
        ///  1 - có một bản ghi bị xóa
        ///  0 - không có bản ghi nào bị xóa
        /// </returns>
        /// CreatedBy: Tran Nam Anh (26/8/2022)
        public int DeleteOneRecord(Guid id)
        {
            return _baseDL.DeleteOneRecord(id);
        }

        protected virtual void Validate(Method method, T record)
        {

        }
        #endregion

    }
}
