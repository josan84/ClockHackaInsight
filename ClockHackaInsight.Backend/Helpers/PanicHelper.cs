using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.
    Services;

namespace ClockHackaInsight.Backend.Helpers
{
    public class PanicHelper : IPanicHelper
    {
        private IUserService _userService;
        private IEnumerable<string> messages = new List<string>
        {
            "Pause for moment, observe your thoughts and tell yourself that your mind is reacting to these thoughts and anxiety.",
            "Try to get a slower and more stable breathing rhythm by breathing in for three seconds, holding your breath for two seconds, and then breathing out for three seconds. As you breathe, ensure that your stomach expands as you take each breath as this helps to ensure the breathing isn't shallow, which can add to the problem.",
            "think of a place or situation that makes you feel relaxed or comfortable. Once you have the image in your mind, focus your attention on it and this should distract you from the panic which should then help ease your symptoms."
        };

        private readonly Dictionary<int, string> grounding = new Dictionary<int, string>();

        public PanicHelper(IUserService userService)
        {
            grounding.Add(1, "Reply HELP with 1 thing you can smell");
            grounding.Add(2, "Reply HELP with 2 things you can taste");
            grounding.Add(3, "Reply HELP with 3 things you can feel");
            grounding.Add(4, "Reply HELP with 4 things you can hear");
            grounding.Add(5, "Reply HELP with 5 things you can see");
            _userService = userService;
        }

        public string GetPanicInfoMessage()
        {
            return messages.First();
        }

        public async Task<string> GroundMe(User user)
        {
            if(user.GroundingExercise == null)
            {
                user.GroundingExercise = new GroundingExercise { Number = 1 };
            }

            user.GroundingExercise.Active = true;
            user.GroundingExercise.Number = user.GroundingExercise.Number + 1;

            if(user.GroundingExercise.Number > 5)
            {
                user.GroundingExercise.Number = 1;
            }

            await _userService.SaveUser(user.Id, user);

            return grounding[user.GroundingExercise.Number];
        }
    }
}
