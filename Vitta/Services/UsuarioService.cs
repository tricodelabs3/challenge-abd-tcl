using Vitta.Models;
using System;

namespace Vitta.Services {
    public class UsuarioService {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository) {
            _repository = repository;
        }

        
        public void Cadastrar(Usuario usuario) {
            if (string.IsNullOrWhiteSpace(usuario.Nome))
                throw new Exception("O nome � obrigat�rio.");

            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new Exception("O email � obrigat�rio.");

            _repository.Add(usuario);
        }


        public void Atualizar(Usuario usuario) {
            if (usuario.Id <= 0)
                throw new Exception("Usu�rio inv�lido.");

            _repository.Update(usuario);
        }

        public void Excluir(int id) {
            _repository.Delete(id);
        }

        public List<Usuario> ListarTodos() => _repository.GetAll();
        public Usuario? BuscarPorId(int id) => _repository.GetById(id);
    }
}
