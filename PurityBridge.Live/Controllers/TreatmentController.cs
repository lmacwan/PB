﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace PurityBridge.Live
{
    public class TreatmentController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            return base.Index(model);
        }

        public ActionResult Photos(RenderModel model)
        {
            return RedirectToAction("Treatment", "Photos", new { model = model });
        }

        public ActionResult Videos(RenderModel model)
        {
            return RedirectToAction("Treatment", "Videos", new { model = model });
        }
    }
}
