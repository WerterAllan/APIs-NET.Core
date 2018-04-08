namespace WerterStore.Domain.ValueObject
{
    public class Document
    {
        public string Number { get; private set; }

        public Document(string number)
        {
            Number = number;
        }

        public override string ToString()
        {
            return Number;
        }

    }
}
