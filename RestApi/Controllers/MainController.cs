namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MainController : Controller
    {
        private IBaseRepository<Book> _bookRepository { get; set; }
        public MainController(
            IBaseRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public JsonResult GetSomeBooks(int firstItem, int lastItem)
            => new JsonResult(_bookRepository.GetRange(firstItem, lastItem));

        [HttpGet]
        public JsonResult GetAllBooks()
            => new JsonResult(_bookRepository.GetAll());
    }
}
