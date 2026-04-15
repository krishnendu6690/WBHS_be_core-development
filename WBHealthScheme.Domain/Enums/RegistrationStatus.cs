// ==========================================================
// Enum: RegistrationStatus
// Purpose: Defines complete application workflow states
// Layer: Domain
// Architecture: Enterprise Clean Architecture
// ==========================================================

namespace WBHealthScheme.Domain.Enums;

public enum RegistrationStatus
{
    Draft = 0,

    PersonalCompleted = 1,

    OfficeCompleted = 2,

    FamilyCompleted = 3,
    PhotoUploaded = 4,

    CcaCompleted = 5,

    Submitted = 6,

    DdoApproved = 7,

    DdoRejected = 8,

    HooApproved = 9,

    HooRejected = 10
}