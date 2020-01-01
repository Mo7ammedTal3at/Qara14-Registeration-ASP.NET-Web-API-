using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Qara14.Models
{
    public class Qarar
    {
        public int Mosalsal { get; set; }
        public int Markaz { get; set; }
        public int Year { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int SoldierId { get; set; }
        [ForeignKey("SoldierId")]
        public virtual Recorder Soldier { get; set; }
        public int CaptinId { get; set; }
        [ForeignKey("CaptinId")]
        public virtual Recorder Captin { get; set; }


    }
}