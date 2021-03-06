﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlynkLibrary.Models
{
    public class Project
    {
            public int id { get; set; }
            public int parentId { get; set; }
            public bool isPreview { get; set; }
            public string name { get; set; }
            public long createdAt { get; set; }
            public long updatedAt { get; set; }
            public List<Device> devices { get; set; }
            public string theme { get; set; }
            public bool keepScreenOn { get; set; }
            public bool isAppConnectedOn { get; set; }
            public bool isShared { get; set; }
            public bool isActive { get; set; }
            public Dictionary<string, string> pinsStorage { get; set; }
    }

}
