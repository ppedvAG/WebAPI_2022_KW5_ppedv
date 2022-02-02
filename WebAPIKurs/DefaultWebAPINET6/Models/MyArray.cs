namespace DefaultWebAPINET6.Models
{
    public class MyArray
    {
        //public string[] Entries { get; set; } = new string[] { "", "" }; -> wäre ein Bug 
        public string[] Entries { get; set; } = default!;
    }
}
