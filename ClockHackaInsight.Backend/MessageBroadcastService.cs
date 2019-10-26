using Clockwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend
{
    public class MessageBroadcastService
    {
        public void SendMessage()
        {
            string JoshNumber = "447952316758";
            string JacobNumber = "";
            string TobyNumber = "";
            string JoseNumber = "";

            try
            {
                Clockwork.API api = new API("94cb22faffa3f64e4fca84afa78c7b472c97fd9f");
                SMSResult result = api.Send(
                    new SMS
                    {
                        To = JoshNumber,
                        Message = "Hello my love, guess who I am."
                    });

                if (result.Success)
                {
                    Console.WriteLine("SMS Sent to {0}, Clockwork ID: {1}",
                    result.SMS.To, result.ID);
                }
                else
                {
                    Console.WriteLine("SMS to {0} failed, Clockwork Error: {1} {2}",
                    result.SMS.To, result.ErrorCode, result.ErrorMessage);
                }
            }
            catch (APIException ex)
            {
                // You’ll get an API exception for errors
                // such as wrong username or password
                Console.WriteLine("API Exception: " + ex.Message);
            }
            catch (WebException ex)
            {
                // Web exceptions mean you couldn’t reach the Clockwork server
                Console.WriteLine("Web Exception: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                // Argument exceptions are thrown for missing parameters,
                // such as forgetting to set the username
                Console.WriteLine("Argument Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Something else went wrong, the error message should help
                Console.WriteLine("Unknown Exception: " + ex.Message);
            }
        }
    }
}
