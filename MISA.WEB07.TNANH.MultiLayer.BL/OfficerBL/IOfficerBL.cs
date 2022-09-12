using ClosedXML.Excel;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities.DTO;

namespace MISA.WEB07.TNANH.MultiLayer.BL
{
    public interface IOfficerBL : IBaseBL<Officer>
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
        /// Lấy file excel danh sách cán bộ nhân viên 
        /// </summary>
        /// <param name="Offset">Vị trí bắt đầu lấy</param>
        /// <param name="Limit">Số nhân viên muốn lấy</param>
        /// <param name="filter">Điều kiện</param>
        /// <returns>
        /// File excel danh sách cán bộ nhân viên
        /// </returns>
        /// CreatedBy: Trần Nam Anh (10/9/2022)
        public XLWorkbook GetDownLoad(int Offset, int Limit, string filter);

    }
}
