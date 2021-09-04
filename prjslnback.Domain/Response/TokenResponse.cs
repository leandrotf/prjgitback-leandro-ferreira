using System;

namespace prjslnback.Domain.Response
{
    public class TokenResponse
    {
        public string UserName { get; set; }
        public bool Authenticated { get; set; }
        public string Token { get; set; }
        public DateTime? ValidUntil { get; set; }
    }
}
