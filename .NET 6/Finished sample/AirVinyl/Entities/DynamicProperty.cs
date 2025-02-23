﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirVinyl.Entities
{
    [Table("DynamicVinylRecordProperties")]
    public class DynamicProperty
    {
        public string Key { get; set; }
        public string SerializedValue { get; set; }

        // EF Core can't store object values, so we need to work 
        // with an in-between property to/from JSON representation
        [NotMapped]
        public object Value
        {
            get
            {
                return JsonConvert.DeserializeObject(SerializedValue);
            }
            set
            {
                SerializedValue = JsonConvert.SerializeObject(value);
            }
        }

        public int VinylRecordId { get; set; }
        public virtual VinylRecord VinylRecord { get; set; }

    }
}
