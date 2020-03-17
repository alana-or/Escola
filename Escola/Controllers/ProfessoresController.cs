using Escola.Services.Professores;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Escola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessoresController : ControllerBase
    {

        private readonly IProfessorService professorService;

        public ProfessoresController(IProfessorService professorService)
        {
            this.professorService = professorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await professorService.BuscarProfessores());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await professorService.BuscarProfessor(id));
    }
}
