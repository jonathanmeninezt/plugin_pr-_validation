using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoInicial {
    internal class Conexao {
        private static CrmServiceClient crmServiceClientTreinamento; // variável do tipo CrmServiceCliente
        public CrmServiceClient ObterConexao() // método que devolve uma CrmServiceCliente
        {
            // variável contendo a ConnectionString
            var connectionStringCRM = @"AuthType=OAuth;
                                     Username = 202304067317@alunos.estacio.br;
                                     Password = **********; SkipDiscovery = True;
                                     AppId = 51f81489-12ee-4a9e-aaae-a2591f45987d;
                                     RedirectUri = app://58145B91-0C36-4500-8554-080854F2AC97;
                                     Url = https://org14dcc1da.crm2.dynamics.com/main.aspx;";

            if (crmServiceClientTreinamento == null) // verifica se a variável crmServiceClientTrinamento está vazia
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // define o protocolo segurança
                crmServiceClientTreinamento = new CrmServiceClient(connectionStringCRM); // executa a conexão
            }
            return crmServiceClientTreinamento; // retorna a conexão para o método chamador
        }

    }
}
