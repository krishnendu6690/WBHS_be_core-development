namespace WBHealthScheme.Application.Dtos
{
    public class UnivBeneficiaryAuthenticationResponse
    {
        public string ApplicationId { get; set; }
        public string EmployeeId { get; set; }
        public string BeneficiaryId { get; set; }
        public string BeneficiaryName { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string MemberType { get; set; }
        public string Relation { get; set; }
        public string RegistrationStatus { get; set; }
        public DateTime? ValidUpto { get; set; }
        public string BloodGroup { get; set; }
        public string PhotoPath { get; set; }
        public string SignPath { get; set; }
    }

}