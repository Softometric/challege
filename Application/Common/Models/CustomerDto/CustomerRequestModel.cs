using Domain.Enum;

namespace Application.Common.Models.CustomerDto
{
    public class CustomerRequestModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? StreetNumber { get; set; }
        public string? StreetName { get; set; }
        public string? LandMark { get; set; }
        public string? City { get; set; }
        public Sex? Gender { get; set; }
    }

    public class CustomerModel
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
    }
}
