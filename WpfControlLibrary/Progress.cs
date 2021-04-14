namespace WpfControlLibrary
{
    public class Progress : IProgress
    {
        private CircularProgressBarView _circularProgressView;

        public void Report(int progress)
        {
            _circularProgressView.ReportProgress(progress);
        }

        public void TryClose()
        {
            _circularProgressView.TryClose();
            _circularProgressView = null;
        }

        public void TryShow()
        {
            _circularProgressView = new CircularProgressBarView();
            _circularProgressView.TryShow();
        }
    }
}