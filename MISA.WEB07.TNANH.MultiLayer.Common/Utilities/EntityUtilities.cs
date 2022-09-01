﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace MISA.WEB07.TNANH.MultiLayer.Common.Utilities
{
    /// <summary>
    /// Những hàm dùng chung xử lý entity
    /// </summary>
    public static class EntityUtilities
    {
        /// <summary>
        /// Lấy tên bảng của entity
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của entity</typeparam>
        /// <returns>Tên bảng</returns>
        /// Created by: TMSANG (24/08/2022)
        public static string GetTableName<T>()
        {
            string tableName = typeof(T).Name;
            var tableAttributes = typeof(T).GetTypeInfo().GetCustomAttributes<TableAttribute>();
            if (tableAttributes.Count() > 0)
            {
                tableName = tableAttributes.First().Name;
            }
            return tableName;
        }
    }
}
