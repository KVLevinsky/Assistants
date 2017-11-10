using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeLogAnalyzer {
    class ELAAgentLog {
        public Dictionary<string, ELAAgentLogRecord> Log { get; private set; }
        public List<string> Actions {
            get {
                List<string> Result = new List<string>();
                lock (Log) {
                    foreach (ELAAgentLogRecord item in Log.Values)
                        Result.Add(item.Action);
                }
                return Result.Distinct().OrderBy(x => x).ToList();
            }
        }
        public List<string> Originators {
            get {
                List<string> Result = new List<string>();
                lock (Log) {
                    foreach (ELAAgentLogRecord item in Log.Values) {
                        if (item.P2FromAddresses != "") Result.Add(item.P2FromAddresses);
                        else Result.Add(item.P1FromAddress);
                    }
                }
                return Result.Distinct().OrderBy(x => x).ToList();
            }
        }
        public List<string> OriginatorsIP {
            get {
                List<string> Result = new List<string>();
                lock (Log) {
                    foreach (ELAAgentLogRecord item in Log.Values) {
                        if (item.EnteredOrgFromIP != "") Result.Add(item.EnteredOrgFromIP);
                    }
                }
                return Result.Distinct().OrderBy(x => x).ToList();
            }
        }
        public List<string> Recipients {
            get {
                List<string> Result = new List<string>();
                lock (Log) {
                    foreach (ELAAgentLogRecord item in Log.Values)
                        Result.AddRange(item.Recipient);
                }
                return Result.Distinct().OrderBy(x => x).ToList();
            }
        }
        public ELAAgentLog() {
            Log = new Dictionary<string, ELAAgentLogRecord>();
        }
        public bool AddRecord(ELAAgentLogRecord record) {
            lock (Log) {
                if (!Log.ContainsKey(record.SessionId)) {
                    Log.Add(record.SessionId, record);
                    return true;
                }
            }
            return false;
        }
        public void Clear() {
            lock (Log) {
                Log.Clear();
            }
        }
    }
}