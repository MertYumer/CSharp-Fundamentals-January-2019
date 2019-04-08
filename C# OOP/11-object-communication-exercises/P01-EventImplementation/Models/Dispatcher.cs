namespace P01_EventImplementation.Models
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        private string name;
        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get => this.name;

            set
            {
                this.name = value;
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }

        protected void OnNameChange(NameChangeEventArgs args)
        {
            if (this.NameChange != null)
            {
                this.NameChange(this, args);
            }
        }
    }
}
