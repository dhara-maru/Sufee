namespace SUFEEASP.Model
{
    public class HomeViewModel
    {
        public List<Ebook>? Ebooks { get; set; }
        public List<Blog>? Blogs { get; set; }
        public List<Qawwali>? Qawwalis { get; set; }
        public List<Writer>? Writers { get; set; }
        public Quote? Quote { get; set; }
    }

    public class Quote
    {
        public int ID { get; set; }
        public string QuoteContent { get; set; }
        public string Quoter { get; set; }
    }
}