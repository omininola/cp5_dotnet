namespace cp5.Services;

public interface IService<TResponse, TDto>
{
    Task<TResponse> Save(TDto dto);
    Task<IEnumerable<TResponse>> FindAll();
    Task<TResponse> FindById(string id);
    Task<TResponse> Update(string id, TDto dto);
    Task<TResponse> Delete(string id);
}