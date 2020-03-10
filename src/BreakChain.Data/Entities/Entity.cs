using System;
using System.ComponentModel.DataAnnotations;

namespace BreakChain.Data.Entities
{
    public abstract class Entity
    {
        [Key]
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid().ToString();
            Timestamp = DateTime.Now;
        }
    }
}
