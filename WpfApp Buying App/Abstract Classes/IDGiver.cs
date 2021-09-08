namespace WpfApp_Buying_App.Abstract_Classes
{
    public abstract class IDGiver
    {
        private static int _id = default;
        public int ID { get; set; } = ++_id;
    }
}