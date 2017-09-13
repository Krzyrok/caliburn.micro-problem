using System.ComponentModel.Composition;

namespace TestingCaliburnMicro.ViewModels
{
    // probably unnecessary
    [Export("TestViewModel", typeof(TestViewModel))]
    public class TestViewModel
    {
        public string TestLabelWithBinding { get; set; }
        public string TestLabelWithoutBinding { get; set; }
        public string TestTextBoxWithBinding { get; set; }
        public string TestTextBoxWithoutBinding { get; set; }

        public void TestAction()
        {
        }

        public TestViewModel()
        {
            TestLabelWithBinding = "label with binding";
            TestLabelWithoutBinding = "label without binding";

            TestTextBoxWithBinding = "text box with binding";
            TestTextBoxWithoutBinding = "text box without binding";
        }

        public void Init()
        {
        }
    }
}
