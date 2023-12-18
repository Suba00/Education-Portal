using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewWebApp.Models.Domain
{
    public class FileMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string FileName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string FilePath { get; set; }
        // Другие метаданные по необходимости
    }

}
