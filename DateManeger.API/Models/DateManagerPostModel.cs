using System.ComponentModel.DataAnnotations;

namespace DateManager.API.Models
{
    public class DateManagerPostModel
    {
        [Required]
        public string DateValue { get; set; }
        [Required]
        public char Op { get; set; }
        [Required]
        public long Time { get; set; }
    }
}
