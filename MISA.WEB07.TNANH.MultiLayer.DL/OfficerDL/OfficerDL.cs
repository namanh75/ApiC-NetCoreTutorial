using Dapper;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities.DTO;
using MySqlConnector;

namespace MISA.WEB07.TNANH.MultiLayer.DL
{
    public class OfficerDL : BaseDL<Officer>, IOfficerDL
    {
        #region Field

        private const string CONNECTION_STRING = "Server=localhost;Port=3306; Database=misa.web07.gd.trannamanh; User Id=root; Password=12345678";

        #endregion

        #region Constructor



        #endregion
        public Officer GetOfficerByID(Guid OfficerID)
        {
            // Khởi tạo kết nối tới DB MySQL
            string connectionString = "Server=localhost;Port=3306; Database=misa.web07.gd.trannamanh; User Id=root; Password=12345678";
            var mySqlConnection = new MySqlConnection(connectionString);
            var sqlCommandGetOfficer = "SELECT * FROM officer WHERE OfficerID=@OfficerID";
            var parameters = new DynamicParameters();
            parameters.Add("@OfficerID", OfficerID);
            var res = mySqlConnection.QueryFirst<Officer>(sqlCommandGetOfficer, parameters);
            return res;
        }

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
            string connectionString = "Server=localhost;Port=3306; Database=misa.web07.gd.trannamanh; User Id=root; Password=12345678";
            var mySqlConnection = new MySqlConnection(connectionString);
            var sqlCommandGetPaging = "Proc_officer_GetPaging";
            var parameters = new DynamicParameters();
            parameters.Add("@v_Offset", Offset);
            parameters.Add("@v_Limit", Limit);
            parameters.Add("@v_Sort", "");
            parameters.Add("@v_Where", "");
            var res = mySqlConnection.QueryMultiple(sqlCommandGetPaging, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return new PagingData
            {
                Data = res.Read<Officer>().ToList(),
                TotalCount = res.Read<int>().Single()
            };
        }



        public int InsertOfficer(Officer officer)
        {
            string connectionString = "Server=localhost;Port=3306; Database=misa.web07.gd.trannamanh; User Id=root; Password=12345678";
            var mySqlConnection = new MySqlConnection(connectionString);
            var sqlCommand = "INSERT INTO officer (OfficerID, OfficerCode, FullName, DateOfBirth, Gender, IdentityNumber, GrantedDay, GrantedPlace, Email, PhoneNumber, GroupID, GroupName, SubjectID, SubjectName,StorageRoomID, StorageRoomName, EquipmentManagementTraining, WorkStatus, QuitDate, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy )" +
                "VALUES(@OfficerID, @OfficerCode, @FullName, @DateOfBirth, @Gender, @IdentityNumber, @GrantedDay, @GrantedPlace, @Email, @PhoneNumber, @GroupID, @GroupName, @SubjectID, @SubjectName,@StorageRoomID, @StorageRoomName, @EquipmentManagementTraining, @WorkStatus, @QuitDate, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy); ";
            var officerID = Guid.NewGuid();
            var parameters = new DynamicParameters();
            parameters.Add("@OfficerID", officerID);
            parameters.Add("@OfficerCode", officer.OfficerCode);
            parameters.Add("@FullName", officer.FullName);
            parameters.Add("@DateOfBirth", officer.DateOfBirth);
            parameters.Add("@Gender", officer.Gender);
            parameters.Add("@IdentityNumber", officer.IdentifyNumber);
            parameters.Add("@GrantedDay", officer.DateGranted);
            parameters.Add("@GrantedPlace", officer.PlaceGranted);
            parameters.Add("@Email", officer.Email);
            parameters.Add("@PhoneNumber", officer.PhoneNumber);
            parameters.Add("@GroupID", "");
            parameters.Add("@GroupName", officer.GroupName);
            parameters.Add("@SubjectID", "");
            parameters.Add("@SubjectName", officer.SubjectName);
            parameters.Add("@StorageRoomID", "");
            parameters.Add("@StorageRoomName", officer.StorageRoomName);
            parameters.Add("@EquipmentManagementTraining", officer.EquipmentManagementTraining);
            parameters.Add("@WorkStatus", officer.WorkStatus);
            parameters.Add("@QuitDate", officer.QuitDate);
            parameters.Add("@CreatedDate", officer.CreatedDate);
            parameters.Add("@CreatedBy", officer.CreatedBy);
            parameters.Add("@ModifiedDate", officer.ModifiedDate);
            parameters.Add("@ModifiedBy", officer.ModifiedBy);
            int res = mySqlConnection.Execute(sqlCommand, parameters);
            return res;
        }

        public int DeleteOfficer(Guid OfficerID)
        {
            string connectionString = "Server=localhost;Port=3306; Database=misa.web07.gd.trannamanh; User Id=root; Password=12345678";
            var mySqlConnection = new MySqlConnection(connectionString);
            var sqlCommandDeleteOfficer = "DELETE FROM officer WHERE OfficerID = @OfficerID";
            var parameters = new DynamicParameters();
            parameters.Add("@OfficerID", OfficerID);
            int res = mySqlConnection.Execute(sqlCommandDeleteOfficer, parameters);
            return res;
        }

    }
}
