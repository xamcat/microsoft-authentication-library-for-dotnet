// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Microsoft.Identity.Client.Extensibility
{
    /// <summary>
    /// Extensions for <see cref="AcquireTokenForClientParameterBuilder"/>
    /// </summary>
    public static class AcquireTokenForClientBuilderExtensions
    {
        /// <summary>
        /// Overrides the client credentials parameters (e.g. client_assertion) and optionally ties the 
        /// resulting token to a key id, similar to POP tokens.
        /// </summary>
        /// <param name="clientAssertionOverride">A lambda which receives a string representing the value of the token endpoint and which needs to return key value pairs to be added to the POST payload</param>
        /// <param name="keyId">A key id to which the access token is associated. The token will not be retrieved from the cache unless the same key id is presented. Can be null.</param>
        /// <param name="builder">Builder to chain config options to</param>
        /// <returns>The builder</returns>
        public static AbstractConfidentialClientAcquireTokenParameterBuilder<T> WithClientAssertionOverride<T>
            (this AbstractConfidentialClientAcquireTokenParameterBuilder<T> builder,
            Func<string, IReadOnlyList<KeyValuePair<string, string>>> clientAssertionOverride,
            string keyId = null)
            where T : AbstractConfidentialClientAcquireTokenParameterBuilder<T>
        {
            builder.ValidateUseOfExperimentalFeature();

            builder.CommonParameters.ClientAssertionOverride = clientAssertionOverride;
            if (!string.IsNullOrEmpty(keyId))
                builder.CommonParameters.AuthenticationScheme = new ExternalBoundTokenScheme(keyId);

            return builder;
        }
    }
}
