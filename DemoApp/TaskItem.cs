using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DemoApp
{
    public class TaskItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string? Text { get; set; }
        public bool Done { get; set; }
    }
}
