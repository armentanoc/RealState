namespace RealState.WebAPI.CustomExceptions
{
    public class IdNotFoundException : Exception
    {
        public IdNotFoundException(string message = "Id não encontrado") : base(message)
        {
        }
    }
}
