using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backender.Model;
using Microsoft.VisualBasic;
using Backender.AppDbContext;
using Backender.DTOs;

namespace Backender.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        /* private readonly HttpClient _httpClient;
         private readonly IHttpContextAccessor _contextAccessor;
         private readonly ILogger<Controller> _logger;
         private readonly IConfiguration _configuration;
         private readonly IHostEnvironment _hostEnvironment;
         private readonly IOptionsMonitor<SomeOptions> _optionsMonitor;
         private readonly IDistributedCache _distributedCache;
         private readonly IMemoryCache _memoryCache;
         private readonly IMapper _mapper;
         private readonly IEmailSender _emailSender;
         private readonly IFileProvider _fileProvider;
         private readonly IBackgroundTaskQueue _backgroundTaskQueue;
         private readonly IHubContext<SomeHub> _hubContext;
         private readonly IAuthorizationService _authorizationService;
         private readonly IStringLocalizer<Controller> _localizer;
         private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;
         private readonly IModelBinderFactory _modelBinderFactory;
         private readonly IObjectModelValidator _objectModelValidator;
         private readonly IUrlHelper _urlHelper;
         private readonly IApiExplorer _apiExplorer;
         private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
         private readonly IPageFactory _pageFactory;
         private readonly IViewComponentFactory _viewComponentFactory;
         private readonly IViewFactory _viewFactory;
         private readonly IViewRenderer _viewRenderer;
         private readonly IViewStartFactory _viewStartFactory;
         private readonly DbContext _context; */
        private readonly AppDbContexts _context; private readonly HttpClient _httpClient;
        //private readonly IConfiguration _configuration;
        //private readonly ILogger<Controller> _logger; //private readonly IMapper _mapper;
        //private readonly IHostEnvironment _hostEnvironment; private readonly IEmailSender _emailSender;

        public MessageController(HttpClient httpClient, AppDbContexts context) {  
            //IConfiguration configuration, IHostEnvironment hostEnvironment, IEmailSender emailSender
            
            _httpClient = httpClient;
            _context = context;
            //_configuration = configuration;
            //_logger = logger;
            //_hostEnvironment = hostEnvironment;
            //_emailSender = emailSender;
        }
        //ILogger<Controller> logger, 


        [HttpPost("create-profile")]
        public async Task<IActionResult> CreateAccountToSendMessage([FromBody] CreateAccountDTO ACD) 
        {
            var user = new UsersChat
            {
                Id = ACD.Id,
                UserName = ACD.UserName,
                BirthDate = ACD.BirthDate   
            };
            if(user.Age < 18)
            {
                return BadRequest(new { message = "Idade mínima para criar uma conta é 18 anos. Lei Felca :b" });
            }
            await _context.UsersOfUsersChat.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Conta criada com sucesso!", age = user.Age });
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> message_sender(MessageDTO msg)
        {
            {
                if (!int.TryParse(msg.IdSender, out var idSender) ||
                    !int.TryParse(msg.IdReceiver, out var idReceiver))
                {
                    return BadRequest("IdSender e IdReceiver devem ser inteiros.");
                }

                var senderExists = await _context.UsersOfUsersChat.AnyAsync(u => u.Id == idSender);
                if (!senderExists)
                {
                    return BadRequest("Sender not found.");
                }

                var receiverExists = await _context.UsersOfUsersChat.AnyAsync(u => u.Id == idReceiver);
                if (!receiverExists)
                {
                    return BadRequest("Receiver not found.");
                }

                var user = new UsersChat { };

                var message = new UserEntity
                {
                    Message = msg.Message,
                    IdSender = idSender,
                    IdReceiver = idReceiver,
                    CreatedAt = DateTime.UtcNow.AddHours(-3), 
                    Message_Receiver = ""
                };
                
                await _context.MessagesOfUsersChat.AddAsync(message);

                await _context.SaveChangesAsync();

                return Ok(new { message_sender = "Mensagem enviada com sucesso!" });
            }
        }

        [HttpDelete("delete-message/{id_message}")]
        public async Task<IActionResult> message_deleter(int id_message, int userId)
        {
            var message = await _context.MessagesOfUsersChat.FirstOrDefaultAsync(m => m.Id == id_message);
            var userExists = await _context.UsersOfUsersChat.AnyAsync(u => u.Id == userId);

            if (message == null)
            {
                return BadRequest("Message not found.");
            }
            if (!userExists)
            {
                return BadRequest("User not found.");
            }

            _context.MessagesOfUsersChat.Remove(message);
            await _context.SaveChangesAsync();

            return Ok(new { message_deleter = "Mensagem deletada com sucesso!", message });
        }

        [HttpGet("get-messages")]
        public async Task<IActionResult> message_getter(int MyId, int MessageId)
        {
            var messages = await _context.MessagesOfUsersChat.FirstOrDefaultAsync(m => m.Id == MessageId);
            var userExists = await _context.UsersOfUsersChat.AnyAsync(u => u.Id == MyId);
            if (messages == null)
            {
                return BadRequest("Message not found.");
            }
            if (!userExists)
            {
                return BadRequest("User not found.");
            }

            return Ok(new { message_getter = messages,  });
        }

        [HttpGet("get-all-message-by-id/{id_wanted}")]
        public async Task<IActionResult> message_getter_all_by_id(int id_wanted)
        {
            var message = await _context.MessagesOfUsersChat.Where(m => m.IdSender == id_wanted || m.IdReceiver == id_wanted).ToListAsync();
            if (message == null)
            {
                return BadRequest("Message not found.");
            }

            return Ok(new { message_getter_all_by_id = message });
        }
    }
}