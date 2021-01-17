// -----------------------------------------------------------------------
// <copyright file="UserReadOnlyController.cs" company="Piotr Xeinaemm Czech">
// Copyright (c) Piotr Xeinaemm Czech. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Template.Api.ReadOnlyControllers
{
    using System.Net.Mime;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Template.Contracts.ApiReadModels;
    using Template.Contracts.Services;
    using Template.Web.Http;

    [Route("repositories/")]
    [ApiController]
    public class UserReadOnlyController : ControllerBase
    {
        private readonly IUserService userService;

        public UserReadOnlyController(IUserService userService) => this.userService = userService;

        [HttpGet("{owner}")]
        [ProducesDefaultResponseType]
        [Produces(TemplateMediaType.MockOutputFormatterJson)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [RequestHeaderMatchesMediaType("Accept", MediaTypeNames.Application.Json, TemplateMediaType.MockOutputFormatterJson)]
        public async Task<IActionResult> GetUserStatistics(string owner, [FromHeader(Name = "Accept")] string mediaType) =>
            mediaType == TemplateMediaType.MockOutputFormatterJson
                ? this.Ok(UserReadModel.MockContract())
                : this.Ok(await this.userService.GetUserStatistics(owner));
    }
}