using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    public class MissionStatus:BaseModel
    {
        [Required(ErrorMessage = "Boş bırakılamaz!.")]
        public string Name {  get; set; }
        public int CustomerId {  get; set; }
        public virtual Customer Customer { get; set; }
    }
}
