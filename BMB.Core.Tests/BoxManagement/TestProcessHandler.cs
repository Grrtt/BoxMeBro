namespace BMB.Core.Tests.BoxManagement
{
    using Core.BoxManagement;

    using Listener;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class TestProcessHandler
    {
        private IBoxRepository boxRepositoryMock;

        private ProcessStartedEventArgs eventArgs;

        private IProcessValidator processValidatorMock;

        private ProcessHandler systemUnderTest;

        [Test]
        public void HandleProcess_ForInvalidProcess_AddsProcessToBoxRepository()
        {
            processValidatorMock.ValidateProcess(eventArgs).Returns(false);

            InvokeHandleProcess();

            boxRepositoryMock.DidNotReceiveWithAnyArgs().AddBoxForProcess(null);
        }

        [Test]
        public void HandleProcess_ForValidProcess_AddsProcessToBoxRepository()
        {
            processValidatorMock.ValidateProcess(eventArgs).Returns(true);

            InvokeHandleProcess();

            boxRepositoryMock.Received(1).AddBoxForProcess(eventArgs);
        }

        [Test]
        public void HandleProcess_WhenInvoked_ValidatesProcess()
        {
            InvokeHandleProcess();

            processValidatorMock.Received(1).ValidateProcess(eventArgs);
        }

        [SetUp]
        public void SetUp()
        {
            eventArgs = new ProcessStartedEventArgs();

            processValidatorMock = Substitute.For<IProcessValidator>();
            boxRepositoryMock = Substitute.For<IBoxRepository>();
            systemUnderTest = CreateSystemUnderTest();
        }

        private ProcessHandler CreateSystemUnderTest()
        {
            return new ProcessHandler(processValidatorMock, boxRepositoryMock);
        }

        private void InvokeHandleProcess()
        {
            systemUnderTest.HandleProcess(eventArgs);
        }
    }
}