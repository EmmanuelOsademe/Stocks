using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage="Symbol must not exceed 10 characters")]
        public string Symbol { get; set; } = string.Empty; 
        
        [Required]
        [MaxLength(100, ErrorMessage="Symbol must not exceed 10 characters")]
        public string CompanyName { get; set; } = string.Empty;
        
        [Required]
        [Range(1, 1000000000000)]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage="Industry must not exceed 10 characters")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1, 10000000000000)]
        public long MarketCap { get; set; }
    }
}