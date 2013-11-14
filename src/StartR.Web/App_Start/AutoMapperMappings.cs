using AutoMapper;
using StartR.Domain;
using StartR.Lib.Messaging.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartR.Web
{
    public static class AutoMapperMappings
    {
        public static void Initialize()
        {
            Mapper.CreateMap<Client, ClientCreatedEvent>();
        }
    }
}