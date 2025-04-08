namespace Hotels.Application.Dtos
{
    public record ReviewDto(
        string ReviewerName,
        string Comment,
        int Rating,
        Guid HotelId,
        Guid Id,
        DateTime CreateAt,
        DateTime? LastModified,
        string? CreatedBy,
        string? LastUdpatedBy);
}
