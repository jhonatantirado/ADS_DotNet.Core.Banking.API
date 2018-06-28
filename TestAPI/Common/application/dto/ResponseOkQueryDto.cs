
namespace Common.Application.Dto
{
    using System.Collections.Generic;
    public class ResponseOkQueryDto<T> {
	private int httpStatus;
	private List<T> data;
	
	public int getHttpStatus() {
		return httpStatus;
	}

	public void setHttpStatus(int httpStatus) {
		this.httpStatus = httpStatus;
	}
       
	public List<T> getData() {
        return data;
    }

    public void setData(List<T> data) {
        this.data = data;
    }
}

}

