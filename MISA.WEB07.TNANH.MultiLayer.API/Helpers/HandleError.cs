﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities.DTO;
using MySqlConnector;
using System.Diagnostics;

namespace MISA.WEB07.TNANH.MultiLayer.NTier.Helpers
{
    /// <summary>
    /// Class static gồm các hàm xử lý lỗi khi gọi API
    /// </summary>
    public static class HandleError
    {
        /// <summary>
        /// Validate 1 entity trả về đối tượng chứa thông tin lỗi
        /// </summary>
        /// <param name="modelState">Đối tượng modelstate hứng được khi gọi API</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        /// Created by: TMSANG (25/08/2022)
        public static ErrorResult? ValidateEntity(ModelStateDictionary modelState, HttpContext httpContext)
        {
            if (!modelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in modelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                var errorResult = new ErrorResult(
                    Common.Enums.CukCukErrorCode.Validate,
                    "Dữ liệu không hợp lệ",
                    errors,
                    "https://openapi.misa.com.vn/errorcode/e002",
                    Activity.Current?.Id ?? httpContext?.TraceIdentifier);

                return errorResult;
            }

            return null;
        }

        /// <summary>
        /// Sinh ra đối tượng lỗi trả về khi gặp exception
        /// </summary>
        /// <param name="exception">Đối tượng exception gặp phải</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        /// Created by: TMSANG (25/08/2022)
        public static ErrorResult? GenerateExceptionResult(Exception exception, HttpContext httpContext)
        {
            Console.WriteLine(exception.Message);
            return new ErrorResult(
                Common.Enums.CukCukErrorCode.Exception,
                "Có lỗi xảy ra. Vui lòng liên hệ MISA!",
                "Catched an exception",
                "https://openapi.misa.com.vn/errorcode/e002",
                Activity.Current?.Id ?? httpContext?.TraceIdentifier);
        }

        /// <summary>
        /// Sinh ra đối tượng lỗi trả về khi gặp lỗi trùng mã
        /// </summary>
        /// <param name="exception">Đối tượng exception gặp phải</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        /// Created by: TMSANG (25/08/2022)
        public static ErrorResult? GenerateDuplicateCodeErrorResult(MySqlException mySqlException, HttpContext httpContext)
        {
            if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
            {
                var errorResult = new ErrorResult(
                    Common.Enums.CukCukErrorCode.DuplicateCode,
                    "Trùng mã",
                    $"{mySqlException.Message}",
                    "https://openapi.misa.com.vn/errorcode/e003",
                    Activity.Current?.Id ?? httpContext?.TraceIdentifier);
                return errorResult;
            }

            Console.WriteLine(mySqlException.Message);
            return new ErrorResult(
                Common.Enums.CukCukErrorCode.Exception,
                "Có lỗi xảy ra. Vui lòng liên hệ MISA!",
                "Catched an exception",
                "https://openapi.misa.com.vn/errorcode/e002",
                Activity.Current?.Id ?? httpContext?.TraceIdentifier);
        }
    }
}
