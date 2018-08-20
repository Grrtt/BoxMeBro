namespace BMB.Core.Tests
{
    using Core.BoxManagement;

    using Listener;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class TestBMBApplication
    {
        private IProcessHandler processHandlerMock;

        private IProcessListener processListenerMock;

        private ProcessStartedEventArgs processStartedEventArgs;

        private BMBApplication systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            processStartedEventArgs = new ProcessStartedEventArgs();

            processListenerMock = Substitute.For<IProcessListener>();
            processHandlerMock = Substitute.For<IProcessHandler>();
            systemUnderTest = CreateSystemUnderTest();
        }

        [Test]
        public void Start_OnProcessStartedEvent_ProcessesProcessStartedEventArgs()
        {
            InvokeStart();

            processListenerMock.ProcessStartedEvent += Raise.EventWith(systemUnderTest, processStartedEventArgs);

            processHandlerMock.Received(1).HandleProcess(processStartedEventArgs);
        }

        [Test]
        public void Start_WhenInvoked_StartsProcessListening()
        {
            InvokeStart();

            processListenerMock.Received(1).Start();
        }

        [Test]
        public void Stop_WhenInvoked_StopsProcessListening()
        {
            InvokeStop();
        }

        private BMBApplication CreateSystemUnderTest()
        {
            return new BMBApplication(processListenerMock, processHandlerMock);
        }

        private void InvokeStart()
        {
            systemUnderTest.Start();
        }

        private void InvokeStop()
        {
            systemUnderTest.Stop();
        }
    }
}