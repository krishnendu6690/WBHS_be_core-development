namespace WBHealthScheme.Domain.Entities;

public class UnivOfficeDetails
{
     public string SLR_NO { get; set; } = null!;
        public string app_id { get; set; } = null!;
        public string PAN_ID { get; set; } = null!;

        public string? univ_nm { get; set; }
        public string? univ_dist_cd { get; set; }
        public string? sub_div_cd { get; set; }
        public string? block_cd { get; set; }
        public string? univ_addr { get; set; }

        public DateTime? DOJ { get; set; }

        public string? desig_type { get; set; }
        public string? desig { get; set; }

        public string? pay_band { get; set; }
        public string? band_pay { get; set; }

        public string? ward_name { get; set; }
        public string? IS_EXISTS { get; set; }

        public string? gd_pay { get; set; }
        public string? basic_pay { get; set; }

        public string? ropa_type { get; set; }
        public string? pay_lavel { get; set; }
        public string? basic_sal { get; set; }

        public string? dept_cd { get; set; }

        public string? ward_tmc { get; set; }
        public string? ward_gpb { get; set; }
}