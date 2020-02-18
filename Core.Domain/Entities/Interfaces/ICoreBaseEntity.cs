using System;

namespace Core.Domain.Entities.Interfaces
{
    public interface ICoreBaseEntity
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
