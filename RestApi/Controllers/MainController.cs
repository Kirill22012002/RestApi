
namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MainController : Controller
    {
        private IBaseRepository<Book> _bookRepository { get; set; }
        private readonly IMapper _mapper;
        public MainController(
            IBaseRepository<Book> bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public List<BookViewModel> GetSomeBooks(int firstItem, int lastItem)
            => _mapper.Map<List<BookViewModel>>(_bookRepository.GetRange(firstItem, lastItem));

        [HttpGet]
        public List<BookViewModel> GetAllBooks()
            => _mapper.Map<List<BookViewModel>>(_bookRepository.GetAll());
    }
}
