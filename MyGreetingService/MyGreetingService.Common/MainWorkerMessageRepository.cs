namespace MyGreetingService.Common
{
    public abstract class MainWorkerMessageRepository
    {
        public string URL { get; set; }
        public MainWorkerMessageRepository(string url)
        {
            this.URL = url;
        }
    }
}
