
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
        public string APP_ID { get; set; }
        public string bName { get; set; }
        public string Relation { get; set; }
        public string age { get; set; }
        public string idno { get; set; }  
        public string effect_date { get; set; }  
        public string ward { get; set; }
        public string WARD_GOVT { get; set; }
        public string WARD_TMC { get; set; }
    }
}