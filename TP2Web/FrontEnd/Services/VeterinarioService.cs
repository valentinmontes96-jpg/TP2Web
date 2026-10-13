using TP2Web.FrontEnd.DTO.Veterinario.Request;
using TP2Web.FrontEnd.DTO.Veterinario.Response;
using TP2Web.FrontEnd.Excepciones;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;
using TP2Web.FrontEnd.Repositories;

namespace TP2Web.FrontEnd.Services;

public class VeterinarioService : IVeterinarioService
{
    private readonly IVeterinarioRepository _veterinarioRepository;

    public VeterinarioService(IVeterinarioRepository veterinarioRepository)
    {
        _veterinarioRepository = veterinarioRepository;
    }

    public async Task<VeterinarioPaginado> ObtenerTodosAsync(VeterinarioQueryParameters parametros)
    {
        var (veterinarios, totalRegistros) = await _veterinarioRepository.ObtenerTodosAsync(parametros);

        var veterinariosResponse = veterinarios.Select(v => new VeterinarioResponse
        {
            Id = v.Id,
            Nombre = v.Nombre,
            Especialidad = v.Especialidad,
            Matricula = v.Matricula
        }).ToList();

        return new VeterinarioPaginado
        {
            Veterinarios = veterinariosResponse,
            TotalRegistros = totalRegistros
        };
    }

    public async Task<VeterinarioResponse> ObtenerPorIdAsync(int id)
    {
        var veterinario = await _veterinarioRepository.ObtenerPorIdAsync(id);

        if (veterinario == null)
            throw new RegistroNoEncontradoException("Veterinario", id);

        return new VeterinarioResponse
        {
            Id = veterinario.Id,
            Nombre = veterinario.Nombre,
            Especialidad = veterinario.Especialidad,
            Matricula = veterinario.Matricula
        };
    }

    public async Task CrearAsync(VeterinarioCrear request)
    {
        var nuevoVeterinario = new Veterinario
        {
            Nombre = request.Nombre,
            Especialidad = request.Especialidad,
            Matricula = request.Matricula
        };

        _veterinarioRepository.Agregar(nuevoVeterinario);
        await _veterinarioRepository.GuardarCambiosAsync();
    }

    public async Task ActualizarAsync(VeterinarioActualizar request)
    {
        var veterinarioExistente = await _veterinarioRepository.ObtenerPorIdAsync(request.Id);

        if (veterinarioExistente == null)
            throw new RegistroNoEncontradoException("Veterinario", request.Id);

        veterinarioExistente.Nombre = request.Nombre;
        veterinarioExistente.Especialidad = request.Especialidad;
        veterinarioExistente.Matricula = request.Matricula;

        _veterinarioRepository.Actualizar(veterinarioExistente);
        await _veterinarioRepository.GuardarCambiosAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var veterinarioExistente = await _veterinarioRepository.ObtenerPorIdAsync(id);

        if (veterinarioExistente == null)
            throw new RegistroNoEncontradoException("Veterinario", id);

        _veterinarioRepository.Eliminar(veterinarioExistente);
        await _veterinarioRepository.GuardarCambiosAsync();
    }
}