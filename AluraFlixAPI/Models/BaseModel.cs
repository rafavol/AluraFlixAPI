using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AluraFlixAPI.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; set; }
    }
}
