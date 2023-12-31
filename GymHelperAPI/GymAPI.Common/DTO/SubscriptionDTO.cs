﻿using System.Security.AccessControl;

namespace GymAPI.Common.DTO;

public class SubscriptionDTO
{
    public string Type { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
 }