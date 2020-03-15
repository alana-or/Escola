using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Models;
using Escola.Services.Professores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public async Task<IActionResult> Get() => Ok(await professorService.BuscarProfessores());
    }
}
