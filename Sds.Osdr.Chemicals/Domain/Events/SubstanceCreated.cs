﻿using Sds.CqrsLite.Events;
using System;

namespace Sds.Osdr.Chemicals.Domain.Events
{
    public class SubstanceCreated : IUserEvent
    {
        public SubstanceCreated(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTimeOffset TimeStamp { get; set; } = DateTimeOffset.UtcNow;

        public int Version { get; set; }
    }
}
