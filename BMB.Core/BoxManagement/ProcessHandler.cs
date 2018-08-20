namespace BMB.Core.BoxManagement
{
    using Listener;

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
            if (IsValidProcess(eventArgs))
            {
                AddBoxToRepository(eventArgs);
            }
        }

        private void AddBoxToRepository(ProcessStartedEventArgs eventArgs)
        {
            boxRepository.AddBoxForProcess(eventArgs);
        }

        private bool IsValidProcess(ProcessStartedEventArgs eventArgs)
        {
            return processValidator.ValidateProcess(eventArgs);
        }
    }
}