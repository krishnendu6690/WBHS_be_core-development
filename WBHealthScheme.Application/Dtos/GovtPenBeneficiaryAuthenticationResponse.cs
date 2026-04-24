namespace WBHealthScheme.Application.dtos
{

    public class EmpPenBeneficiaryAuthenticationResponse
    {
        public string APP_ID { get; set; }
        public string bName { get; set; }
        public string Relation { get; set; }
        public string age { get; set; }
        public string? idno { get; set; }  
        public string? effect_date { get; set; }  
        public string? ward { get; set; }
        public string? WARD_GOVT { get; set; }
        public string? WARD_TMC { get; set; }
    }

}