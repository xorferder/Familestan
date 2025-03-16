namespace Familestan.Core.Entities
{
    public class Word : BaseEntity
    {
        public long WordId { get; set; }
        public required string WordText { get; set; } // متن کلمه

        public ICollection<PostWord> WordPostWords { get; set; } = new List<PostWord>();
    }
}
