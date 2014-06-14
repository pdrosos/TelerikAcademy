namespace School
{
    using System;

    /// <summary>
    /// Human
    /// </summary>
    public abstract class Human : ICommentable
    {
        private string name;
        private string comment;

        public Human(string name, string comment)
        {
            this.Name = name;
            this.Comment = comment;
        }

        public Human(string name): this(name, null)
        {            
        }

        public Human(): this(null, null)
        {
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }
    }
}
