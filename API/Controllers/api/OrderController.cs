using lw.Domain.Models;
using lw.Domain.Models.ApiResponse;
using Microsoft.EntityFrameworkCore;

namespace lw.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly AppDbContext _appDbContext;
    private readonly IRepository<GCConfig> _gccConfigRepo;
    private readonly IRepository<Help> _helpRepo;

    public OrderController(ILogger<OrderController> logger,
        AppDbContext appDbContext)
    {
        _logger = logger;
        _appDbContext = appDbContext;
        _gccConfigRepo = new Repository<GCConfig>(appDbContext);
        _helpRepo = new Repository<Help>(appDbContext);
    }

    [HttpPost("config")]
    public ApiResponse Config([FromBody] BaseRequest request)
    {
        var config = _gccConfigRepo.Where(c => c.LINE == 514 || c.LINE == 515);
        //the below need to be replaced by config table
        //var config = _helpRepo.Where(h => h.SEQ == 1 || h.SEQ == 2).Select(h => new
        //{
        //    LINE = h.TOPIC,
        //    NO = h.SEQ,
        //    LINETEXT = h.INFO
        //}).ToList();

        return new ApiResponse
        {
            meta = new Meta
            {
                status = "OK"
            },
            response = new
            {
                status = "OK",
                config = config
            }
        };
    }
    [HttpPut("config/update")]
    public ApiResponse ConfigUpdate([FromBody] BaseRequest request)
    {
        return new ApiResponse();
    }
    [HttpDelete("config/delete")]
    public ApiResponse ConfigDelete([FromBody] BaseRequest request)
    {
        return new ApiResponse();
    }
    [HttpPut("save")]
    public ApiResponse Save([FromBody] OrderRequest request)
    {
        foreach (var line in request.items)
        {
            //do something
        }
        return new ApiResponse
        {
            meta = new Meta
            {
                status = "OK"
            },
            response = new
            {
                status = "OK",
                orderDetails = request
            }
        };
    }
    [HttpGet("print")]
    public object PrintMe()
    {
        string sql = "Select TOPIC, SEQ, INFO from HELP where INFO IS NOT NULL fetch  first 10 rows only";
        var printList = this._appDbContext.SqlQuery<Print>(sql, x => new Print
        {
            text = x[0].ToString(),
            style = x[1].ToString(),
            type = x[2].ToString()
        });
        string sql1 = "Select TOPIC, SEQ, INFO from HELP where INFO IS NOT NULL and TOPIC='CONNECT'";
        var helpList = this._appDbContext.SqlQuery<Print>(sql1, x => new Print
        {
            text = x[0].ToString(),
            style = x[1].ToString(),
            type = x[2].ToString()
            //TOPIC = x[0].ToString(),
            //SEQ = (decimal)x[1],
            //INFO = x[2].ToString()
        });
        printList.AddRange(helpList);
        return new
        {
            meta = new
            {
                status = "OK"
            },
            response = printList
        };
    }
    #region this is just for testing
    [HttpGet("get-help")]
    public List<Help> GetHelp(string topic = "")
    {
        if (topic != "")
        {
            return this._helpRepo.Where(h => h.TOPIC == topic).ToList();
        }
        return _helpRepo.GetAll().ToList();
    }
    [HttpGet("get-topic-List-from-query")]
    public string GetTopicListFromQuery(string topic = "")
    {
        string sql = "Select INFO from HELP where TOPIC='" + topic + "' and INFO IS NOT NULL";
        var list = this._appDbContext.SqlQuery<string>(sql, x => (x[0] != null ? x[0].ToString() : ""));
        return list[0];
    }
    [HttpGet("update-topic")]
    public void UpdateTopic(string topic, int Seq, string info)
    {
        string sql = $"Update HELP set INFO='{info}' where TOPIC='{topic}' and SEQ={Seq}";
        this._appDbContext.ExecuteQuery(sql);
    }
    [HttpPut("insert-help")]
    public Help InsertHelp([FromBody] Help help)
    {
        this._helpRepo.Add(help);
        this._helpRepo.SaveChanges();
        return help;
    }
    [HttpPut("update-help")]
    public Help UpdateHelp([FromBody] Help help)
    {
        var dbhelp = this._helpRepo.GetSingleOrDefault(h => h.TOPIC == help.TOPIC);
        dbhelp.SEQ = help.SEQ;
        dbhelp.INFO = help.INFO;
        this._helpRepo.SaveChanges();
        return help;
    }
    #endregion
}