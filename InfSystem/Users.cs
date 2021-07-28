namespace InfSystem
{
    internal class User
    {
        internal int Id { get; private set; }

        public User(int id)
        {
            Id = id;
        }
    }

    internal class FavoredUser: User
    {
        public FavoredUser(int id) : base(id) { }
    }

    internal class SuperUser : FavoredUser
    {
        public SuperUser(int id) : base(id) { }
    }
}
