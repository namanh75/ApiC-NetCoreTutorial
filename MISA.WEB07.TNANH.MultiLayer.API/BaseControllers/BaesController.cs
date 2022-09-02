using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.TNANH.MultiLayer.BL;
using MISA.WEB07.TNANH.MultiLayer.NTier.Helpers;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.WEB07.TNANH.MultiLayer.NTier.BaseControllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaesController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _baseBL;


        #endregion

        #region Constructor

        public BaesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method

        /// <summary>
        /// API Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        /// Created by: Tran Nam Anh (30/8/2022)
        [HttpGet]
        public virtual IActionResult GetAllRecords()
        {
            try
            {
                var res = _baseBL.GetAllRecords();
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (MySqlException mySqlException)
            {
                Console.WriteLine(mySqlException);
                return StatusCode(StatusCodes.Status400BadRequest, mySqlException);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        /// <summary>
        /// Lấy thông tin bản ghi theo ID
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <returns>
        /// Thông tin của bản ghi
        /// </returns>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(object))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public virtual IActionResult GetRecordByID([FromRoute] Guid id)
        {
            try
            {
                var result = _baseBL.GetRecordByID(id);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MySqlException mySqlException)
            {
                Console.WriteLine(mySqlException);
                return StatusCode(StatusCodes.Status400BadRequest, mySqlException);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
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
        [HttpPost]
        public virtual IActionResult InsertOneRecord([FromBody] T record)
        {
            try
            {
                var validateResult = HandleError.ValidateEntity(ModelState, HttpContext);
                if (validateResult != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validateResult);
                }
                var recordID = _baseBL.InsertOneRecord(record);

                if (recordID != Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status201Created, recordID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e004");

                }
            }
            catch (MySqlException mySqlException)
            {
                Console.WriteLine(mySqlException);
                return StatusCode(StatusCodes.Status400BadRequest, mySqlException);

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        /// <summary>
        /// Cập nhật thông tin 1 bản ghi
        /// </summary>
        /// <param name="record">Thông tin của bản ghi</param>
        /// <returns>
        /// ID của bản ghi
        /// </returns>
        /// CreateBy: Tran Nam ANnh (1/9/2022)
        [HttpPut("{id}")]
        public virtual IActionResult UpdateOneRecord([FromRoute] Guid id, [FromBody] T record)
        {
            try
            {
                var validateResult = HandleError.ValidateEntity(ModelState, HttpContext);
                if (validateResult != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validateResult);
                }
                int result = _baseBL.UpdateOneRecord(id, record);
                if (result > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, id);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e004");
                }
            }
            catch (MySqlException mySqlException)
            {
                Console.WriteLine(mySqlException);
                return StatusCode(StatusCodes.Status400BadRequest, mySqlException);

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần xóa</param>
        /// <returns>
        ///  ID của bản ghi bị xóa
        /// </returns>
        /// CreatedBy: Tran Nam Anh (26/8/2022)
        [HttpDelete("{id}")]
        public virtual IActionResult DeleteOneRecord([FromRoute] Guid id)
        {
            try
            {
                int res = _baseBL.DeleteOneRecord(id);
                if (res > 0) return StatusCode(StatusCodes.Status200OK, id);
                else return StatusCode(StatusCodes.Status400BadRequest, "e002");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        #endregion
    }
}
