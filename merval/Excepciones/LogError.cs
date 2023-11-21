namespace merval.Excepciones
{
    public class LogError
    {
        #region Atributos
        public Exception Exception { get; set; }
        public string Message { get; set; }
        public DateTime Fecha { get; set; }
        public string MethodName { get; set; }
        #endregion

        #region Constructor
        public LogError(Exception exception, string message, string methodName)
        {
            Exception = exception;
            Message = message;
            Fecha = DateTime.Now;
            MethodName = methodName;
        }
        #endregion







    }
}
