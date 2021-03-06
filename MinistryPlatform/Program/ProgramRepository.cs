﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using Crossroads.Web.Common.Configuration;
using Crossroads.Web.Common.MinistryPlatform;
using log4net;
using MinistryPlatform.Interfaces;
using MinistryPlatform.Models;

namespace MinistryPlatform.Repositories
{
    public class ProgramRepository : MinistryPlatformBase, IProgramRepository
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ProgramRepository(IMinistryPlatformRestRequestBuilderFactory builder,
            IApiUserRepository apiUserRepository,
            IConfigurationWrapper configurationWrapper,
            IMapper mapper) : base(builder, apiUserRepository, configurationWrapper, mapper) { }

        public MpProgram GetProgramByName(string programName)
        {
            var token = ApiUserRepository.GetDefaultApiUserToken();

            // replace ' with '' so that we can search for
            //  a program like I'm in
            var escapedName = programName.Replace("'", "''");
            var filter = $"Program_Name = '{escapedName}'";
            var programs = MpRestBuilder.NewRequestBuilder()
                                .WithAuthenticationToken(token)
                                .WithFilter(filter)
                                .Build()
                                .Search<MpProgram>();

            if(!programs.Any())
            {
                _logger.Error($"GetProgramByName: No program found with name {filter}");
                return null;
            }

            return programs.First();
        }
    }
}
