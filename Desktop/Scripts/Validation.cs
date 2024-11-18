using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Desktop.Scripts
{
    static class Validation
    {
        public static string ValidateUsername(this string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return "Имя пользователя не может быть пустым.";

            if (username.Length < 3)
                return "Имя пользователя должно содержать от 3 до 20 символов.";

            return null;

        }

        public static string ValidateEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return "Электронная почта не может быть пустой.";

            if (!email.Contains("@"))
                return "Электронная почта должна содержать символ '@'.";

            var parts = email.Split('@');
            if (parts.Length != 2)
                return "Электронная почта должна содержать только один символ '@'.";

            if (string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
                return "Электронная почта должна содержать текст до и после '@'.";

            var domainParts = parts[1].Split('.');
            if (domainParts.Length < 2)
                return "Электронная почта должна содержать точку после '@'.";

            if (string.IsNullOrWhiteSpace(domainParts[0]) || string.IsNullOrWhiteSpace(domainParts[1]))
                return "Электронная почта должна содержать текст до и после \".\"";

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(email))
                return "Некорректный формат электронной почты.";

            return null;
        }

        public static string ValidatePassword(this string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return "Пароль не может быть пустым.";

            if (password.Length < 6)
                return "Пароль должен содержать не менее 6 символов.";

            return null;
        }
    }
}

