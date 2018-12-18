namespace FluentHealth.Web.ViewModels
{
    public class BaseItemViewModel<T>
    {
        public virtual T Id { get; set; }
        public virtual string Name { get; set; }
    }
}
