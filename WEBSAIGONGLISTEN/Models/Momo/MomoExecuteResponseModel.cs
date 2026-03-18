namespace WEBSAIGONGLISTEN.Models.Momo;

public class MomoExecuteResponseModel
{
    public string UserID { get; set; }
    public string TotalPrice { get; set; }
    public string OrderInfo { get; set; }
    public string ErrorCode { get; set; }
    public string Message { get; set; }
    public string LocalMessage { get; set; }
    public bool IsSuccess => string.IsNullOrEmpty(ErrorCode) || ErrorCode == "0";
}