namespace MobilePhones.Library.Software
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CallsManager
    {
        private readonly List<Call> callsHistory;

        public CallsManager()
        {
            this.callsHistory = new List<Call>();
        }

        public List<Call> CallsHistory
        {
            get
            {
                return this.callsHistory;
            }
        }

        public void AddCall(Call call)
        {
            this.callsHistory.Add(call);
        }

        public void RemoveCall(Call call)
        {
            this.callsHistory.Remove(call);
        }

        public void ClearCallsHistory()
        {
            this.callsHistory.Clear();
        }

        /// <summary>
        /// Calculates calls total duration in minutes
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalDuration()
        {
            decimal totalDuration = 0;

            foreach (Call call in this.callsHistory)
            {
                totalDuration += call.Duration;
            }

            return totalDuration;
        }

        /// <summary>
        /// Calculates calls total price. Each started minute is charged.
        /// </summary>
        /// <param name="pricePerMinute"></param>
        /// <returns></returns>
        public decimal GetTotalPrice(decimal pricePerMinute)
        {
            decimal totalDuration = Math.Ceiling(GetTotalDuration());
            
            return Math.Round(totalDuration * pricePerMinute, 2);
        }

        /// <summary>
        /// All calls info
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder callsHistoryInfo = new StringBuilder();

            foreach (Call call in this.CallsHistory)
            {
                callsHistoryInfo.AppendLine(call.ToString());
            }

            return callsHistoryInfo.ToString().Trim();
        }
    }
}
