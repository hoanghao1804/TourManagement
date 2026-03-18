using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBSAIGONGLISTEN.Models
{
    public class UserFavoriteProduct
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.Now;

        [StringLength(500)]
        public string? Notes { get; set; }

        // Foreign keys
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}

