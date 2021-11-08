namespace TUUBIB.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int PageCount { get; set; }

        public string AuthorName { get; set; }

        public string Genres { get; set; }

        public string CoverBase64 { get; set; }
    }
}