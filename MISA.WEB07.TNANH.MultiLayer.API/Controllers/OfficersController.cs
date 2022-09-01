using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.TNANH.MultiLayer.BL;
using MISA.WEB07.TNANH.MultiLayer.Common.Entities;
using MISA.WEB07.TNANH.MultiLayer.NTier.BaseControllers;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.WEB07.TNANH.MultiLayer.NTier
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OfficersController : BaesController<Officer>
    {
        #region Field

        private IOfficerBL _officerBL;

        #endregion

        #region Constructor

        public OfficersController(IOfficerBL officerBL) : base(officerBL)
        {
            _officerBL = officerBL;
        }

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
        public IActionResult GetPagingOfficer([FromQuery] int Offset, [FromQuery] int Limit)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _officerBL.GetPagingOfficer(Offset, Limit));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        #endregion

    }
}
