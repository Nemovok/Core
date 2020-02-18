using System;

using Core.Domain.Entities.Interfaces;

#pragma warning disable CS0234 // The type or namespace name 'Interfaces' does not exist in the namespace 'Core.Domain' (are you missing an assembly reference?)
#pragma warning disable CS0234 // The type or namespace name 'Interfaces' does not exist in the namespace 'Core.Domain' (are you missing an assembly reference?)
#pragma warning restore CS0234 // The type or namespace name 'Interfaces' does not exist in the namespace 'Core.Domain' (are you missing an assembly reference?)
#pragma warning restore CS0234 // The type or namespace name 'Interfaces' does not exist in the namespace 'Core.Domain' (are you missing an assembly reference?)

namespace Core.Domain.Entities.Implementations
{
#pragma warning disable CS0246 // The type or namespace name 'ICoreBaseEntity' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'ICoreBaseEntity' could not be found (are you missing a using directive or an assembly reference?)
    public abstract class CoreBaseEntity : ICoreBaseEntity
#pragma warning restore CS0246 // The type or namespace name 'ICoreBaseEntity' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'ICoreBaseEntity' could not be found (are you missing a using directive or an assembly reference?)
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
