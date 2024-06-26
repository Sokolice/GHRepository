﻿namespace API.Domain
{
    public class Cell
    {
        public Guid Id { get; set; }
        public int X {  get; set; }
        public int Y { get; set; }  
        public bool IsActive { get; set; }
        public string GridArea { get; set; }
        public string BackgroundImage { get; set; }
        public Guid PlantRecordId { get; set; }
        public bool isHidden { get; set; }

        public string ObjectID { get; set; }
        public Cell() {
            GridArea = string.Empty;
            BackgroundImage = string.Empty;
            PlantRecordId = Guid.Empty;
            isHidden = false;
            IsActive = false;
            ObjectID = string.Empty;
        }
    }
}
