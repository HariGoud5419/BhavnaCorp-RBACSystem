using System;
using System.ComponentModel.DataAnnotations;

namespace RBACSystem.Core.Entities
{
    ///<summary>
    /// Base Entity classs providing common properities for all entities in the RBACSystem
    /// Includes auditiong fields for tracking creation and modification details
    /// </summary>
    public abstract class BaseEntity
    {
        ///<summary>
        /// Primary key identifier for the entity.
        /// </summary>
        /// 
        public Guid Id { get; set; } = Guid.NewGuid();

        ///<summary>
        /// TimeStamp Indicating when the entity was created
        /// Automatically set when the entity is instantiated.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Timestamp indicating when the entity was last modified
        /// Nullable because the entity may never be modified after creation
        /// </summary>
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Optional : Username or identifier for who created the entity
        /// which is useful for auditing and tracking purposes
        /// </summary>

        [MaxLength(100)]
        public string? CreatedBy { get; set; }
        /// <summary>
        /// optional : Username or identifier for who last modified the entity
        /// Useful for auditing and tracking purposes.
        /// </summary>

        [MaxLength(100)]
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Soft delete flag. True if the entity is marked as deleted but not physically removed from the database.
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Flag indicating whether the entity is active.
        /// </summary>
        public bool IsActive { get; set; } = true;

    }
}