using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewWebApp.Models
{
    public class AddFileMetadata
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
