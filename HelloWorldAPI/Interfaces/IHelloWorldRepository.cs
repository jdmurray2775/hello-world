using System.Collections.Generic;
using HelloWorldAPI.Models;

namespace HelloWorldAPI.Interfaces
{
    public interface IHelloWorldRepository
    {
        IEnumerable<HelloWorldModel> ListAll();
        HelloWorldModel Get(long id);

        void Add();
    }
}