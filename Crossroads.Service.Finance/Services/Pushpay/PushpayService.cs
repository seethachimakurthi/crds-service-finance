﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Crossroads.Service.Finance.Interfaces;
using Crossroads.Service.Finance.Models;
using Pushpay;
using Pushpay.Client;

namespace Crossroads.Service.Finance.Services
{
    public class PushpayService : IPushpayService
    {
        private readonly IPushpayClient _pushpayClient;
        private readonly IMapper _mapper;

        public PushpayService(IPushpayClient pushpayClient, IMapper mapper)
        {
            _pushpayClient = pushpayClient;
            _mapper = mapper;
        }

        public PaymentsDto GetChargesForTransfer(string settlementKey)
        {
            var result = _pushpayClient.GetPushpayDonations(settlementKey);
            return _mapper.Map<PaymentsDto>(result);
        }

        // TODO replace
        public Boolean DoStuff()
        {
            _pushpayClient.DoStuff();
            return true;
        }

    }
}
