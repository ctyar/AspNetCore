﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Http.Security;

namespace Microsoft.AspNet.Security.Twitter.Messages
{
    /// <summary>
    /// The Twitter request token obtained from the request token endpoint.
    /// </summary>
    public class RequestToken
    {
        /// <summary>
        /// Gets or sets the Twitter request token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the Twitter token secret.
        /// </summary>
        public string TokenSecret { get; set; }

        public bool CallbackConfirmed { get; set; }

        /// <summary>
        /// Gets or sets a property bag for common authentication properties.
        /// </summary>
        public AuthenticationProperties Properties { get; set; }
    }
}
