namespace Artichaut.Interfaces.IService
{
    /// <summary>
    /// Interface for cookie service
    /// </summary>
    public interface IMailService
    {
        public bool SendMail(string to, string subject, string bodyText);
    }
}
