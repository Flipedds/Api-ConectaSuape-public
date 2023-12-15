using Microsoft.AspNetCore.Mvc;
using Api.models;
using Api.repositories;
namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Login(ILoginRepository repository) : ControllerBase
{
    private readonly ILoginRepository _repository = repository;

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult Authenticate(User user)
    {
        UserDto query = _repository.Authenticate(user);

        return query != null
        ? Ok(query) : NotFound("Usuário não encontrado !");
    }
}
