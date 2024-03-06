namespace API.Core
{
    public class Result<T>
    {
        public bool IsSucess { get; set; }

        public T Value { get; set; }

        public string Error { get; set; }
        public bool NotFound { get; set; }

        public static Result<T> Success(T value) => new Result<T> { IsSucess = true, Value = value, NotFound = false };
        public static Result<T> Failure(string error, bool notFound) => new Result<T> { IsSucess = false, Error = error, NotFound = notFound };

    }
}
