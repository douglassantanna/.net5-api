using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace UsuariosAPI.Models
{
    public class Mensagem
    {
        public string Conteudo { get; set; }
        public string Assunto { get; set; }
        public List<MailboxAddress> Destinatario { get; set; }
        public Mensagem(IEnumerable<string> destinatario, string assunto, int usuarioId, string codigo)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(dest => new MailboxAddress(dest)));
            Assunto = assunto;
            Conteudo = $"https://localhost:6001/confirmar-email?UsuarioId={usuarioId}&CodigoDeAtivacao={codigo}";
        }


    }
}