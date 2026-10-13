using TP2Web.FrontEnd.DTO.Cita.Request;
using TP2Web.FrontEnd.DTO.Cita.Response;
using TP2Web.FrontEnd.Excepciones;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;
using TP2Web.FrontEnd.Repositories;

namespace TP2Web.FrontEnd.Services;

public class CitaService : ICitaService
{
    private readonly ICitaRepository _citaRepository;

    public CitaService(ICitaRepository citaRepository)
    {
        _citaRepository = citaRepository;
    }

    public async Task<CitaPaginado> ObtenerTodasAsync(CitaQueryParameters parametros)
    {
        // Recibimos la tupla desde el repositorio
        var (citas, totalRegistros) = await _citaRepository.ObtenerTodasAsync(parametros);

        // Mapeamos a DTO
        var citasResponse = citas.Select(c => new CitaResponse
        {
            Id = c.Id,
            FechaHora = c.FechaHora,
            Motivo = c.Motivo,
            Estado = c.Estado,
            MascotaId = c.MascotaId,
            VeterinarioId = c.VeterinarioId,
            NombreMascota = c.Mascota?.Nombre ?? "Sin Mascota", // Extraemos los nombres
            NombreVeterinario = c.Veterinario?.Nombre ?? "Sin Veterinario"
        }).ToList();

        // Devolvemos el objeto paginado listo para la UI
        return new CitaPaginado
        {
            Citas = citasResponse,
            TotalRegistros = totalRegistros
        };
    }

    public async Task<CitaResponse> ObtenerPorIdAsync(int id)
    {
        var cita = await _citaRepository.ObtenerPorIdAsync(id);

        if (cita == null)
            throw new RegistroNoEncontradoException("Cita", id);

        return new CitaResponse
        {
            Id = cita.Id,
            FechaHora = cita.FechaHora,
            Motivo = cita.Motivo,
            Estado = cita.Estado,
            MascotaId = cita.MascotaId,
            VeterinarioId = cita.VeterinarioId,
            NombreMascota = cita.Mascota?.Nombre ?? "Sin Mascota",
            NombreVeterinario = cita.Veterinario?.Nombre ?? "Sin Veterinario"
        };
    }

    public async Task CrearAsync(CitaCrear request)
    {
        var nuevaCita = new Cita
        {
            FechaHora = request.FechaHora,
            Motivo = request.Motivo,
            Estado = request.Estado,
            MascotaId = request.MascotaId,
            VeterinarioId = request.VeterinarioId
        };

        _citaRepository.Agregar(nuevaCita);
        await _citaRepository.GuardarCambiosAsync();
    }

    public async Task ActualizarAsync(CitaActualizar request)
    {
        var citaExistente = await _citaRepository.ObtenerPorIdAsync(request.Id);

        if (citaExistente == null)
            throw new RegistroNoEncontradoException("Cita", request.Id);

        citaExistente.FechaHora = request.FechaHora;
        citaExistente.Motivo = request.Motivo;
        citaExistente.Estado = request.Estado;
        citaExistente.MascotaId = request.MascotaId;
        citaExistente.VeterinarioId = request.VeterinarioId;

        _citaRepository.Actualizar(citaExistente);
        await _citaRepository.GuardarCambiosAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var citaExistente = await _citaRepository.ObtenerPorIdAsync(id);

        if (citaExistente == null)
            throw new RegistroNoEncontradoException("Cita", id);

        _citaRepository.Eliminar(citaExistente);
        await _citaRepository.GuardarCambiosAsync();
    }
}