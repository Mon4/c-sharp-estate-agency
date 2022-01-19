namespace estates
{
    /// <summary>
    /// Interface with necessary methods for repositories
    /// </summary>
    internal interface IRepository
    {
        void SaveToXML();
        string ToString();
    }
}