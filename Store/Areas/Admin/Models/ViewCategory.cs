using System.ComponentModel.DataAnnotations;

namespace Store.Areas.Admin.Models
{
    public class ViewCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}