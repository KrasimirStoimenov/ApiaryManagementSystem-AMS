namespace ApiaryManagementSystem.Application.Common.Models;

using Microsoft.EntityFrameworkCore;

public class PaginatedList<T>
{
    private PaginatedList(IReadOnlyCollection<T> items, int count, int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }

    public IReadOnlyCollection<T> Items { get; }

    public int Page { get; }

    public int PageSize { get; }

    public int TotalPages { get; }

    public int TotalCount { get; }

    public bool HasPreviousPage => Page > 1;

    public bool HasNextPage => Page < TotalPages;

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int page, int pageSize)
    {
        var count = await source.CountAsync();

        var items = await source
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<T>(items, count, page, pageSize);
    }
}
