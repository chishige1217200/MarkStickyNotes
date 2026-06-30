using System;
using System.Collections.Generic;
using System.Text;

namespace MarkStickyNotes.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ColorCode { get; set; } = string.Empty;
        public int Order { get; set; }
    }
}
