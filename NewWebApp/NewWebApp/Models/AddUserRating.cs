using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewWebApp.Models
{
    public class AddUserRating
    {
        public string FullName { get; set; }
        public string Score { get; set; }
    }
}
