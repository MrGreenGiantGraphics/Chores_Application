namespace ProjectChore_Application
{
    using System;
    using System.Collections.Generic;
    
    public partial class Chore
    {
        public Chore()
        {
            this.ChoreLookUps = new HashSet<ChoreLookUp>();
        }
    
        public int ChoreId { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<ChoreLookUp> ChoreLookUps { get; set; }
    }
}
