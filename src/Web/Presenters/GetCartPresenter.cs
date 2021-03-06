﻿using Core.Interfaces;
using Core.Dto.UseCaseResponses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Web.Presenters
{
    public sealed class GetCartPresenter : IOutputPort<GetCartResponse>
    {
        public JsonResult JsonResult { get; }

        public GetCartPresenter()
        {
            JsonResult = new JsonResult(null);
        }

        public void Handle(GetCartResponse response)
        {
            JsonResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            JsonResult.Value = response;
        }
    }
}
