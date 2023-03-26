namespace AirlineCompany.Data.Abstract
{
    public interface IRepository<Entity>
    {
        public void Create(Entity e);
        public void Update(Entity e);
        public void Delete(Entity e);
        public Entity? Get(int id);
    }
}
