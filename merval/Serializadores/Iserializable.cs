namespace merval.Serializadores
{
    internal interface Iserializable<T>
    {
        bool Serializar(T datos);

        T Deserializar();



    }
}
