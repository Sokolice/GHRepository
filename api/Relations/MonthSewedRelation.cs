﻿using api.DTOs;

namespace api.Relations
{
    public class MonthSewedRelation
    {
        public string Month { get; set; }
        public virtual List<PlantDTO> SewedPlants { get; set; }

    }
}