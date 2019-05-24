using System;
using System.Collections.Generic;
using System.Text;

namespace App3
{
    public class RootObject
    {
        public Post Post { get; set; }
    }
    public class Kryesore
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string Date { get; set; }
    }
    public class Post : Kryesore
    {
        public string Video { get; set; }
        public string Content { get; set; }
    }
}
