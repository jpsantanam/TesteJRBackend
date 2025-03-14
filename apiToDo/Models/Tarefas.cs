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
            var tarefa = _tarefas.FirstOrDefault(x => x.IdTarefa == idTarefa); //Percorre a lista de tarefas e retorna a primeira ocorrência (se tiver) ou nulo
            
            if (tarefa is null) //Verifica se a tarefa foi encontrada
            {
                throw new TarefaNaoEncontrada($"Nenhuma tarefa encontrada com o id {idTarefa}."); //Lança uma exceção personalizada
            }

            _tarefas.Remove(tarefa); //Remove a tarefa encontrada
        }
    }
}
