namespace BMB.Core.Tests.BoxManagement
{
    using System.Diagnostics;

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

            boxRepositoryMock.DidNotReceiveWithAnyArgs().AddBoxToCache(null);
        }

        [Test]
        public void HandleProcess_ForValidProcess_AddsProcessToBoxRepository()
        {
            processValidatorMock.ValidateProcess(eventArgs).Returns(true);

            InvokeHandleProcess();

            boxRepositoryMock.Received(1).AddBoxToCache(eventArgs);
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
            eventArgs = CreateProcessStartedEventArgs();

            processValidatorMock = Substitute.For<IProcessValidator>();
            boxRepositoryMock = Substitute.For<IBoxRepository>();
            systemUnderTest = CreateSystemUnderTest();
        }

        private ProcessStartedEventArgs CreateProcessStartedEventArgs()
        {
            return new ProcessStartedEventArgs(Process.GetCurrentProcess());
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