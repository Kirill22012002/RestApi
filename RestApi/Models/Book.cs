
namespace RestApi.Models
{
    public class Book : BaseModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishingYear { get; set; } = new DateTime();
    }
}
