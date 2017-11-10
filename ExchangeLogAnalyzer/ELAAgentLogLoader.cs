using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeLogAnalyzer {
    class ELAAgentLogLoader {
        public string FullFilename { get; private set; }
        public ELAAgentLogLoader(string fullFilename) {
            FullFilename = fullFilename;
        }
        public IEnumerable<ELAAgentLogRecord> LoadData() {
            if (File.Exists(FullFilename)) {
                using (FileStream fileReader = new FileStream(FullFilename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                    using (StreamReader reader = new StreamReader(fileReader)) {
                        while (!reader.EndOfStream) {
                            string data = reader.ReadLine();
                            if (data[0] != '#') {
                                yield return new ELAAgentLogRecord(data);
                            }
                        }
                    }
                }
            }
        }
    }
}