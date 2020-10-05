using System;
using System.Threading.Tasks;
using Api.Dtos;
using Domain.Entities;
using Domain.Services;
using Domain.UnitOfWorks.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeriesController : ControllerBase
    {
        /// <summary>
        /// <see cref="ISerieService"/> to use for managing series.
        /// </summary>
        private readonly ISerieService _serieService;
        private readonly ISerieRepository _serieRepository;

        public SeriesController(ISerieService serieService, ISerieRepository serieRepository)
        {
            if (serieService == null)
                throw new ArgumentNullException(nameof(serieService));

            _serieService = serieService;
            _serieRepository = serieRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetSeries()
        {
            var series = await _serieRepository.AllSync();
            return Ok(series);
        }

        [HttpGet("{id}", Name = "SerieById")]
        public async Task<IActionResult> GetSerieById(int id)
        {
            var serie = await _serieService.SingleOrDefaultAsync(id);

            return Ok(serie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSerie([FromBody] SerieDto serieDto)
        {
            var serie = new Serie(
                serieDto.Name,
                serieDto.Episodes,
                serieDto.Release
            );

            await _serieService.CreateAsync(serie);

            return CreatedAtRoute("SerieById", new { id = serie.Id }, serie);
        }
    }
}