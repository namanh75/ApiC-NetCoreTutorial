using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.DL;

namespace MISA.WEB07.TNANH.MultiLayer.BL
{
    public class StorageRoomBL : BaseBL<StorageRoom>, IStorageRoomBL
    {
        #region Field

        private IStorageRoomDL _storageroomDL;

        #endregion

        #region Constructor

        public StorageRoomBL(IStorageRoomDL storageroomDL) : base(storageroomDL)
        {
            _storageroomDL = storageroomDL;
        }

        #endregion
    }
}
