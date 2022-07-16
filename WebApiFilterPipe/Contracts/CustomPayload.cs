using System;
namespace WebApiFilterPipe.Contracts
{
    public class CustomPayload
    {
        public Guid IdOrganizacao { get; set; }
        public Guid IdUsuario { get; set; }
        public bool UsuarioEmbarcado { get; set; }
    }
}

