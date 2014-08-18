namespace T4Template
{
    using System;
    using System.Linq;

    partial class HtmlTable
    {
        private int rows;
        private int cols;

        public HtmlTable(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }
            set
            {
                this.rows = value;
            }
        }
  
        public int Cols
        {
            get
            {
                return this.cols;
            }
            set
            {
                this.cols = value;
            }
        }
    }
}
