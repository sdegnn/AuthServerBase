using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class Response<T> where T:class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }

        [JsonIgnore] //ıssucccessful prop ıgnore edilecek serialize edilirken.
        public bool IsSuccessful { get;  private set; } //status code yerine proje içinde kontrol etmemizi kolayca sağlar.

        public ErrorDto Error { get;  private set; }

        public static Response<T> Success(T data,int statusCode)
        {

            return new Response<T> { Data = data, StatusCode = statusCode,IsSuccessful=true };
            
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data=default,StatusCode = statusCode, IsSuccessful = true };
            
        }
        public static Response<T> Fail(ErrorDto errorDto,int statusCode)
        {
            return new Response<T>
            {
                Error = errorDto,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }
        public static Response<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDTO = new ErrorDto(errorMessage, isShow);

            return new Response<T> { Error = errorDTO, StatusCode = statusCode, IsSuccessful = false };

        }

    }
}
