namespace Task9.Models.DTO
{
    public class ResultDTO<T>
    {
        public int Code {  get; init; }

        public T Result { get; init; }
    }
}
