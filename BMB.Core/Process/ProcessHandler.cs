namespace BMB.Core.Process
{
    using System;
    using System.Linq;

    using BoxManagement;

    public class ProcessHandler : IProcessHandler
    {
        private readonly IBoxRepository boxRepository;

        private readonly IProcessValidator processValidator;

        public ProcessHandler(IProcessValidator processValidator, IBoxRepository boxRepository)
        {
            this.processValidator = processValidator;
            this.boxRepository = boxRepository;
        }

        public void HandleProcess(ProcessStartedEventArgs eventArgs)
        {
            LogProcess(eventArgs);
            if (IsValidProcess(eventArgs))
            {
                AddBoxToRepository(eventArgs);
            }
        }

        public void HandleProcess(ProcessStoppedEventArgs eventArgs)
        {
            if (BoxInRepository(eventArgs))
            {
                boxRepository.Remove(eventArgs.ProcessId);
            }
        }

        private void AddBoxToRepository(ProcessStartedEventArgs eventArgs)
        {
            boxRepository.AddBoxToCache(eventArgs);
        }

        private bool BoxInRepository(ProcessStoppedEventArgs eventArgs)
        {
            return boxRepository.GetAll().Any(box => box.ProcessId == eventArgs.ProcessId);
        }

        private bool IsValidProcess(ProcessStartedEventArgs eventArgs)
        {
            return processValidator.ValidateProcess(eventArgs);
        }

        private void LogProcess(ProcessStartedEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.MainWindowHandle);
        }
    }
}