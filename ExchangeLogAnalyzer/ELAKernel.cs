using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeLogAnalyzer {
    public enum ELADataLoadMode {
        First,
        Full
    }

    class ELAKernel {
        private ELAAgentLog AgentLog;
        private ELAAgentLogLoader AgentLogLoader;

        public ELADataLoadMode DataLoadMode { get; private set; }
        public bool DataAutoLoad { get; private set; }

        public event EventHandler<OnDataLoadEventArgs> OnDataLoad;
        public event EventHandler<OnKernelModeChangedEventArgs> OnKernelModeChanged;

        public ELAKernel() {
            AgentLog = new ELAAgentLog();
            AgentLogLoader = new ELAAgentLogLoader("");
        }

        public void Initialize() {
            new Thread(
                new ThreadStart(
                    (ThreadStart)delegate {
                        AgentLogLoader.LoadData();
                        OnDataLoad(this, new OnDataLoadEventArgs(true));
                    }))
            .Start();
        }

        public void SetMode(ELADataLoadMode dataLoadMode = ELADataLoadMode.First, bool dataAutoLoad = true) {
            DataLoadMode = dataLoadMode;
            DataAutoLoad = dataAutoLoad;
            OnKernelModeChanged(this, new OnKernelModeChangedEventArgs());
        }
    }
}