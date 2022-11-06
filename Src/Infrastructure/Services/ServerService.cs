using SourceServerManager.Infrastructure.Data;

namespace SourceServerManager.Infrastructure.Services;

public class ServerService : IServerService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public ServerService(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ServerDetailsDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Servers.Where(s => s.Id == id)
            .ProjectToType<ServerDetailsDto>(_mapper.Config)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<ServerDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Servers.ProjectToType<ServerDto>(_mapper.Config)
            .ToListAsync(cancellationToken);
    }

    public async Task<Result<int>> CreateAsync(ServerCreateDto dto, CancellationToken cancellationToken = default)
    {
        var directoryExists = await _dbContext.Servers.AnyAsync(s => s.DirectoryName == dto.DirectoryName,
            cancellationToken);

        if (directoryExists)
        {
            return new ErrorResult<int>("The specified directory name already exists for another server.");
        }

        var server = _mapper.Map<Server>(dto);
        _dbContext.Servers.Add(server);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new SuccessResult<int>(server.Id);
    }

    public async Task<Result> UpdateAsync(ServerUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var server = await _dbContext.Servers.FindAsync(new object[] { dto.Id }, cancellationToken);

        if (server == null)
        {
            return new ErrorResult("The specified server could not be found.");
        }

        var directoryExists =
            await _dbContext.Servers.AnyAsync(s => s.Id != dto.Id && s.DirectoryName == dto.DirectoryName,
                cancellationToken);

        if (directoryExists)
        {
            return new ErrorResult("The specified directory name already exists for another server.");
        }

        _mapper.Map(dto, server);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new SuccessResult();
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var server = await _dbContext.Servers.FindAsync(new object[] { id }, cancellationToken);

        if (server == null)
        {
            return new ErrorResult("The specified server could not be found.");
        }

        _dbContext.Servers.Remove(server);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new SuccessResult();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _dbContext.DisposeAsync();
    }
}
