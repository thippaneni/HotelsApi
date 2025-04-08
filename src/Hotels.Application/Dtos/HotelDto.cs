namespace Hotels.Application.Dtos
{
    public record HotelDto(
        string Name,
        string Address,
        int Stars,
        string Description,
        List<ReviewDto> Reviews,
        Guid Id,
        DateTime CreateAt,
        DateTime? LastModified,
        string? CreatedBy,
        string? LastUdpatedBy);
}
