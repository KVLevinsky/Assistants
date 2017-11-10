using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeLogAnalyzer {
    public class ELAAgentLogRecord {
        public DateTime Timestamp { get; private set; }
        public string SessionId { get; private set; }
        public string LocalEndpoint { get; private set; }
        public string RemoteEndpoint { get; private set; }
        public string EnteredOrgFromIP { get; private set; }
        public string MessageId { get; private set; }
        public string P1FromAddress { get; private set; }
        public string P2FromAddresses { get; private set; }
        public List<string> Recipient { get; private set; }
        public int NumRecipients { get; private set; }
        public string Agent { get; private set; }
        public string Event { get; private set; }
        public string Action { get; private set; }
        public string SmtpResponse { get; private set; }
        public string Reason { get; private set; }
        public string ReasonData { get; private set; }
        public string Diagnostics { get; private set; }
        public ELAAgentLogRecord(string Data) {
            List<string> lines = new List<string>();
            string token = "";
            bool isString = false;
            for (int i = 0; i < Data.Length; i++) {
                if (Data[i] == '"') isString = !isString;
                if (((Data[i] == ',') || (i == Data.Length - 1)) && (!isString)) {
                    token = token.Replace("\"", "");
                    lines.Add(token);
                    token = "";
                } else token += Data[i];
            }
            lines.Add("");
            string[] values = lines.ToArray();
            Timestamp = DateTime.Parse(values[0]);
            SessionId = values[1];
            LocalEndpoint = values[2];
            RemoteEndpoint = values[3];
            EnteredOrgFromIP = values[4];
            MessageId = values[5];
            P1FromAddress = values[6].Replace(";", "");
            P2FromAddresses = values[7].Replace(";", "");
            Recipient = values[8].Split(';').ToList();
            NumRecipients = int.Parse(values[9]);
            Agent = values[10];
            Event = values[11];
            Action = values[12];
            SmtpResponse = values[13];
            Reason = values[14];
            ReasonData = values[15];
            Diagnostics = values[16];
        }
        public override string ToString() {
            List<string> Result = new List<string>();
            Result.Add(Timestamp.ToString("dd.MM.yyyy HH:mm:ss"));
            Result.Add(SessionId);
            Result.Add(LocalEndpoint);
            Result.Add(RemoteEndpoint);
            Result.Add(EnteredOrgFromIP);
            Result.Add(MessageId);
            Result.Add(P1FromAddress);
            Result.Add(P2FromAddresses);
            Result.Add(string.Join(",", Recipient.ToArray()));
            Result.Add(NumRecipients.ToString());
            Result.Add(Agent);
            Result.Add(Event);
            Result.Add(Action);
            Result.Add(SmtpResponse);
            Result.Add(Reason);
            Result.Add(ReasonData);
            Result.Add(Diagnostics);
            return string.Join("|", Result.ToArray());
        }
    }
}
