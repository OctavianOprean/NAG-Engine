using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAGEngine.System
{
    /// <summary>
    /// enumerator of the posible states a system can be in, if the system is ofline then the run function will do nothing
    /// </summary>
    public enum SystemStatus 
    { 
        Ofline,      
        Online,
    }

    public interface System
    {
        /// <summary>
        /// read only valuable of the cu
        /// </summary>
        SystemStatus Status{get;}
        void BootAllSubSystems();     
        void BootSubSystem(string SystemName);

        void ShutDownAllSubSystems();
        void ShutDownSubSystem(string SystemName);

        void AddSubSystem<T>(string SystemName) where T : System, new();       
        System GetSubSystem(string SystemName);
        SystemType GetSubSystem<SystemType>(string SystemName) where SystemType:System;
        void Boot();
        void Run();
        void ShutDown();
    }

    public abstract class GameSystem : System
    {
        protected SystemStatus status;
        protected Dictionary<String, System> SubSytemList;        
        public SystemStatus Status 
        { 
            get { return status; } 
        }        

        public GameSystem()
        {
            this.SubSytemList = new Dictionary<String, System>();
            status = SystemStatus.Ofline;
        }


        public void BootAllSubSystems()
        {
            List<System> subSystems = SubSytemList.Values.ToList();

            for (int i = 0; i < subSystems.Count; i++)
                if (subSystems[i].Status == SystemStatus.Ofline)
                    subSystems[i].Boot();            
        }
        public void BootSubSystem(string SystemName)
        {
            if (SubSytemList[SystemName].Status == SystemStatus.Ofline)
                SubSytemList[SystemName].Boot();
        }


        public void ShutDownAllSubSystems()
        {
            List<System> subSystems = SubSytemList.Values.ToList();

            for (int i = 0; i < subSystems.Count; i++)
                if (subSystems[i].Status == SystemStatus.Online)
                    subSystems[i].ShutDown();
        }
        public void ShutDownSubSystem(string SystemName)
        {
            if (SubSytemList[SystemName].Status == SystemStatus.Online)
                SubSytemList[SystemName].ShutDown();
        }


        public void AddSubSystem<T>(string SystemName) where T : System, new()
        {                               
            SubSytemList.Add(SystemName, new T() as System);            
        }
        public System GetSubSystem(string SystemName)
        {
            return SubSytemList[SystemName];
        }

        public SystemType GetSubSystem<SystemType>(string SystemName ) where SystemType:System
        {
            return (SystemType) SubSytemList[SystemName];
        }

        public void Boot()
        {
            status = SystemStatus.Online;
            BootLogic();
            BootAllSubSystems();           
        }
        public void Run()
        {
            if (status == SystemStatus.Online)
            {
                RunLogic();
                List<System> subSystems = SubSytemList.Values.ToList();

                for (int i = 0; i < subSystems.Count; i++)
                    if (subSystems[i].Status == SystemStatus.Online)
                        subSystems[i].Run();
            }
            
        }

        public void ShutDown()
        {
            status = SystemStatus.Ofline;
            ShutDownLogic();  
            ShutDownAllSubSystems();
                      
        }

        protected virtual  void BootLogic()
        {

        }
        protected virtual  void RunLogic()
        {
        
        }    
        protected virtual  void ShutDownLogic()
        {

        }


    }
}
