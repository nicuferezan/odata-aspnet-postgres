using System.ComponentModel.DataAnnotations;

namespace ODataAPI.Entities
{
    public class Activity
    {
        [Key]
        public int activityid { get; set; }
        public string name { get; set; }
    }
}
