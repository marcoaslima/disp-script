using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp.Window
{
    public class DButton
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public List<DesignSize> DesignSize { get; set; }
        public List<Location> Location { get; set; }
        public List<ButtonEvent> Events { get; set; }
    }
}
