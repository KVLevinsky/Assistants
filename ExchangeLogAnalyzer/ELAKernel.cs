using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeLogAnalyzer {
    public enum ELADataLoadMode {
        First,
        Full
    }

    class ELAKernel {
        private ELAAgentLog agentLog;
        private ELAAgentLogLoader agentLogLoader;

        public ELADataLoadMode DataLoadMode { get; private set; }
        public bool DataAutoLoad { get; private set; }
        public string[] LogPaths { get; private set; }

        public event EventHandler<OnDataLoadEventArgs> OnDataLoadBegin;
        public event EventHandler<OnDataLoadEventArgs> OnDataLoadEnd;
        public event EventHandler<OnDataLoadProgressEventArgs> OnDataLoadProgress;
        public event EventHandler<OnKernelModeChangedEventArgs> OnKernelModeChanged;

        public ELAKernel() {
            agentLog = new ELAAgentLog();
        }

        public void Initialize(string[] logPaths) {
            LogPaths = logPaths;
            SetMode();
        }

        public void SetMode(ELADataLoadMode dataLoadMode = ELADataLoadMode.First, bool dataAutoLoad = true) {
            DataLoadMode = dataLoadMode;
            DataAutoLoad = dataAutoLoad;
            OnKernelModeChanged(this, new OnKernelModeChangedEventArgs());
            if (DataAutoLoad) {
                //Create timer
            } else {
                //Dispose timer
            }
        }

        protected void loadData(string fullFileName) {
            //new Thread(new ThreadStart((ThreadStart)delegate {
                agentLogLoader = new ELAAgentLogLoader(fullFileName);
                IEnumerable<ELAAgentLogRecord> records = agentLogLoader.LoadData();
                int count = 0;
                foreach (ELAAgentLogRecord item in records) {
                    agentLog.AddRecord(item);
                    OnDataLoadProgress(this, new OnDataLoadProgressEventArgs(fullFileName, count++, records.Count()));
                }
                //OnDataLoad(this, new OnDataLoadEventArgs(true));
            //})).Start();
        }

        public void LoadData() {
            new Thread(new ThreadStart(() => {
                try {
                    OnDataLoadBegin(this, new OnDataLoadEventArgs(LoadPhase.Begin));
                    foreach (string path in LogPaths) {
                        DirectoryInfo di = new DirectoryInfo(path);
                        if (DataLoadMode == ELADataLoadMode.Full) {
                            foreach (FileInfo fi in di.GetFiles().OrderByDescending(x => x.FullName)) loadData(fi.FullName);
                        } else {
                            loadData(di.GetFiles().OrderByDescending(x => x.FullName).First().FullName);
                        }
                    }
                    //if (cbAutoDisplay.Checked) {
                    //    List<ELAAgentLogRecord> Result = null;
                    //    Invoke((MethodInvoker)delegate { Result = FilterLog(); SetCacheOutagedStatus(true); });
                    //    lvResult.ItemChecked -= lvResult_ItemChecked;
                    //    FillInListView(lvResult, Result);//log.Log.Values.OrderByDescending(x => x.Timestamp).ToList());
                    //    lvResult.ItemChecked += lvResult_ItemChecked;
                    //}
                } catch (SecurityException) {
                    //MessageBox.Show("Вы не являетесь администратором Exchange!", "Доступ запрещен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Application.Exit(new CancelEventArgs(false));
                } catch (Exception e) {
                    //MessageBox.Show(string.Format("Произошла непредвиденная ошибка\r\nСообщение: [{0}]", e.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Application.Exit(new CancelEventArgs(false));
                } finally {
                    OnDataLoadEnd(this, new OnDataLoadEventArgs(LoadPhase.End));
                }
            })).Start();
        }
    }
}