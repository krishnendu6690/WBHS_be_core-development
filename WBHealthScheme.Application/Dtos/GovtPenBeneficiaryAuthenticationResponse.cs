namespace WBHealthScheme.Application.dtos
{

    public class EmpPenBeneficiaryAuthenticationResponse
    {
        public string AppId { get; set; }
        public string BName { get; set; }
        public string Relation { get; set; }
        public string Age { get; set; }
        public string? Idno { get; set; }  
        public string? EffectDate { get; set; }  
        public string? Ward { get; set; }
        public string? WardGovt { get; set; }
        public string? WardTmc { get; set; }
    }

}