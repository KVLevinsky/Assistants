namespace ExchangeLogAnalyzer {
    public class OnDataLoadEventArgs {
        public bool IsPrimaryLoading { get; private set; }

        public OnDataLoadEventArgs(bool isPrimaryLoading = false) {
            IsPrimaryLoading = isPrimaryLoading;
        }
    }
}