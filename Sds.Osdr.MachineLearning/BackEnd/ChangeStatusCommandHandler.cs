﻿using CQRSlite.Domain;
using MassTransit;
using Sds.Osdr.MachineLearning.Domain;
using Sds.Osdr.MachineLearning.Domain.Commands;
using System;
using System.Threading.Tasks;

namespace Sds.Osdr.MachineLearning.BackEnd
{
    public class ChangeStatusCommandHandler : IConsumer<ChangeStatus>
    {
        private readonly ISession session;

        public ChangeStatusCommandHandler(ISession session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public async Task Consume(ConsumeContext<ChangeStatus> context)
        {
            var model = await session.Get<Model>(context.Message.Id);

            model.ChangeStatus(context.Message.UserId, context.Message.Status);

            await session.Commit();
        }
    }
}
