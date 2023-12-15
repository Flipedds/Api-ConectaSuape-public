using Api.models;

namespace Api.repositories;

public interface ILoginRepository
{
    UserDto Authenticate(User user);
}
