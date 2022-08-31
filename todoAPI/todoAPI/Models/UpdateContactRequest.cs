namespace todoAPI.Models
{
    public class UpdateContactRequest
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public Boolean IsComplete { get; set; }
    }
}
