namespace CadProfissao.Application.Interfaces
{
    public abstract class Entity<T>
    {
        public Entity(T id) => this.Id = id;

        public T Id { get; private set; }
    }
}
