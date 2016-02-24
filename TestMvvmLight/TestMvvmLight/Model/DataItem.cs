namespace TestMvvmLight.Model
{
    public class DataItem
    {
        public string Title
        {
            get;
            private set;
        }

        public DataItem(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}