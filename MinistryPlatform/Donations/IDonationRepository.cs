﻿using System;
using System.Collections.Generic;
using System.Text;
using MinistryPlatform.Models;

namespace MinistryPlatform.Interfaces
{
    public interface IDonationRepository
    {
        MpDonation GetDonationByTransactionCode(string transactionCode); // theoretically on settlement as transactionid
        List<MpDonation> Update(List<MpDonation> donations);
        MpDonation Update(MpDonation donation);
        MpDonor CreateDonor(MpDonor donor);
        MpDonorAccount CreateDonorAccount(MpDonorAccount donor);
    }
}
