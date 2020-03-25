using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace tut2
{
    public class UniversityWrapper
    {
        [JsonPropertyName("university")]
        public University University { get; set; }
    }
}
