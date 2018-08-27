namespace BMB.Core.Tests
{
    using System.Diagnostics;

    using Core.BoxManagement;

    using Keyboard;

    using NSubstitute;

    using NUnit.Framework;

    using Process;

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
            processStartedEventArgs = CreateProcessStartedEventArgs();

            processListenerMock = Substitute.For<IProcessListener>();
            processHandlerMock = Substitute.For<IProcessHandler>();
            systemUnderTest = CreateSystemUnderTest();
        }

        [Test]
        public void Start_OnProcessStartedEvent_ProcessesProcessStartedEventArgs()
        {
            InvokeStart();

            processListenerMock.ProcessStarted += Raise.EventWith(systemUnderTest, processStartedEventArgs);

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
            return new BMBApplication(
                processListenerMock,
                processHandlerMock,
                new KeyboardListener(),
                new DefaultKeyboardHandler(new BoxRepository()));
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