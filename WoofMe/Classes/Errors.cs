using System;

namespace WoofMe.Classes
{
    public class Errors
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public Errors(string text)
        {
            Id = Guid.NewGuid();
            Text = text;
        }
    }
}
