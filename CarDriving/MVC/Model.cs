namespace CarDriving.MVC
{
    public class Model<T>  where T : new()
    {
        public virtual T Property { get; set; } = new T();
    }
}
