using MISA.WEB07.TNANH.MultiLayer.BL;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.NTier.BaseControllers;

namespace MISA.WEB07.TNANH.MultiLayer.NTier
{
    public class StorageRoomsController : BaesController<StorageRoom>
    {
        #region Field

        private IStorageRoomBL _storageRoomBL;

        #endregion

        #region Constructor

        public StorageRoomsController(IStorageRoomBL storageroomBL) : base(storageroomBL)
        {
            _storageRoomBL = storageroomBL;
        }

        #endregion

    }
}
