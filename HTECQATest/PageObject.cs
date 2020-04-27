namespace HTECQATest
{
    public static class PageObject
    {
        public static LoginPage LoginPage
        {
            get
            {
                var loginPage = new LoginPage();
                return loginPage;
            }
        }

        public static UseCasesPage UseCasesPage
        {
            get
            {
                var useCasesPage = new UseCasesPage();
                return useCasesPage;
            }
        }

    }
}
