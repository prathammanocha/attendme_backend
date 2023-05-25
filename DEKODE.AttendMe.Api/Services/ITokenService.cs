using System.Collections.Generic;
using System.Security.Claims;

namespace DEKODE.AttendMe.Api.Services
{
    public interface ITokenService
    {
        string GenerateToken(string userName, string organisationId, string firstname, string lastname);

        string GenerateToken(string userName, string organisationId, byte[] key);

        IEnumerable<Claim> ValidateToken(string token, byte[] key);
    }
}