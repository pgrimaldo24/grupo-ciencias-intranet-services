using System;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Auth
{
    public class CredentialDto
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
    public class AuthDto
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CreationDate { get; set; }
    }
    public class JWTDto
    {
        public string Token { get; set; }
        public string Status { get; set; }
    }
}
