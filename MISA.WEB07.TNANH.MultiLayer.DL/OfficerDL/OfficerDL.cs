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
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var sqlCommandGetPaging = "Proc_officer_GetPaging";
                var parameters = new DynamicParameters();
                parameters.Add("@v_Offset", Offset);
                parameters.Add("@v_Limit", Limit);
                parameters.Add("@v_Sort", "");

                if (condition == "1")
                {
                    parameters.Add("@v_Where", "");
                    var res = mySqlConnection.QueryMultiple(sqlCommandGetPaging, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new PagingData
                    {
                        Data = res.Read<Officer>().ToList(),
                        TotalCount = res.Read<int>().Single() - 1
                    };
                }
                else
                {
                    parameters.Add("@v_Where", $"FullName LIKE '%{condition}%' OR OfficerCode LIKE '%{condition}%'");
                    var res = mySqlConnection.QueryMultiple(sqlCommandGetPaging, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new PagingData
                    {
                        Data = res.Read<Officer>().ToList(),
                        TotalCount = res.Read<int>().Single() - 1
                    };
                }

            }

        }

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách ID của các bản ghi cần xóa</param>
        /// <param name="size">Độ dài mảng</param>
        /// <returns>
        /// Số bản ghi bị ảnh hưởng
        /// </returns>
        /// CreatedBy: Trần Nam Anh (8/9/2022)
        public int DeleteManyOfficers(Guid[] ids, int size)
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var sqlCommandDelete = $"DELETE FROM officer WHERE OfficerID IN (";
                for (int i = 0; i < size; i++)
                {
                    if (i != size - 1) sqlCommandDelete += $"'{ids[i]}',";
                    if (i == size - 1) sqlCommandDelete += $"'{ids[i]}'";
                }
                sqlCommandDelete += ")";
                var res = mySqlConnection.Execute(sqlCommandDelete);
                return res;
            }
        }


    }
}

