using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.Domain.Enum;

namespace WebAppTesting.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; } //запис опису помилки

        public StatusCode StatusCode { get; set; } //Код помилки

        public T Data { get; set; } //запис результату


    }

    public interface IBaseResponse<T>
    {
        T Data { get; }
        StatusCode StatusCode { get; }
    }
}
