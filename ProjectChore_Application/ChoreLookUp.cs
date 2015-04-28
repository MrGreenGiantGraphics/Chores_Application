namespace ProjectChore_Application
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChoreLookUp
    {
        public int ChoreLookUpId { get; set; }
        public Nullable<System.DateTime> DateCompleted { get; set; }
        public Nullable<System.DateTime> DateAssigned { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> KidId { get; set; }
        public Nullable<int> ChoreId { get; set; }
    
        public virtual Chore Chore { get; set; }
        public virtual Kid Kid { get; set; }
    }
}
