using System;
using Microsoft.AspNetCore.Mvc;
using Voyages.Domain;

namespace Voyages.WebApi.Controllers
{

    [Route("[controller]")]
    public class VoyageController : Controller
    {
        private readonly IVoyageService voyageService;

        public VoyageController(IVoyageService voyageService)
        {
            if (voyageService == null)
                throw new ArgumentNullException(
                    "voyageService");

            this.voyageService = voyageService;
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetClient([FromRoute] int id)
        {
            try
            {
                var client = voyageService.GetClient(id);
                if (client != null)
                {
                    return Ok(client);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("[action]/{name}/{lastname}")]
        public IActionResult GetClientByName([FromRoute] string name, string lastname)
        {
            try
            {
                var client = voyageService.GetClientByName(name, lastname);
                if (client != null)
                {
                    return Ok(client);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetFile([FromRoute] int id)
        {
            try
            {
                var file = voyageService.GetFile(id);
                if (file != null)
                {
                    return Ok(file);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            try
            {
                var product = voyageService.GetProduct(id);
                if (product != null)
                {
                    return Ok(product);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}