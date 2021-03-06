﻿using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace PurityBridge.Live
{
    public class TheRightChoiceController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            var breadcrumbs = new List<BreadCrumbElement>();

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = (string)model.Content.GetProperty("heading").Value,
                Value = "/" + model.Content.UrlName
            });

            ViewBag.BreadCrumbs = breadcrumbs;
            return base.Index(model);
        }
    }
}
