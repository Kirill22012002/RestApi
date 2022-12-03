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
        public JsonResult GetBooks(int startId, int endId)
            => new JsonResult(_bookRepository.GetRange(startId, endId));
    }
}
