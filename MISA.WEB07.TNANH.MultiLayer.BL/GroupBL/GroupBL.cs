using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.DL;

namespace MISA.WEB07.TNANH.MultiLayer.BL
{
    public class GroupBL : BaseBL<Group>, IGroupBL
    {
        #region Field

        private IGroupDL _groupDL;

        #endregion

        #region Constructor

        public GroupBL(IGroupDL groupDL) : base(groupDL)
        {
            _groupDL = groupDL;
        }

        #endregion
    }
}
