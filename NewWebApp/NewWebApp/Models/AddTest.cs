using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewWebApp.Models
{
	public class AddTest
	{
        //[Column(TypeName = "varchar")]
        //[StringLength(20)]
        public string FullName { get; set; }
    }
}
