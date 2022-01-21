﻿using MediatR;
using Unicorn.Core.Development.ServiceHost.SDK.DTOs;
using Unicorn.Core.Infrastructure.Communication.Common.Operation;

namespace Unicorn.Core.Development.ServiceHost.Controllers;

internal class GetFilmsDescriptionRequest : IRequest<OperationResult<FilmDescriptionDTO>>
{
    public Guid FilmId { get; set; }
}