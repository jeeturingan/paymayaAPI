using System;

namespace paymayAPI.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity() 
        {
        }
        public int Id { get; set; }
    }
}
