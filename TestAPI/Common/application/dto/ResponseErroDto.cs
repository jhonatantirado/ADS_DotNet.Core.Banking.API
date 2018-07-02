
namespace Common.Application.Dto
{
    using System.Collections.Generic;

    public class ResponseErrorDto
    {
        public int httpStatus { get; set; }
        public List<ErrorDto> errors { get; set; }

        public ResponseErrorDto()
        {
        }

        public ResponseErrorDto(List<ErrorDto> errors)
        {
            this.errors = errors;
        }
    }

}

