using System;

using Core.Domain.Entities.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Core.Infrastructure.Identity.Entities
{
    public class CoreIdentityUser : IdentityUser<Guid>, ICoreBaseEntity
    {
        public bool Deleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
