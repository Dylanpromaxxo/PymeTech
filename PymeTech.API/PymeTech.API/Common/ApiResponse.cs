namespace PymeTech.API.Common
{
    public class ApiResponse<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public T Data { get; set; } 
        public List<string> Errors { get; set; } = new();


        ///<summary>
        ///Funcion en caso seas exitosa
        ///</summary>
        ///
        public static ApiResponse<T> Ok(T data, string message = "Operacion exitosa ") 
        {
            return new ApiResponse<T>
            {
                Succeeded = true, 
                Message = message, 
                Data = data 
            }; 
        }

        ///<summary>
        ///Funcion en caso seas Falso
        ///</summary>
        public static ApiResponse<T> Fail(string message, List<string> errors = null) 
        {
            return new ApiResponse<T>
            {
                Succeeded = false, 
                Message = message,
                Errors = errors ?? new List<string>()
            };
        }

    }
}
