namespace MobilePhones.Library.Software
{
    using System;
    using System.Text;

    public class Call
    {
        private readonly DateTime dateAndTime;
        private readonly string dialedPhoneNumber;
        private readonly uint duration;

        public Call(DateTime dateAndTime, string dialedPhoneNumber, uint duration)
        {
            if (string.IsNullOrEmpty(dialedPhoneNumber))
            {
                throw new ArgumentException("Dialed phone number can not be empty");
            }

            this.dateAndTime = dateAndTime;
            this.dialedPhoneNumber = dialedPhoneNumber;
            this.duration = duration;
        }

        public DateTime DateAndTime
        {
            get
            {
                return this.dateAndTime;
            }
        }

        public string DialedPhoneNumber
        {
            get
            {
                return this.dialedPhoneNumber;
            }
        }

        /// <summary>
        /// Call duration in minutes
        /// </summary>
        public decimal Duration
        {
            get
            {
                return Math.Round((decimal)this.duration / 60, 2);
            }
        }

        /// <summary>
        /// Call duration in human readable format: mm:ss
        /// </summary>
        public string HumanReadableDuration
        {
            get
            {
                return this.duration / 60 + ":" + this.duration % 60;
            }
        }

        /// <summary>
        /// Calculates call price. Each started minute is charged.
        /// </summary>
        /// <param name="pricePerMinute"></param>
        /// <returns></returns>
        public decimal GetPrice(decimal pricePerMinute)
        {
            return Math.Round(Duration * pricePerMinute, 2);
        }

        /// <summary>
        /// Call info
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder callInfo = new StringBuilder();

            callInfo.Append("Date and time: ").Append(this.DateAndTime).AppendLine();
            callInfo.Append("Dialed phone number: ").Append(this.DialedPhoneNumber).AppendLine();
            callInfo.Append("Duration: ").Append(this.HumanReadableDuration);

            return callInfo.ToString();
        }
    }
}
