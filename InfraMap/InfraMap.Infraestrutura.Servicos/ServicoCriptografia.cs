using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Autenticacao;

namespace InfraMap.Infraestrutura.Servicos
{
    public class ServicoCriptografia : IServicoCriptografia
    {
        public string CriptografarSenha(string senha)
        {
            return PegarHashMd5(senha + "INFRAMAP");
        }

        public string PegarHashMd5(string senha)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();            
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);         
            byte[] hash = md5.ComputeHash(inputBytes);           
            System.Text.StringBuilder sb = new System.Text.StringBuilder();           
            foreach (var b in hash)
            {
                sb.Append(b.ToString("X2"));
            }          
            return sb.ToString();
        }
    }
}
