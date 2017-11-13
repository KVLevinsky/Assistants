namespace ExchangeLogAnalyzer {
    public class OnDataLoadProgressEventArgs {
        public string FullFileName { get; private set; }
        public int Progress { get; private set; }
        public int Total { get; private set; }

        public OnDataLoadProgressEventArgs(string fullFileName, int progress, int total) {
            FullFileName = fullFileName;
            Progress = progress;
            Total = total;
        }
    }
}