namespace _01.Exercise_Image.Models.ORM
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;
        public DateTime? DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
