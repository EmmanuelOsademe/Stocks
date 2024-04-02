using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> 9baac7698b0b5d369a45897dcb8ebbf5e2b0a8c6

namespace api.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
<<<<<<< HEAD
        
=======
        [Required]
        [MinLength(5, ErrorMessage="Title must be at least 5 characters")]
        [MaxLength(280, ErrorMessage="Title must not exceed 280 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage="Content must be at least 5 characters")]
        [MaxLength(280, ErrorMessage="Content must not exceed 280 characters")]
        public string Content { get; set; } = string.Empty;
>>>>>>> 9baac7698b0b5d369a45897dcb8ebbf5e2b0a8c6
    }
}