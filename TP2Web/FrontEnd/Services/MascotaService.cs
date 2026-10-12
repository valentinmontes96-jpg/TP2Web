using TP2Web.FrontEnd.DTO.Mascota.Request;
using TP2Web.FrontEnd.DTO.Mascota.Response;
using TP2Web.FrontEnd.DTO.Paginado;
using TP2Web.FrontEnd.DTO.Paginado.Response;
using TP2Web.FrontEnd.Excepciones;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;
using TP2Web.FrontEnd.Repositories;

namespace TP2Web.FrontEnd.Services;

public class MascotaService : IMascotaService
{
    private readonly IMascotaRepository _mascotaRepository;

    public MascotaService(IMascotaRepository mascotaRepository)
    {
        _mascotaRepository = mascotaRepository;
    }

    public async Task<PaginadoResponse<MascotaResponse>> ObtenerTodasAsync(MascotaPaginado request)
    {
        // traducir el Request del usuario a los Parámetros del Repositorio
        var parametros = new MascotaQueryParametros
        {
            PaginaActual = request.NumeroPagina,
            TamanoPagina = request.TamanoPagina,
            Buscar = request.Buscar,
            OrdenarPor = request.OrdenarPor,
            Direccion = request.Direccion
        };

        //buscar los datos a la BD
        var resultadoBD = await _mascotaRepository.ObtenerTodasAsync(parametros);

        //mapear los Modelos reales a DTOs de salida
        var itemsResponse = resultadoBD.Items.Select(m => new MascotaResponse
        {
            Id = m.Id,
            Nombre = m.Nombre,
            Especie = m.Especie
        }).ToList();

        //retornar el nuevo paquete paginado
        return new PaginadoResponse<MascotaResponse>
        {
            Items = itemsResponse,
            PaginaActual = resultadoBD.PaginaActual,
            TamanoPagina = resultadoBD.TamanoPagina,
            TotalRegistros = resultadoBD.TotalRegistros
        };
    }

    public async Task CrearAsync(MascotaCrear request)
    {
        var nuevaMascota = new Mascota
        {
            Nombre = request.Nombre,
            Especie = request.Especie
        };

        await _mascotaRepository.AgregarAsync(nuevaMascota);
    }

    public async Task<MascotaResponse?> ObtenerPorIdAsync(int id)
    {
        var mascota = await _mascotaRepository.ObtenerPorIdAsync(id);
        if (mascota == null)
            throw new RegistroNoEncontradoException("Mascota", id);

        return new MascotaResponse
        {
            Id = mascota.Id,
            Nombre = mascota.Nombre,
            Especie = mascota.Especie
        };
    }
}