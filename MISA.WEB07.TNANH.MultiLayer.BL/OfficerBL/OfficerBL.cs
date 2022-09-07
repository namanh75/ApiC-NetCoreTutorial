using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities.DTO;
using MISA.WEB07.TNANH.MultiLayer.DL;

namespace MISA.WEB07.TNANH.MultiLayer.BL
{
    public class OfficerBL : BaseBL<Officer>, IOfficerBL
    {
        #region Field

        private IOfficerDL _officerDL;

        #endregion

        #region Constructor

        public OfficerBL(IOfficerDL officerDL) : base(officerDL)
        {
            _officerDL = officerDL;
        }

        #endregion

        #region Methods

        /// <summary>
        /// lấy phân trang
        /// </summary>
        /// <param name="Offset">Ví trí bắt đầu lấy</param>
        /// <param name="Limit">Số nhân viên lấy</param>
        /// <returns>
        /// Số bản ghi giới hạn 
        /// </returns>
        public PagingData GetPagingOfficer(int Offset, int Limit, string condition)
        {
            return _officerDL.GetPagingOfficer(Offset, Limit, condition);
        }

        /// <summary>
        /// Danh sách nhân viên có chứa chuỗi trong ô tìm kiếm
        /// </summary>
        /// <param name="OfficerString">Chuỗi được nhập trong ô tìm kiếm</param>
        /// <returns>
        /// Danh sách nhân viên
        /// </returns>
        /// CreatedBy: Trần Nam Anh (7/9/2022)

        #endregion
    }
}
