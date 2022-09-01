using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities.DTO;

namespace MISA.WEB07.TNANH.MultiLayer.DL
{
    public interface IOfficerDL : IBaseDL<Officer>
    {
        /// <summary>
        /// Lấy bản ghi thông tin của một cán bộ
        /// </summary>
        /// <param name="OfficerID">ID của cán bộ cần tìm</param>
        /// <returns>
        /// 200 -  Tìm thấy thông tin của cán bộ
        /// 204 -  Không tìm thấy thông tin bản ghi
        /// 500 -  Xảy ra Exception
        /// </returns>
        /// CreatedBy: Trần Nam Anh (19/08/2022)
        public Officer GetOfficerByID(Guid OfficerID);

        /// <summary>
        /// lấy ra danh sách cán bộ nhân viên
        /// </summary>
        /// <param name="Offset">Vị trí bản ghi bắt đầu</param>
        /// <param name="Limit">Số lượng bản ghi</param>
        /// <returns>Danh sách cán bộ nhân viên</returns>
        /// CreatedBy: Tran Nam Anh (22/08/2022)
        //public List<Officers> GetOfficers(int Offset, int Limit);

        /// <summary>
        /// Chèn vào một bản ghi nhân viên
        /// </summary>
        /// <param name="OfficerID">ID của nhân viên cần sửa</param>
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
