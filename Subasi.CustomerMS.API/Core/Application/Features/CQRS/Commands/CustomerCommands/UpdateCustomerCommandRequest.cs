﻿using MediatR;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands
{
    public class UpdateCustomerCommandRequest : IRequest
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
