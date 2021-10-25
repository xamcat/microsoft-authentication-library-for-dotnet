// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Identity.Client.TokenAcquisition
{


    /// <summary>
    /// Goals: 
    /// 
    /// 1. Do not expose CCA
    /// 1.1. CCA must be created via options
    /// 1.2. Singleton vs 1 per request? Start with 1 per request.
    /// 1.3. Logging
    /// 
    /// 2. Make it easy to configure caching 
    /// 2.1. Via existing mechanism?
    /// 2.2. Logging is enabled in both cache and MSAL.
    ///
    /// 3. Allow SAL to use ITokenAcquisition?    
    /// 3.1. Specialized method: AcquireTokenForClient with special POP, AcquireTokenOboWith2Assertions
    /// 3.2. Convenience methods: WithClientCredentials(SigningCredentails); WithPOPCredentials(SingingCredentials)
    /// 3.3. Specialized Options?
    /// 
    /// IDownstreamWebApi - the target. HttpClient + delegated handler that uses ITokenAcquisition.
    /// 
    /// 4. POP
    /// 5. B2C
    /// 6. PublicClient
    /// 
    /// ASP.NET Core *AuthenticationSchemes*
    /// </summary>
    public interface ITokenAcquisition
    {
        // redeem the code -> web app
        // 

        Task<AuthenticationResult> GetAccessTokenForUserAsync(
           IEnumerable<string> scopes,
           string tenantId = null,
           string userFlow = null, 
           ClaimsPrincipal user = null, 
           TokenAcquisitionOptions tokenAcquisitionOptions = null);

        Task<AuthenticationResult> GetAuthenticationResultForAppAsync(
           string scope,
           string tenant = null,
           TokenAcquisitionOptions tokenAcquisitionOptions = null);
    }

    public class TokenAcquisition : ITokenAcquisition
    {

    }

    public class TokenAcquisitionOptions
    {
    }



}
