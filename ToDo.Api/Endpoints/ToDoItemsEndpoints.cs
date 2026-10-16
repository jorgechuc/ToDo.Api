using Microsoft.EntityFrameworkCore;
using ToDo.Api.Data;
using ToDo.Api.DTOs;
using ToDo.Api.Models;

namespace ToDo.Api.Endpoints
{
    public static class ToDoItemsEndpoints
    {
        public static void MapToDoItemsEndpoint(this IEndpointRouteBuilder routes)
        {
            var toDoItemsEndpoints = routes.MapGroup("/api/pendientes")
                .WithTags("Pendientes");
            toDoItemsEndpoints.MapGet("/", GetAllToDoItems);
            toDoItemsEndpoints.MapGet("/{id:int}", GetToDoItemById);
            toDoItemsEndpoints.MapPost("/", CreateToDoItem);
            toDoItemsEndpoints.MapPut("/{id:int}", UpdateToDoItem);
            toDoItemsEndpoints.MapDelete("/{id:int}", DeleteToDoItem);
        }

        private static async Task<IResult> GetAllToDoItems(
            AppDbContext dbContext)
        {
            var toDoItemDtos = await dbContext
                .ToDoItems
                .Select(p => new ToDoItemDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    IsCompleted = p.IsCompleted
                })
                .ToListAsync();

            //var toDoItemDtos = new List<ToDoItemDto>();
            //foreach (var t in toDoItems)
            //{
            //    toDoItemDtos.Add(new ToDoItemDto()
            //    {
            //        Id = t.Id,
            //        Name = t.Name,
            //        IsCompleted = t.IsCompleted,
            //    });
            //}

            return Results.Ok(toDoItemDtos);
        }

        private static async Task<IResult> GetToDoItemById(
            AppDbContext dbContext, int id)
        {
            var toDoItem = await dbContext
                .ToDoItems
                .FirstOrDefaultAsync(tdi => tdi.Id == id);
            if (toDoItem is null)
            {
                return Results.NotFound();
            }
            var toDoItemDto = new ToDoItemDto()
            {
                Id = toDoItem.Id,
                Name = toDoItem.Name,
                IsCompleted = toDoItem.IsCompleted
            };
            return Results.Ok(toDoItemDto);
        }

        private static async Task<IResult> CreateToDoItem(
            AppDbContext dbContext, CreateToDoItemDto createToDoItemDto)
        {
            var toDoItem = new ToDoItem()
            {
                Name = createToDoItemDto.Name,
                IsCompleted = false
            };
            await dbContext.ToDoItems.AddAsync(toDoItem);
            await dbContext.SaveChangesAsync();

            var toDoItemDto = new ToDoItemDto()
            {
                Id = toDoItem.Id,
                Name = toDoItem.Name,
                IsCompleted = false
            };
            return Results.Created(
                $"/api/pendientes/{toDoItem.Id}", toDoItemDto);
        }

        private static async Task<IResult> UpdateToDoItem(
            AppDbContext dbContext, int id, UpdateToDoItemDto item)
        {
            var toDoItem = await dbContext
                .ToDoItems
                .FirstOrDefaultAsync(tdi => tdi.Id == id);
            if (toDoItem is null)
            {
                return Results.NotFound();
            }
            toDoItem.Name = item.Name;
            toDoItem.IsCompleted = item.IsCompleted;

            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        }

        private static async Task<IResult> DeleteToDoItem(
            AppDbContext dbContext, int id)
        {
            var toDoItem = await dbContext
                .ToDoItems
                .FirstOrDefaultAsync(tdi => tdi.Id == id);
            if (toDoItem is null)
            {
                return Results.NotFound();
            }
            dbContext.ToDoItems.Remove(toDoItem);
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        }
    }
}
