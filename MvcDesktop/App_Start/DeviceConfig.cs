﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace MvcDesktop
{
    /// <summary>
    /// Device specific startup configuration
    /// </summary>
    public static class DeviceConfig
    {
        const string DeviceTypePhone = "Phone";               
        const string DeviceTypeTablet = "Tablet";

        /// <summary>
        /// Evaluates incoming request and determines device.
        /// Adds an entry into the Display mode table
        /// </summary>
        public static void EvaluateDisplayMode()
        {
            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode(DeviceTypePhone)
                {  //modify file (view that is served)

                    //Query condition
                    ContextCondition = (ctx => (

                        //look at user agent
                        (ctx.GetOverriddenUserAgent() != null) &&

                        (//...either iPhone or iPad

                            (ctx.GetOverriddenUserAgent().IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (ctx.GetOverriddenUserAgent().IndexOf("iPod", StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                ))
                });

            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode(DeviceTypeTablet)
                {
                    ContextCondition = (ctx => (

                        (ctx.GetOverriddenUserAgent() != null) &&

                        (
                            (ctx.GetOverriddenUserAgent().IndexOf("iPad", StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (ctx.GetOverriddenUserAgent().IndexOf("Playbook", StringComparison.OrdinalIgnoreCase) >= 0)
                        )

                ))
                });
        }
    }
}