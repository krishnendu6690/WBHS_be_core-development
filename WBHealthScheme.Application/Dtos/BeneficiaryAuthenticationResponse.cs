namespace WBHealthScheme.Application.Dtos
{
    public class BeneficiaryAuthenticationResponse
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
    }
    public class Beneiciary_ward_resp_broto
    {
    public string wardname {get; set;}
    public string wardtmc { get; set; }
    public string wardgovt { get; set; }
   }
}