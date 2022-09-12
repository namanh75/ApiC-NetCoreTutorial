using MISA.WEB07.TNANH.MultiLayer.BL;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.NTier.BaseControllers;
namespace MISA.WEB07.TNANH.MultiLayer.NTier
{
    public class GroupsController : BaseController<Group>
    {
        #region Field

        private IGroupBL _groupBL;

        #endregion

        #region Constructor

        public GroupsController(IGroupBL groupBL) : base(groupBL)
        {
            _groupBL = groupBL;
        }

        #endregion
    }
}
