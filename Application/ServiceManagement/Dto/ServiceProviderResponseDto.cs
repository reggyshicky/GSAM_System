using Domain.Entities.ServiceMngt;

namespace Application.ServiceManagement.Dto
{
    public record ServiceProviderResponseDto(int Id,
                                             string Name,
                                             string AccountNumber,
                                             string PhoneNumber,
                                             string? Postal,
                                             string Email,
                                             Service Service,
                                             Region Region);
}
