using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Qara14.Models
{
    
    public class Recorder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int DaragaId { get; set; }
        [ForeignKey("DaragaId")]
        public virtual Daraga Daraga { get; set; }
        public virtual List<Qarar> Qarars { get; set; }
    }
}