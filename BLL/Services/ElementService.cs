using BLL.Interface;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
    public class ElementService : IElementService
    {
        private readonly IElementRepository _repository;
        public ElementService(IElementRepository repository)
        {
            _repository = repository;
        }
        public Task<TblSubElements> AddElement(TblSubElements element)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteElement(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TblSubElements> GetElement(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateElement(int id, TblSubElements element)
        {
            throw new NotImplementedException();
        }
    }
}
