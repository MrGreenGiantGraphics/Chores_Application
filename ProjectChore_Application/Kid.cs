namespace ProjectChore_Application
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kid
    {
        public Kid()
        {
            this.ChoreLookUps = new HashSet<ChoreLookUp>();
        }
    
        public int KidId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public virtual ICollection<ChoreLookUp> ChoreLookUps { get; set; }
    }
}
