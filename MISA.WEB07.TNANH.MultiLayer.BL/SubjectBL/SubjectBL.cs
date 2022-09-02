using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.DL;

namespace MISA.WEB07.TNANH.MultiLayer.BL
{
    public class SubjectBL : BaseBL<Subject>, ISubjectBL
    {
        #region Field

        private ISubjectDL _subjectDL;

        #endregion

        #region Constructor

        public SubjectBL(ISubjectDL subjectDL) : base(subjectDL)
        {
            _subjectDL = subjectDL;
        }

        #endregion
    }
}
