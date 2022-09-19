using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities.DTO;

namespace MISA.WEB07.TNANH.MultiLayer.DL
{
    public interface IOfficerDL : IBaseDL<Officer>
    {
        /// <summary>
        /// lấy phân trang
        /// </summary>
        /// <param name="Offset">Ví trí bắt đầu lấy</param>
        /// <param name="Limit">Số nhân viên lấy</param>
        /// <returns>
        /// Số bản ghi giới hạn 
        /// </returns>
        public PagingData GetPagingOfficer(int Offset, int Limit, string condition);

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách ID của các bản ghi cần xóa</param>
        /// <param name="size">Độ dài mảng</param>
        /// <returns>
        /// Số bản ghi bị ảnh hưởng
        /// </returns>
        /// CreatedBy: Trần Nam Anh (8/9/2022)
        public int DeleteManyOfficers(Guid[] ids, int size);

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>
        /// 1 mã nhân viên mới
        /// </returns>
        public List<Officer> NewOfficerCode();

    }
}
