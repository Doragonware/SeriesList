using System;
using System.Threading.Tasks;
using Api.Dtos;
using Domain.Entities;
using Domain.Services;
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

        public SeriesController(ISerieService serieService)
        {
            if (serieService == null)
                throw new ArgumentNullException(nameof(serieService));

            _serieService = serieService;

        }

        [HttpGet]
        public async Task<IActionResult> GetSeries()
        {
            var series = await _serieService.AllAsync();
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSerie(int id, [FromBody] SerieDto serieDto)
        {
            var serie = await _serieService.SingleOrDefaultAsync(id);

            serie.SetName(serieDto.Name);
            serie.SetEpisodes(serieDto.Episodes);
            serie.SetRelease(serieDto.Release);

            await _serieService.UpdateAsync(serie);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerie(int id)
        {
            await _serieService.RemoveAsync(id);

            return NoContent();
        }

    }
}