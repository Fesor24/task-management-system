namespace Shared.EndpointResponseWrapper;

public class ApiResponseBase
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; }
    public bool Successful => StatusCode >= 200 && 
        StatusCode < 300 && string.IsNullOrWhiteSpace(ErrorMessage);
}

public class ApiResponse : ApiResponseBase
{
    public ApiResponse()
    {
        
    }
}

public class ApiResponse<TData> : ApiResponseBase
{
    public TData Data { get; set;}

    public ApiResponse()
    {
        
    }

    public ApiResponse(TData data)
    {
        Data = data;
    }

    public static ApiResponse<T> Ok<T>(T data)
    {
        return new ApiResponse<T>(data)
        {
            StatusCode = 200,
            Data = data
        };
    }

    public static ApiResponse<T> Failed<T>(T data, int statusCode) 
    {
        return new ApiResponse<T>(data)
        {
            Data = data,
            StatusCode = statusCode
        };
    }
}
