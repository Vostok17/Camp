using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translater.UserInfo;

namespace Translater.Behavior
{
    internal static class UnknownKeyHandler
    {
        private const int AttemptsCount = 3;

        public static string Fix(string message)
        {
            for (int i = 0; i < AttemptsCount; i++)
            {
                string answer = UserDialog.Ask(message);
                if (answer is not null)
                    return answer;
            }
            return null;
        }
    }
}
