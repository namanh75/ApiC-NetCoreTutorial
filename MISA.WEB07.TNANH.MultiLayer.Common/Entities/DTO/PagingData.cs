namespace MISA.WEB07.TNANH.MultiLayer.Common.Entities.DTO
{
    public class PagingData
    {
        /// <summary>
        /// Mảng đổi tượng khi lọc và phân trang
        /// </summary>
        public List<Officer> Data { get; set; } = new List<Officer>();

        /// <summary>
        /// Tổng số bản ghi thỏa mãn điều kiện
        /// </summary>
        public int TotalCount { get; set; }
    }
}
