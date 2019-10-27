using ClockHackaInsight.Backend.Models;
using Clockwork;
using System;
using System.Net;

namespace ClockHackaInsight.Backend.Services
{
    public class MessageBroadcastService : IMessageBroadcastService
    {
        const string APIKey = "94cb22faffa3f64e4fca84afa78c7b472c97fd9f";

        const string JoshNumber = "447952316758";
        const string JacobNumber = "447507100781";
        const string TobyNumber = "447498330042";
        const string JoseNumber = "447761389099";

        public void SendMessage()
        {
            Send("Josh", "447952316758", "Hello my love, guess who I am.");
        }

        public void SendMessage(User user, string messageContent)
        {
            Send(user.Name, user.Number, messageContent);
        }

        public void SendMessage(string userName, string userPhoneNumber, string messageContent)
        {
            Send(userName, userPhoneNumber, messageContent);
        }

        private void Send(string userName, string userPhoneNumber, string messageContent)
        {
            try
            {
                var api = new API(APIKey);

                SMSResult result = api.Send(
                    new SMS
                    {
                        To = userPhoneNumber,
                        Message = $"Hello {userName}, {messageContent}",
                        From = "447860033104"
                    }); ;

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
