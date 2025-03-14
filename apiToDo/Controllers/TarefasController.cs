using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        
        private Tarefas _tarefas;

        public TarefasController(Tarefas tarefas)
        {
            _tarefas = tarefas;
        }

        [HttpGet]
        public ActionResult LstTarefas()
        {
            try
            {
                return Ok(_tarefas.LstTarefas());
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpPost]
        public ActionResult InserirTarefas([FromBody] TarefaDTO request)
        {
            try
            {
                _tarefas.InserirTarefa(request);
                return Ok(_tarefas.LstTarefas());

            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpDelete]
        public ActionResult DeleteTask([FromQuery(Name="ID_TAREFA")] int idTarefa)
        {
            try
            {
                _tarefas.DeletarTarefa(idTarefa);
                return Ok(_tarefas.LstTarefas());
            }
            catch(TarefaNaoEncontrada ex) //Verifica se a exceção lançada é do tipo personalizado TarefaNaoEncontrada
            {
                return NotFound(ex.Message); //Retorna a mensagem de erro com o código 404
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
