// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Identity.Client.Extensibility;

namespace Microsoft.Identity.Client.Extensibility
{
    /// <summary>
    /// </summary>
    public static class AcquireTokenParameterBuilderExtensions
    {
        /// <summary>
        /// Adds additional Http Headers to the token request.
        /// </summary>
        /// <param name="builder">Parameter builder for a acquiring tokens.</param>
        /// <param name="extraHttpHeaders">additional Http Headers to add to the token request.</param>
        /// <returns>builder to chain other methods to</returns>
        public static T WithExtraHttpHeaders<T>(this AbstractAcquireTokenParameterBuilder<T> builder, IDictionary<string, string> extraHttpHeaders)
            where T : AbstractAcquireTokenParameterBuilder<T>
        {
            builder.CommonParameters.ExtraHttpHeaders = extraHttpHeaders;
            return (T)builder;
        }

        /// <summary>
        /// Configure the request to use an <see cref="IAuthenticationScheme"/>. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">builder to chain other methods to</param>
        /// <param name="scheme">the auth scheme</param>
        /// <returns>builder to chain other methods to</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T WithAuthenticationScheme<T>(this AbstractAcquireTokenParameterBuilder<T> builder, IAuthenticationScheme scheme)
            where T : AbstractAcquireTokenParameterBuilder<T>
        {
            builder.CommonParameters.AuthenticationScheme = scheme ?? throw new ArgumentNullException(nameof(scheme));
            return (T)builder;
        }
    }
}

namespace Microsoft.Identity.Client.Advanced
{
    /// <summary>
    /// </summary>
    public static class AcquireTokenParameterBuilderExtensions
    {
        /// <summary>
        /// Adds additional Http Headers to the token request.
        /// </summary>
        /// <param name="builder">Parameter builder for a acquiring tokens.</param>
        /// <param name="extraHttpHeaders">additional Http Headers to add to the token request.</param>
        /// <returns></returns>
        [Obsolete("Please use the same type from Microsoft.Identity.Client.Extensibility namespace", false)]       
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T WithExtraHttpHeaders<T>(this AbstractAcquireTokenParameterBuilder<T> builder, IDictionary<string, string> extraHttpHeaders)
            where T : AbstractAcquireTokenParameterBuilder<T>
        {
            builder.CommonParameters.ExtraHttpHeaders = extraHttpHeaders;
            return (T)builder;
        }
    }
}
