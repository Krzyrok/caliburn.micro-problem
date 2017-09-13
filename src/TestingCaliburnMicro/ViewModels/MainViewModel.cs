using Caliburn.Micro;

namespace TestingCaliburnMicro.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        public string TestLabel { get; set; }
        public string TestTextBox { get; set; }


        public MainViewModel()
        {
            TestLabel = "label from MainVM";
            TestTextBox = "text box from MainVM";
        }

        public void TestAction()
        {
        }

    }
}
