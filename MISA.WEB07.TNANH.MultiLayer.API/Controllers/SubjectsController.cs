using MISA.WEB07.TNANH.MultiLayer.BL;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.NTier.BaseControllers;

namespace MISA.WEB07.TNANH.MultiLayer.NTier
{
    public class SubjectsController : BaseController<Subject>
    {
        #region Field

        private ISubjectBL _subjectBL;

        #endregion

        #region Constructor
        public SubjectsController(ISubjectBL subjectBL) : base(subjectBL)
        {
            _subjectBL = subjectBL;
        }

        #endregion
    }
}
