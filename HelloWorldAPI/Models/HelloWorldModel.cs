using System;

namespace HelloWorldAPI.Models
{
    public class HelloWorldModel
    {
        public long Id { get; set; }
        public String Text { get; }

        public HelloWorldModel()
        {
            this.Text = "Hello World";
        }
    }
}
