namespace Phonebook.ConsoleCommands.Sanitizers
{
    using System.Text;

    public class PhoneSanitizer : IPhoneSanitizer
    {
        protected const string Code = "+359";

        public string Sanitize(string phone)
        {
            StringBuilder sanitizedPhone = new StringBuilder();

            foreach (char character in phone)
            {
                if (char.IsDigit(character) || (character == '+'))
                {
                    sanitizedPhone.Append(character);
                }
            }

            if (sanitizedPhone.Length >= 2 && sanitizedPhone[0] == '0' && sanitizedPhone[1] == '0')
            {
                sanitizedPhone.Remove(0, 1);
                sanitizedPhone[0] = '+';
            }

            while (sanitizedPhone.Length > 0 && sanitizedPhone[0] == '0')
            {
                sanitizedPhone.Remove(0, 1);
            }

            if (sanitizedPhone.Length > 0 && sanitizedPhone[0] != '+')
            {
                sanitizedPhone.Insert(0, Code);
            }

            return sanitizedPhone.ToString();
        }
    }
}
