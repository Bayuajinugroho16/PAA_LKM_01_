using System.Collections.Generic;

namespace PAA_LKM_01.DTOs
{
    public class ApiResponse<T>
    {
        public string Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public MetaData Meta { get; set; }
    }

    public class ApiErrorResponse
    {
        public string Status { get; set; } = "error";
        public string Message { get; set; }
    }

    public class MetaData
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
    }
}