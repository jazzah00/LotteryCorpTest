using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryCorpTest.Controllers {
    [ApiController]
    [Route("Lottery")]
    public class LotteryController : ControllerBase {
        private readonly ILogger<LotteryController> _logger;
        private LotteryTicket _lotto;

        public LotteryController(ILogger<LotteryController> logger) {
            _logger = logger;
            _lotto = new LotteryTicket();
        }

        [HttpGet]
        public string Intro() {
            return "Please add \"/PrintOut/\" to the URL followed by a number, for a pretty print out\n" +
                "Otherwise add \"/Numbers/\" to the URL followed by a number, to see the list of numbers generated.\n\n" +
                "Note: functions generated separate list of numbers for display.\n";
        }
                
        [HttpGet]
        [Route("PrintOut/{games}")]
        public string QuickPickPrintOut(int games) {
            return _lotto.GetLotteryTicketPrintOut(games);
        }

        [HttpGet]
        [Route("Numbers/{games}")]
        public List<List<int>> QuickPrintNumbers(int games) {
            return new LotteryTicket(games).GameTicketNumbers;
        }
    }
}
