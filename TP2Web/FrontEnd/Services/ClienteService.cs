using TP2Web.FrontEnd.DTO.Cliente.Request;
using TP2Web.FrontEnd.DTO.Cliente.Response;
using TP2Web.FrontEnd.Excepciones;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;
using TP2Web.FrontEnd.Repositories;

namespace TP2Web.FrontEnd.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<IEnumerable<ClienteResponse>> ObtenerTodosAsync()
    {
        //DUDA
        var clientes = await _clienteRepository.ObtenerTodosAsync(ClienteQueryParameters);

        // Mapeamos de Modelo a DTO
        return clientes.Select(c => new ClienteResponse
        {
            Id = c.Id,
            Nombre = c.Nombre,
            Telefono = c.Telefono,
            Email = c.Email,
        });
    }

    public async Task<ClienteResponse> ObtenerPorIdAsync(int id)
    {
        var cliente = await _clienteRepository.ObtenerPorIdAsync(id);

        if (cliente == null)
            throw new RegistroNoEncontradoException("Cliente", id);

        return new ClienteResponse
        {
            Id = cliente.Id,
            Nombre = cliente.Nombre,
            Telefono = cliente.Telefono,
            Email = cliente.Email
        };
    }

    public async Task CrearAsync(ClienteCrear request)
    {
        var nuevoCliente = new Cliente
        {
            Nombre = request.Nombre,
            Telefono = request.Telefono,
            Email = request.Email
        };

        _clienteRepository.Agregar(nuevoCliente);
        await _clienteRepository.GuardarCambiosAsync();
    }

    public async Task ActualizarAsync(ClienteActualizar request)
    {
        var clienteExistente = await _clienteRepository.ObtenerPorIdAsync(request.Id);

        if (clienteExistente == null)
            throw new RegistroNoEncontradoException("Cliente", request.Id);

        // Actualizamos los datos
        clienteExistente.Nombre = request.Nombre;
        clienteExistente.Telefono = request.Telefono;
        clienteExistente.Email = request.Email;

        _clienteRepository.Actualizar(clienteExistente);
        await _clienteRepository.GuardarCambiosAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var clienteExistente = await _clienteRepository.ObtenerPorIdAsync(id);

        if (clienteExistente == null)
            throw new RegistroNoEncontradoException("Cliente", id);

        _clienteRepository.Eliminar(clienteExistente);
        await _clienteRepository.GuardarCambiosAsync();
    }
}