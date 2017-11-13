namespace ExchangeLogAnalyzer {
    public enum LoadPhase {
        Begin,
        End
    }

    public class OnDataLoadEventArgs {
        public bool IsPrimaryLoading { get; private set; }
        public LoadPhase Phase { get; private set; }

        public OnDataLoadEventArgs(LoadPhase phase, bool isPrimaryLoading = false) {
            Phase = phase;
            IsPrimaryLoading = isPrimaryLoading;
        }
    }
}