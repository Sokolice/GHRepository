using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace api.Model
{
    public class Cell
    {
        public Guid Id { get; set; }
        public int X {  get; set; }
        public int Y { get; set; }  
        public bool IsActive { get; set; }
        public string GridColumn { get; set; }
        public string GridRow { get; set; }
        public string BackgroundImage { get; set; }

        public Cell() {
            GridColumn = string.Empty;
            GridRow = string.Empty;
            BackgroundImage = string.Empty;
        }
    }
}
