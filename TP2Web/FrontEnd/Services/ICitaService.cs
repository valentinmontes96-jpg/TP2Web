using TP2Web.FrontEnd.DTO.Cita.Request;
using TP2Web.FrontEnd.DTO.Cita.Response;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;

namespace TP2Web.FrontEnd.Services;

public interface ICitaService
{
    Task<CitaPaginado> ObtenerTodasAsync(CitaQueryParameters parametros);
    Task<CitaResponse> ObtenerPorIdAsync(int id);
    Task CrearAsync(CitaCrear request);
    Task ActualizarAsync(CitaActualizar request);
    Task EliminarAsync(int id);
}