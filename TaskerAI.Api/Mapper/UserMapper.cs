namespace TaskerAI.Api.Mapper
{
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Api.Models;
    using TaskerAI.Domain;
    using TaskerAI.Infrastructure;

    public class UserMapper : IMapper<Domain.User, UserModel>
    {
        public void Map(Domain.User from, UserModel to)
        {

        }

        public UserModel Map(Domain.User from)
        {
            var to = new UserModel();

            Map(from, to);

            return to;
        }

        public void Map(IEnumerable<User> from, IEnumerable<UserModel> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<UserModel> Map(IEnumerable<User> from) => from.Select(f => Map(f)).ToArray();
    }
}
