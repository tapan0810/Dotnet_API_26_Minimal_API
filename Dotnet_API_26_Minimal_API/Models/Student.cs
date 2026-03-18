namespace Dotnet_API_26_Minimal_API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool IsPresent { get; set; } = false;
    }
}
