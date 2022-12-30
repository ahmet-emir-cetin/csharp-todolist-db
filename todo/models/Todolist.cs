using System;
using System.Collections.Generic;

namespace todo.Models
{
    public partial class Todolist
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public ulong IsComplated { get; set; }
    }
}
