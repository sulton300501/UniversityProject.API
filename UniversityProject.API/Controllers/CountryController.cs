﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Application.UseCases.Countries.Commands;
using UniversityProject.Application.UseCases.Countries.Queries;

namespace UniversityProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly IMediator _mediatr;

        public CountryController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }



        [HttpPost]
        public async Task<IActionResult> createAuthor(CreateCountryCommand command, CancellationToken cancellation)
        {
            var result = await _mediatr.Send(command, cancellation);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> deleteAuthor(DeleteCountryCommand command, CancellationToken cancellation)
        {
            var result = await _mediatr.Send(command, cancellation);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> updateAuthor(UpdateCountryCommand command, CancellationToken cancellation)
        {
            var result = await _mediatr.Send(command, cancellation);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getAllAuthor( CancellationToken cancellation)
        {
            var data = new GetAllCountryCommand();
            var result = await _mediatr.Send(data, cancellation);
            return Ok(result);
        }




    }
}
