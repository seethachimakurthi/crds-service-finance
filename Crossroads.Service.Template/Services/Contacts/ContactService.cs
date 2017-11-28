﻿using System;
using AutoMapper;
using Crossroads.Service.Template.Models;
using Crossroads.Service.Template.Services.Interfaces;
using MinistryPlatform.Interfaces;

namespace Crossroads.Service.Template.Services.Contact
{
    public class ContactService : IContactService
    {
        IContactRepository _contactRepository;
        IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public ContactDto GetContact(int contactId)
        {
            var mpContact = _contactRepository.GetContact(contactId);
            if (mpContact != null)
            {
                return _mapper.Map<ContactDto>(mpContact);
            }
            return null;
        }

    }
}
