using System.Data.Linq;

namespace DataModul.DomainModel
{
    public class Image
    {
        public int ImageId { get; set; }
        public Binary ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public int ProductId { get; set; }
    }
}