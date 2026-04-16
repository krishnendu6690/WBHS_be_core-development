namespace WBHealthScheme.Domain.Entities;

public class UnivfamilyDetails
    {
        public string SLR_NO { get; set; } = null!;
        public string APP_ID { get; set; } = null!;
        public string PAN_ID { get; set; } = null!;
        public string BEN_ID { get; set; } = null!;

        public string? BEN_NM { get; set; }
        public DateTime? BEN_DOB { get; set; }
        public string? AGE { get; set; }
        public string? INCOME { get; set; }
        public string? RELATION { get; set; }
        public string? BLD_GRP { get; set; }

        public string? ID_TYPE { get; set; }
        public string? ID_NO { get; set; }

        public string? BEN_PHOTO_FILE_NAME { get; set; }
        public byte[]? BEN_IMG_PHOTO { get; set; }

        public string? BEN_SIG_FILE_NAME { get; set; }
        public byte[]? BEN_IMG_SIG { get; set; }

        public string? PHOTO_FTP { get; set; }
        public string? SIGN_FTP { get; set; }

        public DateTime? STATUS_UPDATION_DATETIME { get; set; }
        public string? UPLOADING_ID { get; set; }
        public string? UPLOADING_IP { get; set; }

        public string? IS_EXISTS { get; set; }
        public string? status { get; set; }

        public DateTime? date_death { get; set; }
        public string? TERM_CAUSE { get; set; }
        public DateTime? TERM_DATETIME { get; set; }
        public DateTime? INVALID_DATETIME { get; set; }

        public DateTime? INSERTED_DATETIME { get; set; }

        public string? BEN_CAT { get; set; }
        public DateTime? valid_upto { get; set; }

        public string? ben_mob_no { get; set; }
        public string? ben_email { get; set; }

        public string? Adhar_No { get; set; }
        public string? INSERT_FTP_FLAG { get; set; }

        public DateTime? APPROVE_REJECT_DATETIME { get; set; }
        public DateTime? effect_date { get; set; }

        public string? APPROVE_USER { get; set; }
        public string? APPROVER_USER_ROLL { get; set; }
        public string? APPROVER_NAME { get; set; }
        public string? APPROVER_DESIG { get; set; }
    }