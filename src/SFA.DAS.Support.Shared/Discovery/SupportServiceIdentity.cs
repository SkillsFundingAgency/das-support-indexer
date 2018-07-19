namespace SFA.DAS.Support.Shared.Discovery
{
    /// <summary>
    ///     Extend this enumeration for each new service
    /// </summary>
    public enum SupportServiceIdentity
    {
        [ServiceRoute("portal")]
        SupportPortal,
        [ServiceRoute("employerusers")]
        SupportEmployerUser,
        [ServiceRoute("employers")]
        SupportEmployerAccount,
        [ServiceRoute("providers")]
        SupportProvider,
        [ServiceRoute("commitments")]
        SupportCommitments,
        [ServiceRoute("payments")]
        SupportPayments
    }
}