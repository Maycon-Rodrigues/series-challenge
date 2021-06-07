using System.Collections.Generic;
using SeriesChallenge.Interface;

namespace SeriesChallenge.Class
{
  public class SerieRepository : IRepository<Serie>
  {
    private List<Serie> _repository = new List<Serie>();

    public List<Serie> GetAll()
    {
      return _repository;
    }

    public Serie GetById(int id)
    {
      return _repository[id];
    }

    public void Create(Serie entity)
    {
      _repository.Add(entity);
    }

    public void Delete(int id)
    {
      _repository[id].Inactive();
    }

    public int NextId()
    {
      return _repository.Count;
    }

    public void Update(int id, Serie entity)
    {
      _repository[id] = entity;
    }
  }
}