using AirlineCompany.Data.Abstract;

namespace AirlineCompany.Data.EntityFramework
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void Delete(T e)
        {
            using (var context = new DataContext())
            {
                try
                {
                    context.Set<T>().Remove(e);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public T? Get(int id)
        {
            using (var context = new DataContext())
            {
                return context.Set<T>().Find(id);

            }
        }
        public void Update(T e)
        {
            using (var context = new DataContext())
            {
                context.Set<T>().Update(e);
                context.SaveChanges();
            }
        }
   

        public async Task<T> Create(T e)
        {
            using (var context = new DataContext())
            {
                context.Set<T>().Add(e);
                await context.SaveChangesAsync();
                return e;

            }
        }
    }
}
