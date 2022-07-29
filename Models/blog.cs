using System;

namespace BlogAPI.Models
{
    public class blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate  { get; set; } = DateTime.Now;

    }
}
