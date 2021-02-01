using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.FollowupAggregate;

namespace Starks.Infrastructure.TwiiloAdapter
{
    public class TwiiloCalls : IFollowupAdapter
    {
        private void Call(long phonenumber)
        {
            //var response = new VoiceResponse();

            //// Use the <Gather> verb to collect user input
            //response.Gather(new Gather(numDigits: 1)
            //                .Say("For sales, press 1. For support, press 2."));
            //// If the user doesn't enter input, loop
            //response.Redirect("/voice");

            //return TwiML(response);

        }

        public async Task<string> MakeCall(short coutry, long phone)
        {
            const string accountSid = "ACb456fed7ffc3646abd4a511bd1322afe";
            const string authToken = "2c1c26a0be8034990ef04103778c6c1f";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber($"+{coutry}{phone}");
            var from = new PhoneNumber("+5511976255210");
            var call = CallResource.Create(
                to,
                from,
                url: new Uri("http://demo.twilio.com/docs/voice.xml"),
                statusCallback: new Uri("https://prod-07.brazilsouth.logic.azure.com/workflows/b6f5c11c193a4a6b90856d7fc2e85481/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=76AsHVYTJ7hFD_Fv5rP-7i9Mij6kdnQFGFvnWakmEyU"),
                statusCallbackEvent: new List<string> { "initiated", "ringing", "answered", "completed" },
                statusCallbackMethod: HttpMethod.Post
            );

            return call.Sid;
        }
    }
}
