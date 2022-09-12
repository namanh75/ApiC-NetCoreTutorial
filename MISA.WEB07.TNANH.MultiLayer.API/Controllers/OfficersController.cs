using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MISA.WEB07.TNANH.MultiLayer.BL;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.NTier.BaseControllers;
using MISA.WEB07.TNANH.MultiLayer.NTier.Helpers;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.WEB07.TNANH.MultiLayer.NTier
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OfficersController : BaseController<Officer>
    {
        #region Field

        private IOfficerBL _officerBL;

        #endregion

        #region Constructor

        public OfficersController(IOfficerBL officerBL) : base(officerBL)
        {
            _officerBL = officerBL;
        }
        //public string ChangeDataToX(int? data)
        //{
        //    if (data == 1) return "x";
        //    else return "";
        //}

        #endregion

        #region Methods

        /// <summary>
        /// lấy phân trang
        /// </summary>
        /// <param name="Offset">Ví trí bắt đầu lấy</param>
        /// <param name="Limit">Số nhân viên lấy</param>
        /// <returns>
        /// Số bản ghi giới hạn 
        /// </returns> 
        [HttpGet("paging")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(object))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPagingOfficer([FromQuery] int Offset, [FromQuery] int Limit, string filter)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _officerBL.GetPagingOfficer(Offset, Limit, filter));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách ID của các bản ghi cần xóa</param>
        /// <returns>
        /// Số bản ghi bị ảnh hưởng
        /// </returns>
        /// CreatedBy: Trần Nam Anh (8/9/2022)
        [HttpPost("ManyDelete")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(object))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteManyOfficers([FromBody] Guid[] ids, [FromQuery] int size)
        {
            try
            {
                int res = _officerBL.DeleteManyOfficers(ids, size);
                if (res > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, res);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }


        }

        /// <summary>
        /// Lấy file excel danh sách cán bộ nhân viên 
        /// </summary>
        /// <param name="Offset">Vị trí bắt đầu lấy</param>
        /// <param name="Limit">Số nhân viên muốn lấy</param>
        /// <param name="filter">Điều kiện</param>
        /// <returns>
        /// File excel danh sách cán bộ nhân viên
        /// </returns>
        /// CreatedBy: Trần Nam Anh (10/9/2022)
        [HttpGet("export")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(object))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDownLoad([FromQuery] int Offset, [FromQuery] int Limit, string filter)
        {
            try
            {
                XLWorkbook wbook = _officerBL.GetDownLoad(Offset, Limit, filter);
                //Đường dẫn file để gửi đi
                string filePathName = Path.Combine(Directory.GetCurrentDirectory(), "Danh sách cán bộ nhân viên.xlsx");
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(filePathName, out var contentType))
                {
                    contentType = "application/octet-stream";
                }
                //Lấy kích thước file
                var bytes = await System.IO.File.ReadAllBytesAsync(filePathName);
                return File(bytes, contentType, Path.GetFileName(filePathName));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(ex, HttpContext));
            }
        }

        #endregion

    }
}
