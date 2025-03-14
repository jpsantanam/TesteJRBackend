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
        
        private readonly Tarefas _tarefas;

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

        [HttpGet("{id}")]
        public ActionResult GetTarefaById(int id)
        {
            try
            {
                return Ok(_tarefas.GetTarefaById(id));
            }
            catch (TarefaNaoEncontrada ex) //Verifica se a exceção lançada é do tipo personalizado TarefaNaoEncontrada
            {
                return NotFound(ex.Message); //Retorna a mensagem de erro com o código 404
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

        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            try
            {
                _tarefas.DeletarTarefa(id);
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
