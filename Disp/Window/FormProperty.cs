using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp.Window
{
    public class FormProperty
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string WindowPosition { get; set; }
        public string Class { get; set; }
        public string Icon { get; set; }
        public string BackColor { get; set; }
        public string BackGroundImage { get; set; }
        public List<DesignSize> DesignSize { get; set; }
        public List<FormEvent> Events { get; set; }
        public string ScriptAssociated { get; set; }
        public string EnableMaximizeBox { get; set; }
        public string EnableMinimizeBox { get; set; }
    }
}
