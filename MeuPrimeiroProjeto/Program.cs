using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoInicial {
    internal class Program {
        static void Main(string[] args) {
            var crmService = new Conexao().ObterConexao();
            //FetchXML(crmService);
        }
        static void FetchXML(CrmServiceClient crmService) // recebe como parâmetro a conexão - Método
        {
            string query = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                             <entity name='account'>
                             <attribute name='name' />
                             <attribute name='telephone1' />
                             <attribute name='accountid' />
                             <attribute name='emailaddress1' />
                             <order attribute='name' descending='false' />
                             </entity>
                             </fetch>"; // declara variável do tipo String contendo o FechXML da consulta

            EntityCollection colecao = crmService.RetrieveMultiple(new FetchExpression(query)); // declara variável do tipo
            foreach (var item in colecao.Entities) // para cada entidade (registro) armazenará na variável item
            {
                Console.WriteLine(item["name"]); // exibe o atributo name
                if (item.Attributes.Contains("telephone1")) // verifica se retornou o atributo telephone1
                {
                    Console.WriteLine(item["telephone1"]); // exibe o atributo telephone
                }
            }
            Console.ReadKey(); // aguarda o usuário pressionar qualquer tecla para continuar
        }



        static void Create(CrmServiceClient crmService) // recebe como parâmetro a conexão


{
            Guid newRecord = new Guid(); // declara variável do tipo Guid
            Entity newEntity = new Entity("account"); // declara variável do Entity a partir da entidade Account
            newEntity.Attributes.Add("name", "Conta Criada em Treinamento - " + DateTime.Now.ToString()); // nome
            newEntity.Attributes.Add("telephone1", "11985326471"); // telefone
            newEntity.Attributes.Add("emailaddress1", "contato@provedor.com"); // e-mail
            newRecord = crmService.Create(newEntity); // executa o método Create e armazena na variável newRecord o Guid retornado do novo registro no Dataverse. 

            if (newRecord != Guid.Empty) // verificar se a variável newRecord contém um Guid
{
                Console.WriteLine("Id do Registro criado : " + newRecord); // exibe informação no console do usuário
            } else // caso contrário
              {
                Console.WriteLine("newRecord não criado!"); // exibe informação que não foi criado o registro
            }
            Console.ReadKey(); // aguarda o usuário pressionar qualquer tecla para continuar
        }


    }
}
