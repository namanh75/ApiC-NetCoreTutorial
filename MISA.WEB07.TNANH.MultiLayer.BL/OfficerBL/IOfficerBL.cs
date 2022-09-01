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
        public PagingData GetPagingOfficer(int Offset, int Limit);
    }
}
