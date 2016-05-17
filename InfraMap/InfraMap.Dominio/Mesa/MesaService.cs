using System;
using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa.Ramal;
using InfraMap.Dominio.Usuario;
using InfraMap.Dominio.LDAP;

namespace InfraMap.Dominio.Mesa
{
    public class MesaService
    {
        private IMesaRepositorio mesaRepositorio;
        private IUsuarioRepositorio usuarioRepositorio;
        private IMaquinaRepositorio maquinaRepositorio;
        private IRamalRepositorio ramalRepositorio;
        private IModeloMaquinaRepositorio modeloMaquinaRepositorio;
        private IMaquinaPessoalRepositorio maquinaPessoalRepositorio;

        public MesaService(IMesaRepositorio mesaRepositorio, IUsuarioRepositorio usuarioRepositorio, IMaquinaRepositorio maquinaRepositorio, IRamalRepositorio ramalRepositorio, IModeloMaquinaRepositorio modeloMaquinaRepositorio, IMaquinaPessoalRepositorio maquinaPessoalRepositorio)
        {
            this.mesaRepositorio = mesaRepositorio;
            this.usuarioRepositorio = usuarioRepositorio;
            this.maquinaRepositorio = maquinaRepositorio;
            this.ramalRepositorio = ramalRepositorio;
            this.modeloMaquinaRepositorio = modeloMaquinaRepositorio;
            this.maquinaPessoalRepositorio = maquinaPessoalRepositorio;
        }

        public void AdicionarColaborador(int idMesa, string nomeColaborador)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            var colaborador = this.usuarioRepositorio.BuscarPorNome(nomeColaborador);
            if (colaborador == null)
            {
                var login = LDAPService.GetUserLogin(nomeColaborador);
                if (login.Length > 0)
                {
                    colaborador = new Usuario.Usuario(LDAPService.GetUserLogin(nomeColaborador), nomeColaborador, null);
                    colaborador = this.usuarioRepositorio.Adicionar(colaborador);
                }

                if (colaborador == null)
                {
                    throw new ArgumentException("Colaborador não encontrado!");
                }
            }
            var mesaColaborador = this.mesaRepositorio.BuscarMesaPorColaborador(colaborador.Login);
            if (mesaColaborador != null)
            {
                throw new UsuarioEmOutraMesaException("Colaborador " + colaborador.Login + " já está em outra mesa!");
            }

            mesa.AdicionarColaborador(colaborador);
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void TrocarColaborador(int idMesa, string nomeColaborador, bool temMaquina, bool temRamal)
        {
            //TODO: verificar se a troca está correta(teste)
            var mesaNova = this.mesaRepositorio.BuscarPorId(idMesa);
            var colaborador = this.usuarioRepositorio.BuscarPorNome(nomeColaborador);
            var mesaAtual = this.mesaRepositorio.BuscarMesaPorColaborador(colaborador.Login);

            if (mesaAtual != null)
            {
                if (temMaquina && mesaAtual.MaquinaPessoal != null)
                {
                    mesaNova.AdicionarMaquina(mesaAtual.MaquinaPessoal);
                    mesaAtual.RemoverMaquina();
                }

                if (temRamal && mesaAtual.Ramal != null)
                {
                    mesaNova.AdicionarRamal(mesaAtual.Ramal);
                    mesaAtual.RemoverRamal();
                }

                mesaNova.AdicionarColaborador(mesaAtual.Colaborador);
                mesaAtual.RemoverColaborador();
                mesaRepositorio.Atualizar(mesaNova);
                mesaRepositorio.Atualizar(mesaAtual);
            }
        }

        public void RemoverColaborador(int idMesa)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            if (mesa.Colaborador == null)
            {
                throw new Exception("Esta mesa não tem colaborador!");
            }

            mesa.RemoverColaborador();
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void AdicionarMaquina(int idMesa, MaquinaPessoal maquinaPessoal)
        {
            if (maquinaPessoal.EtiquetaServico == "")
                throw new MaquinaEmOutraMesaException("Por favor, insira uma Etiqueta de Serviço válida!");
            if  (maquinaPessoal.Patrimonio < 1)
                throw new MaquinaEmOutraMesaException("Por favor, insira um Patrimônio válido!");
            if (maquinaPessoal.Maquina.ModeloMaquina_Id == 0)
                throw new MaquinaEmOutraMesaException("Por favor, selecione uma máquina válida!");
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            maquinaPessoal.Maquina.ModeloMaquina = this.modeloMaquinaRepositorio.BuscarPorId((int)maquinaPessoal.Maquina.ModeloMaquina_Id);

            if (this.mesaRepositorio.TemMaquinaComPatrimonio(maquinaPessoal.Patrimonio))
            {
                throw new MaquinaEmOutraMesaException("Este patrimônio já está sendo utlizado em outra mesa!");
            }

            if (this.mesaRepositorio.TemMaquinaComEtiqueta(maquinaPessoal.EtiquetaServico))
            {
                throw new MaquinaEmOutraMesaException("Esta Etiqueta de Serviço já está sendo utlizada em outra mesa!");
            }
            var novaMaquinaPessoal = this.maquinaPessoalRepositorio.Adicionar(maquinaPessoal);
            mesa.AdicionarMaquina(novaMaquinaPessoal);
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void RemoverMaquina(int idMesa)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            if (mesa.MaquinaPessoal == null)
            {
                throw new Exception("Esta mesa não possui maquina!");
            }

            mesa.RemoverMaquina();

            this.mesaRepositorio.Atualizar(mesa);
        }

        public void AdicionarRamal(int idMesa, string numeroRamal, int tipoRamal)
        {
            var tipo = (TipoRamal)tipoRamal;
            var ramal = new Ramal.Ramal
            {
                Numero = numeroRamal,
                Tipo = tipo
            };

            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            this.ramalRepositorio.Adicionar(ramal);
            mesa.AdicionarRamal(ramal);
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void RemoverRamal(int idMesa)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            if (mesa.Ramal == null)
            {
                throw new Exception("Esta mesa não possui ramal!");
            }
            var ramal = mesa.Ramal;

            mesa.RemoverRamal();
            this.mesaRepositorio.Atualizar(mesa);

            this.ramalRepositorio.Deletar(ramal);
        }

        public void SalvarCorDosColaboradores(int[] listaIdColaborador, string gerenteLogin)
        {
            var gerente = this.usuarioRepositorio.BuscarPorLogin(gerenteLogin);
            if (gerente == null)
            {
                throw new ArgumentException("Gerente não encontrado!");
            }
            foreach (int idColaborador in listaIdColaborador)
            {
                var colaborador = this.usuarioRepositorio.BuscarPorId(idColaborador);
                if (colaborador != null)
                {
                    colaborador.Cor = gerente.Cor;
                    colaborador.GerenteId = gerente.Id;
                    this.usuarioRepositorio.Atualizar(colaborador);
                }
            }
        }

        public void SalvarCorDosColaboradores(System.Collections.Generic.List<Usuario.Usuario> listaIdColaborador, string gerenteLogin)
        {
            var gerente = this.usuarioRepositorio.BuscarPorLogin(gerenteLogin);
            if (gerente == null)
            {
                throw new ArgumentException("Gerente não encontrado!");
            }
            foreach (var idColaborador in listaIdColaborador)
            {
                    idColaborador.Cor = gerente.Cor;
                    idColaborador.GerenteId = gerente.Id;
                    this.usuarioRepositorio.Atualizar(idColaborador);
            }
        }
    }
}
