using System.ComponentModel.DataAnnotations;

namespace WEBSAIGONGLISTEN.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string? ImageUrl { get; set; }

        public List<ProductImage>? Images { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [Range(0, 10000)]
        public int Quantity { get; set; }

        // Ngày khởi hành
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        // Phương thức để tính số ngày và số đêm
        public string DaysNightsDescription
        {
            get
            {
                int totalDays = (EndDate - StartDate).Days + 1; // Thêm 1 để tính ngày bắt đầu
                int nights = totalDays - 1; // Số đêm là số ngày - 1
                return $"{totalDays} ngày {nights} đêm";
            }
        }

        // Giá cho các nhóm tuổi
        [Range(100000, 5000000)] // Khoảng giá hợp lý cho trẻ dưới 2 tuổi (giả sử giá thấp hơn cho trẻ em)
        public decimal PriceUnder2 { get; set; }

        [Range(200000, 10000000)] // Khoảng giá cho trẻ từ 2 đến 10 tuổi
        public decimal Price2To10 { get; set; }

        [Range(500000, 20000000)] // Khoảng giá cho người trên 10 tuổi
        public decimal PriceAbove10 { get; set; }

        public List<TourDay>? TourDays { get; set; }

        // Tọa độ Google Maps cho địa điểm
        public double? Latitude { get; set; } // Vĩ độ

        public double? Longitude { get; set; } // Kinh độ

        [StringLength(200)]
        public string? Address { get; set; } // Địa chỉ chi tiết

        [StringLength(100)]
        public string? City { get; set; } // Thành phố

        [StringLength(100)]
        public string? Province { get; set; } // Tỉnh/Thành phố

    }
}
