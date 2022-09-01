using Dapper;
using MySqlConnector;
using System.ComponentModel.DataAnnotations;

namespace MISA.WEB07.TNANH.MultiLayer.DL
{
    public class BaseDL<T> : IBaseDL<T>
    {
        #region Feild

        #endregion

        #region Methods
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        /// CreatedBy: Tran Nam Anh (24/8/2022)
        public IEnumerable<dynamic> GetAllRecords()
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                string className = typeof(T).Name;
                var sqlCommandGetAllRecords = $"Proc_{className.ToLower()}_Get{className}s";
                var res = mySqlConnection.Query(sqlCommandGetAllRecords, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }

        /// <summary>
        /// Lấy thông tin của bản ghi theo ID
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <returns>
        /// Thông tin của bản ghi
        /// </returns>
        public dynamic GetRecordByID(Guid id)
        {

            var className = typeof(T).Name;
            var sqlCommadGetRecordByID = $"Proc_{className.ToLower()}_Get{className}ByID";
            var parameters = new DynamicParameters();
            parameters.Add($"@v_{className}ID", id);
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var result = mySqlConnection.Query(sqlCommadGetRecordByID, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Thêm mới môt bản ghi
        /// </summary>
        /// <param name="record">Thông tin bản ghi</param>
        /// <returns>
        /// ID của bản ghi
        /// </returns>
        /// CreatedBy: Tran Nam Anh (30/8/2022)
        public Guid InsertOneRecord(T record)
        {
            // Khai báo tên stored procedure INSERT
            string tableName = typeof(T).Name.ToLower();
            string insertStoredProcedureName = $"Proc_{tableName}_Insert{tableName.Substring(0, 1).ToUpper()}{tableName.Substring(1)}";

            // Chuẩn bị tham số đầu vào của stored procedure
            var properties = typeof(T).GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                string propertyName = $"@v_{property.Name}";
                var propertyValue = property.GetValue(record); // Đọc vào object record --> lấy được value của property tên là DepartmentCode
                parameters.Add(propertyName, propertyValue);
            }

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure với tham số đầu vào ở trên
            int numberOfAffectedRows = 0;
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                numberOfAffectedRows = mySqlConnection.Execute(insertStoredProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                var result = Guid.Empty;
                if (numberOfAffectedRows > 0)
                {

                    var primaryKeyProperty = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0);
                    var newId = primaryKeyProperty?.GetValue(record);
                    if (newId != null)
                    {
                        result = (Guid)newId;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Cập nhật 1 bản ghi
        /// </summary>
        /// <param name="record">Thông tin của bản ghi cần sửa</param>
        /// <returns>
        /// ID của bản ghi được chỉnh sửa
        /// </returns>
        /// CreatedBy: Tran Nam Anh (31/8/2022)
        public int UpdateOneRecord(Guid id, T record)
        {
            string className = typeof(T).Name.ToLower();
            var sqlCommandUpdate = $"Proc_{className}_Update{className.Substring(0, 1).ToUpper()}{className.Substring(1)}";

            var properties = typeof(T).GetProperties();
            var parameters = new DynamicParameters();

            foreach (var property in properties)
            {
                string propertyName = $"@v_{property.Name}";
                var propertyValue = property.GetValue(record); // Đọc vào object record --> lấy được value của property tên là DepartmentCode
                parameters.Add(propertyName, propertyValue);
            }

            int numberOfAffectedRows = 0;
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                numberOfAffectedRows = mySqlConnection.Execute(sqlCommandUpdate, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return numberOfAffectedRows;
            }
        }

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần xóa</param>
        /// <returns>
        ///  1 - có một bản ghi bị xóa
        ///  0 - không có bản ghi nào bị xóa
        /// </returns>
        /// CreatedBy: Tran Nam Anh (26/8/2022)
        public int DeleteOneRecord(Guid id)
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {

                string className = typeof(T).Name.ToLower();
                var sqlCommanDeleteRecord = $"Proc_{className}_Delete{className.Substring(0, 1).ToUpper()}{className.Substring(1)}";
                var parameters = new DynamicParameters();
                parameters.Add($"v_{className.Substring(0, 1).ToUpper()}{className.Substring(1)}ID", id);
                var res = mySqlConnection.Query(sqlCommanDeleteRecord, parameters, commandType: System.Data.CommandType.StoredProcedure);
                int TotolCount = 0;
                if (res != null) TotolCount = 1;
                return TotolCount;
            }
        }

        #endregion
    }
}
