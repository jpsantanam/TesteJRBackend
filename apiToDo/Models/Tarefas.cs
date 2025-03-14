using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        private List<TarefaDTO> _tarefas;

        public Tarefas()
        {
            _tarefas = new List<TarefaDTO>
            {
                new() { IdTarefa = 1, DsTarefa = "Fazer Compras" },
                new() { IdTarefa = 2, DsTarefa = "Fazer Atividade Faculdade" },
                new() { IdTarefa = 3, DsTarefa = "Subir Projeto de Teste no GitHub" }
            };
        }

        public List<TarefaDTO> LstTarefas()
        {
            try
            {
                return _tarefas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TarefaDTO GetTarefaById(int idTarefa)
        {
            try
            {
                var tarefa = _tarefas.FirstOrDefault(x => x.IdTarefa == idTarefa); //Busca a tarefa na lista de tarefas

                if (tarefa is null) //Verifica se a tarefa foi encontrada
                {
                    throw new TarefaNaoEncontrada($"Nenhuma tarefa encontrada com o id {idTarefa}."); //Caso não tenha sido encontrada, lança a exceção personalizada TarefaNaoEncontrada
                }

                return tarefa; //Retorna a tarefa encontrada
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void InserirTarefa(TarefaDTO request)
        {
            try
            {
                _tarefas.Add(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletarTarefa(int idTarefa)
        {
            var tarefa = GetTarefaById(idTarefa); //Chama o método GetTarefaById para retornar a tarefa, caso ela exista

            _tarefas.Remove(tarefa); //Remove a tarefa da lista
        }
    }
}