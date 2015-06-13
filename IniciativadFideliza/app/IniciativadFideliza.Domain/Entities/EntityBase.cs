using System;

namespace IniciativadFideliza.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtAlteracao { get; set; }
        public Guid MyGuidId { get; set; }
    }
}
