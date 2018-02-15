using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
