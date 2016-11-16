using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAGEngine
{
    public enum SystemStatus 
    { 
        Ofline,      
        Online,
    }

    public interface System
    {
        SystemStatus Status{get;}
        void BootAllSubSystems();     
        void BootSubSystem(string SystemName);

        void ShutDownAllSubSystems();
        void ShutDownSubSystem(string SystemName);

        void AddSubSystem<T>(string SystemName) where T : System, new();
        System GetSubSystem(string SystemName);

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

        public void Boot()
        {
            status = SystemStatus.Online;
            BootAllSubSystems();
            BootLogic();
            
        }
        public void Run()
        {
            List<System> subSystems = SubSytemList.Values.ToList();

            for (int i = 0; i < subSystems.Count; i++)
                if (subSystems[i].Status == SystemStatus.Online)
                    subSystems[i].Run();    

            if (status == SystemStatus.Online)
                RunLogic();
        }
        public void ShutDown()
        {
            status = SystemStatus.Ofline;
            ShutDownAllSubSystems();
            ShutDownLogic();            
        }

        protected virtual  void BootLogic()
        {

        }
        protected abstract void RunLogic();    
        protected virtual  void ShutDownLogic()
        {

        }


    }
}
