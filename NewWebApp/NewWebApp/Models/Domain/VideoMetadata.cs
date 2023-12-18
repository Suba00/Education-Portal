using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewWebApp.Models.Domain
{
    public class VideoMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string VideoTitle { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string VideoUrl { get; set; }
    }

}
