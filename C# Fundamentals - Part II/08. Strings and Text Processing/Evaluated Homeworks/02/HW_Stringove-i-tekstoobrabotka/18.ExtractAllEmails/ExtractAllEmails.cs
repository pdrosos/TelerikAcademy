//Write a program for extracting all email addresses from given text. 
//All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ExtractAllEmails
{
    static void Main()
    {
        string input = "В миналото много пощенски proba@bg-linux.org сървъри приемат съобщения за всеки получател в Интернет, опитвайки се да ги доставят до него. Те играят важна роля в първите години на Интернет, когато мрежовите връзки се относително ненадеждни. Когато даден пощенски сървър не успее да се свърже със test@test.tr сървъра на получателя, той може да се опита да достави съобщението на такъв отворен сървър, по-близък до крайния получател, който от своя страна има по-добри шансове stavri@oohay.com да се свърже с него в по-късен момент. Този gosho@mailg.com механизъм на предаване се оказва силно уязвим за разпространение на спам, поради което днес pesho@vba.bg приложението му е ограничено.";
        string pattern = @"\w*@\w*.\w{2,3}";
        Match match = Regex.Match(input, pattern);
        while (match.Success)
        {
            Console.WriteLine(match);
            match = match.NextMatch();
        }
    }
}