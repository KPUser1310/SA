namespace SmartAttend.Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get;  set; }
        public long CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public long? LastModifiedBy { get; set; }
       
    }
}
