using Pradadge.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace WebApi.Jwt.Filters
{
    public class JwtAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public string Realm { get; set; }
        public bool AllowMultiple => false;

        public JwtAuthenticationAttribute()
        {

        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
                return;

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Jwt Token", request);
                return;
            }

            var token = authorization.Parameter;
            var principal = await AuthenticateJwtToken(token);

            if (principal == null)
                context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);

            else
                context.Principal = principal;
        }



        private static bool ValidateToken(string token, out UserDetail claim)
        {
            claim = null;
             

            var simplePrinciple = JwtManager.GetPrincipal(token);
            var identity = simplePrinciple?.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;
           
            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            var usernameEmail = identity.FindFirst(ClaimTypes.Email);
            var NameIdentifier = identity.FindFirst(ClaimTypes.NameIdentifier);


            //username = usernameClaim?.Value;
            //email = usernameEmail?.Value;
            //userId = NameIdentifier?.Value;

             claim = new UserDetail
            {
                UserEmail = usernameEmail?.Value,
                UserId = NameIdentifier?.Value,
                UserName = usernameClaim?.Value
            };
            
            
            if (string.IsNullOrEmpty(claim.UserName) && string.IsNullOrEmpty(claim.UserId) && string.IsNullOrEmpty(claim.UserEmail))
                return false;

            // More validate to check whether username exists in system

            return true;
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            UserDetail users;

            if (ValidateToken(token, out users))
            {
                // based on username to get more information from database in order to build local identity
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, users.UserName),
                    new Claim(ClaimTypes.Email, users.UserEmail),
                    new Claim(ClaimTypes.NameIdentifier, users.UserId)
                    // Add more claims if needed: Roles, ...
                };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter = null;

            if (!string.IsNullOrEmpty(Realm))
                parameter = "realm=\"" + Realm + "\"";

            context.ChallengeWith("Bearer", parameter);
        }
    }
}
