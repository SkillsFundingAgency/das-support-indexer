using System;

namespace SFA.DAS.Support.Shared.Navigation
{
    [Flags]
    public enum SupportMenuPerspectives
    {
        None,
        EmployerAccount = 1,
        EmployerUser = 2,
        TrainingProvider = 4,
        Apprentice = 8,
        All = int.MaxValue
    }
}