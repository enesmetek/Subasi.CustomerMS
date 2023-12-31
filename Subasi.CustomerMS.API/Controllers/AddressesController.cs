﻿using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Requests;

namespace Subasi.CustomerMS.API.Controllers
{
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IValidator<CreateAddressCommandRequest> _createAddressCommandRequestValidator;
        private readonly IValidator<UpdateAddressCommandRequest> _updateAddressCommandRequestValidator;
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator, 
            IValidator<CreateAddressCommandRequest> createAddressCommandRequestValidator, 
            IValidator<UpdateAddressCommandRequest> updateAddressCommandRequestValidator)
        {
            _mediator = mediator;
            _createAddressCommandRequestValidator = createAddressCommandRequestValidator;
            _updateAddressCommandRequestValidator = updateAddressCommandRequestValidator;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllAddressesQueryRequest());
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetAddressQueryRequest(id));
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet]
        [Route("api/Customers/{id}/[controller]")]
        public async Task<IActionResult> GetByCustomerID(int id)
        {
            var result = await _mediator.Send(new GetAllAddressesByCustomerIDQueryRequest(id));
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Create(CreateAddressCommandRequest request)
        {
            var result = _createAddressCommandRequestValidator.Validate(request);
            if(result.IsValid)
            {
                await _mediator.Send(request);
                return Created("", request);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Update(UpdateAddressCommandRequest request, int id)
        {
            if (id != request.ID)
            {
                return BadRequest("Route ID and Body ID are not matching.");
            }
            var validationResult = _updateAddressCommandRequestValidator.Validate(request);
            if(validationResult.IsValid)
            {
                var handlerResult = await _mediator.Send(request);
                if(handlerResult.IsSucceed)
                {
                    return NoContent();
                }
                return NotFound();
            }
            return BadRequest(validationResult.Errors); 
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteAddressCommandRequest(id));
            if(result.IsSucceed)
            {
                return NoContent();
                
            }
            return NotFound();
        }
    }
}
