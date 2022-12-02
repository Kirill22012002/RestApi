namespace RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        {
            var books = new List<Book>();
            int id = startId;
            
            while(true)
            {
                books.Add(_bookRepository.Get(id));
                if (id == endId)
                    break;
                id++;
            }
            return new JsonResult(books);
        }
        [HttpPost]
        public JsonResult SeedMethod()
        {
            var model = new Book()
            {
                Author = "Herman Melville",
                PublishingYear = new DateTime(2002, 5, 20),
                Title = "Moby Dick"
            };

            _bookRepository.Create(model);

            return new JsonResult(true);
        }


        /*[HttpPost]
        public JsonResult Post()
        {
            GetDataService.GetData();
            return new JsonResult("Work was successfully done");
        }
        [HttpPut]
        public JsonResult Put(User user)
        {
            bool success = true;
            var dbUser = Users.Get(user.Id);
            try
            {
                if(dbUser is not null)
                {
                    user = Users.Update(user);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult($"Update successful {user.Id}")
                           : new JsonResult($"Update was not successful"); 
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool success = true;
            var user = Users.Get(id);

            try
            {
                if(user is not null)
                {
                    Users.Delete(user.Id);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult("Delete successful")
                           : new JsonResult("Delete was not successful");
        }*/
    }
}
