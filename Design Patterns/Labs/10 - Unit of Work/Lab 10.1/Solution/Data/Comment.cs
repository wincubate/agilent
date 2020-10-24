namespace Wincubate.UnitOfWorkExamples.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string Description { get; set; }
    }
}