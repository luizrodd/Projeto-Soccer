using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using APIzinha.ViewModels;
using Service.DTOs;

namespace APIzinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        private readonly IChampionshipService _championshipService;
        public ChampionshipsController(IChampionshipService championshipService)
        {
            _championshipService = championshipService;
        }

        /// <summary>
        /// Obtém todos os campeonatos.
        /// </summary>
        /// <returns>Lista de campeonatos.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ChampionshipVMGet>), 203)]
        [ProducesResponseType(typeof(List<ChampionshipVMGet>), 400)]
        [ProducesResponseType(typeof(List<ChampionshipVMGet>), 500)]
        public async Task<IActionResult> GetAll()
        {
            var championships = await _championshipService.GetAll();
            var vm = championships.Select(x => new ChampionshipVMGet()
            {
                Name = x.Name,
                Image = x.Image,
                Rounds = x.Rounds,
                Teams = x.TeamsList.Count,
                Games = x.GamesList.Count,
            });
            if (vm.Count() == 0)
                return StatusCode(203, "Está vazia");

            return StatusCode(200, vm);
        }

        /// <summary>
        /// Cria um novo campeonato.
        /// </summary>
        /// <param name="championship">Informações do campeonato a ser criado.</param>
        /// <returns>Resposta de status.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(typeof(bool), 400)]
        [ProducesResponseType(typeof(bool), 500)]
        public async Task<IActionResult> Create(ChampionshipVMCreate championship )
        {
            var dto = new ChampionshipDTO() { Name = championship.Name, Image = championship.Image, Rounds = championship.Rounds };
            var returnStatus = await _championshipService.Create(dto);
            if (returnStatus != true)
                return StatusCode(400, "Não foi criado");

            return StatusCode(201, "Criado");
            
        }

        /// <summary>
        /// Atualiza um campeonato.
        /// </summary>
        /// <param name="championship">Informações do campeonato a ser atualizado.</param>
        /// <returns>Resposta de status.</returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(typeof(bool), 400)]
        [ProducesResponseType(typeof(bool), 500)]
        public async Task<IActionResult> Update (ChampionshipVMCreate championship)
        {
            var dto = new ChampionshipDTO() { Name = championship.Name, Image = championship.Image, Rounds = championship.Rounds };
            var returnStatus = await _championshipService.Update(dto);
            if (returnStatus != true)
                return StatusCode(400, "Não foi atualizado");

            return StatusCode(201, "Atualizado");
        }

        /// <summary>
        /// Apaga um campeonato.
        /// </summary>
        /// <param name="id">Id do campeonato a ser apagado.</param>
        /// <returns>Resposta de status.</returns>
        [HttpDelete]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 400)]
        [ProducesResponseType(typeof(bool), 500)]
        public async Task<IActionResult> Delete (Guid id)
        {
            var returnStatus = await _championshipService.Delete(id);
            if (returnStatus != true)
                return StatusCode(404, "Não foi encontrado esse campeonato");

            return StatusCode(200, "Excluído");
        }
    }
}
