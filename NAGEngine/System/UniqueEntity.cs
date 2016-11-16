using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAGEngine.System
{

    public class UniqueEntity
    {
        public String ID { get { return GUID; } }
        protected String GUID;
        public UniqueEntity()
        {
            GUID = Guid.NewGuid().ToString();
        }

        public void ChangeID(string newID)
        {
            GUID = newID;
        }
        
    }
}
