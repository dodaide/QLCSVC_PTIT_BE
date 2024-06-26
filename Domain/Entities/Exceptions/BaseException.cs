﻿using System.Text.Json;

namespace Domain.Entities;

public class BaseException
{
    /// <summary>
    ///     Hàm biến đổi thành chuỗi
    /// </summary>
    /// <returns>
    ///     Chuỗi Json
    /// </returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    #region Properties

    /// <summary>
    ///     Mã lỗi nghiệp vụ
    /// </summary>
    public int ErrorCode { get; set; }

    /// <summary>
    ///     Thông báo cho Dev
    /// </summary>
    public string? DevMessage { get; set; }

    /// <summary>
    ///     Thông báo cho người dùng
    /// </summary>
    public string? UserMessage { get; set; }

    /// <summary>
    ///     Id của lỗi trong log
    /// </summary>
    public string? TraceId { get; set; }

    /// <summary>
    ///     Đường dẫn tới trang tra cứu lỗi
    /// </summary>
    public string? MoreInfo { get; set; }

    /// <summary>
    ///     Danh sách lỗi
    /// </summary>
    public object? Errors { get; set; }

    #endregion
}