using TextCheckerMachine.UITests.SetUp;

namespace TextCheckerMachine.UITests.UIs
{
    public class HomeUi: BrowserConfiguration
    {
        public void Goto()
        {
            Goto(WebSiteUrl);
        }

        public bool IsAt()
        {
            return Title == "Text Checker Machine";
        }
    }
}
