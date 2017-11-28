﻿using System;
using Newtonsoft.Json;

namespace Crossroads.Service.Template.Models
{
    public class ContactDto
    {
        [JsonProperty(PropertyName = "contactId")]
        public int ContactId { get; set; }

        [JsonProperty(PropertyName = "householdId")]
        public int HouseholdId { get; set; }
    }
}