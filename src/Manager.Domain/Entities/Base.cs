using System.Collections.Generic;

namespace Manager.Domain.Entities
{
    public abstract class Base
    {
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;
        public long Id { get; set; }       
        public abstract bool Validate();
    }

}
