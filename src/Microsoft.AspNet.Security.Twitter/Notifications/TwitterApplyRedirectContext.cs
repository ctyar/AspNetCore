﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Security;
using Microsoft.AspNet.Security.Notifications;

namespace Microsoft.AspNet.Security.Twitter
{
    /// <summary>
    /// Context passed when a Challenge causes a redirect to authorize endpoint in the Twitter middleware
    /// </summary>
    public class TwitterApplyRedirectContext : BaseContext<TwitterAuthenticationOptions>
    {
        /// <summary>
        /// Creates a new context object.
        /// </summary>
        /// <param name="context">The HTTP request context</param>
        /// <param name="options">The Facebook middleware options</param>
        /// <param name="properties">The authenticaiton properties of the challenge</param>
        /// <param name="redirectUri">The initial redirect URI</param>
        public TwitterApplyRedirectContext(HttpContext context, TwitterAuthenticationOptions options,
            AuthenticationProperties properties, string redirectUri)
            : base(context, options)
        {
            RedirectUri = redirectUri;
            Properties = properties;
        }

        /// <summary>
        /// Gets the URI used for the redirect operation.
        /// </summary>
        public string RedirectUri { get; private set; }

        /// <summary>
        /// Gets the authenticaiton properties of the challenge
        /// </summary>
        public AuthenticationProperties Properties { get; private set; }
    }
}
