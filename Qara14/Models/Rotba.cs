using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qara14.Models
{
    public class Rotba
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual List<Recorder> Recorders { get; set; }
    }
}