using SKL.Models;
using SKL.Util;
using System.Collections.Generic;
using SKL.Service;
using SKL.Strategy;
using SKL.Strategy.StrategyImpl;

namespace SKL.Facade
{
    /*
     Fachada para realizar a abstração, criação e 
     execução de serviços e validações do sistema
    */
    public class FacadeImpl : IFacade
    {
        private readonly SkldbMainContext _context;

        private static readonly string _ALTERAR = "ALTERAR";
        private static readonly string _CONSULTAR = "CONSULTAR";
        private static readonly string _DELETAR = "DELETAR";
        private static readonly string _SALVAR = "SALVAR";

        Resultado Resultado { get; set; }
        private IStrategy StrategySelecionada { get; set; }
        private IService ServiceSelecionada { get; set; }

        private Dictionary<string, IService> listaService;
        private Dictionary<string, IStrategy> listaStrategy;
     
        public FacadeImpl(SkldbMainContext context)
        {
            _context = context;
            listaService = MontaServiceDictionary(_context);
            listaStrategy = MontaStrategyDictionary();
        }
        
        private static Dictionary<string, IService> MontaServiceDictionary(SkldbMainContext context)
        {
            return new Dictionary<string, IService>
            {
                { typeof(Login).Name, new LoginService(context) },
            };
        }

        private static Dictionary<string, IStrategy> MontaStrategyDictionary()
        {
            return new Dictionary<string, IStrategy>
            {
                {  typeof(Login).Name, new LoginStrategy() },
            };
        }

        private Resultado ExecutarValidacoes(Entidade entidade, string operacao)
        {
            StrategySelecionada = listaStrategy.GetValueOrDefault(entidade.GetType().Name, null);
            Resultado = StrategySelecionada.ValidaEntidade(entidade);

            return Resultado;
        }


        public Resultado Alterar(Entidade entidade)
        {
            Resultado = ExecutarValidacoes(entidade, _ALTERAR);
            if (Resultado.MensagemErro.Length > 0)
                return Resultado;

            ServiceSelecionada = listaService.GetValueOrDefault(entidade.GetType().Name, null);
            Resultado = ServiceSelecionada.Alterar(entidade);

            return Resultado;
        }

        public Resultado Consultar(Entidade entidade)
        {
            Resultado = ExecutarValidacoes(entidade, _CONSULTAR);
            if (Resultado.MensagemErro.Length > 0)
                return Resultado;

            ServiceSelecionada = listaService.GetValueOrDefault(entidade.GetType().Name, null);
            Resultado = ServiceSelecionada.Consultar(entidade);

            return Resultado;
        }

        public Resultado Deletar(Entidade entidade)
        {
            Resultado = ExecutarValidacoes(entidade, _DELETAR);
            if (Resultado.MensagemErro.Length > 0)
                return Resultado;

            ServiceSelecionada = listaService.GetValueOrDefault(entidade.GetType().Name, null);
            Resultado = ServiceSelecionada.Deletar(entidade);

            return Resultado;
        }

        public Resultado Salvar(Entidade entidade)
        {
            Resultado = ExecutarValidacoes(entidade, _SALVAR);
            if (Resultado.MensagemErro.Length > 0)
                return Resultado;

            ServiceSelecionada = listaService.GetValueOrDefault(entidade.GetType().Name, null);
            Resultado = ServiceSelecionada.Deletar(entidade);

            return Resultado;
        }
    }
}
