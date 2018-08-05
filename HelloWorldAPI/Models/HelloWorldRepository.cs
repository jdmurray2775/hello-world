using System.Collections.Generic;
using System.Linq;
using HelloWorldAPI.Interfaces;

namespace HelloWorldAPI.Models
{
    public class HelloWorldRepository : IHelloWorldRepository
    {
        private readonly HelloWorldContext _context;

        public HelloWorldRepository(HelloWorldContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<HelloWorldModel> ListAll()
        {
            return _context.HelloWorldModel.AsEnumerable();
        }

        public HelloWorldModel Get(long id)
        {
            return _context.HelloWorldModel.Find(id);
        }

        public void Add()
        {
            if (_context.HelloWorldModel.Count() == 0)
            {
                _context.HelloWorldModel.Add(new HelloWorldModel());
                _context.SaveChanges();
            }

        }
    }
}