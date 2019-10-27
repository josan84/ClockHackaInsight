using System.Collections.Generic;
using System.Linq;

namespace ClockHackaInsight.Backend.Helpers
{
    public class PanicHelper : IPanicHelper
    {
        private IEnumerable<string> messages = new List<string>
        {
            "If possible, you should stay where you are during a panic attack. As the attack could last up to one hour, you may need to pull over and park where it's safe to do so if driving. Then pause for moment, observe your thoughts and tell yourself that your mind is reacting to these thoughts and anxiety. These feelings are normal - it's just the body's alarm system doing its job when it doesn't need to.",
            "Try to get a slower and more stable breathing rhythm by breathing in for three seconds, holding your breath for two seconds, and then breathing out for three seconds. As you breathe, ensure that your stomach expands as you take each breath as this helps to ensure the breathing isn't shallow, which can add to the problem.",
            "think of a place or situation that makes you feel relaxed or comfortable. Once you have the image in your mind, focus your attention on it and this should distract you from the panic which should then help ease your symptoms."
        };

        public string GetPanicInfoMessage()
        {
            return messages.First();
        }
    }
}
