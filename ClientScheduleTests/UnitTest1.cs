namespace ClientScheduleTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var userview = new DummyLoginView();
            var presenter = new LoginPresenter(userview);
        }
    }

    class DummyLoginView : ILoginView
    {
        public event EventHandler<IUserContext> LoginAttempted;
        public string Username { get; set; }
        public string Password {  get; set; }

        // Imitate login button click from form
        public void Login() => LoginAttempted?.Invoke(this, EventArgs.Empty);

        public void FailLogin();
    }
}