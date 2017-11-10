using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeLogAnalyzer {
    class ELAKernel {
        private ELAAgentLog AgentLog;
        private ELAAgentLogLoader AgentLogLoader;

        public ELAKernel() {
            AgentLog = new ELAAgentLog();
            AgentLogLoader = new ELAAgentLogLoader("");

            AgentLogLoader.LoadData();
        }
    }
}
