namespace CarDriving.MVC
{
    public abstract class View<T> where T : new()
    {
        private T model = new T();

        public T Model
        {
            get => model;
            set
            {
                model = value;
                Update();
            }
        }
        
        protected abstract void Update();
    }
}
