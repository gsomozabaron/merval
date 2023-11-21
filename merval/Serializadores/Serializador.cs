namespace merval.Serializadores
{
    public abstract class Serializador
    {
        public string Path { get; set; }

        public Serializador(string path)
        {
            Path = path;
        }

    }

}
