using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities.DTO;

namespace MISA.WEB07.TNANH.MultiLayer.BL
{
    public interface IOfficerBL : IBaseBL<Officer>
    {
        /// <summary>
        /// Lấy thông tin chi tiết của một nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// Created by: Tran Nam Anh (21/08/2022)
        public Officer GetOfficerByID(Guid employeeID);

        /// <summary>
        /// lấy ra danh sách cán bộ nhân viên
        /// </summary>
        /// <param name="Offset">Vị trí bản ghi bắt đầu</param>
        /// <param name="Limit">Số lượng bản ghi</param>
        /// <returns>Danh sách cán bộ nhân viên</returns>
        /// CreatedBy: Tran Nam Anh (22/08/2022)
        //public List<Officers> GetOfficers(int Offset, int Limit);

        /// <summary>
        /// Thêm mới một nhân viên
        /// </summary>
        /// <param name="officer">Thông tin bản ghi của nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: Tran Nam Anh (22/08/2022)
        public int InsertOfficer(Officer officer);

        /// <summary>
        /// Xóa một nhân viên
        /// </summary>
        /// <param name="OfficerID">ID của nhân viên muốn xóa</param>
        /// <returns>
        /// 200 -  Xóa thành công
        /// 400 -  ID nhân viên không tồn tại
        /// 500 -  Có exception
        /// </returns>
        public int DeleteOfficer(Guid OfficerID);

        /// <summary>
        /// lấy phân trang
        /// </summary>
        /// <param name="Offset">Ví trí bắt đầu lấy</param>
        /// <param name="Limit">Số nhân viên lấy</param>
        /// <returns>
        /// Số bản ghi giới hạn 
        /// </returns>
        public PagingData GetPagingOfficer(int Offset, int Limit);
    }
}
