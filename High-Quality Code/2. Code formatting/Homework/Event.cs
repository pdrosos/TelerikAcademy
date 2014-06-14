namespace CodeFormatting
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;

            int compareDate = this.Date.CompareTo(other.Date);
            int compareTitle = this.Title.CompareTo(other.Title);
            int compareLocation = this.Location.CompareTo(other.Location);

            if (compareDate == 0)
            {
                if (compareTitle == 0)
                {
                    return compareLocation;
                }
                else
                {
                    return compareTitle;
                }
            }
            else
            {
                return compareDate;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.Title);

            if (this.Location != null && this.Location != string.Empty)
            {
                toString.Append(" | " + this.Location);
            }

            return toString.ToString();
        }
    }
}