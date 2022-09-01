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
        public PagingData GetPagingOfficer(int Offset, int Limit)
        {
            return _officerDL.GetPagingOfficer(Offset, Limit);
        }
        public Officer GetOfficerByID(Guid OfficerID)
        {
            return _officerDL.GetOfficerByID(OfficerID);
        }

        public int InsertOfficer(Officer officer)
        {
            //validate 

            //if validate success
            int res = _officerDL.InsertOfficer(officer);
            return res;
        }

        public int DeleteOfficer(Guid OfficerID)
        {
            int res = _officerDL.DeleteOfficer(OfficerID);
            return res;
        }
        #endregion
    }
}
